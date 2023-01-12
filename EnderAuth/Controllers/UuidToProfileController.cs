using EnderAuth.Core;
using EnderAuth.Models;
using EnderAuth.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EnderAuth.Controllers
{
    [Route("session/minecraft/profile")]
    [ApiController]
    public class UuidToProfileController : ControllerBase
    {
        [HttpGet("{id}")]
        public object Get(string id/*, [FromRoute] bool unsigned*/)
        {
            bool unsigned = false;
            Error e = new Error();
            
            if (id == null ||
                id == "")
            {
                e.error = "Method Not Allowed";
                e.errorMessage = "The method specified in the request is not allowed for the resource identified by the request URI";
                return e;
            }

            UuidToProfileResponse uuidToProfileResponse = new UuidToProfileResponse();

            for (int i = 0; i < Database.Select("id").Length; i++)
            {
                if (Database.Select("uuid")[i] == id)
                {
                    string skin_url = null;
                    string cape_url = null;
                    bool signature_required = false;

                    if (Database.Select("skin_url")[i] != null)
                        skin_url = Database.Select("skin_url")[i];
                    if (Database.Select("cape_url")[i] != null)
                        cape_url = Database.Select("cape_url")[i];

                    UuidToProfileBase64 uuidToProfileBase64 = new UuidToProfileBase64()
                    {
                        timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString(),
                        profileId = Database.Select("uuid")[i],
                        profileName = Database.Select("username")[i],
                        signatureRequired = unsigned,
                    };

                    if (skin_url != null || cape_url != null)
                        uuidToProfileBase64.textures = new Textures();

                    if (skin_url != null)
                        uuidToProfileBase64.textures.SKIN = new Skin()
                        {
                            url = skin_url
                        };

                    if (skin_url != null)
                        uuidToProfileBase64.textures.SKIN = new Skin()
                        {
                            url = cape_url
                        };

                    uuidToProfileResponse.id = Database.Select("uuid")[i];
                    uuidToProfileResponse.name = Database.Select("username")[i];
                    uuidToProfileResponse.properties = new Properties()
                    {
                        name = "textures",
                        value = Encryption.Base64Encode(uuidToProfileBase64)
                    };

                    if (!unsigned)
                        uuidToProfileResponse.properties.signature = Database.Select("privateKey")[i];

                    return uuidToProfileResponse;
                }
            }

            e.error = "Method Not Allowed";
            e.errorMessage = "The method specified in the request is not allowed for the resource identified by the request URI";
            return e;
        }
    }
}
