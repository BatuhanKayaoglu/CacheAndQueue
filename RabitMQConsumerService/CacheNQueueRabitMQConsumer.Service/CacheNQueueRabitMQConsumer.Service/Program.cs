
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://dmiqcjjy:FpxMQO_YeLTH2j-pdyggCr6jtygu_UFT@chimpanzee.rmq.cloudamqp.com/dmiqcjjy");


using var connection = factory.CreateConnection();
var channel = connection.CreateModel();


channel.QueueDeclare("Order", true, false, false);

var consumer = new EventingBasicConsumer(channel);

channel.BasicConsume("Order", true, consumer);
consumer.Received += Consumer_Received;
Console.ReadLine();

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    //gelen siparişe dair işlem yaptımız mail veya herhangi bir işlem yaptığımız yer
    Console.WriteLine("Gelen mesaj:" + Encoding.UTF8.GetString(e.Body.ToArray()));
}