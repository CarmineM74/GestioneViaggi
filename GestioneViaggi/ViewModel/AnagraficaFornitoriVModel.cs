﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using System.Windows.Forms;

namespace GestioneViaggi.ViewModel
{
    public class AnagraficaFornitoriVModel : IVModel<Fornitore>
    {
        public List<Fornitore> items { get; set; }
        public Fornitore current { get; set; }
        public Boolean isSelected { get { return current != null; } }
    }
}
