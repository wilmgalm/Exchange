using DolarExchange.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.Business.IManager
{
    public interface ITransactionManager
    {
        public CurrencyPurchaseResponse CurrencyPurchase(CurrencyPurchaseRequest currencyPurchaseRequest);
    }
}
