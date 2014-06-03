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
        long FornitoreId { get; set; }
        String Descrizione { get; set; }
        DateTime ValidoDal { get; set; }
        Decimal Costo { get; set; }
    }

    [Table("Prodotto")]
    public class Prodotto : IProdotto
    {
        public long Id { get; set; }
        public long FornitoreId { get; set; }
        public String Descrizione { get; set; }
        public DateTime ValidoDal { get; set; }
        public Decimal Costo { get; set; }

        public Prodotto Clone()
        {
            return new Prodotto
            {
                Id = this.Id,
                FornitoreId = this.FornitoreId,
                Descrizione = this.Descrizione,
                ValidoDal = this.ValidoDal,
                Costo = this.Costo
            };
        }

        public List<String> Errors;
        public Boolean isValid()
        {
            Errors = new List<string>();
            if (this.FornitoreId <= 0)
                Errors.Add("Nessun fornitore specificato");
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
