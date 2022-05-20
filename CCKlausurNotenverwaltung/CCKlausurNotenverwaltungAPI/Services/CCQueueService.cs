using Azure.Storage.Queues;
using CCKlausurNotenverwaltungAPI.Models;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System.Text;

namespace CCKlausurNotenverwaltungAPI.Services
{
    public class CCQueueService
    {
        //public async Task AddMessageAsync(string message)
        //{
        //    QueueClient queueClient = new QueueClient("UseDevelopmentStorage=true", "klausur");
        //    queueClient.Create();
        //    await queueClient.SendMessageAsync(Base64Encode(message));
        //}

        public async Task AddLVBewertungAsync(LVBewertung lvBewertung)
        {
            QueueClient queueClient = new QueueClient("DefaultEndpointsProtocol=https;AccountName=csb10032001f904c851;AccountKey=soodIlxFWhsqshyNzx4CPAaF8zJnxGgk7tywWPRJ0u1iSmzFTM+NsJpZnf9kkt81h1mM+yWmgATi1mCxU8gXCg==;EndpointSuffix=core.windows.net", "queuelvbewertung");

            // Create the queue if it doesn't already exist
            queueClient.CreateIfNotExists();

            if (queueClient.Exists())
            {
                var messageToSend = Convert.ToBase64String(Encoding.UTF8.GetBytes(lvBewertung.ToString()));
                // Send a message to the queue
                queueClient.SendMessage(messageToSend);                
            }
        }

        //private static string Base64Encode(string plainText)
        //{
        //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        //    return System.Convert.ToBase64String(plainTextBytes);
        //}
    }
}
