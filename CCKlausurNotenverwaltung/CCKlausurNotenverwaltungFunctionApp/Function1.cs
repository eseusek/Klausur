using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CCKlausurNotenverwaltungFunctionApp
{
    public class LVGesamtbewertung
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string PersonenKennzeichen { get; set; }
        public double PunkteGesamt { get; set; }
    }

    public class LVBewertung
    {
        public int LVBewertungId { get; set; }

        public int StudPersNummer { get; set; }

        public string LVBezeichnung { get; set; }
        public double PunkteTheorie { get; set; }
        public double PunktePraxis { get; set; }
    }
    public class Function1
    {
        [FunctionName("Function1")]
        [return: Table("Bewertungen", Connection = "StorageConnectionString")]
        public LVGesamtbewertung Run([QueueTrigger("queuelvbewertung", Connection = "StorageConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            LVGesamtbewertung tableRow = new LVGesamtbewertung();

            var gesamtBewertung = JsonConvert.DeserializeObject<LVBewertung>(myQueueItem);

            tableRow.PartitionKey = gesamtBewertung.LVBezeichnung;
            tableRow.PunkteGesamt = gesamtBewertung.PunktePraxis + gesamtBewertung.PunkteTheorie;
            tableRow.PersonenKennzeichen = gesamtBewertung.StudPersNummer.ToString();
            tableRow.RowKey = Guid.NewGuid().ToString();

            return tableRow;
        }
    }
}
