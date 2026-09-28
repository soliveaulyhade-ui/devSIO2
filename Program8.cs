using System.Net.Mail;
var email = new NotificationEmail();
var sms = new NotificationSms();
var console = new NotificationConsole();

 NotificationEmail.EnvoyerNotification(email, "Votre commande est prête");
 NotificationSms.EnvoyerNotification(sms, "Votre commande est prête");
 NotificationConsole.EnvoyerNotification(console, "Votre commande est prête");
//Console.WriteLine("Hello, World!");
