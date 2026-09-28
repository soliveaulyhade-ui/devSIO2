# Exercices — Les interfaces en C#

## BTS SIO 2e année

Ces exercices correspondent au **chapitre 17 — Comprendre les interfaces**, jusqu'à la partie **17.14**.

L'objectif est de comprendre progressivement :

* ce qu'est une interface ;
* la notion de **contrat** ;
* comment une classe implémente une interface ;
* comment plusieurs classes peuvent respecter le même contrat ;
* comment manipuler un objet à travers une interface ;
* comment passer une interface en paramètre d'une méthode ;
* comment une classe peut implémenter plusieurs interfaces ;
* la différence entre **héritage** et **interface** ;
* le polymorphisme obtenu grâce aux interfaces.

---

# Exercice 1 — Première interface

On souhaite représenter des objets qui peuvent être affichés.

Créer l'interface suivante :

```csharp
public interface IAffichable
{
    void Afficher();
}
```

Créer ensuite une classe `Produit` possédant les propriétés suivantes :

```text
Nom
Prix
```

La classe `Produit` doit implémenter l'interface `IAffichable`.

La méthode `Afficher()` devra afficher les informations du produit.

Exemple :

```text
Clavier - 49.90 €
```

Dans `Program.cs` :

1. créer un produit ;
2. appeler sa méthode `Afficher()`.

## Questions

1. Que signifie `: IAffichable` dans la déclaration de `Produit` ? 
<!-- `: IAffichable` signifie que `Produit`a un contrat avec IAffichable. -->

2. Que se passe-t-il si la classe `Produit` ne contient pas la méthode `Afficher()` ?
<!-- `Produit` ne pourra pas être affichée. -->

3. Pourquoi dit-on qu'une interface constitue un **contrat** ?

---

# Exercice 2 — Plusieurs classes, un même contrat

On reprend l'interface :

```csharp
public interface IAffichable
{
    void Afficher();
}
```

Créer deux classes :

```text
Produit
Client
```

La classe `Produit` possède :

```text
Nom
Prix
```

La classe `Client` possède :

```text
Nom
Email
```

Les deux classes doivent implémenter `IAffichable`.

Chaque classe doit cependant fournir sa propre implémentation de `Afficher()`.

Exemple pour un produit :

```text
Clavier - 49.90 €
```

Exemple pour un client :

```text
Alice - alice@example.com
```

Tester ensuite :

```csharp
var produit = new Produit(...);
var client = new Client(...);

produit.Afficher();
client.Afficher();
```

## Questions

1. `Produit` hérite-t-il de `Client` ?
<!-- Non -->

2. `Client` hérite-t-il de `Produit` ?
<!-- Non -->

3. Quelle capacité possèdent pourtant les deux classes ?
<!-- Ils possèdent la capacité d'être affichée. -->

4. Pourquoi une interface est-elle adaptée à cette situation ?
<!-- On cherche à afficher un client et un produit. -->
---

# Exercice 3 — Une variable de type interface

À partir des classes précédentes, écrire :

```csharp
IAffichable element = new Produit(...);

element.Afficher();
```

Remplacer ensuite le produit par un client :

```csharp
IAffichable element = new Client(...);

element.Afficher();
```

Le code suivant reste donc identique :

```csharp
element.Afficher();
```

## Questions

1. Quel est le type de la variable `element` ?
2. Quel est le type réel de l'objet dans le premier exemple ?
3. Quel est le type réel de l'objet dans le deuxième exemple ?
4. Pourquoi `element.Afficher()` fonctionne-t-il dans les deux cas ?
5. Peut-on écrire :

```csharp
element.Prix
```

Pourquoi ?

---

# Exercice 4 — Une méthode utilisant une interface

Créer la méthode suivante :

```csharp
public static void AfficherElement(IAffichable element)
{
    element.Afficher();
}
```

Créer ensuite :

```csharp
var produit = new Produit(...);
var client = new Client(...);
```

Utiliser la même méthode avec les deux objets :

```csharp
AfficherElement(produit);
AfficherElement(client);
```

Ajouter maintenant une troisième classe :

```text
Commande
```

Cette classe doit également implémenter `IAffichable`.

Elle possède par exemple :

```text
Numero
Montant
```

Implémenter sa méthode `Afficher()`.

Tester ensuite :

```csharp
AfficherElement(new Commande(...));
```

## Questions

1. A-t-il été nécessaire de modifier `AfficherElement()` ?
<!-- Non -->

2. Pourquoi cette méthode peut-elle accepter des objets de classes différentes ?
<!-- Elle peut accepter des objets de classes différentes car la méthode demande quelque chose qu'elle peut afficher.  -->

3. Quel serait l'inconvénient d'écrire uniquement :

```csharp
public static void AfficherProduit(Produit produit)
{
    produit.Afficher();
}
```
<!-- L'incovénient serait que cette méthode ne prennent que Produit et rien d'autres. -->
---

# Exercice 5 — Une collection d'interfaces

Créer plusieurs objets :

