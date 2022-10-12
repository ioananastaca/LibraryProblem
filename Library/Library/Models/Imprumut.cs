using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    internal class Imprumut
    {
        private string NrTelefonCititor; //nr de telefon/id
        private string ISBN { get; set; }
        private DateTime DataImprumut { get; set; }
        private bool RestituireOverDate { get; set; }

        public Imprumut(string nrTelefonCititor, string iSBN, DateTime dataImprumut, bool restituireOverDate)
        {
            NrTelefonCititor = nrTelefonCititor;
            ISBN = iSBN;
            DataImprumut = dataImprumut;
            RestituireOverDate = restituireOverDate;
        }

        public Imprumut(string nrTelefonCititor, string iSBN, DateTime dataImprumut)
        {
            NrTelefonCititor = nrTelefonCititor;
            ISBN = iSBN;
            DataImprumut = dataImprumut;
        }

        public Imprumut()
        {

        }

        public override string ToString()
        {
            return $"ISBN carte: "+ ISBN +"\n"+"Numar telefon cititor: " + NrTelefonCititor +"\n"
                +"Data imprumut: " + DataImprumut+"\n -----------------------------\n";
        }
        public string nrTelefon
        {
            get { return NrTelefonCititor; }
            set { NrTelefonCititor = value; }
        }
        public string iSBN
        {
            get { return ISBN; }
            
        }

        public DateTime dataImprumut
        {
            get { return DataImprumut; }
            set { DataImprumut = value; }

        }
    }
}
