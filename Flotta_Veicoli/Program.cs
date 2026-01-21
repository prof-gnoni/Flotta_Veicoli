using System;
using System.Collections.Generic; // Serve per passare i dati in una lista temporanea per il sort

namespace GestioneFlotta
{
    class Program
    {
        static void Main(string[] args)
        {
            // CAMBIAMENTO 1: Usiamo la KeyedCollection personalizzata
            FlottaCollection flotta = new FlottaCollection();

            // Dati di prova (Aggiornati con i cavalli)
            // Targa (chiave) viene gestita automaticamente dalla collezione
            flotta.Add(new Auto("TEST_01", "Fiat Panda", 15000, 850, 300, 4));
            flotta.Add(new Camion("TEST_02", "Iveco Daily", 50000, 4000, 180, 3.5));
            flotta.Add(new Auto("TEST_03", "Ferrari Roma", 5000, 1200, 620, 2));

            bool esci = false;

            while (!esci)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIONE FLOTTA (KeyedCollection + Comparable) ===");
                Console.WriteLine("1. Inserisci nuovo veicolo");
                Console.WriteLine("2. Visualizza report flotta (Ordinata per inserimento)");
                Console.WriteLine("3. Visualizza report flotta (Ordinata per POTENZA)"); // NUOVA OPZIONE
                Console.WriteLine("4. Cerca Veicolo per Targa"); // NUOVA OPZIONE (dimostra la potenza della KeyedCollection)
                Console.WriteLine("0. Esci");
                Console.Write("\nScegli un'opzione: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        InserisciVeicolo(flotta);
                        break;
                    case "2":
                        // Passiamo false per non ordinare
                        VisualizzaFlotta(flotta, false);
                        break;
                    case "3":
                        // Passiamo true per ordinare usando IComparable
                        VisualizzaFlotta(flotta, true);
                        break;
                    case "4":
                        CercaVeicolo(flotta);
                        break;
                    case "0":
                        esci = true;
                        break;
                    default:
                        break;
                }
            }
        }

        static void InserisciVeicolo(FlottaCollection collezione)
        {
            Console.Clear();
            Console.WriteLine("--- NUOVO INSERIMENTO ---");

            try
            {
                Console.Write("Inserisci Targa (Univoca): ");
                string targa = Console.ReadLine().ToUpper();

                // Controllo preventivo: KeyedCollection contiene già la chiave?
                if (collezione.Contains(targa))
                {
                    Console.WriteLine("ERRORE: Targa già presente in archivio!");
                    Console.ReadLine();
                    return;
                }

                Console.Write("Inserisci Marca: ");
                string marca = Console.ReadLine();

                Console.Write("Inserisci Km totali: ");
                double km = double.Parse(Console.ReadLine());

                Console.Write("Inserisci Litri consumati: ");
                double litri = double.Parse(Console.ReadLine());

                Console.Write("Inserisci Cavalli (CV): ");
                int cavalli = int.Parse(Console.ReadLine());

                Console.WriteLine("\nTipo veicolo: [A] Auto | [C] Camion");
                string tipo = Console.ReadLine().ToUpper();

                if (tipo == "A")
                {
                    Console.Write("Numero Posti: ");
                    int posti = int.Parse(Console.ReadLine());
                    // .Add() della KeyedCollection estrarrà la targa automaticamente
                    collezione.Add(new Auto(targa, marca, km, litri, cavalli, posti));
                }
                else if (tipo == "C")
                {
                    Console.Write("Capacità Carico (t): ");
                    double carico = double.Parse(Console.ReadLine());
                    collezione.Add(new Camion(targa, marca, km, litri, cavalli, carico));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                Console.ReadLine();
            }
        }

        static void VisualizzaFlotta(FlottaCollection collezione, bool ordinaPerPotenza)
        {
            Console.Clear();
            string titolo = ordinaPerPotenza ? "REPORT ORDINATO PER POTENZA (CV)" : "REPORT STANDARD (INSERIMENTO)";
            Console.WriteLine($"=== {titolo} ===");

            if (collezione.Count == 0)
            {
                Console.WriteLine("Nessun veicolo.");
                Console.ReadLine();
                return;
            }

            // PER ORDINARE UNA KEYEDCOLLECTION:
            // La KeyedCollection non ha un metodo Sort nativo perché mantiene l'ordine di inserimento.
            // Per ordinare, copiamo i riferimenti in una List<Veicolo> temporanea.
            List<Veicolo> listaTemp = new List<Veicolo>(collezione);

            if (ordinaPerPotenza)
            {
                // Qui viene chiamato automaticamente il metodo CompareTo definito in Veicolo
                listaTemp.Sort();
                Console.WriteLine("(Ordinamento effettuato tramite IComparable su proprietà 'Cavalli')\n");
            }

            foreach (Veicolo v in listaTemp)
            {
                Console.WriteLine(v.GetDettagliCompleti());
            }

            Console.WriteLine("\nPremi invio...");
            Console.ReadLine();
        }

        // Metodo extra per dimostrare l'utilità della KeyedCollection
        static void CercaVeicolo(FlottaCollection collezione)
        {
            Console.Clear();
            Console.Write("Inserisci targa da cercare: ");
            string targa = Console.ReadLine().ToUpper();

            // KeyedCollection permette accesso diretto con le parentesi quadre usando la chiave (stringa)
            // invece dell'indice numerico
            if (collezione.Contains(targa))
            {
                Veicolo trovato = collezione[targa]; // Accesso diretto O(1)
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nVEICOLO TROVATO:");
                Console.WriteLine(trovato.GetDettagliCompleti());
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Veicolo non trovato.");
            }
            Console.ReadLine();
        }
    }
}