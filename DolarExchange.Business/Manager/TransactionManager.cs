using DolarExchange.Business.IManager;
using DolarExchange.Commons.Constants;
using DolarExchange.DataAccess.TransactionHistory;
using DolarExchange.Model;
using DolarExchange.Model.TransactionsModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolarExchange.Business.Manager
{
    public class TransactionManager : ITransactionManager
    {

        private readonly IConfiguration _configuration;
        private readonly IExternalServicesManager _externalServicesManager;
        private readonly ICrudTransactions _crudTransations;

        public TransactionManager(IConfiguration configuration, IExternalServicesManager externalServicesManager, ICrudTransactions crudTransations)
        {
            _configuration = configuration;
            _externalServicesManager = externalServicesManager;
            _crudTransations = crudTransations;
        }

        public CurrencyPurchaseResponse CurrencyPurchase(CurrencyPurchaseRequest currencyPurchaseRequest)
        {
            CurrencyPurchaseResponse currencyPurchaseResponse = new CurrencyPurchaseResponse();
            try
            {
                ExchangeRateResponse exchangeRateResponse = _externalServicesManager.GetExchangeRate(new ExchangeRateRequest() { Currency = currencyPurchaseRequest.Currency_Code });

                var transactions = _crudTransations.GetUserTransactionsByCurrency(currencyPurchaseRequest.User_Id, currencyPurchaseRequest.Currency_Code);

                double currencyAmount = currencyPurchaseRequest.Amount / exchangeRateResponse.Bought;

                double sumTransactions = transactions.Sum(x => x.Currency_Amount) + currencyAmount;

                //Get the max amount allowed from app.settings
                string maxAmountAllowedString = _configuration["Parameters:MaxAmount" + currencyPurchaseRequest.Currency_Code];
                double maxAmount = 0;
                Double.TryParse(maxAmountAllowedString, out maxAmount);


                if (sumTransactions > maxAmount)
                {
                    currencyPurchaseResponse.ErrorCode = ERROR.NOK;
                    currencyPurchaseResponse.Msg = string.Format(ERROR.MAX_AMOUNT_EXCEEDED, currencyPurchaseRequest.User_Id);
                }
                else
                {
                    bool insertTransaction = _crudTransations.InsertTransaction(new Transactions()
                    {

                        Amount = currencyPurchaseRequest.Amount,
                        Currency_Amount = currencyAmount,
                        Currency_Code = currencyPurchaseRequest.Currency_Code,
                        Status = ERROR.OK,
                        Date = DateTime.UtcNow,
                        User_Id = currencyPurchaseRequest.User_Id
                    });

                    if (insertTransaction)
                    {
                        currencyPurchaseResponse.ErrorCode = ERROR.OK;
                        currencyPurchaseResponse.Msg = string.Format(currencyPurchaseRequest.Amount + "/" + currencyAmount + " " + currencyPurchaseRequest.Currency_Code);
                    }
                    else
                    {
                        currencyPurchaseResponse.ErrorCode = ERROR.NOK;
                    }

                }
                return currencyPurchaseResponse;
            }
            catch (Exception ex)
            {
                currencyPurchaseResponse.Msg = ERROR.NOK;
                currencyPurchaseResponse.Msg = ex.Message;
                return currencyPurchaseResponse;
            }
        }
    }
}
