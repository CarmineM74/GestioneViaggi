using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneViaggi.View
{
    public class ViewHelpers
    {
        public static string EvaluateValue(object obj, string property)
        {
            string prop = property;
            string ret = string.Empty;
            if (property.Contains("."))
            {
                prop = property.Substring(0, property.IndexOf("."));
                System.Reflection.PropertyInfo[] props = obj.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo propa in props)
                {
                    object obja = propa.GetValue(obj, new object[] { });
                    if (obja.GetType().Name.Contains(prop))
                    {
                        ret = EvaluateValue(obja, property.Substring(property.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(prop);
                ret = pi.GetValue(obj, new object[] { }).ToString();
            }
            return ret;
        }
    }
}
