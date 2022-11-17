using MarketplaceCF.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceCF.Controllers
{

    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<object> Get()
        {
            return new ResponseDto
            {
               
            };
        }
    }
}
