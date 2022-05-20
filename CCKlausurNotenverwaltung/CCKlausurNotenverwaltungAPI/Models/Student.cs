using Azure;
using Azure.Data.Tables;

namespace CCKlausurNotenverwaltungAPI.Models
{
    public class Student : ITableEntity
    {
        public int StudentId { get; set; }
        public double Points { get; set; }
        public string Firstname { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        ETag ITableEntity.ETag { get; set; }
    }
}
