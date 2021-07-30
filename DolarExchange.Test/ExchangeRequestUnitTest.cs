using DolarExchange.Business.Manager;
using DolarExchange.Model;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace DolarExchange.Test
{
    public class ExchangeRequestUnitTest
    {

        public static IConfiguration Configuration { get; set; }
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
            Configuration = configuration;
        }


        [Test]
        public void ValidExchangeRequestTest()
        {

            ExchangeRateRequest exchangeRateRequest = new ExchangeRateRequest() { Currency = "USD" };
            ExternalServicesManager _externalServicesManager = new ExternalServicesManager(Configuration);
            ExchangeRateResponse response = _externalServicesManager.GetExchangeRate(exchangeRateRequest);
            Assert.IsNotNull(response);
        }

        [Test]
        public void InvalidExchangeRequestTest()
        {

            ExchangeRateRequest exchangeRateRequest = new ExchangeRateRequest() { Currency = "USDDD" };
            ExternalServicesManager _externalServicesManager = new ExternalServicesManager(Configuration);
            ExchangeRateResponse response = _externalServicesManager.GetExchangeRate(exchangeRateRequest);
            Assert.Negative(response.Bought);
        }
    }
}