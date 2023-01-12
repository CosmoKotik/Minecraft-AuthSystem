using EnderAuth.Modules;

namespace EnderAuth.Models
{
    public class UuidToProfileBase64
    {
        public string timestamp { get; set; }
        public string profileId { get; set; }
        public string profileName { get; set; }
        public bool signatureRequired { get; set; } = false;
        public Textures textures { get; set; }
    }
}
