public class NotificationSms : INotification
{
 public void Envoyer(string message)
    {
        Console.WriteLine($"Sms : {message}");
    }

    public static void EnvoyerNotification(INotification notification, string message)
    {
        notification.Envoyer(message);
    }
    
}