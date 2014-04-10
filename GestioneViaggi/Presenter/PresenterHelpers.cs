using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneViaggi.Presenter
{
    public delegate void NotifyMessagesDelegate(List<String> messages);
    public delegate void NotifyMessagesMapDelegate(Dictionary<String,List<String>> messages);
}
