# TP — Comprendre et reconstruire une application MVC

**BTS SIO 2e année · durée indicative : 2 h · thème : films**

Vous avez déjà suivi le tutoriel MVC de Microsoft. Ici, vous créez un nouveau projet sur le même thème afin de comprendre ce qui relie une URL, une action C# et la page affichée. Nous utiliserons une liste en mémoire : pas de base de données dans ce TP.

## Objectifs

À la fin de la séance, vous devrez pouvoir expliquer le rôle du routage, d'un contrôleur, d'une action, d'un modèle et d'une vue ; créer une page de liste puis adapter cet exemple à une page de détail et à une page filtrée.

| Étape | Durée indicative | Modalité |
|---|---:|---|
| Repérage et routage | 15 min | Discussion et lancement du projet |
| Premier exemple : liste des films | 35 min | Construction accompagnée |
| Mission 1 : enrichir la liste | 15 min | Autonomie |
| Mission 2 : détail d'un film | 30 min | Autonomie, mise en commun |
| Mission 3 : filtrer par année | 20 min | Autonomie |
| Bilan | 5 min | Explication orale |

## 1. Lancer le projet et comprendre le routage

```bash
dotnet new mvc -n MvcFilms
cd .\MvcFilms\ 
dotnet build
dotnet run
```

Ouvrez l'adresse indiquée par le terminal. Repérez `Program.cs`, `Controllers/`, `Models/`, `Views/` et `wwwroot/`. Quel rôle attribuez-vous à chacun ?

Dans `Program.cs`, retrouvez l'appel à `app.MapControllerRoute` et son motif :

```csharp
pattern: "{controller=Home}/{action=Index}/{id?}"
```

Le **système de routage d'ASP.NET Core** examine le chemin demandé. Ce motif indique où lire le nom du contrôleur, le nom de l'action et éventuellement un identifiant. `Home` et `Index` sont des valeurs par défaut ; le `?` signifie que le segment `id` est facultatif **dans l'URL**.

| Chemin demandé | Contrôleur | Action | Valeur de `id` dans l'URL |
|---|---|---|---|
| `/` | `HomeController` | `Index` | absente |
| `/Films` | `FilmsController` | `Index` | absente |
| `/Films/Details/2` | `FilmsController` | `Details` | `2` |

**Question à expliquer oralement :** quelle méthode de quelle classe ASP.NET Core cherchera-t-il lorsque vous saisirez `/Films` ? Cette classe existe-t-elle déjà dans votre nouveau projet ? Que se passera-t-il si elle n'existe pas ?

## 2. Premier exemple : afficher une liste

Créez `Models/Film.cs` :

```csharp
namespace MvcFilms.Models;

public class Film
{
    public int Id { get; set; }
    public string Titre { get; set; } = "";
    public int Annee { get; set; }
}
```

Créez `Controllers/FilmsController.cs` :

```csharp
using Microsoft.AspNetCore.Mvc;
using MvcFilms.Models;

namespace MvcFilms.Controllers;

public class FilmsController : Controller
{
    private static readonly List<Film> films = new()
    {
        new Film { Id = 1, Titre = "Alien", Annee = 1979 },
        new Film { Id = 2, Titre = "Dune", Annee = 2021 },
        new Film { Id = 3, Titre = "Interstellar", Annee = 2014 }
    };

    public IActionResult Index()
    {
        return View(films);
    }
}
```

**Avant de créer la vue**, demandez `/Films` dans le navigateur. Lisez l'erreur : quel fichier est recherché ? Si le message indique qu'une vue est introuvable, qu'est-ce qui a déjà fonctionné dans le trajet de la requête ? Si vous obtenez une erreur de compilation, corrigez-la avant de tirer une conclusion sur le routage.

Créez `Views/Films/Index.cshtml` :

```html
@model List<MvcFilms.Models.Film>

<h1>Liste des films</h1>
<ul>
@foreach (var film in Model)
{
    <li>@film.Titre (@film.Annee)</li>
}
</ul>
```

Rechargez `/Films`. Expliquez à voix haute : que vaut `films` dans le contrôleur ? Pourquoi la vue accède-t-elle à ces données avec `Model` ? Quel type est déclaré après `@model` ?

## 3. Mission 1 — enrichir la liste, 15 min

**À réaliser sans nouvelle démonstration :** ajoutez un réalisateur à chaque film et un quatrième film de votre choix. Affichez chaque ligne sous la forme « Dune — Denis Villeneuve — 2021 ».

