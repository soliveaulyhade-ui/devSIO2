public class Client : IAffichable
{
     public void Afficher()
    {
        Console.WriteLine($"Client : {Nom} - Email : {Email} €");
    }
    public string Nom {get; set;} = "";
    public string Email {get; set;} = "";

    public static void AfficherClient (IAffichable client)
    {
        client.Afficher();
    }

}