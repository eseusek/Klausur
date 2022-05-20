using Azure;
using Azure.Data.Tables;
using CCKlausurNotenverwaltungAPI.Models;
using Newtonsoft.Json;

namespace CCKlausurNotenverwaltungAPI.Services
{
    public class CCTableService
    {
        TableClient tableClient = null;
        public CCTableService()
        {
            tableClient = new TableClient("DefaultEndpointsProtocol=https;AccountName=csb10032001f904c851;AccountKey=soodIlxFWhsqshyNzx4CPAaF8zJnxGgk7tywWPRJ0u1iSmzFTM+NsJpZnf9kkt81h1mM+yWmgATi1mCxU8gXCg==;EndpointSuffix=core.windows.net", "Bewertungen");
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
            IList<LVBewertungKompakt> bewertungen = new List<LVBewertungKompakt>();
            Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{lvBezeichnung}'");

            foreach (TableEntity qEntity in queryResultsFilter)
            {
                var rowKey = qEntity.RowKey;
                var partitionKey = qEntity.PartitionKey;
                var eTag = qEntity.ETag;
                var personenKennzeichen = qEntity.GetString("PersonenKennzeichen");
                var punkteGesamt = qEntity.GetDouble("PunkteGesamt");
                var timestamp = qEntity.GetDateTimeOffset("Timestamp");
                bewertungen.Add(new LVBewertungKompakt()
                {
                    RowKey = rowKey,
                    PartitionKey = partitionKey,
                    ETag = eTag,
                    PunkteGesamt = punkteGesamt.Value,
                    Timestamp = timestamp,
                    PersonenKennzeichen = personenKennzeichen
                });
            }

            return bewertungen;
        }
    }
}
