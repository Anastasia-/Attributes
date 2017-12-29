using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attr.AttrSet
{
    public class EvenAttribute : VerifiableAttribute
    {
        public override bool Verify<T>(T value)
        {
            if (value is int)
            {
                var intvalue = (value as int?).Value;
                if (intvalue % 2 != 0)
                {
                    //throw new Exception("Not Even");
                    return false;
                }
                return true;
            } else if (value is List<int>)
            {
                var listval = value as List<int>;
                foreach(int elem in listval)
                {
                    if (elem % 2 != 0)
                    {
                        //throw new Exception("Not Even");
                        return false;
                    }
                }
                return true;
            } else
            {
                throw new Exception("Not Applicable");
            }
        }
    }
}
