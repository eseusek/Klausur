
using CCKlausurNotenverwaltungAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCKlausurNotenverwaltungAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCCosmosDBController : ControllerBase
    {
        [HttpPost]
        public async void Post([FromBody] string firstName)
        {
            CCCosmosService ccCosmosService = new CCCosmosService();

            await ccCosmosService.TestCosmosDB(firstName);
        }
    }
}
