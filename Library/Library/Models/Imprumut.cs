using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    internal class Imprumut
    {
        private string NrTelefonCititor { get; set; } //nr de telefon/id
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

        public Imprumut()
        {

        }
    }
}
