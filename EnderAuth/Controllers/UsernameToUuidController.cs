using EnderAuth.Core;
using EnderAuth.Models;
using EnderAuth.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnderAuth.Controllers
{
    [Route("users/profiles/minecraft")]
    [ApiController]
    public class UsernameToUuidController : ControllerBase
    {
        private readonly ILogger _logger;

        public UsernameToUuidController(ILogger<UsernameToUuidController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public object Get(string id)
        {
            if (id == null ||
                id == "")
            {
                Error e = new Error();
                e.error = "Method Not Allowed";
                e.errorMessage = "The method specified in the request is not allowed for the resource identified by the request URI";
                return e;
            }

            UsernameToUuidResponse response = new UsernameToUuidResponse();
            response.name = id;
            _logger.LogInformation(id + " is trying to get uuid from username");
            for (int i = 0; i < Database.Select("id").Length; i++)
            {
                if (id == Database.Select("username")[i])
                {
                    if (Convert.ToBoolean(Database.Select("legacy")[i]))
                        response.legacy = true;
                    response.id = Database.Select("uuid")[i];

                    _logger.LogInformation(id + " succeed");
                }    
            }

            return response;
        }

        [HttpPost]
        public object Post([FromBody] string[] players)
        {
            if (players.Length < 1)
            {
                Error e = new Error();
                e.error = "Method Not Allowed";
                e.errorMessage = "The method specified in the request is not allowed for the resource identified by the request URI";
                return e;
            }    

            List<UsernameToUuidResponse> response = new List<UsernameToUuidResponse>();
            
            for (int i = 0; i < Database.Select("id").Length; i++)
            {
                if (players.Contains(Database.Select("username")[i]))
                {
                    UsernameToUuidResponse player = new UsernameToUuidResponse();
                    
                    if (Convert.ToBoolean(Database.Select("legacy")[i]))
                        player.legacy = true;

                    player.name = Database.Select("username")[i];
                    player.id = Database.Select("uuid")[i];

                    response.Add(player);
                }
            }

            return response;
        }
    }
}
