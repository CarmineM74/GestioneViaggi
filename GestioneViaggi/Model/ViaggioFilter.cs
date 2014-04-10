using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneViaggi.Model
{
    public class ViaggioFilter
    {
        public String fornitore { get; set; }
        public Boolean fornitoreValid { get; set; }
        public String targa { get; set; }
        public Boolean targaValid { get; set; }
        public String conducente { get; set; }
        public Boolean conducenteValid { get; set; }
        public DateTime dal { get; set; }
        public DateTime al { get; set; }
        public Boolean dataEnabled { get; set; }
        public Boolean dataValid { get; set; }

        public ViaggioFilter()
        {
            fornitore = "";
            fornitoreValid = false;
            targa = "";
            targaValid = false;
            conducente = "";
            conducenteValid = false;
            dal = DateTime.Today;
            al = dal;
            dataEnabled = false;
            dataValid = false;
        }

        private void AddErrorMessage(Dictionary<String,List<String>> msgs, String key, String msg)
        {
            List<String> ms;
            if (!msgs.Keys.Contains(key))
                msgs.Add(key, new List<string>());
            ms = msgs[key];
            ms.Add(msg);
        }

        public void CheckValidity(Dictionary<String,List<String>> msgs)
        {
            //fornitoreValid = !String.IsNullOrWhiteSpace(fornitore) && (fornitore.Trim().Length >= 3);
            fornitoreValid = !String.IsNullOrWhiteSpace(fornitore);
            //if (!fornitoreValid)
            //    AddErrorMessage(msgs, "fornitore", "Lunghezza insufficiente");
            //targaValid = !String.IsNullOrWhiteSpace(targa) && (targa.Trim().Length >= 3);
            targaValid = !String.IsNullOrWhiteSpace(targa);
            //if (!targaValid)
            //    AddErrorMessage(msgs, "targa", "Lunghezza insufficiente");
            //conducenteValid = !String.IsNullOrWhiteSpace(conducente) && (conducente.Trim().Length >= 3);
            conducenteValid = !String.IsNullOrWhiteSpace(conducente);
            //if (!conducenteValid)
            //    AddErrorMessage(msgs, "conducente", "Lunghezza insufficiente");
            dataValid = al >= dal;
            if (!dataValid)
                AddErrorMessage(msgs, "data", "Intervallo date non corretto!");
        }
    }
}
