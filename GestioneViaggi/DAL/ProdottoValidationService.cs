using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;

namespace GestioneViaggi.DAL
{
    public class ProdottoValidationService
    {
        public static List<String> Validate(Prodotto prodotto)
        {
            List<String> errors = new List<string>();
            if (prodotto.FornitoreId <= 0)
                errors.Add("Nessun fornitore specificato");
            if (String.IsNullOrEmpty(prodotto.Descrizione))
                errors.Add("La descrizione è obbligatoria");
            Decimal res;
            if (!Decimal.TryParse(prodotto.Costo.ToString(), out res))
            {
                errors.Add("Il costo deve essere un campo decimale");
            }
            else
            {
                if (res < 0)
                    errors.Add("Il costo non può essere inferiore a 0");
            }
            if (DateTime.Compare(prodotto.ValidoDal.Date, prodotto.ValidoAl.Date) > 0)
                errors.Add("Data inizio validità superiore a quella di fine");
            if (!hasCorrectDateValidity(prodotto))
                errors.Add("L'intervallo di validità specificato NON è valido perchè incluso in conflitto con altri intervalli");
            return errors;
        }

        private static Boolean hasCorrectDateValidity(Prodotto prodotto)
        {
            DateTime inizio, fine;
            inizio = prodotto.ValidoDal.Date;
            fine = prodotto.ValidoAl.Date;
            String sql = "Select * from Prodotto Where Descrizione='{0}' and fornitoreId={3} ";
            sql += "and ( (('{1}' <= ValidoDal) and ('{2}' between ValidoDal and ValidoAl)) ";
            sql += "or (('{1}' between ValidoDal and ValidoAl) and ('{2}' >= ValidoAl)) ";
            sql += "or (('{1}' between ValidoDal and ValidoAl) and ('{2}' between ValidoDal and ValidoAl)) )";
            sql = String.Format(sql, prodotto.Descrizione, inizio.ToString("yyyy-MM-dd"), fine.ToString("yyyy-MM-dd"),prodotto.FornitoreId);
            List<Prodotto> ps = Dal.connection.Query<Prodotto>(sql).ToList();
            return (ps.Count == 0);
        }

        public static Boolean isValid(Prodotto prodotto)
        {
            return (Validate(prodotto).Count == 0);
        }

        public static List<String> CanUpdate(Prodotto prodotto)
        {
            List<String> errors = new List<string>();
            if (prodotto.Id <= 0)
            {
                errors.Add("Prodotto nuovo, non è possibile aggiornarlo!");
            }
            else
            {
                if (isValid(prodotto))
                {
                    // Se esistono viaggi con questo prodotto
                    // - Non possiamo aggiornare:
                    //   - se abbiamo modificato il costo
                    //   - se abbiamo modificato la validità
                    if (ViaggiService.FindByProdotto(prodotto).Count > 0)
                    {
                        Prodotto tmp = Dal.connection.Get<Prodotto>(prodotto.Id);
                        if ((tmp.Costo != prodotto.Costo) || (DateTime.Compare(tmp.ValidoDal.Date, prodotto.ValidoDal.Date) != 0)) 
                            errors.Add("Il prodotto è stato utilizzato in almeno un viaggio, e si sta modificando il costo e/o la validità!");
                    }
                }
                else
                {
                    errors.AddRange(Validate(prodotto));
                }
            }
            return errors;
        }

        public static List<String> CanDelete(Prodotto prodotto)
        {
            List<String> errors = new List<string>();
            List<Viaggio> vs = ViaggiService.FindByProdotto(prodotto);
            if (vs.Count > 0)
                errors.Add(String.Format("Prodotto utilizzato in {0} un viaggi",vs.Count));
            return errors;
        }

        public static List<String> CanInsert(Prodotto prodotto)
        {
            List<String> errors = new List<string>();
            // Possiamo inserire se:
            // - Non esiste un prodotto con la stessa descrizione
            // - Oppure esiste ma la data validità è diversa
            List<Prodotto> ps = Dal.db.Prodotti.All().Where(p => p.Descrizione == prodotto.Descrizione).ToList();
            if (ps.Count > 0)
            {
                if (ps.Where(p => DateTime.Compare(p.ValidoDal.Date, prodotto.ValidoDal.Date) == 0).Count() > 0)
                    errors.Add("Prodotto già esistente!");
            }
            return errors;
        }
    }
}
