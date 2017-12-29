using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Attr.Checker
{
    public class CheckerMethods
    {
        public static bool Check(Object CheckObj)
        {
            bool result = true;
            var methods = CheckObj.GetType().GetMethods();
            foreach(MethodInfo minf in methods)
            {
                var attrs = minf.GetCustomAttributes();
                foreach(Attribute attr in attrs)
                {
                    if (attr is VerifiableAttribute)
                    {
                        var vAttr = attr as VerifiableAttribute;
                        result = result && vAttr.Verify(minf);
                    }
                }
            }
            return result;
        }
    }
}
