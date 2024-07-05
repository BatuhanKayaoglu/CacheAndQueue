using CacheNQueue.Application.Abstractions.RabitMQ;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Infrastructure.RabitMQ
{
    public class RabitMQPublisherService : IRabitMQService
    {
        private readonly IConfiguration _configuration;

        public RabitMQPublisherService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Message(string Message, string QueueKey)
        {

            var factory = new ConnectionFactory();
            //factory.Uri = new Uri(_configuration.GetConnectionString("RabitMQ:Key"));
            factory.Uri = new Uri("amqps://dmiqcjjy:FpxMQO_YeLTH2j-pdyggCr6jtygu_UFT@chimpanzee.rmq.cloudamqp.com/dmiqcjjy");
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(QueueKey, true, false, false);

            var body = Encoding.UTF8.GetBytes(Message);

            channel.BasicPublish(string.Empty, QueueKey, null, body);



        }
    }
}
