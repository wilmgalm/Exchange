using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.Model
{
    public class ExchangeRequest
    {
    }

    public class ExchangeRateRequest
    {
        public string Currency { get; set; }
    }

    public class CurrencyPurchaseRequest
    {
        public string User_Id { get; set; }
        public double Amount { get; set; }
        public string Currency_Code { get; set; }
    }

}
