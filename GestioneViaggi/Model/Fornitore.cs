using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Contrib.Extensions;

namespace GestioneViaggi.Model
{
    public interface IFornitore
    {
        [Key]
        long Id { get; set; }
        String RagioneSociale { get; set; }
        List<Prodotto> Listino { get; set; }
    }

    [Table("Fornitore")]
    public class Fornitore : IFornitore
    {
        public long Id { get; set; }
        public String RagioneSociale { get; set; }
        
        [Write(false)]
        public List<Prodotto> Listino { get; set; }

        public Fornitore()
        {
            this.Listino = new List<Prodotto>();
        }

        public Fornitore Clone()
        {
            return new Fornitore
            {
                Id = this.Id,
                RagioneSociale = this.RagioneSociale,
                Listino = this.Listino.ToList()
            };
        }

        public List<String> Errors;
        public Boolean isValid()
        {
            Errors = new List<string>();
            if (String.IsNullOrEmpty(this.RagioneSociale))
                Errors.Add("La ragione sociale è obbligatoria");
            return Errors.Count == 0;
        }
    }
}
