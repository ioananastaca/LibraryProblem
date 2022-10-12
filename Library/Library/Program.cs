using Library;
using Library.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

//lista carti biblioteca pentru testare
var HomoSapiens = new Carte("12345", "Homo Sapiens", 10, 4);
var Malala = new Carte("6789", "Eu sunt Malala", 12.5, 5);
var Maine = new Carte("101112", "Maine", 9, 2);
var cartiBiblioteca = new List<Carte>();
cartiBiblioteca.Add(HomoSapiens);
cartiBiblioteca.Add(Malala);
cartiBiblioteca.Add(Maine);

//lista imprumuturi pentru testare
var listaImprumuturi = new List<Imprumut>();
var imprumut1 = new Imprumut("0756830839", "12345", DateTime.Now);
var imprumut2 = new Imprumut("0756830839", "6789", DateTime.Now);
var imprumut3 = new Imprumut("0756830899", "12345", DateTime.Now);
listaImprumuturi.Add(imprumut1);
listaImprumuturi.Add(imprumut3);
listaImprumuturi.Add(imprumut2);

//adaugare carte 
static void AdaugaCarte(List<Carte> listaCarti)
{
    Console.WriteLine("ISBN carte: ");
    string ISBN = Console.ReadLine().ToString();

    Console.WriteLine("Numar exemplare: ");
    int nrExemplare = int.Parse(Console.ReadLine());

    var carte = listaCarti.FirstOrDefault(x => x.iSBN == ISBN); ;

    if (carte != null)
    {
        if (nrExemplare == 0)
        {
            Console.Write("Numarul de exemplare adaugat trebuie sa fie mai mare decat 0!");
        }
        else
        {
            carte.nrExemplare = carte.nrExemplare + nrExemplare;
        }
    }
    else
    {
        Console.WriteLine("Nume carte: ");
        string numeCarte = Console.ReadLine().ToString();

        Console.WriteLine("Pret carte: ");
        double pretInchiriere = double.Parse(Console.ReadLine());

        Carte carteNoua = new Carte(ISBN, numeCarte, pretInchiriere, nrExemplare);
        listaCarti.Add(carteNoua);

        Console.WriteLine("Ati adaugat o carte noua!");
    }
}

//afisare lista carti total
static void AfisareCarti(List<Carte> cartiBiblioteca)
{
    foreach (var carte in cartiBiblioteca) Console.WriteLine(carte);
}

