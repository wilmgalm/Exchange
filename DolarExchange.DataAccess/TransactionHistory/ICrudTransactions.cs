using DolarExchange.Model.TransactionsModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.DataAccess.TransactionHistory
{
    public interface ICrudTransactions
    {
        public List<Transactions> GetUserTransactionsByCurrency(string userId, string currency);
        public bool InsertTransaction(Transactions transaction);
    }
}
