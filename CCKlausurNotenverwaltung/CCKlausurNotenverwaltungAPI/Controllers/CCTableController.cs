
using CCKlausurNotenverwaltungAPI.Models;
using CCKlausurNotenverwaltungAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CCKlausurNotenverwaltungAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCTableController : ControllerBase
    {

        [HttpGet]
        public  StudentDTO Get([FromBody] int sutdentId)
        {
            CCTableService cCTableService = new CCTableService();
            return cCTableService.GetStutend(sutdentId);
        }

        // POST api/<CCTableController>
        [HttpPost]
        public async void Post([FromBody] StudentDTO studentDTO)
        {
            CCTableService cCTableService = new CCTableService();
            Student newStudent = new Student() {
                StudentId=studentDTO.StudentId,
                Firstname=studentDTO.FirstName,
                Points = studentDTO.Points,
                PartitionKey="FH",
                RowKey=studentDTO.StudentId.ToString()
            };
            await cCTableService.CreateAndInsertAsync(newStudent);
        }

        //[HttpGet]
        //public async Task<IList<LVBewertungKompakt>> Get(string lvBezeichnung)
        //{
        //    CCTableService ccTableService = new CCTableService();
        //    return await ccTableService.GetBewertungenByLV(lvBezeichnung);

        //}

    }
}
