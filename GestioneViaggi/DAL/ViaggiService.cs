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
    public class ViaggiService
    {
        private static IEnumerable<Viaggio> AllBySql(String sql)
        {
            var vs = Dal.connection.QueryParentChild<Viaggio, RigaViaggio, long>(sql,
                viaggio => viaggio.Id,
                viaggio => viaggio.Righe,
                splitOn: "Id");
            return vs;
        }

        private static IEnumerable<Viaggio> RehidrateAllFields(IEnumerable<Viaggio> vs) 
        {
            Dictionary<long, Viaggio> viaggiLookup = vs.ToDictionary<Viaggio, long>(v => v.Id);
            List<long> viaggio_fornitore_map = vs.Select<Viaggio, long>(v => v.FornitoreId).ToList();
            List<long> viaggio_prodotti_map = vs.Select<Viaggio, List<long>>(v => v.Righe.Select<RigaViaggio, long>(r => (r == null) ? 0 : r.ProdottoId).ToList()).SelectMany(x => x).ToList();
            Dictionary<long, Prodotto> prodLookup = Dal.connection.Query<Prodotto>("select * from Prodotto where Id in @Ids", new { Ids = viaggio_prodotti_map.Select(p => p).Distinct() }).ToDictionary<Prodotto, long>(p => p.Id);
            Dictionary<long, Fornitore> fornLookup = Dal.connection.Query<Fornitore>("select * from Fornitore where Id in @Ids", new { Ids = viaggio_fornitore_map.Select(f => f).Distinct() }).ToDictionary<Fornitore, long>(f => f.Id);

            vs = vs.Select(v =>
            {
                Fornitore f;
                fornLookup.TryGetValue(v.FornitoreId, out f);
                v.Fornitore = f;
                v.Righe = v.Righe.Select(r =>
                {
                    Prodotto p;
                    if (r != null)
                    {
                        prodLookup.TryGetValue(r.ProdottoId, out p);
                        r.Prodotto = p;
                    }
                    return r;
                }).ToList();
                return v;
            });

            return vs;
        }

        public static List<Viaggio> All()
        {
            String sql = @"Select * from Viaggio left outer join RigaViaggio on Viaggio.Id = RigaViaggio.ViaggioId";
            var vs = AllBySql(sql);
            return RehidrateAllFields(vs).ToList();
        }

        public static List<Viaggio> FindByFornitore(Fornitore fornitore)
        {
            String sql = String.Format(@"Select * from viaggio left outer join RigaViaggio on Viaggio.Id = RigaViaggio.ViaggioId where FornitoreId={0}",fornitore.Id);
            return AllBySql(sql).ToList();
        }

        public static List<Viaggio> FindByProdotto(Prodotto prodotto)
        {
            String sql = String.Format(@"Select * from viaggio left outer join RigaViaggio on Viaggio.Id = RigaViaggio.ViaggioId where RigaViaggio.ProdottoId={0}", prodotto.Id);
            return AllBySql(sql).ToList();
        }

        public static List<String> Save(Viaggio viaggio) 
        {
            List<String> errori = new List<string>();
            int righe_salvate = 0;
            Boolean viaggio_salvato = false;
            Boolean aggiorna_riga = false;
            try
            {
                long id = (viaggio.Id == 0) ? 0 : viaggio.Id;
                if (id != 0)
                    Dal.connection.Update<Viaggio>(viaggio);
                else
                {
                    id = Dal.connection.Insert<Viaggio>(viaggio);
                    viaggio.Id = id;
                    viaggio_salvato = true;
                }
                foreach (RigaViaggio rv in viaggio.Righe)
                {
                    aggiorna_riga = rv.ViaggioId != 0;
                    rv.ViaggioId = id;
                    try
                    {
                        if (aggiorna_riga)
                            Dal.connection.Update<RigaViaggio>(rv);
                        else
                            rv.Id = Dal.connection.Insert<RigaViaggio>(rv);
                        righe_salvate += 1;
                    }
                    catch (Exception erv)
                    {
                        errori.Add(String.Format("Riga non salvata: {0} - {1} - {2} - {3} ({4})", rv.Prodotto.Descrizione, rv.Pesata, rv.Costo, rv.CaloPesoPercentuale, erv.Message));
                    }
                }
                if (righe_salvate == 0)
                    throw new Exception("Nessuna riga salvata");
            }
            catch (Exception ev)
            {
                if (viaggio_salvato)
                    Dal.connection.Delete<Viaggio>(viaggio);
                errori.Add(String.Format("Viaggio non salvato: {0} - {1} - {2} - {3} - {4} ({5})",viaggio.Id,viaggio.Data,viaggio.Fornitore.RagioneSociale,viaggio.Conducente,viaggio.TargaAutomezzo,ev.Message));
            }
            return errori;
        }
    }
}
