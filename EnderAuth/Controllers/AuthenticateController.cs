﻿using EnderAuth.Core;
using EnderAuth.Models;
using EnderAuth.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json;
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
            return e;
        }
        // POST api/<AuthenticationController>
        [HttpPost]
        public object Post([FromBody] AuthenticatePayload value)
        {
            //Getting from normal users database
            string[] usernames = Database.Select("username");
            string[] passwordhashs = Database.Select("passwordhash");
            string[] emails = Database.Select("email");
            string[] remoteIDs = Database.Select("id");
            string[] uuids = Database.Select("uuid");

            //Getting from minecraft users database
            string[] clientTokens = Database.Select("clientToken", "mcusers");
            string[] accessTokens = Database.Select("accessToken", "mcusers");
            
            object result = null;

            for (int i = 0; i < usernames.Length; i++)
            {
                string player = usernames[i];
                string passwordHash = passwordhashs[i];
                string email = emails[i];
                string remoteID = remoteIDs[i];
                string uuid = uuids[i];

                string clientToken = clientTokens[i];
                string accessToken = accessTokens[i];
                if (player == value.username &&
                    passwordHash == Encryption.HashPassword(value.password))
                {
                    result = CreateResponse(player, passwordHash, email, remoteID, uuid, clientToken, accessToken);
                    return result;
                }
                else if (player == value.username &&
                         clientToken == value.clientToken)
                {
                    result = CreateResponse(player, passwordHash, email, remoteID, uuid, clientToken, accessToken);
                    return result;
                }
                else
                {
                    Error er = new Error();
                    er.error = "ForbiddenOperationException";
                    er.errorMessage = "Invalid credentials. Invalid username or password.";

                    result = er;
                }
            }

            return result;
        }

        private AuthenticateResponse CreateResponse(string username, string passwordhash, string email, string remoteID, string uuid, string clientToken, string accessToken)
        {
            Properties preferredLanguage = new Properties();
            preferredLanguage.name = "preferredLanguage";
            preferredLanguage.value = "en-us";

            Properties registrationCountry = new Properties();
            registrationCountry.name = "registrationCountry";
            registrationCountry.value = "US";

            User usr = new User();
            usr.username = email;
            usr.id = remoteID;
            usr.properties = new List<Properties>();
            usr.properties.Add(preferredLanguage);
            usr.properties.Add(registrationCountry);

            AvailableProfiles ap = new AvailableProfiles();
            ap.name = username;
            ap.id = uuid;
            SelectedProfiles sp = new SelectedProfiles();
            sp.name = username;
            sp.id = uuid;

            AuthenticateResponse ar = new AuthenticateResponse();
            ar.user = usr;
            ar.clientToken = clientToken;
            ar.accessToken = accessToken;
            ar.availableProfiles = new List<AvailableProfiles>();
            ar.availableProfiles.Add(ap);
            ar.selectedProfiles = sp;

            return ar;
        }
    }
}
