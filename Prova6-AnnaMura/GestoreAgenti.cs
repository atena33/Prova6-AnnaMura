using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova6_AnnaMura
{
    static class GestoreAgenti
    {
        public static void ShowAgenti()
        {
            List<Agente> agenti = DbConnectedManager.GetAgenti();

            foreach (var item in agenti)
            {
                item.StampaAgente();
            }
        }

        public static void ShowAgentiPerArea()
        {
            Console.WriteLine("Inserisci un'area geogeafica");
            var areaGeografica = Console.ReadLine();
            List<Agente> agenti = DbConnectedManager.GetAgentiArea(areaGeografica);

            foreach (var item in agenti)
            {
                if (item.AreaGeografica.Contains(areaGeografica) )
                {
                    item.StampaAgente();

                }
                else
                {
                    Console.WriteLine("Nessun agente presente in quell'area");
                }
            }
        }

        public static void ShowAgentiPerAnni()
        {
            Console.WriteLine("Inserisci un numero di anni");
            var anni = int.Parse(Console.ReadLine());
            List<Agente> agenti = DbConnectedManager.GetAgentiAnni(anni);

            foreach (var item in agenti)
            {
                if (item.InizioAttivita >= anni)
                {
                    item.StampaAgente();

                }
                
             }
        }

        public static void InserisciAgente()
        {
            Console.WriteLine("Inserisci il codice fiscale dell'agente");
            var cf = Console.ReadLine();
            var isPresent = DbConnectedManager.VerificaEsistenzaAgente(cf);
            if (isPresent)
            {
                Console.WriteLine("Agente già esistente");
            }
            else
            {
                Console.WriteLine("Inserisci nome");
                var nome = Console.ReadLine();
                Console.WriteLine("Inserisci cognome");
                var cognome = Console.ReadLine();
                Console.WriteLine("Inserisci area geografica");
                var area = Console.ReadLine();
                Console.WriteLine("Inserisci anno inizio attività");
                var anno = int.Parse(Console.ReadLine());

                Agente agente = new Agente (nome, cognome, cf, area, anno);

                DbConnectedManager.AddAgente(agente);

                Console.WriteLine("Agente aggiunto con successo");
            }
        }
    }
}
