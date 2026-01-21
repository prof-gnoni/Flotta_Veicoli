using System;

namespace GestioneFlotta
{
    public class Camion : Veicolo
    {
        public double CapacitaCaricoTonnellate { get; set; }

        // Aggiunto parametro 'int cavalli'
        public Camion(string targa, string marca, double km, double litri, int cavalli, double carico)
            : base(targa, marca, km, litri, cavalli)
        {
            CapacitaCaricoTonnellate = carico;
        }

        public override string GetDettagliCompleti()
        {
            return base.GetDettagliCompleti() + $" | Carico: {CapacitaCaricoTonnellate}t";
        }
    }
}