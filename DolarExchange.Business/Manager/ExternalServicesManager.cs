using DolarExchange.Business.IManager;
using DolarExchange.Commons.Constants;
using DolarExchange.Commons.Utils;
using DolarExchange.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.Business.Manager
{
    public class ExternalServicesManager : IExternalServicesManager
    {
        private readonly IConfiguration _configuration;

        public ExternalServicesManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Invoke an external service to give the exchange rate for a given currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>

        public ExchangeRateResponse GetExchangeRateExternal(string currency)
        {

            double sold = -1;
            double bought = -1;

            //TODO: It could be used an IF to modify the endpoint according to de Currency requested
            string endPoint = _configuration[CONFIG.END_POINT_EXTERNAL_EXC_SERVICES] + "" + _configuration[CONFIG.EXC_GET_EXCHANGE_DOLAR];
        
            string responseRequest = Utils.SendRequest(null, null, endPoint, null);
            string[] parsed = JsonConvert.DeserializeObject<string[]>(responseRequest);

            double.TryParse(parsed[0], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out sold);
            double.TryParse(parsed[1], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out bought);

            ExchangeRateResponse response = new ExchangeRateResponse() { 
                Sold= sold,
                Bought= bought,
                Description=parsed[2],
                Currency_Code= currency
            };
            return response;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exchangeRateRequest"></param>
        /// <returns>Exchange rate according to the given currency</returns>
        public ExchangeRateResponse GetExchangeRate(ExchangeRateRequest exchangeRateRequest)
        {
            //Invoke to get the Exchange Rate from external service
            ExchangeRateResponse response = GetExchangeRateExternal(exchangeRateRequest.Currency);
            
            if (exchangeRateRequest.Currency.Equals(CUNRRENCY.USD) ){
            }
            else if (exchangeRateRequest.Currency.Equals(CUNRRENCY.BRL)) {
                response.Sold = response.Sold * CUNRRENCY_RATIO.BRL;
                response.Bought = response.Bought * CUNRRENCY_RATIO.BRL;
            }
            else {
                response.Sold = -1;
                response.Bought = -1;
                response.Description="Currency not supported";
            }

            return response;
        }
    }
}
