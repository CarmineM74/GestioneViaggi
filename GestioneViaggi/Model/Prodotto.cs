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
    }

    [Table("Prodotto")]
    public class Prodotto : IProdotto
    {
        public long Id { get; set; }
        public String Descrizione { get; set; }
    }
}
