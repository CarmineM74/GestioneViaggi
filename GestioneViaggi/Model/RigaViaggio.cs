using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Contrib.Extensions;

namespace GestioneViaggi.Model
{
    public interface IRigaViaggio
    {
        [Key]
        long Id { get; set; }
        long ViaggioId { get; set; }
        long ProdottoId { get; set; }
        Decimal Pesata { get; set; }
        Decimal Costo { get; set; }

        Prodotto Prodotto { get; set; }
    }

    [Table("RigaViaggio")]
    public class RigaViaggio : IRigaViaggio
    {
        public long Id { get; set; }
        public long ViaggioId { get; set; }
        public long ProdottoId { get; set; }
        public Decimal Pesata { get; set; }
        public Decimal Costo { get; set; }
    
        [Write(false)]
        public Prodotto Prodotto { get; set; }

        public RigaViaggio()
        {
        }

        public RigaViaggio(Prodotto prodotto)
        {
            this.Prodotto = prodotto;
            this.ProdottoId = prodotto.Id;
        }

        public Boolean isNew()
        {
            return (Id == 0);
        }

    }
}
