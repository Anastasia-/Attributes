using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Tests.TestsData
{
    class MultipleAttrFieldTestData
    {
        [Even]
        [SizeInterval(Max = 8, Min = 3)]
        public List<int> intlist;

        [SizeInterval(Max = 8, Min = 3)]
        [Mask(Mask="[0-3]")]
        public string str;

        public MultipleAttrFieldTestData(List<int> list, string str)
        {
            intlist = list;
            this.str = str;
        }
    }
}
