using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Attr.Checker
{
    public class CheckerFields : Checker
    {
        public static bool Check(Object CheckObj)
        {
            bool result = true;
            var fields = CheckObj.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                foreach (Attribute attr in field.GetCustomAttributes())
                {
                    if (attr is VerifiableAttribute)
                    {
                        var vAttr = attr as VerifiableAttribute;
                        result = result && vAttr.Verify(field.GetValue(CheckObj));
                    }
                }
            }

            return result;
        }
    }
}
