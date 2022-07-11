using System.Collections.Generic;

namespace EnderAuth.Modules
{
    public class User
    {
        public string username { get; set; }
        public List<Properties> properties { get; set; }
        public string id { get; set; }
    }
}
