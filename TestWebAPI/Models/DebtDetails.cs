using Newtonsoft.Json;

namespace TestWebAPI.Models
{
    public class DebtDetails
    {
        [JsonProperty("balance_of_debt")]
        public float Balance_of_debt { get; set; }
        public bool Complaints { get; set; }
    }
}
