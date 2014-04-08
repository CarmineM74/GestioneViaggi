using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Contrib.Extensions;

namespace GestioneViaggi.Model
{
    public interface IProdotto
    {
        [Key]
        long Id { get; set; }
        String Descrizione { get; set; }
        Decimal Costo { get; set; }
    }

    [Table("Prodotto")]
    public class Prodotto : IProdotto
    {
        public long Id { get; set; }
        public String Descrizione { get; set; }
        public Decimal Costo { get; set; }

        public List<String> Errors;
        public Boolean isValid()
        {
            Errors = new List<string>();
            if (String.IsNullOrEmpty(this.Descrizione))
                Errors.Add("La descrizione è obbligatoria");
            Decimal res;
            if (!Decimal.TryParse(this.Costo.ToString(), out res))
            {
                Errors.Add("Il costo deve essere un campo decimale");
            }
            else
            {
                if (res < 0)
                    Errors.Add("Il costo non può essere inferiore a 0");
            }
            return Errors.Count == 0;
        }
    }

}
