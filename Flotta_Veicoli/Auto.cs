using System;

namespace GestioneFlotta
{
    public class Auto : Veicolo
    {
        public int NumeroPosti { get; set; }

        public Auto(string targa, string marca, double km, double litri, int posti)
            : base(targa, marca, km, litri)
        {
            NumeroPosti = posti;
        }

        public override string GetDettagliCompleti()
        {
            // Chiama la base e aggiunge i posti
            return base.GetDettagliCompleti() + $" | Posti: {NumeroPosti}";
        }
    }
}