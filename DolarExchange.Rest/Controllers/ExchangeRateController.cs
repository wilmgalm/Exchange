using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DolarExchange.Business.IManager;
using DolarExchange.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DolarExchange.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IExternalServicesManager _externalServicesManager;
        private readonly ITransactionManager _transactionManager;

        public ExchangeRateController(IExternalServicesManager externalServicesManager, ITransactionManager transactionManager)
        {
            _externalServicesManager = externalServicesManager;
            _transactionManager = transactionManager;

        }

        [Route("Init")]
        [HttpGet]
        public ActionResult<string> Get()
        {

            return Ok("running");
        }


        [Route("GetExchangeRate")]
        [HttpPost]
        public ActionResult<ExchangeRateResponse> GetExchangeRate([FromBody] ExchangeRateRequest exchangeRateRequest)
        {
            try
            {
                ExchangeRateResponse response = _externalServicesManager.GetExchangeRate(exchangeRateRequest);

                return Ok(response);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [Route("CurrencyPurchase")]
        [HttpPost]
        public ActionResult<ExchangeRateResponse> CurrencyPurchase([FromBody] CurrencyPurchaseRequest currencyPurchaseRequest)
        {
            try
            {
                CurrencyPurchaseResponse response = _transactionManager.CurrencyPurchase(currencyPurchaseRequest);

                return Ok(response);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
