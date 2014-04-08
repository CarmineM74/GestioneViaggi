using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using GestioneViaggi.Model;

namespace GestioneViaggi.DAL
{
    public class Db: Database<Db>
    {
        public Table<Cliente> Clienti { get; set; }
        public Table<Prodotto> Prodotti { get; set; }
        public Table<Viaggio> Viaggi { get; set; }
    }
}
