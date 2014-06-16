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
        Fornitore Fornitore { get; set; }
        String Descrizione { get; set; }
        DateTime ValidoDal { get; set; }
        DateTime ValidoAl { get; set; }
        Decimal Costo { get; set; }
    }

    [Table("Prodotto")]
    public class Prodotto : IProdotto
    {
        public long Id { get; set; }
        public long FornitoreId { get; set; }

        [Write(false)]
        public Fornitore Fornitore { get; set; }

        public String Descrizione { get; set; }
        public DateTime ValidoDal { get; set; }
        public DateTime ValidoAl { get; set; }
        public Decimal Costo { get; set; }

        public Prodotto()
        {
            ValidoDal = DateTime.Today;
            ValidoAl = DateTime.Today;
        }

        public Boolean isNew()
        {
            return (Id == 0);
        }

        public Prodotto Clone()
        {
            return new Prodotto
            {
                Id = this.Id,
                FornitoreId = this.FornitoreId,
                Descrizione = this.Descrizione,
                ValidoDal = this.ValidoDal,
                ValidoAl = this.ValidoAl,
                Costo = this.Costo
            };
        }
    }

}
