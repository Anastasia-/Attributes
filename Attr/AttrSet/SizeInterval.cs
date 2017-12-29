using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attr.AttrSet
{
    public class SizeInterval : VerifiableAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override bool Verify<T>(T value)
        {
            if (value is IEnumerable)
            {
                var enumval = value as IEnumerable;
                
                return (Count(enumval) >= Min) && (Count(enumval) <= Max);
            }
            else
            {
                throw new Exception("Not Applicable");
            }
        }

        private static int Count(IEnumerable source)
        {
            int c = 0;
            var e = source.GetEnumerator();
                while (e.MoveNext())
                    c++;
            return c;
        }
    }
}