```csharp
var produit = new Produit(...);
var client = new Client(...);
var commande = new Commande(...);
```

Créer ensuite une collection :

```csharp
List<IAffichable> elements = new();
```

Ajouter les trois objets :

```csharp
elements.Add(produit);
elements.Add(client);
elements.Add(commande);
```

Parcourir ensuite la collection :

```csharp
foreach (var element in elements)
{
    // à compléter
}
```

Le programme doit appeler `Afficher()` pour chaque élément.

## Questions

1. Comment une même collection peut-elle contenir des `Produit`, des `Client` et des `Commande` ?
2. Quel est leur point commun ?
3. Quelle méthode le compilateur sait-il pouvoir appeler sur chaque élément ?
4. Le programme a-t-il besoin de connaître le type exact de chaque objet pour appeler `Afficher()` ?

---

# Exercice 6 — Deux capacités différentes

On souhaite maintenant distinguer deux capacités :

* pouvoir être imprimé ;
* pouvoir être exporté.

Créer les interfaces suivantes :

```csharp
public interface IImprimable
{
    void Imprimer();
}
```

et :

```csharp
public interface IExportable
{
    void Exporter(string fichier);
}
```

Créer ensuite les classes :

```text
Facture
Rapport
```

Une `Facture` doit être :

```text
imprimable
ET
exportable
```

Un `Rapport` doit être uniquement :

```text
exportable
```

La déclaration de `Facture` devra donc utiliser les deux interfaces.

Créer ensuite :

```csharp
var facture = new Facture(...);
```

Puis :

```csharp
IImprimable imprimable = facture;
IExportable exportable = facture;
```

Appeler les méthodes accessibles depuis chaque variable.

## Questions

1. Combien d'objets `Facture` ont été créés ?
<!-- 2 objets ont été créées  -->

2. `imprimable` et `exportable` peuvent-ils référencer le même objet ?
<!-- Oui -->

3. Quelle méthode est accessible avec `imprimable` ?
<!-- Imprimer() -->

4. Quelle méthode est accessible avec `exportable` ?
<!-- Exporter() -->

5. Une classe C# peut-elle implémenter plusieurs interfaces ?
<!-- Oui -->

---

# Exercice 7 — Héritage et interface

Créer une classe :

```csharp
public class Document
{
    public string Titre { get; set; }
}
```

Créer ensuite une classe `Facture`.

Une facture :

* **est un** document ;
* **peut être imprimée**.

La classe devra donc utiliser à la fois :

```text
Document
IImprimable
```

Compléter :

```csharp
public class Facture : ...............
{
    public decimal Montant { get; set; }

    // à compléter
}
```

Créer ensuite une facture :

```csharp
var facture = new Facture(...);
```

et appeler sa méthode `Imprimer()`.

## Questions

Pour chacune des phrases suivantes, indiquer s'il s'agit d'un **héritage** ou d'une **interface** :

```text
Facture EST UN Document **héritage**
```

```text
Facture PEUT ÊTRE imprimée **interface**
```

Compléter ensuite :

```text
L'héritage décrit principalement ce qu'un objet **peut être**.

Une interface décrit principalement ce qu'un objet **peut faire**.
```

---

# Exercice 8 — Système de notifications

Une application doit pouvoir envoyer des notifications de différentes manières.

Créer l'interface :

```csharp
public interface INotification
{
    void Envoyer(string message);
}
```

Créer trois classes qui implémentent cette interface :

```text
NotificationEmail
NotificationSms
NotificationConsole
```

Chaque classe fournit sa propre implémentation.

Exemple :

```text
EMAIL : Votre commande est prête.
SMS : Votre commande est prête.
CONSOLE : Votre commande est prête.
```

Créer ensuite la méthode :

```csharp
public static void EnvoyerNotification(
    INotification notification,
    string message)
{
    // à compléter
}
```

Tester :

```csharp
var email = new NotificationEmail();
var sms = new NotificationSms();
var console = new NotificationConsole();

EnvoyerNotification(email, "Votre commande est prête.");
EnvoyerNotification(sms, "Votre commande est prête.");
EnvoyerNotification(console, "Votre commande est prête.");
```

## Contrainte

La méthode `EnvoyerNotification()` ne doit pas utiliser :

```csharp
if
```

pour déterminer le type de notification.

Elle doit uniquement travailler avec l'interface `INotification`.

## Questions

1. Comment `EnvoyerNotification()` peut-elle fonctionner sans connaître la classe exacte ?
<!-- Elle peut fonctionner sans connaître la classe exacte en ayant mis l'interface qui a un contrat avec toutes les autres notifications au lieu d'en préciser une pour éviter que EnvoyerNotification() ne prend que celle préciser et non les autres. -->

2. Quelle méthode l'interface garantit-elle ?
<!-- Elle garantit la méthode EnvoyerNotification(). -->

3. Pourrait-on ajouter demain une classe `NotificationPush` sans modifier `EnvoyerNotification()` ?
<!-- On pourrait ajouter demain une classe `NotificationPush` sans modifier `EnvoyerNotification()` tant que `NotificationPush` a un contrat avec l'interface INotification. -->
---

