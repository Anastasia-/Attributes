using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Attr.AttrSet
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HasAttrParamAttribute : VerifiableAttribute
    {
        public string attr { get; set; }
        public int paramnum { get; set; }
        public HasAttrParamAttribute(string attr, int paramnum)
        {
            this.attr = attr;
            this.paramnum = paramnum;
        }

        public override bool Verify<T>(T value)
        {
            bool result = false;
            if(value is MethodInfo)
            {
                MethodInfo minf = value as MethodInfo;
                ParameterInfo[] paramsinf = minf.GetParameters();
                if (paramnum >= paramsinf.Length)
                {
                    throw new Exception("Incorrect parameter number");
                }

                ParameterInfo pinf = paramsinf[paramnum];
                var attrs = pinf.GetCustomAttributes();

                foreach(Attribute attrib in attrs)
                {                   
                    if (Equals(attrib.GetType().ToString(), attr))
                    {
                        result = true;
                    }
                }
                return result;
            } else
            {
                throw new Exception("Not Applicable");
            }

        }
    }
}
