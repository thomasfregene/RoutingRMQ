using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "myroutingexchange", type: ExchangeType.Direct);

var message = "This message needs to be routed";
var body = Encoding.UTF8.GetBytes(message);
channel.BasicPublish("myroutingexchange", "both", null, body);
Console.WriteLine($"Send message: {message}");