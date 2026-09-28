public class NotificationEmail : INotification
{
    public void Envoyer(string message)
    {
        Console.WriteLine($"Email : {message}");
    }

    public static void EnvoyerNotification(INotification notification, string message)
    {
        notification.Envoyer(message);
    }
    
}