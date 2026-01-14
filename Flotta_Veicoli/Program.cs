using System;
using System.Collections.Generic;
// using System.Linq;  <-- RIMOSSO: Non usiamo più questa libreria

namespace GestioneFlotta
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Veicolo> flotta = new List<Veicolo>();

            // Dati di prova
            flotta.Add(new Auto("TEST_01", "Fiat Panda", 15000, 850, 4));

            bool esci = false;

            while (!esci)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIONE FLOTTA (NO LINQ) ===");
                Console.WriteLine("1. Inserisci nuovo veicolo");
                Console.WriteLine("2. Visualizza report flotta");
                Console.WriteLine("0. Esci");
                Console.Write("\nScegli un'opzione: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        InserisciVeicolo(flotta);
                        break;
                    case "2":
                        VisualizzaFlotta(flotta);
                        break;
                    case "0":
                        esci = true;
                        Console.WriteLine("Chiusura in corso...");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opzione non valida. Premi invio.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void InserisciVeicolo(List<Veicolo> listaVeicoli)
        {
            Console.Clear();
            Console.WriteLine("--- NUOVO INSERIMENTO ---");

            try
            {
                Console.Write("Inserisci Targa: ");
                string targa = Console.ReadLine();

                Console.Write("Inserisci Marca: ");
                string marca = Console.ReadLine();

                Console.Write("Inserisci Km totali: ");
                double km = double.Parse(Console.ReadLine());

                Console.Write("Inserisci Litri consumati: ");
                double litri = double.Parse(Console.ReadLine());

                bool tipoValido = false;

                while (!tipoValido)
                {
                    Console.WriteLine("\nTipo veicolo: [A] Auto | [C] Camion");
                    Console.Write("Scelta: ");
                    string tipo = Console.ReadLine().ToUpper();

                    if (tipo == "A")
                    {
                        Console.Write("Numero Posti: ");
                        int posti = int.Parse(Console.ReadLine());
                        listaVeicoli.Add(new Auto(targa, marca, km, litri, posti));

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--> Auto aggiunta con successo!");
                        Console.ResetColor();
                        tipoValido = true;
                    }
                    else if (tipo == "C")
                    {
                        Console.Write("Capacità Carico (t): ");
                        double carico = double.Parse(Console.ReadLine());
                        listaVeicoli.Add(new Camion(targa, marca, km, litri, carico));

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--> Camion aggiunto con successo!");
                        Console.ResetColor();
                        tipoValido = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERRORE: Devi inserire 'A' oppure 'C'. Riprova.");
                        Console.ResetColor();
                    }
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERRORE GRAVE: Hai inserito del testo in un campo numerico.");
                Console.WriteLine("L'inserimento è stato annullato.");
                Console.ResetColor();
            }

            Console.WriteLine("\nPremi invio per tornare al menu...");
            Console.ReadLine();
        }

        // --- QUI C'È LA MODIFICA PRINCIPALE ---
        static void VisualizzaFlotta(List<Veicolo> listaVeicoli)
        {
            Console.Clear();
            Console.WriteLine("=== REPORT FLOTTA COMPLETO ===");

            if (listaVeicoli.Count == 0)
            {
                Console.WriteLine("Nessun veicolo in elenco.");
            }
            else
            {
                // 1. Inizializziamo l'accumulatore a zero prima del ciclo
                double sommaKm = 0;

                foreach (Veicolo v in listaVeicoli)
                {
                    // Stampa dettagli
                    Console.WriteLine(v.GetDettagliCompleti());
                    Console.WriteLine($"   -> Consumo: {v.CalcolaKmPerLitro():F2} km/l");
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - -");

                    // 2. Aggiungiamo i km del veicolo corrente al totale
                    // (Sostituisce la funzione .Sum() di LINQ)
                    sommaKm = sommaKm + v.KmPercorsi;
                }

                // 3. Stampiamo il risultato finale
                Console.WriteLine($"\nTotale Km percorsi dalla flotta: {sommaKm:N0}");
            }

            Console.WriteLine("\nPremi invio per tornare al menu...");
            Console.ReadLine();
        }
    }
}