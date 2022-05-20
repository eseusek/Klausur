using Azure;
using Azure.Data.Tables;

namespace CCKlausurNotenverwaltungAPI.Models
{
    public class CosmosStudent 
    {
        public string id { get; set; }
        public double Points { get; set; }
        public string Firstname { get; set; }
        
    }
}
