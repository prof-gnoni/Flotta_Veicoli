using System;

namespace GestioneFlotta
{
    public class Auto : Veicolo
    {
        public int NumeroPosti { get; set; }

        // Aggiunto parametro 'int cavalli'
        public Auto(string targa, string marca, double km, double litri, int cavalli, int posti)
            : base(targa, marca, km, litri, cavalli)
        {
            NumeroPosti = posti;
        }

        public override string GetDettagliCompleti()
        {
            return base.GetDettagliCompleti() + $" | Posti: {NumeroPosti}";
        }
    }
}