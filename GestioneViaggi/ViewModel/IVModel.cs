using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneViaggi.ViewModel
{
    public interface IVModel<T>
    {
        List<T> items { get; set; }
        T current { get; set; }
        Boolean isSelected { get; }
    }
}
