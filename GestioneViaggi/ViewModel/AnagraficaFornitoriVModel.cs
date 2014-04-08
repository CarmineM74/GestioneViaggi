using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using System.Windows.Forms;

namespace GestioneViaggi.ViewModel
{
    public class AnagraficaFornitoriVModel
    {
        public List<Fornitore> Fornitori { get; set; }
        public Fornitore currentClient { get; set; }
        public Boolean isSelectedClient { get { return currentClient != null; } }
    }
}