# Exercice 9 — Calcul des frais bancaires

On souhaite maintenant gérer différentes manières de calculer des frais bancaires.

Créer l'interface :

```csharp
public interface ICalculFrais
{
    decimal Calculer(decimal montant);
}
```

Créer trois implémentations :

```text
FraisStandard
FraisPremium
SansFrais
```

Les règles sont les suivantes :

| Type            | Calcul           |
| --------------- | ---------------- |
| `FraisStandard` | 1 % du montant   |
| `FraisPremium`  | 0,5 % du montant |
| `SansFrais`     | 0 €              |

Par exemple, pour :

```text
montant = 1000 €
```

on doit obtenir :

```text
FraisStandard → 10 €
FraisPremium  → 5 €
SansFrais     → 0 €
```

Créer ensuite la méthode :

```csharp
public static void AfficherFrais(
    ICalculFrais calcul,
    decimal montant)
{
    // à compléter
}
```

Tester cette méthode avec les trois systèmes de calcul.

Par exemple :

```csharp
AfficherFrais(new FraisStandard(), 1000m);
AfficherFrais(new FraisPremium(), 1000m);
AfficherFrais(new SansFrais(), 1000m);
```

## Questions

1. Pourquoi `AfficherFrais()` utilise-t-elle `ICalculFrais` plutôt que `FraisStandard` ?
<!-- Pour calculer les frais de toutes les classes et ne pas refuser toutes les autres classes juste pour en calculer une. -->

2. Quelle méthode le contrat `ICalculFrais` garantit-il ?
<!-- Il garantit la méthode Calculer(). -->

3. Le programme qui appelle `Calculer()` a-t-il besoin de savoir comment les frais sont calculés ?
<!-- Non -->

---

# Exercice 10 — Mini-application : modes de livraison

Une boutique en ligne propose plusieurs modes de livraison.

Créer l'interface :

```csharp
public interface ICalculLivraison
{
    decimal Calculer(decimal montantCommande);
}
```

Créer trois classes :

```text
LivraisonStandard
LivraisonExpress
RetraitMagasin
```

## Livraison standard

Les frais sont :

```text
5 € si la commande est inférieure à 50 €
0 € sinon
```

## Livraison express

Les frais sont toujours :

```text
12 €
```

## Retrait en magasin

Les frais sont toujours :

```text
0 €
```

Chaque classe doit implémenter :

```csharp
ICalculLivraison
```

Créer ensuite :

```csharp
public static void AfficherTotal(
    decimal montantCommande,
    ICalculLivraison calculLivraison)
{
    // calculer les frais de livraison

    // calculer le total

    // afficher le montant de la commande

    // afficher les frais

    // afficher le total
}
```

Tester :

```csharp
AfficherTotal(
    40m,
    new LivraisonStandard());

AfficherTotal(
    40m,
    new LivraisonExpress());

AfficherTotal(
    40m,
    new RetraitMagasin());
```

Comparer les résultats.

Tester ensuite avec une commande de :

```text
100 €
```

## Évolution de l'application

La boutique souhaite maintenant proposer :

```text
LivraisonInternationale
```

Les frais sont toujours de :

```text
25 €
```

Ajouter cette nouvelle possibilité.

## Contraintes

Il est interdit de modifier :

```csharp
AfficherTotal()
```

Il est également interdit d'ajouter dans cette méthode :

```csharp
if (calculLivraison is LivraisonInternationale)
```

## Questions finales

1. Quelle classe faut-il ajouter ?


2. Quelle interface doit-elle implémenter ?
<!-- Elle doit implémenter l'interface ICalculLivraison. -->

3. Pourquoi `AfficherTotal()` continue-t-elle à fonctionner sans modification ?
<!-- Elle continue à fonctionner sans modification car  `AfficherTotal()` appelle les méthodes des livraisons et du retrait du magasin. -->
4. Quel avantage apporte ici l'utilisation de l'interface ?
<!-- Toutes les classes peuvent être calculées sans modifications grâce à l'interface.  -->
5. Que signifie finalement la phrase :

> **Une interface décrit ce qu'un objet sait faire, sans dire comment il le fait.**

---

# À retenir

Une interface définit un **contrat**.

Par exemple :

```csharp
public interface IImprimable
{
    void Imprimer();
}
```

signifie :

```text
Tout objet IImprimable doit savoir exécuter Imprimer().
```

Plusieurs classes différentes peuvent respecter le même contrat :

```text
                 IImprimable
                      ▲
                      │
          ┌───────────┼───────────┐
          │           │           │
       Facture      Ticket      Rapport
```

Le programme peut alors travailler avec la **capacité** :

```csharp
IImprimable
```

plutôt qu'avec une classe particulière :

```csharp
Facture
Ticket
Rapport
```

C'est ce qui permet d'écrire du code capable de manipuler différents objets à travers une interface commune.
