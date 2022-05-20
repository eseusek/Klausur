
using CCKlausurNotenverwaltungAPI.Models;
using CCKlausurNotenverwaltungAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCKlausurNotenverwaltungAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCQueueController : ControllerBase
    {
        [HttpGet]
        public  LVBewertung GetSampleLVBewergung()
        {
            LVBewertung lVBewertung = new LVBewertung();
            lVBewertung.StudPersNummer = 12;
            lVBewertung.PunkteTheorie  = 7;
            lVBewertung.PunktePraxis = 12;
            lVBewertung.LVBezeichnung = "Cloud Computing";

            return lVBewertung;

        }

        [HttpPost]
        public async void Post([FromBody] LVBewertung lvBewertung)
        {
            CCQueueService ccQueueService = new CCQueueService();

            await ccQueueService.AddLVBewertungAsync(lvBewertung);
        }
    }
}
