
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://dmiqcjjy:FpxMQO_YeLTH2j-pdyggCr6jtygu_UFT@chimpanzee.rmq.cloudamqp.com/dmiqcjjy");


using var connection = factory.CreateConnection();
var channel = connection.CreateModel();



channel.QueueDeclare("Order", true, false, false);//kullandığımız kuyruk sistemi ismi 

var consumer = new EventingBasicConsumer(channel);

channel.BasicConsume("Order", true, consumer);
consumer.Received += Consumer_Received;
Console.ReadLine();


void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    //gelen siparişi işlem yaptımız mail veya hesahangibir işlem yaptığımızdaki kısım burasıdır
    Console.WriteLine("Gelen mesaj:" + Encoding.UTF8.GetString(e.Body.ToArray()));
}