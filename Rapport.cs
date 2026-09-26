public class Rapport : IExportable
{
 public void Exporter(string Fichier)
    {
        Console.WriteLine($"Le rapport est exportée vers {Fichier}");
    }
    public string Fichier {get;} = "";

    public static void ExporterFacture (IExportable rapport)
    {
        rapport.Exporter("doc-rap");
    } 
}