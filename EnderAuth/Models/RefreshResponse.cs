using EnderAuth.Modules;

namespace EnderAuth.Models
{
    public class RefreshResponse
    {
        public string accessToken { get; set; }
        public string clientToken { get; set; }
        public SelectedProfiles selectedProfiles { get; set; }
        public User user { get; set; }
    }
}
