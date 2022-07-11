using EnderAuth.Modules;
using System.Collections.Generic;

namespace EnderAuth.Models
{
    public class AuthenticatePayload
    {
        //Request
        public Agent agent { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string clientToken { get; set; }
        public bool requestUser { get; set; }
        //Response
    }
}
