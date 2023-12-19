// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using service.Models;

Console.WriteLine("Сервис для обработки билетов запущен!");

var factory = new ConnectionFactory() {
    HostName = "localhost",
    UserName = "user",
    Password = "pass",
    VirtualHost = "/"
};

using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "bookings",
            durable: true,
            exclusive: false
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, eq) => {
            Console.WriteLine("FSDF");

            var body = eq.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(message);

            Booking booking = JsonSerializer.Deserialize<Booking>(body);

            if (booking == null)
            {
                Console.WriteLine("Ошибка десериализации!!!");
            } 
            else 
            {
                booking.Status = "Finished";
                Console.WriteLine($"Booking {booking.Id} status: {booking.Status}");
            }
            
        };

        channel.BasicConsume(queue: "bookings",
            autoAck: true,
            consumer: consumer);

        Console.ReadKey();
    }
}