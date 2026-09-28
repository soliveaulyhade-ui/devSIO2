using System.Runtime.CompilerServices;

public class NotificationConsole : INotification
{
    public void Envoyer(string message)
    {
        Console.WriteLine($"Console : {message} ");
    }

    public static void EnvoyerNotification(INotification notification, string message)
    {
        notification.Envoyer("Votre commande est prête");
    }
}