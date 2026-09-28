public class SansFrais : ICalculFrais
{
    public decimal Calculer(decimal montant)
    {
       return 0m;
    }

    public static void AfficherFrais(ICalculFrais calcul, decimal montant)
    {
        calcul.Calculer(montant);
        Console.WriteLine($"Montant sans frais : {montant}");
    }

}