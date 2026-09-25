namespace MvcFilms.Models;

public class Film
{
    public int Id { get; set; }
    public string Titre { get; set; } = "";
    public int Annee { get; set; }
     public string Réalisateur { get; set; } = "";
}