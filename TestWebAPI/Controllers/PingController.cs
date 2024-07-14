using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Services;
using TestWebAPI.Data;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IExternalService _externalService;
        public PingController(IExternalService externalService)
        {
            _externalService = externalService;
        }

        [HttpGet("/ping")]
        public async Task<bool> IsServerWorking() {
            try
            {
                var response = await _externalService.GetAsync(StaticData.BaseUrl);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
