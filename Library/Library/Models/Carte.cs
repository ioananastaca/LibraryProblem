using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Carte
    {
        private string ISBN;

        private string NumeCarte;
        private double PretInchiriere;
        private int NrExemplare;

        public Carte()
        {

        }
        public Carte(string ISBN, string NumeCarte, double PretInchiriere, int NrExemplare)
        {
            this.ISBN = ISBN;
            this.NumeCarte=NumeCarte;
            this.PretInchiriere = PretInchiriere;
            this.NrExemplare = NrExemplare;
        }

        public string iSBN
        {
            get { return ISBN; }
        }

        public double pretInchiriere
        {
            get { return PretInchiriere; }
            set { PretInchiriere = value; }
        }

        public string numeCarte
        {
            get { return NumeCarte; }
        }

        public int nrExemplare
        {
            get { return NrExemplare; }
            set { NrExemplare = value; }
        }

        public override string ToString()
        {
            return $"Cartea - {NumeCarte}, ISBN: {ISBN} are pretul de inchiriere: {PretInchiriere} lei." +
                $" Numar exemplare disponibile: {NrExemplare}." ;
        }

    }
}
