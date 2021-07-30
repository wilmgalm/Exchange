using DolarExchange.Commons.Constants;
using DolarExchange.Commons.Utils;
using DolarExchange.Model.ConfigurationModel;
using DolarExchange.Model.TransactionsModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.DataAccess.TransactionHistory
{
    public class CrudTransactions : ICrudTransactions
    {

        private readonly IMongoCollection<Transactions> _TransactionsHistory;

        public CrudTransactions(IConnectionStrings settings)
        {
            var client = new MongoClient(settings.MongoConectionstring);
            var database = client.GetDatabase(settings.MongoDatabaseName);
            _TransactionsHistory = database.GetCollection<Transactions>(DATABASE_COLLECTIONS.TRANSACTIONS_COLLECTION);

        }

        public List<Transactions> GetUserTransactionsByCurrency(string userId, string currency)
        {
            try
            {
                return _TransactionsHistory.Find(x => x.User_Id.Equals(userId) && x.Currency_Code.Equals(currency)).ToList();
            }
            catch (MongoException mongoEx)
            {
                ServiceTrace.TraceError(EXCEPTION.CLASS + GetType().ToString(),
                    EXCEPTION.METHOD + System.Reflection.MethodBase.GetCurrentMethod().Name, EXCEPTION.MON_ERROR_QUERY, mongoEx.Message, mongoEx.StackTrace);
                throw mongoEx;
            }
            catch (Exception ex)
            {
                ServiceTrace.TraceError(EXCEPTION.CLASS + GetType().ToString(),
                    EXCEPTION.METHOD + System.Reflection.MethodBase.GetCurrentMethod().Name, EXCEPTION.MON_ERROR_QUERY, ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        public bool InsertTransaction(Transactions transaction)
        {
            try
            {
                _TransactionsHistory.InsertOne(transaction);
                return true;
            }
            catch (MongoException mongoEx)
            {
                ServiceTrace.TraceError(EXCEPTION.CLASS + GetType().ToString(),
                    EXCEPTION.METHOD + System.Reflection.MethodBase.GetCurrentMethod().Name, EXCEPTION.MON_ERROR_QUERY, mongoEx.Message, mongoEx.StackTrace);
                throw mongoEx;
            }
            catch (Exception ex)
            {
                ServiceTrace.TraceError(EXCEPTION.CLASS + GetType().ToString(),
                    EXCEPTION.METHOD + System.Reflection.MethodBase.GetCurrentMethod().Name, EXCEPTION.MON_ERROR_QUERY, ex.Message, ex.StackTrace);
                throw ex;
            }
        }
    }
}
