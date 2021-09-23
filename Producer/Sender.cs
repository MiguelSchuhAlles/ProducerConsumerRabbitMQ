using System;
using System.Threading.Channels;
using RabbitMQ.Client;
using System.Text;
using System.Net.Http;

namespace Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);

                string message = "Getting started with .Net Core RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine($"Sent message '{message}'");

                Console.WriteLine("Press any key to exit the Sender app...");
                Console.ReadLine();
            }
        }
    }
}
