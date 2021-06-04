using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova6_AnnaMura
{
    class Agente : Persona
    {
        public string AreaGeografica { get; set; }
        public int InizioAttivita { get; set; }

        public Agente(string nome, string cognome, string codiceFiscale, string areaGeografica, int inizioAttivita)
            :base(nome, cognome, codiceFiscale)
        {
            AreaGeografica = areaGeografica;
            InizioAttivita = inizioAttivita;
        }

        

        public override void StampaAgente()
        {

             Console.WriteLine($"Nome: {Nome}- Cognome : {Cognome} - Anni di servizio: {2021 - InizioAttivita}");
        }
    }
}
