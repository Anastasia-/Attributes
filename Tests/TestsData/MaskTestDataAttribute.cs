using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Tests.TestsData
{
    class MaskTestDataAttribute
    {
        [Mask(Mask="[1-2]")]
        string MaskField { get; set; }

        [Mask(Mask = "[1-5]")]
        List<string> MaskListField { get; set; }


        string NotMaskField = "safsdg";

        List<string> NotMaskListField = new List<string>() { "gdfg", "cbfdh" };

        public MaskTestDataAttribute(string Field, List<string> ListField)
        {
            MaskField = Field;
            MaskListField = ListField;
        }
    }
}

