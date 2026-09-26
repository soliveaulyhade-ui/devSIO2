public class Facture : IImprimable, IExportable
{
    public void Imprimer()
    {
        Console.WriteLine("La facture est imprimable");
    }

    public static void ImprimerFacture (IImprimable facture)
    {
        facture.Imprimer();
    }  

    public void Exporter(string Fichier)
    {
        Console.WriteLine($"La facture est exportée vers {Fichier}");
    }

    public static void ExporterFacture (IExportable facture)
    {
        facture.Exporter("doc-fac");
    } 
}