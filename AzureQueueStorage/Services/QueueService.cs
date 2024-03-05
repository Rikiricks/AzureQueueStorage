using Azure.Storage.Queues.Models;
using Azure.Storage.Queues;

namespace AzureQueueStorage.Services
{
    public class QueueService : IQueueService
    {
        private readonly QueueServiceClient _queueServiceClient;

        public QueueService(QueueServiceClient queueServiceClient)
        {
            _queueServiceClient = queueServiceClient;
        }

        public async Task SendMessageAsync(string queueName, string messageText)
        {
            var queueClient = _queueServiceClient.GetQueueClient(queueName);
            await queueClient.SendMessageAsync(messageText);
        }

        public async Task<string> ReceiveMessageAsync(string queueName)
        {
            var queueClient = _queueServiceClient.GetQueueClient(queueName);
            QueueMessage[] messages = await queueClient.ReceiveMessagesAsync();

            if (messages.Length > 0)
            {
                var message = messages[0];
                return message.MessageText;
            }

            return null;
        }
    }
}
