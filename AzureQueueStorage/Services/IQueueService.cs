namespace AzureQueueStorage.Services
{
    public interface IQueueService
    {
        Task SendMessageAsync(string queueName, string messageText);
        Task<string> ReceiveMessageAsync(string queueName);
    }
}
