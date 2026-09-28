public class FraisPremium : ICalculFrais
{
    public decimal Calculer(decimal montant)
    {
        return montant * 1.005m;
    }
    
    public static void AfficherFrais(ICalculFrais calcul, decimal montant)
    {
        calcul.Calculer(montant);
        Console.WriteLine($"Montant avec frais premium : {montant}");
    }   

}