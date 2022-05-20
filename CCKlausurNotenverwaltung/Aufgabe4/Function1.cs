using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Aufgabe4
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "irgendeineMethode")] HttpRequest req,
            [CosmosDB(
                databaseName: "LVAuswertungErgebnisse",
                collectionName: "Ergebnisse",
                ConnectionStringSetting = "AzureWebJobsStorage")]out dynamic document,
            ILogger log)
        {
            var requestbody = req.Body;
            //Hier könnte eine Berechnung stattfinden
            document = new { requestbody };            
        }
    }
}
