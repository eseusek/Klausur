using Azure;
using Azure.Data.Tables;

namespace CCKlausurNotenverwaltungAPI.Models
{
    public class LVBewertungKompakt : ITableEntity
    {
        public string PersonenKennzeichen { get; set; }
        public double PunkteGesamt { get; set; }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
      
    }
}
