using Library;
using Library.Models;
using System;
using System.Collections;
using System.Collections.Generic;


Carte HomoSapiens = new Carte("12345", "Homo Sapiens", 15, 3);
Carte Malala = new Carte("6789", "Eu sunt Malala", 12.5, 5);
Carte Maine = new Carte("101112", "Maine", 9, 2);


List<Carte> cartiBiblioteca = new List<Carte>();
cartiBiblioteca.Add(HomoSapiens);
cartiBiblioteca.Add(Malala);
cartiBiblioteca.Add(Maine);


//adaugare carte 
//de adaugat constrangeri
static void AdaugaCarte(List<Carte> listaCarti)
{
    Console.WriteLine("***Adauga carte***");

    Console.WriteLine("ISBN carte: ");
    string ISBN = Console.ReadLine().ToString();

    Console.WriteLine("Numar exemplare: ");
    int nrExemplare =int.Parse(Console.ReadLine());

    Carte carte = listaCarti.FirstOrDefault(x => x.iSBN == ISBN); ;

    if (carte != null)
    {
        carte.nrExemplare=carte.nrExemplare+nrExemplare;
    }
    else
    {
        Console.WriteLine("Nume carte: ");
        string numeCarte = Console.ReadLine().ToString();

        Console.WriteLine("Pret carte: ");
        double pretInchiriere = double.Parse(Console.ReadLine());

        Carte carteNoua = new Carte(ISBN, numeCarte, pretInchiriere, nrExemplare);
        listaCarti.Add(carteNoua);

        Console.WriteLine("ati adaugat o carte noua!");
    }
}

//afisare lista carti total
static void AfisareCarti(List<Carte> cartiBiblioteca)
{
    foreach (var carte in cartiBiblioteca) Console.WriteLine(carte);
}

//afisare numar exemplare disponibile pt o anumita carte

static void AfisareNumarExemplareDisponibile(List<Carte>lista, string ISBN)
{
    var carte=lista.FirstOrDefault(x => x.iSBN == ISBN);
    if(carte != null)
    {
        Console.WriteLine("Nr exemplare disponibile: ");
        Console.WriteLine(carte.nrExemplare);
    }
    else
    {
        Console.WriteLine("Nu am gasit aceasta carte. Incercati alta varianta.");
    }

}

//imprumut carte 

//returnare carte


// ----------------------MAIN section -------------------------------

//AdaugaCarte(cartiBiblioteca);
/*Console.WriteLine(findcarte("12345"));*/

AfisareCarti(cartiBiblioteca);
AfisareNumarExemplareDisponibile(cartiBiblioteca, "12345");


