using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attr.AttrSet
{
    public abstract class VerifiableAttribute : Attribute
    {
        public VerifiableAttribute() {}

        public abstract bool Verify<T>(T value);
    }
}