//afisare numar exemplare disponibile pt o anumita carte
static void AfisareNumarExemplareDisponibile(List<Carte> lista, string ISBN)
{
    var carte = lista.FirstOrDefault(x => x.iSBN == ISBN);
    if (carte != null)
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
static void ImprumutaCarte(List<Carte> cartiBiblioteca, string ISBN, List<Imprumut> listaImprumuturi, string nrTelefonCititor)
{
    var dataImprumut = DateTime.Now;

    var carte = cartiBiblioteca.FirstOrDefault(x => x.iSBN == ISBN);

    if (carte != null)
    {
        if (carte.nrExemplare > 0)
        {
            var imprumut = new Imprumut(nrTelefonCititor, ISBN, dataImprumut);
            carte.nrExemplare--;
            listaImprumuturi.Add(imprumut);
            Console.WriteLine("Imprumut realizat cu succes!");
        }
        else
        {
            Console.WriteLine("Nu mai exista exemplare disponibile din cartea " + carte.numeCarte + ".");
        }
    }
    else
    {
        Console.WriteLine("Ne pare rau! Cartea nu este disponibila in biblioteca noastra!");
    }
}

//afisare lista imprumuturi
static void AfisareListaImprumuturi(List<Imprumut> listaImprumuturi)
{
    foreach (var imprumut in listaImprumuturi) Console.WriteLine(imprumut);
}

//lista imprumuturi pt un anumit cititor
static void ListaImprumuturiCititor(List<Imprumut> listaImprumuturi, string nrTelefonCititor)
{
    var imprumuturiCititor = new List<Imprumut>();
    for (int i = 0; i < listaImprumuturi.Count; i++)
    {
        if (listaImprumuturi[i].nrTelefon == nrTelefonCititor)
        {
            imprumuturiCititor.Add(listaImprumuturi[i]);
        }
    }
    foreach (var i in imprumuturiCititor) Console.WriteLine(i);
}


//returnare carte
void ReturnareCarte(List<Imprumut> listaImprumuturi, string nrTelefonCititor, string ISBN, List<Carte> cartiBiblioteca)
{
    var imprumut = listaImprumuturi.FirstOrDefault(x => x.nrTelefon == nrTelefonCititor && x.iSBN == ISBN);
    var carteaImprumutata = cartiBiblioteca.FirstOrDefault(x => x.iSBN == ISBN); // cartea din imprumu

    if (imprumut != null)
    {
        try { 
               var dataImprumut = imprumut.dataImprumut;

               Console.WriteLine("----Introduceti data restituirii----");

               Console.WriteLine("Ziua: [1-31]");
               var zi = int.Parse(Console.ReadLine());
               Console.WriteLine("Luna: [1-12]");
               var luna = int.Parse(Console.ReadLine());
               Console.WriteLine("An: [1 - x]");
               var an = int.Parse(Console.ReadLine());

               var dataRestituire = Convert.ToDateTime(luna + "/" + zi + "/" + an);

               var intervalImprumut = dataRestituire - dataImprumut;

               if (intervalImprumut.Days <= 14)
               {
                   carteaImprumutata.nrExemplare++;
                   Console.WriteLine("Multumim pentru respectarea conditiilor de imprumutare!");
               }
               else
               {
                   int numarZileContraCost = intervalImprumut.Days - 14;
                   double pretInchiriere = (carteaImprumutata.pretInchiriere * 0.01) * numarZileContraCost;

                   Console.WriteLine("Din cauza ca ati depasit zilele permise pentru impumutarea unei carti, " +
                       "trebuie achitata suma de " + pretInchiriere + " lei.");
               }

               listaImprumuturi.Remove(imprumut);
        }
        catch(FormatException)
        {
            Console.WriteLine("Invalid data!");
        }
    }
    else
    {
        Console.WriteLine("Nu au fost gasite informaii aferente datelor.Va rugam sa verificati datele. ");
    }
}

// meniu principal
bool ShowMenu()
{
    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
    Console.WriteLine("Alege o optiune:");
    Console.WriteLine("1) Lista carti biblioteca");
    Console.WriteLine("2) Lista imprumuturi");
    Console.WriteLine("3) Afisare numar exemplare disponibile dintr-o carte");
    Console.WriteLine("4) Imprumuta carte");
    Console.WriteLine("5) Restituie carte");
    Console.WriteLine("6) Adauga carte");
    Console.WriteLine("7) Iesire");
    Console.Write("\r\nSelecteaza optiunea: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("\n---Lista carti biblioteca---\n ");
            AfisareCarti(cartiBiblioteca);
            return true;
        case "2":
            Console.WriteLine("\n---Lista imprumuturi---\n ");
            AfisareListaImprumuturi(listaImprumuturi);
            return true;
        case "3":
            Console.WriteLine("\n---Afisare numar exemplare disponibile carte---\n ");
            Console.WriteLine("Introduceti ISBN carte: ");
            string ISBNcarte = Console.ReadLine().ToString();
            AfisareNumarExemplareDisponibile(cartiBiblioteca, ISBNcarte);
            return true;
        case "4":
            Console.WriteLine("\n---Imprumuta carte---\n ");
            Console.WriteLine("Introduceti ISBN carte: ");
            string ISBN = Console.ReadLine().ToString();
            Console.WriteLine("Introduceti numar telefon cititor: ");
            string telefon = Console.ReadLine().ToString();
            ImprumutaCarte(cartiBiblioteca, ISBN, listaImprumuturi, telefon);
            return true;
        case "5":
            Console.WriteLine("\n---Restituie carte---\n ");
            Console.WriteLine("Introduceti ISBN carte: ");
            string iSBN = Console.ReadLine().ToString();
            Console.WriteLine("Introduceti numar telefon cititor: ");
            string nrtelefon = Console.ReadLine().ToString();
            ReturnareCarte(listaImprumuturi, nrtelefon, iSBN, cartiBiblioteca);
            return true;
        case "6":
            Console.WriteLine("\n---Adauga carte carte---\n ");
            AdaugaCarte(cartiBiblioteca);
            return true;
        case "7":
            return false;

        default:
            return true;
    }
    Console.Clear();
}

//apelare meniu
bool meniu = true;
while (meniu)
{
    meniu = ShowMenu();
}


