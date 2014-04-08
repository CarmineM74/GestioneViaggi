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
        Decimal Tariffa { get; set; }
    }

    [Table("Fornitore")]
    public class Fornitore : IFornitore
    {
        public long Id { get; set; }
        public String RagioneSociale { get; set; }
        public Decimal Tariffa { get; set; }

        public Fornitore Clone()
        {
            return new Fornitore
            {
                Id = this.Id,
                RagioneSociale = this.RagioneSociale,
                Tariffa = this.Tariffa
            };
        }

        public List<String> Errors;
        public Boolean isValid()
        {
            Errors = new List<string>();
            if (String.IsNullOrEmpty(this.RagioneSociale))
                Errors.Add("La ragione sociale è obbligatoria");
            Decimal res;
            if(!Decimal.TryParse(this.Tariffa.ToString(), out res)) {
                Errors.Add("La tariffa deve essere un campo decimale");
            } else {
                if (res < 0)
                    Errors.Add("La tariffa non può essere inferiore a 0");
            }
            return Errors.Count == 0;
        }
    }
}
