public class Produit : IAffichable
{
    public void Afficher()
    {
        Console.WriteLine($"Produit : {Nom} - Prix : {Prix} €");
    }

    public string Nom {get; set;} = "";
    public decimal Prix {get; set;}

    public static void AfficherProduit (IAffichable produit)
    {
        produit.Afficher();
    }

}
