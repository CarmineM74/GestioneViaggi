using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;

namespace GestioneViaggi.ViewModel
{
    public class ElencoViaggiVModel : IVModel<Viaggio>
    {
        public List<Viaggio> items { get; set; }
        public Viaggio current { get; set; }
        public Boolean isSelected { get { return current != null; } }
    }
}
