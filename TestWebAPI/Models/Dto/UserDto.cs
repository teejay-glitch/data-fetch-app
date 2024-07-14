namespace TestWebAPI.Models.Dto
{
    public class UserDto
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Address { get; set; }
        public float Assessed_income { get; set; }
        public float Balance_of_debt { get; set; }
        public bool Complaints { get; set; }
    }
}
