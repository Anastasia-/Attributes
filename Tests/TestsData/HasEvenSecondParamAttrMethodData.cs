using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Tests.TestsData
{
    class HasEvenSecondParamAttrMethodData
    {
        [HasAttrParam("Attr.AttrSet.EvenAttribute",  1)]
        public static int method1([Even] int param1, int param2)
        {
            return param1 + param2;
        }
    }
}
