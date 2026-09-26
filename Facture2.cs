public class Facture2 : Document, IImprimable
{
    public decimal Montant { get; set; }
    
     public void ImprimerFacture()
    {
        Console.WriteLine($"Facture : {Titre} - {Montant} €");
    }

}