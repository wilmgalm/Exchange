using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.Commons.Constants
{
    public static class CONFIG
    {
        public const string END_POINT_EXTERNAL_EXC_SERVICES = "Services:ExternalExchange";
        public const string EXC_GET_EXCHANGE_DOLAR = "Services:GetExchangeDolar";

    }

    public static class CUNRRENCY
    {
        public const string ARS = "ARS";
        public const string BRL = "BRL";
        public const string COP = "COP";
        public const string USD = "USD";

    }

    public static class CUNRRENCY_RATIO
    {
        public const double BRL = 0.25;
    }

    public static class DATABASE_COLLECTIONS
    {
        public const string TRANSACTIONS_COLLECTION = "EXCH_CURRENCY_TRANSACTIONS";

    }

    public static class EXCEPTION
    {
        public const string METHOD = "MetHod:";
        public const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string CLASS = "Class:";
        public const string MON_ERROR_DELETE = "MongoException DELETING:";
        public const string MON_ERROR_INSERT = "MongoException INSERTING:";
        public const string MON_ERROR_UPDATE = "MongoException UPDATING:";
        public const string MON_ERROR_QUERY = "MongoException al QUERYING:";

    }

    public static class ERROR
    {
        public const string OK = "OK";
        public const string NOK = "NOK";

        public const string MAX_AMOUNT_EXCEEDED = "Max amount exceeded for the user {0}";
        public const string TRANSACTION_NOT_INSERTED = "Error executing the transaction, try again";

    }
}
