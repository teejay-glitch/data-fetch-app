using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestWebAPI.Data;
using TestWebAPI.Models;
using TestWebAPI.Models.Dto;
using TestWebAPI.Services;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IExternalService _externalService;

        public UserController(
            IExternalService externalService
        )
        {
            _externalService = externalService;
        }

        [HttpGet("credit-data/{ssn}")]
        public async Task<ActionResult<UserDto>> GetPersonalDetails(string ssn)
        {
            if (string.IsNullOrEmpty(ssn)) return BadRequest("SSN is required");

            try
            {
                string personalDetailsUrl = $"{StaticData.BaseUrl}/personal-details/{ssn}";
                string incomeDetailsUrl = $"{StaticData.BaseUrl}/assessed-income/{ssn}";
                string debtDetailsUrl = $"{StaticData.BaseUrl}/debt/{ssn}";

                var personalDetailsRes = await _externalService.GetAsync(personalDetailsUrl);
                var incomeDetailsRes = await _externalService.GetAsync(incomeDetailsUrl);
                var debtDetailRes = await _externalService.GetAsync(debtDetailsUrl);

                if (personalDetailsRes == null || 
                    incomeDetailsRes == null ||
                    debtDetailRes == null
                ) return NotFound();

                var personalDetailsString = await personalDetailsRes.Content.ReadAsStringAsync();
                var personalDetails = JsonConvert.DeserializeObject<PersonalDetails>(personalDetailsString);

                var incomeDetailsString = await incomeDetailsRes.Content.ReadAsStringAsync();
                var incomeDetails = JsonConvert.DeserializeObject<IncomeDetails>(incomeDetailsString);

                var debtDetailsString = await debtDetailRes.Content.ReadAsStringAsync();
                var debtDetails = JsonConvert.DeserializeObject<DebtDetails>(debtDetailsString);

                UserDto user = new()
                {
                    First_name = personalDetails.First_name,
                    Last_name = personalDetails.Last_name,
                    Address = personalDetails.Address,
                    Assessed_income = incomeDetails.Assessed_income,
                    Balance_of_debt = debtDetails.Balance_of_debt,
                    Complaints = debtDetails.Complaints
                };

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
