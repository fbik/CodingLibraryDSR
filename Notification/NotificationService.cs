using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Notification;

public class NotificationService
{
    private readonly IModel _channel;
    
    public NotificationService(IConnectionFactory connectionFactory)
    {
        var connection = connectionFactory.CreateConnection();
        _channel = connection.CreateModel();
        _channel.QueueDeclare("notifications", durable:true, exclusive:false);
    }
    
    public void SendNotification(NotificationDTO notificationDto)
    {
        var json = JsonSerializer.Serialize(notificationDto);
        var body = Encoding.UTF8.GetBytes(json);
        _channel.BasicPublish(exchange: "", routingKey: "notifications", body: body);
    }
}