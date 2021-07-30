using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.Model
{
    class ExchangeResponse
    {
    }

    public class ExchangeRateResponse
    {
        public double Sold { get; set; }
        public double Bought { get; set; }
        public string Description { get; set; }
        public string Currency_Code { get; set; }
    }

    public class CurrencyPurchaseResponse
    {
        public string Msg { get; set; }
        public string ErrorCode { get; set; }
    }
}
