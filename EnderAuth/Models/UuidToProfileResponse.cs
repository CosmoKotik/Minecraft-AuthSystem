using EnderAuth.Modules;

namespace EnderAuth.Models
{
    public class UuidToProfileResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public Properties properties { get; set; }
    }
}
