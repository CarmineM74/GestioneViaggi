using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;
using System.Windows.Forms;

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
            if (!fornitore.isNew())
                Dal.connection.Update<Fornitore>(fornitore);
            else
                fornitore.Id = Dal.connection.Insert<Fornitore>(fornitore);
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

        internal static void SaveProduct(Prodotto prodotto)
        {
            if (prodotto.isNew())
            {
                prodotto.Id = Dal.connection.Insert<Prodotto>(prodotto);
            }
            else
            {
                Dal.connection.Update<Prodotto>(prodotto);
            }
        }

        internal static List<Prodotto> ListinoValidoPerFornitore(Fornitore fornitore,DateTime validita)
        {
            if (fornitore == null)
                return new List<Prodotto>();
            String sql = "Select * from Prodotto where FornitoreId={0} ";
            sql += "and ValidoDal <= DateTime('{1}') ";
            sql += "and ValidoAl >= DateTime('{1}')";
            sql = String.Format(sql, fornitore.Id, validita.ToString("yyyy-MM-dd"));
            //MessageBox.Show(sql);
            return Dal.connection.Query<Prodotto>(sql).ToList();
        }
    }
}
