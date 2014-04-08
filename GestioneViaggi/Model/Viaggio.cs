using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Contrib.Extensions;

namespace GestioneViaggi.Model
{
    public interface IViaggio
    {
        [Key]
        long Id { get; set; }
        long ClienteId { get; set; }
        long ProdottoId { get; set; }
        DateTime Data { get; set; }
        String TargaAutomezzo { get; set; }
        String Conducente { get; set; }
        Decimal Pesata { get; set; }
        int CaloPesoPercentuale { get; set; }

        Fornitore Cliente { get; set; }
        Prodotto Prodotto { get; set; }
    }

    [Table("Viaggio")]
    public class Viaggio : IViaggio
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public long ProdottoId { get; set; }
        public DateTime Data { get; set; }
        public String TargaAutomezzo { get; set; }
        public String Conducente { get; set; }
        public Decimal Pesata { get; set; }
        public int CaloPesoPercentuale { get; set; }
        
        [Write(false)]
        public Fornitore Cliente { get; set; }
        [Write(false)]
        public Prodotto Prodotto { get; set; }
    }
}
