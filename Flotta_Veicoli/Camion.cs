using System;

namespace GestioneFlotta
{
    public class Camion : Veicolo
    {
        public double CapacitaCaricoTonnellate { get; set; }

        public Camion(string targa, string marca, double km, double litri, double carico)
            : base(targa, marca, km, litri)
        {
            CapacitaCaricoTonnellate = carico;
        }

        public override string GetDettagliCompleti()
        {
            // Chiama la base e aggiunge il carico
            return base.GetDettagliCompleti() + $" | Carico: {CapacitaCaricoTonnellate}t";
        }
    }
}