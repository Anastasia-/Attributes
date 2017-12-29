using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Tests.TestsData
{
    [HasStaticMetod(num = 4, typeCompare = TypeCompare.Equal)]
    public class EqualFalseStaticMethodClassTestData
    {
        public int val { get; set; }

        public static int ReturnZero()
        {
            return 0;
        }

        public static int ReturnOne()
        {
            return 1;
        }

        public static int ReturnTwo()
        {
            return 3;
        }

        public int ReturnSumOne()
        {
            return val + 1;
        }

        public int ReturnSumTwo()
        {
            return val + 2;
        }
    }
}
