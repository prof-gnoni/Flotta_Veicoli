using System.Collections.ObjectModel;

namespace GestioneFlotta
{
    // Il primo parametro (string) è il tipo della chiave (Targa)
    // Il secondo parametro (Veicolo) è il tipo dell'oggetto memorizzato
    public class FlottaCollection : KeyedCollection<string, Veicolo>
    {
        // Questo metodo è obbligatorio: dice alla collezione QUALE proprietà usare come chiave
        protected override string GetKeyForItem(Veicolo item)
        {
            return item.Targa;
        }
    }
}