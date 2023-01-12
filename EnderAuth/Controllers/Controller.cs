using EnderAuth.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace EnderAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly ILogger _logger;
        public Controller(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        // GET: /
        [HttpGet]
        public RootPage Get()
        {
            RootPage rp = new RootPage();
            rp.Status = "OK";
            rp.Runtime_Mode = "productionMode";
            rp.Application_Author = "Mojang Web Force";
            rp.Application_Description = "Mojang Authentication Server.";
            rp.Specification_Version = "5.2.0";
            rp.Application_Name = "yggdrasil.auth.restlet.server";
            rp.Implementation_Version = "5.2.0";
            rp.Application_Owner = "Mojang";

            _logger.LogInformation("Client accessing /");

            /*string json = JsonConvert.SerializeObject(rp);
            json = json.Replace("_", "-");
            
            return json;*/

            return rp;
        }
    }
}
