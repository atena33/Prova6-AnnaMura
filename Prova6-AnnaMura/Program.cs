using System;

namespace Prova6_AnnaMura
{
    class Program
    {
        //Risposte
        //Risposta 1: a, e, g, h;
        //Risposta 2: b, d;
        //Risposta 3: c, d;
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Fai la tua scelta");
                Console.WriteLine("1. Mostra tutti gli agenti");
                Console.WriteLine("2. Mostra gli agenti per area geografica");
                Console.WriteLine("3. Mosta gli agenti per anni di servizio");
                Console.WriteLine("4. Inserisci un nuovo agente");
                Console.WriteLine("0. Esci");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        GestoreAgenti.ShowAgenti();
                        break;
                    case "2":
                        GestoreAgenti.ShowAgentiPerArea();
                        break;
                    case "3":
                        GestoreAgenti.ShowAgentiPerAnni();
                        break;
                    case "4":
                        GestoreAgenti.InserisciAgente();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Scelta errata");

                        break;
                }






            } while (true);
        }
    }
}
