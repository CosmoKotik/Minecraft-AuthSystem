using EnderAuth.Core;
using EnderAuth.Models;
using EnderAuth.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
//using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnderAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        // GET: api/<AuthenticationController>
        [HttpGet]
        public Error Get()
        {
            Error e = new Error();
            e.error = "Method Not Allowed";
            e.errorMessage = "The method specified in the request is not allowed for the resource identified by the request URI";
            e.cause = "";
            return e;
        }
        // POST api/<AuthenticationController>
        [HttpPost]
        public string Post([FromBody] AuthenticatePayload value)
        {
            AuthenticatePayload result = new AuthenticatePayload();

            Properties preferredLanguage = new Properties();
            preferredLanguage.name = "preferredLanguage";
            preferredLanguage.value = "en-us";
            
            Properties registrationCountry = new Properties();
            registrationCountry.name = "registrationCountry";
            registrationCountry.value = "US";

            User usr = new User();
            usr.username = "email";
            usr.id = "UUID";
            usr.properties = new List<Properties>();
            usr.properties.Add(preferredLanguage);
            usr.properties.Add(registrationCountry);

            AvailableProfiles ap = new AvailableProfiles();
            ap.name = "CosmoKotik";
            ap.id = "CosmoKotik";
            SelectedProfiles sp = new SelectedProfiles();
            sp.name = "CosmoKotik";
            sp.id = "CosmoKotik";

            AuthenticateResponse ar = new AuthenticateResponse();
            ar.user = usr;
            ar.clientToken = "ccccl";
            ar.accessToken = "acccc";
            ar.availableProfiles = new List<AvailableProfiles>();
            ar.availableProfiles.Add(ap);
            ar.selectedProfiles = sp;

            string[] usernames = Database.Select("username");

            foreach (string player in usernames)
            {
                if (player == value.username)
                { 
                    
                }
            }

            return Database.Select("username")[1];
        }
    }
}
