using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Tests.TestsData
{
    public class EvenFieldsTestData
    {
        [Even]
        public int EvenField;

        [Even]
        public List<int> EvenListField;

        public EvenFieldsTestData(int Field, List<int> ListField)
        {
            EvenField = Field;
            EvenListField = ListField;
        }
    }
}
