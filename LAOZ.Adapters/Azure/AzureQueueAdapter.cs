using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage;

namespace LAOZ.CQRS.Adapters.Azure
{
    /// <summary>
    /// La clase AzureQueueAdapter es responsable de la interacción con las colas de Azure.
    /// Proporciona métodos para enviar, recibir y eliminar mensajes de la cola.
    /// </summary>
    public class AzureQueueAdapter : IQueueAdapter
    {
        private readonly CloudQueueClient queueClient;
        public string QueueName { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AzureQueueAdapter"/>.
        /// </summary>
        /// <param name="connectionString">La cadena de conexión a la cola de Azure.</param>
        /// <param name="queueName">El nombre de la cola de Azure.</param>
        public AzureQueueAdapter(string connectionString, string queueName)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            CloudStorageAccount storageAccount;
            if (CloudStorageAccount.TryParse(connectionString, out storageAccount))
            {
                queueClient = storageAccount.CreateCloudQueueClient();
            }
            else
            {
                throw new ArgumentException("Invalid storage account connection string");
            }
            QueueName = queueName;
        }

        /// <summary>
        /// Crea una cola con el nombre dado si no existe.
        /// </summary>
        /// <param name="queueName">El nombre de la cola a crear.</param>
        /// <returns>Un Task que representa la operación asincrónica.</returns>
        public Task EnqueueMessage(string message)
        {
            var queue = GetQueueReference(QueueName);
            return queue.AddMessageAsync(new CloudQueueMessage(message));
        }

        /// <summary>
        /// Crea una cola con el nombre dado si no existe.
        /// </summary>
        /// <returns>Un Task que representa la operación asincrónica.</returns>
        public async Task<string> DequeueMessage()
        {
            var queue = GetQueueReference(QueueName);
            Task<CloudQueueMessage> message = queue.GetMessageAsync();

            if (message != null)
            {
                await queue.DeleteMessageAsync(message.Result);
                return message.Result.ToString();
            }

            return null;
        }

        /// <summary>
        /// Comprueba si existe una cola con el nombre dado.
        /// </summary>
        /// <returns>Un Task que representa la operación asincrónica. El valor de la tarea es true si la cola existe; de lo contrario, es false.</returns>
        public async Task<bool> QueueExists()
        {
            var queue = GetQueueReference(QueueName);
            return await queue.ExistsAsync();
        }

        /// <summary>
        /// Crea una cola con el nombre dado si no existe.
        /// </summary>
        /// <returns>Un Task que representa la operación asincrónica.</returns>
        public async Task CreateQueue()
        {
            var queue = GetQueueReference(QueueName);
            await queue.CreateIfNotExistsAsync();
        }

        /// <summary>
        /// Elimina una cola con el nombre dado si existe.
        /// </summary>
        /// <returns>Un Task que representa la operación asincrónica.</returns>
        public async Task DeleteQueue()
        {
            var queue = GetQueueReference(QueueName);
            await queue.DeleteIfExistsAsync();
        }

        /// <summary>
        /// Obtiene una referencia a una cola con el nombre dado.
        /// </summary>
        /// <param name="queueName">El nombre de la cola.</param>
        /// <returns>Una referencia a la cola.</returns>
        private CloudQueue GetQueueReference(string queueName)
        {
            return queueClient.GetQueueReference(queueName);
        }
    }
}
