using Newtonsoft.Json;

namespace TestWebAPI.Models
{
    public class IncomeDetails
    {
        [JsonProperty("assessed_income")]
        public float Assessed_income { get; set; }
    }
}
