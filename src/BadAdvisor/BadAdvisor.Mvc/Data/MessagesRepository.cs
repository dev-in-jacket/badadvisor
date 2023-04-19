using System;
using System.Collections.Generic;
using Azure.Data.Tables;

namespace BadAdvisor.Mvc.Data
{
    public class MessagesRepository : IMessagesRepository
    {
        private static readonly Message Default = new() { Text = "Default message"};
        private static Random _rand = new (DateTime.UtcNow.Millisecond);
        private readonly TableClient _tableClient;

        public MessagesRepository(TableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public Message GetNext()
        {
            var partitionKey = "fun";
            var queryResultsFilter = _tableClient.Query<Message>(filter: $"PartitionKey eq '{partitionKey}'");

            int totalCount = 0;
            var messages = new List<Message>();

            foreach (Message message in queryResultsFilter)
            {
                totalCount++;
                messages.Add(message);
            }

            if (totalCount == 0)
            {
                return Default;
            }

            var itemNumber = _rand.Next(totalCount);

            return messages[itemNumber];
        }
    }

    public interface IMessagesRepository
    {
        Message GetNext();
    }
}
