using System;

namespace GestioneFlotta
{
    // Aggiungiamo l'interfaccia IComparable<Veicolo>
    public abstract class Veicolo : IComparable<Veicolo>
    {
        public string Targa { get; set; }
        public string Marca { get; set; }
        public double KmPercorsi { get; set; }
        public double LitriCarburanteConsumati { get; set; }

        // NUOVA PROPRIETÀ
        public int Cavalli { get; set; }

        public Veicolo(string targa, string marca, double km, double litri, int cavalli)
        {
            Targa = targa;
            Marca = marca;
            KmPercorsi = km;
            LitriCarburanteConsumati = litri;
            Cavalli = cavalli;
        }

        public virtual double CalcolaKmPerLitro()
        {
            if (LitriCarburanteConsumati <= 0) return 0;
            return KmPercorsi / LitriCarburanteConsumati;
        }

        public virtual string GetDettagliCompleti()
        {
            // Aggiungo i cavalli alla stringa base
            return $"Targa: {Targa,-8} | Marca: {Marca,-15} | CV: {Cavalli.ToString(),-4} | Km: {KmPercorsi,8:N0}";
        }

        // IMPLEMENTAZIONE DI ICOMPARABLE
        // Permette di ordinare una lista di veicoli automaticamente (es. con .Sort())
        public int CompareTo(Veicolo other)
        {
            if (other == null) return 1;

            // Confronto basato sui Cavalli (dal più piccolo al più grande)
            //return this.Cavalli.CompareTo(other.Cavalli);

            if(this.Cavalli < other.Cavalli)
                return -1;
            else if(this.Cavalli > other.Cavalli)
                return 1;
            else
                return 0;


            // Se volessi ordinare per Km, userei:
            // return this.KmPercorsi.CompareTo(other.KmPercorsi);
        }
    }
}