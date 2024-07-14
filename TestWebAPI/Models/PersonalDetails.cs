using Newtonsoft.Json;

namespace TestWebAPI.Models
{
    public class PersonalDetails
    {
        [JsonProperty("first_name")]
        public string First_name { get; set; }
        [JsonProperty("last_name")]
        public string Last_name { get; set; }
        public string Address { get; set; }
    }
}
