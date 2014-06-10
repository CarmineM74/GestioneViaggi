using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;

namespace GestioneViaggi.DAL
{
    public class FornitoreService
    {
        private static IEnumerable<Fornitore> AllBySql(String sql)
        {
            var vs = Dal.connection.QueryParentChild<Fornitore, Prodotto, long>(sql,
                fornitore => fornitore.Id,
                fornitore => fornitore.Listino,
                splitOn: "Id");
            return vs;
        }

        private static IEnumerable<Fornitore> RehidrateAllFields(IEnumerable<Fornitore> fs)
        {
            Dictionary<long, Fornitore> fornitoriLookup = fs.ToDictionary<Fornitore, long>(v => v.Id);
            fs = fs.Select(f =>
            {
                f.Listino = f.Listino.Select(p =>
                {
                    Fornitore f1;
                    if (p != null)
                    {
                        fornitoriLookup.TryGetValue(p.FornitoreId, out f1);
                        p.Fornitore = f1;
                    }
                    return p;
                }).ToList();
                return f;
            });
            return fs;
        }

        public static List<Fornitore> All()
        {
            String sql = @"Select * from Fornitore left outer join Prodotto on Fornitore.Id = Prodotto.FornitoreId";
            var vs = AllBySql(sql);
            return RehidrateAllFields(vs).ToList();
        }

        public static void Save(Fornitore fornitore)
        {
            long id = (fornitore.Id == 0) ? 0 : fornitore.Id;
            if (id != 0)
                Dal.connection.Update<Fornitore>(fornitore);
            else
            {
                id = Dal.connection.Insert<Fornitore>(fornitore);
                fornitore.Id = id;
            }
        }

        public static void Delete(Fornitore fornitore)
        {
            Dal.connection.Execute(@"delete from Prodotto where Prodotto.FornitoreId = @Id", new { Id = fornitore.Id });
            Dal.connection.Delete(fornitore);
        }

        internal static void DeleteProduct(Prodotto prodotto)
        {
            Dal.connection.Delete(prodotto);
        }

        internal static List<String> SaveProduct(Prodotto prodotto)
        {
            List<String> errori = new List<string>();
            if (prodotto.isValid())
            {
                try
                {
                    long id = (prodotto.Id == 0) ? 0 : prodotto.Id;
                    if (id != 0)
                    {
                        // Se esistono viaggi con questo prodotto
                        // - Non possiamo aggiornare:
                        //   - se abbiamo modificato il costo
                        //   - se abbiamo modificato la validità
                        if (ViaggiService.FindByProdotto(prodotto).Count > 0)
                        {
                            Prodotto tmp = Dal.connection.Get<Prodotto>(prodotto.Id);
                            if ((tmp.Costo != prodotto.Costo) || (DateTime.Compare(tmp.ValidoDal.Date, prodotto.ValidoDal.Date) != 0))
                                errori.Add("Il prodotto è stato utilizzato in almeno un viaggio, e si sta modificando il costo e/o la validità!");
                        }
                        Dal.connection.Update<Prodotto>(prodotto);
                    }
                    else
                    {
                        id = Dal.connection.Insert<Prodotto>(prodotto);
                        prodotto.Id = id;
                    }
                }
                catch (Exception ev)
                {
                    errori.Add(String.Format("Prodotto non salvato: {0} - {1} - {2} ({3})", prodotto.Descrizione, prodotto.ValidoDal.ToString(),prodotto.Costo, ev.Message));
                }
            }
            else
            {
                errori.AddRange(prodotto.Errors);
            }
            return errori;
        }
    }
}
