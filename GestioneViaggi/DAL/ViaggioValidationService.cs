using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;

namespace GestioneViaggi.DAL
{
    public class ViaggioValidationService
    {
        public static List<String> Validate(Viaggio viaggio)
        {
            List<String> errors = new List<string>();
            if (viaggio.FornitoreId <= 0)
                errors.Add("Nessun fornitore specificato");
            Decimal res;
            if (!Decimal.TryParse(viaggio.CaloPeso.ToString(), out res))
            {
                errors.Add("Il calo peso deve essere un campo decimale");
            }
            else
            {
                if (res < 0)
                    errors.Add("Il calo peso non può essere inferiore a 0");
            }
            if (viaggio.Righe.Where(r => DateTime.Compare(viaggio.Data.Date, r.Prodotto.ValidoDal.Date) < 0).Count() > 0)
                errors.Add("La data specificata per il viaggio non è valida, perchè in conflitto con uno o più prodotti");
            return errors;
        }

        public static Boolean isValid(Viaggio viaggio)
        {
            return (Validate(viaggio).Count == 0);
        }

    }
}
