using System.Net.Mail;

var facture = new Facture();
IImprimable imprimable = facture;
IExportable exportable = facture;

var rapport = new Rapport();
IExportable exportableRapport = rapport;
//Console.WriteLine("Hello, World!");
