using System.Net.Mail;

var produit = new Produit
{
    Nom = "téléphone",
    Prix = 300m
};



var client = new Client
{
    Nom = "Alice",
    Email = "alice@example.com"
};

produit.Afficher();
client.Afficher();

//"téléphone -", 300m
//Console.WriteLine("Hello, World!");
