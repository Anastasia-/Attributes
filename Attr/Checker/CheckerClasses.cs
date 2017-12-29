using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Attr.AttrSet;

namespace Attr.Checker
{
    public class CheckerClasses : Checker
    {

        public static bool Check(Object CheckObj)
        {
            bool result = true;
            Type objType = CheckObj.GetType();
            var classAttr = objType.GetCustomAttributes();

            foreach(Attribute attr in classAttr)
            {
                if (attr is VerifiableAttribute)
                {
                    var vAttr = attr as VerifiableAttribute;
                    result = result && vAttr.Verify(objType.GetTypeInfo());
                }
            }
            return result;
         }

    }
}
