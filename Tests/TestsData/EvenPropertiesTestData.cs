using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Tests.TestsData
{
    class EvenPropertiesTestData
    {
        [Even]
        public int EvenField { get; set; }
        
        [Even]
        public List<int> EvenListField { get; set; }

        public EvenPropertiesTestData(int Field, List<int> ListField)
        {
            EvenField = Field;
            EvenListField = ListField;
        }
    }
}
