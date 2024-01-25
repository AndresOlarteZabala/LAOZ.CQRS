namespace LAOZ.CQRS.Adapters
{
    public interface IQueueAdapter
    {
        /// <summary>
        /// Enqueue a message to the queue.
        /// </summary>
        /// <param name="message"></param>
        Task EnqueueMessage(string message);

        /// <summary>
        /// Dequeue a message from the queue.
        /// </summary>
        /// <returns></returns>
        Task<string> DequeueMessage();

        /// <summary>
        /// Check if the queue exists.
        /// </summary>
        /// <returns></returns>
        Task<bool> QueueExists();

        /// <summary>
        /// Create the queue if it doesn't exist.
        /// </summary>
        /// <returns></returns>
        Task CreateQueue();

        /// <summary>
        /// Delete the queue if it exists.
        /// </summary>
        /// <returns></returns>
        Task DeleteQueue();
    }
}
