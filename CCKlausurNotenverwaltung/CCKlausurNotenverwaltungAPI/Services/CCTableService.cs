using Azure.Data.Tables;
using CCKlausurNotenverwaltungAPI.Models;

namespace CCKlausurNotenverwaltungAPI.Services
{
    public class CCTableService
    {
        TableClient tableClient = null;
        public CCTableService()
        {
            tableClient = new TableClient("UseDevelopmentStorage=true", "mystudents");
        }
        public async Task CreateAndInsertAsync(Student student)
        {
            
            await tableClient.CreateIfNotExistsAsync();
            await tableClient.AddEntityAsync(student);
        }

        internal StudentDTO GetStutend(int sutdentId)
        {
            //TODO Klausur implement
            throw new NotImplementedException();
        }

        public async Task<IList<LVBewertungKompakt>> GetBewertungenByLV(string lvBezeichnung)
        {
            //Aufgabe 3
            throw new NotImplementedException();
        }
    }
}
