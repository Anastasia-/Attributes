using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Attr.Checker
{
    public class CheckerProperties : Checker
    {

        public static bool Check(Object CheckObj)
        {
            bool result = true;
            var props = CheckObj.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                foreach(Attribute attr in prop.GetCustomAttributes())
                {
                    if (attr is VerifiableAttribute)
                    {
                        var vAttr = attr as VerifiableAttribute;
                         result = result && vAttr.Verify(prop.GetValue(CheckObj));
                    }
                }
            }

            return result;
        }
    }
}
