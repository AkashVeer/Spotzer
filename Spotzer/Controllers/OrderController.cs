using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Serilog;
using Spotzer.Helpers;
using Spotzer.Services.Contracts;
using System;

namespace Spotzer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly PartnerFactory partnerFactory;
        public OrderController(ILogger logger, PartnerFactory partnerFactory)
        {
            this.logger = logger;
            this.partnerFactory = partnerFactory;
        }

        [HttpPost]
        //[Route()] - Can give custom route
        public IActionResult Post([FromBody]JObject orderRequest)
        {
            if (orderRequest == null)
                return BadRequest("Invalid request!");

            try
            {
                logger.Information("Entered Post method");
                IPartnerService partner = partnerFactory.GetInstance(orderRequest);
                var response = partner.Process();
                if(response.IsSuccess == false || response.ErrorList.Count > 0)
                {
                    logger.Information("Exited Post method");
                    return BadRequest(response);
                }
                logger.Information("Exited Post method");
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.Error("Error in Post method. Stack trace: " + ex.StackTrace);
                return BadRequest();
            }
        }
    }
}
