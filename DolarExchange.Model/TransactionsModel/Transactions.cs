using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.Model.TransactionsModel
{


    [BsonIgnoreExtraElements]
    public class Transactions
    {

        public DateTime? Date { get; set; }

        public string User_Id { get; set; }

        public double Amount { get; set; }

        public string Currency_Code { get; set; }

        public double Currency_Amount { get; set; }

        public string Status { get; set; }
    }
}
