using DolarExchange.Business.Manager;
using DolarExchange.Commons.Constants;
using DolarExchange.DataAccess.TransactionHistory;
using DolarExchange.Model;
using DolarExchange.Model.ConfigurationModel;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.Test
{
    public class PurchaseRequestUnitTest
    {
        public static IConfiguration Configuration { get; set; }
        public static IConnectionStrings ConnectionStrings { get; set; }
        [SetUp]
        public void Setup()
        {
            var myConfiguration = new Dictionary<string, string>{
                    {"Parameters:MaxAmountUSD", "200"},
                    {"Parameters:MaxAmountBRL", "300"},

                    {"Services:ExternalExchange", "https://www.bancoprovincia.com.ar/"},
                    {"Services:GetExchangeDolar", "Principal/Dolar"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
            

            var connectionStrings = new ConnectionStrings()
            {
                MongoConectionstring = "mongodb://wilmgalm:10wil33dan@cluster0-shard-00-00.bysjb.mongodb.net:27017,cluster0-shard-00-01.bysjb.mongodb.net:27017,cluster0-shard-00-02.bysjb.mongodb.net:27017/myFirstDatabase?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority",
                MongoDatabaseName = "MDM"
            };

            Configuration = configuration;
            ConnectionStrings = connectionStrings;
        }


        [Test]
        public void ValidExchangePurchaseTest()
        {
            CurrencyPurchaseRequest currencyPurchaseRequest = new CurrencyPurchaseRequest() 
            { 
                User_Id="DAN",
	            Amount=10,
	            Currency_Code="BRL" 
            };


            ExternalServicesManager externalServicesManager = new ExternalServicesManager(Configuration);
            CrudTransactions crudTransations = new CrudTransactions(ConnectionStrings);
             

            TransactionManager _externalServicesManager = new TransactionManager(Configuration, externalServicesManager, crudTransations);
            CurrencyPurchaseResponse response = _externalServicesManager.CurrencyPurchase(currencyPurchaseRequest);
            Assert.AreEqual(response.ErrorCode,ERROR.OK);
        }

        [Test]
        public void InvalidExchangeRequestTest()
        {

            CurrencyPurchaseRequest currencyPurchaseRequest = new CurrencyPurchaseRequest()
            {
                User_Id = "DAN",
                Amount = 200000000,
                Currency_Code = "USD"
            };


            ExternalServicesManager externalServicesManager = new ExternalServicesManager(Configuration);
            CrudTransactions crudTransations = new CrudTransactions(ConnectionStrings);


            TransactionManager _externalServicesManager = new TransactionManager(Configuration, externalServicesManager, crudTransations);
            CurrencyPurchaseResponse response = _externalServicesManager.CurrencyPurchase(currencyPurchaseRequest);
            Assert.AreEqual(response.ErrorCode, ERROR.NOK);
        }

    }
}