**À montrer :** quatre lignes complètes sur `/Films`. Indiquez les fichiers modifiés et expliquez pourquoi vous avez dû toucher à chacun.
<!-- Les fichiers modifiés sont la classe Films pour ajouter réalisateur comme paramètre pour les films et Index pour afficher les réalisateurs des films et placer réalisateur entre titre et année.  -->
<details>
<summary>Indice si nécessaire</summary>
La nouvelle donnée "réalisateur" doit exister à la fois dans la classe `Film`, dans les objets créés par le contrôleur et dans le HTML produit par la vue.
</details>


## 4. Mission 2 — page de détail, 30 min

À partir de l'exemple `Index`, créez une page pour **un seul film**. L'adresse `/Films/Details/2` doit afficher le titre, l'année et le réalisateur du film 2. Ajoutez un lien « Détails » pour chaque film dans la liste et un lien de retour sur la page de détail. Si l'identifiant ne correspond à aucun film, renvoyez une réponse **404**.

**Livrables :** une action `Details`, une vue adaptée à un objet `Film`, un lien depuis la liste. Testez `/Films/Details/2` et `/Films/Details/999`.

**Questions :** qui extrait le `2` de l'URL ? Dans quel paramètre de l'action arrive-t-il ? Pourquoi le modèle de la vue de détail n'est-il pas une `List<Film>` ?

<details>
<summary>Indices si nécessaire</summary>
1. Avec la route par défaut, le dernier segment est nommé <code>id</code>.
L'action peut commencer par <code>public IActionResult Details(int? id)</code>.<br><br>
2. La liste <code>films</code> du contrôleur est accessible aux différentes actions.
Pour chercher un objet : <code>films.FirstOrDefault(f => f.Id == id)</code>.<br><br>
3. Si la recherche renvoie <code>null</code>, on peut utiliser
<code>return NotFound();</code>. Sinon, transmettre le film à
<code>View(film)</code>.<br><br>
4. La vue attendue est <code>Views/Films/Details.cshtml</code> et son
<code>@model</code> est de type <code>MvcFilms.Models.Film</code>.<br><br>
5. Un lien peut utiliser les Tag Helpers : <br>
<code>&lt;a asp-action="Details" asp-route-id="&#64;film.Id"&gt;Détails&lt;/a&gt;</code>.
</details>
<br>

**Cas limite à discuter :** `{id?}` autorise une URL sans dernier segment du point de vue du routage. Cela ne garantit pas qu'une action qui recherche un film puisse fonctionner sans identifiant. Comment traiteriez-vous explicitement `/Films/Details` ?

## 5. Mission 3 — filtrer par année, 20 min

Créez une page `/Films/Apres/2000` qui affiche les films sortis **strictement après** 2000. Réutilisez le modèle et la liste existants. Testez aussi `/Films/Apres/2020` et `/Films/Apres/2030`. Une liste vide doit produire une page compréhensible.

**Livrables :** une nouvelle action et sa vue. Expliquez les résultats des trois URL en fonction des films présents dans **votre** liste.

<details>
<summary>Indices si nécessaire</summary>
1. L'action s'appelle <code>Apres</code> et reçoit un <code>int id</code> avec la route actuelle. Ce nom est imposé par <code>{id?}</code>, même si la valeur représente ici une année.<br><br>
2. Pour sélectionner les films : <code>films.Where(f => f.Annee > id).ToList()</code>.<br><br>
3. Une action nommée <code>Apres</code> cherchera par défaut <code>Views/Films/Apres.cshtml</code>. La vue reçoit une liste de films.
</details>

### 6. Bilan — Que se passe-t-il quand on demande une page ?

À partir de : `GET /Films/Details/2`

Complétez puis expliquez à votre voisin :

```text
Navigateur
    │
    │ GET /Films/Details/2
    ▼
Système de routage ASP.NET Core
    │
    │ Controller = __________
    │ Action     = __________
    │ id         = __________
    ▼
________________Controller
    │
    ▼
Méthode __________________(int? id)
    │
    │ recherche du film demandé
    ▼
Objet Film
    │
    ▼
View(____________)
    │
    ▼
Vue __________________.cshtml
    │
    │ Razor génère le HTML
    ▼
Page HTML
    │
    ▼
Navigateur
    
```

**Pour aller plus loin :** si nous remplaçons plus tard la liste en mémoire par SQLite et Entity Framework Core, quelle partie du trajet de la requête restera identique ?
