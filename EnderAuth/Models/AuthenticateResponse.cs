using EnderAuth.Modules;
using System.Collections.Generic;

namespace EnderAuth.Models
{
    public class AuthenticateResponse
    {
        public User user { get; set; }
        public string clientToken { get; set; }
        public string accessToken { get; set; }
        public List<AvailableProfiles> availableProfiles { get; set; }
        public SelectedProfiles selectedProfiles { get; set; }
    }
}
