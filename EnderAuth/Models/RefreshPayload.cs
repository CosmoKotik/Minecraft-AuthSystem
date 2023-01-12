using EnderAuth.Modules;

namespace EnderAuth.Models
{
    public class RefreshPayload
    {
        public string accessToken { get; set; }
        public string clientToken { get; set; }
        public bool requestUser { get; set; }
        public SelectedProfiles selectedProfiles { get; set; }
    }
}
