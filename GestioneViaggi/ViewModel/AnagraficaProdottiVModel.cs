using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;

namespace GestioneViaggi.ViewModel
{
    public class AnagraficaProdottiVModel : IVModel<Prodotto>
    {
        public List<Prodotto> items { get; set; }
        public Prodotto current { get; set; }
        public Boolean isSelected { get { return current != null; } }
    }
}
