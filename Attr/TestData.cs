
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Attr
{
    //[AttrSet.HasStaticMetod(num=3, typeCompare=AttrSet.TypeCompare.Equal)]
    class TestData
    {
 
        public string SomeValue { get; set; }


        public static int ReturnZero()
        {
            return 0;
        }

        public static int ReturnOne()
        {
            return 1;
        }

        public int SomeMetod()
        {
            return 14;
        }

        [HasAttrParam("Attr.AttrSet.EvenAttribute", 0)]
        public static int SM([Mask] int a, int b)
        {
            return a + b;
        }
    }
}
