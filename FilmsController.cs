using Microsoft.AspNetCore.Mvc;
using MvcFilms.Models;

namespace MvcFilms.Controllers;

public class FilmsController : Controller
{
    private static readonly List<Film> films = new()
    {
        new Film { Id = 1, Titre = "Alien", Réalisateur = "Ridley Scott", Annee = 1979, },
        new Film { Id = 2, Titre = "Dune", Réalisateur = " Denis Villeneuve", Annee = 2021, },
        new Film { Id = 3, Titre = "Interstellar", Réalisateur = " Christopher Nolan", Annee = 2014, },
        new Film { Id = 4, Titre = "Spider-Man Brand New Day", Réalisateur = "Destin Daniel Cretton" , Annee = 2026, },
    };

    public IActionResult Index()
    {
        return View(films);
    }
}