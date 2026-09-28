public class FraisStandard : ICalculFrais
{
    public decimal Calculer(decimal montant)
    {
        return montant * 1.01m;
    }
    public static void AfficherFrais( ICalculFrais calcul, decimal montant)
    {
        calcul.Calculer(montant);
        Console.WriteLine($"Montant avec frais standard : {montant}");
    }
}