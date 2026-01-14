using System;

namespace GestioneFlotta
{
    public abstract class Veicolo
    {
        public string Targa { get; set; }
        public string Marca { get; set; }
        public double KmPercorsi { get; set; }
        public double LitriCarburanteConsumati { get; set; }

        public Veicolo(string targa, string marca, double km, double litri)
        {
            Targa = targa;
            Marca = marca;
            KmPercorsi = km;
            LitriCarburanteConsumati = litri;
        }

        public virtual double CalcolaKmPerLitro()
        {
            if (LitriCarburanteConsumati <= 0) return 0;
            return KmPercorsi / LitriCarburanteConsumati;
        }

        // Metodo virtuale: fornisce la stringa base, le figlie la completeranno
        public virtual string GetDettagliCompleti()
        {
            // PadRight serve ad allineare il testo per incolonnarlo bene
            return $"Targa: {Targa.PadRight(8)} | Marca: {Marca.PadRight(15)} | Km: {KmPercorsi:N0}";
        }
    }
}