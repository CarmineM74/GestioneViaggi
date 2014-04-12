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
        long FornitoreId { get; set; }
        DateTime Data { get; set; }
        String TargaAutomezzo { get; set; }
        String Conducente { get; set; }

        Fornitore Fornitore { get; set; }
        List<RigaViaggio> Righe { get; set; }
    }

    [Table("Viaggio")]
    public class Viaggio : IViaggio
    {
        public long Id { get; set; }
        public long FornitoreId { get; set; }
        public DateTime Data { get; set; }
        public String TargaAutomezzo { get; set; }
        public String Conducente { get; set; }
        
        [Write(false)]
        public Fornitore Fornitore { get; set; }

        [Write(false)]
        public List<RigaViaggio> Righe { get; set; }

        public Viaggio()
        {
            this.Righe = new List<RigaViaggio>();
            this.Data = DateTime.Now;
        }

    }
}
