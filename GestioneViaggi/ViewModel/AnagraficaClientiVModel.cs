using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using System.Windows.Forms;

namespace GestioneViaggi.ViewModel
{
    public class AnagraficaClientiVModel
    {
        public List<Cliente> Clienti { get; set; }
        public Cliente currentClient { get; set; }
        public Boolean isSelectedClient { get { return currentClient != null; } }
    }
}
