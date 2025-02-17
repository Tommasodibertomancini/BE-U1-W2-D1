using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_U1_W2_D1.Models
{
     class Menu
    {
        private Dictionary<int, (string, double)> portate = new Dictionary<int, (string, double)>()
        {
            {1, ("Coca Cola 150 ml", 2.50)},
            {2, ("Insalata di pollo", 5.20)},
            {3, ("Pizza Margherita", 10)},
            {4, ("Pizza 4 Formaggi", 12.50)},
            {5, ("Pz Patatine Fritte", 3.50)},
            {6, ("Insalata di Riso", 8)},
            {7, ("Frutta di Stagione", 5)},
            {8, ("Pizza Fritta", 5)},
            {9, ("Piadina Vegetariana", 6)},
            {10, ("Panino con Hamburger", 7.90)},
            
        };

        private List<(string, double)> ordine = new List<(string, double)>();

        public void MostraMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==============MENU==============");
                foreach (var portata in portate)
                {
                    Console.WriteLine($"{portata.Key} - {portata.Value.Item1} - {portata.Value.Item2}€");
                }
                Console.WriteLine("11: Stampa conto finale e conferma");
                Console.WriteLine("==============MENU==============");
                Console.Write("Seleziona un'opzione: ");

                if (int.TryParse(Console.ReadLine(), out int scelta))
                {
                    switch (scelta)
                    {
                        case 11:
                            StampaConto();
                            return;
                        case int n when (n >= 1 && n <= 10):
                            ordine.Add(portate[scelta]);
                            Console.WriteLine($"{portate[scelta].Item1} aggiunto all'ordine");
                            break;
                        default:
                            Console.WriteLine("Scelta non valida");
                            Console.WriteLine("Premi un tasto per tornare al menu");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Inserisci un numero valido!");
                    Console.WriteLine("Premi un tasto per tornare al menu");
                    Console.ReadKey();
                }
            }


        }

        private void StampaConto()
        {
            Console.Clear();
            if (ordine.Count == 0)
            {
                Console.WriteLine("Non hai ordinato nulla. Vuoi ordinare qualcosa?");
                Console.WriteLine("1: Torna al menu");
                Console.WriteLine("2: Esci");
                Console.Write("Seleziona un'opzione: ");
                if (int.TryParse(Console.ReadLine(), out int scelta))
                {
                    if (scelta == 1)
                    {
                        MostraMenu();
                        return;
                    }
                    else if (scelta == 2)
                    {
                        Console.WriteLine("Arrivederci! Premi un tasto per uscire.");
                        Console.ReadKey();
                        return;
                    }
                }
                Console.WriteLine("Scelta non valida. Prei un tasto per tornare al menu principale.");
                Console.ReadKey();
                MostraMenu();
                return;
            }

            Console.WriteLine("==============CONTO FINALE==============");
            double totale = 0;
            foreach (var portata in ordine)
            {
                Console.WriteLine($"{portata.Item1}: € {portata.Item2:F2}");
                totale += portata.Item2;
            }
            totale += 3.00;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Servizio al tavolo: € 3.00");
            Console.WriteLine($"TOTALE: € {totale:F2}");
            Console.WriteLine("========================================");
            Console.WriteLine("Grazie per aver ordinato. Arrivederci!");
            Console.WriteLine("Premi un tasto per uscire.");
            Console.ReadKey();
        }
    }
}



