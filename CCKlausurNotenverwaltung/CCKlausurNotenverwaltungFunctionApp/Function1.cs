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
        [return: Table("Bewertungen", Connection = "mylocaltable")]
        public LVGesamtbewertung Run([QueueTrigger("queuelvbewertung", Connection = "mylocalqueue")]string myQueueItem, ILogger log)
        {
             log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            LVGesamtbewertung tableRow = new LVGesamtbewertung();

            //TODO - Aufgabe 2
          
            return tableRow;
        }
    }
}
