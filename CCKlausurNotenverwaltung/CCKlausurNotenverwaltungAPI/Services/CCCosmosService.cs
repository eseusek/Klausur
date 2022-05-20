using CCKlausurNotenverwaltungAPI.Models;
using Microsoft.Azure.Cosmos;

namespace CCKlausurNotenverwaltungAPI.Services
{
    public class CCCosmosService
    {
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        // The name of the database and container we will create
        private string databaseId = "dbKlausurvorbereitung";
        private string containerId = "students";

        public async Task TestCosmosDB(string firstname)
        {
            CosmosClient cosmosClient = new CosmosClient(
               "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            
            database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);

            container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/Firstname", 400);

            CosmosStudent student =new CosmosStudent();
            student.id = "AB1";
            student.Points = 100;
            student.Firstname = firstname;

            await container.CreateItemAsync<CosmosStudent>(student, new PartitionKey(student.Firstname));


        }

        public void CreateStatistic()
        {
            //TODO - Aufgabe 4
        }
    }
}
