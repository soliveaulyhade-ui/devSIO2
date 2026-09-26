public class Document : IImprimable
{ public void Imprimer()
    {
        Console.WriteLine("Le document est imprimable");
    }
    public string Titre { get; set; } = "";

    public static void ImprimerFacture (IImprimable document)
    {
        document.Imprimer();
    }  

}