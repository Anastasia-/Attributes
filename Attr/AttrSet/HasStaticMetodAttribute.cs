using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Attr.AttrSet
{
    public enum TypeCompare { More, Less, Equal}

    [AttributeUsage(AttributeTargets.Class)]

    public class HasStaticMetodAttribute : VerifiableAttribute
    {
        public int num { get; set; }
        public TypeCompare typeCompare { get; set; }


        public override bool Verify<T>(T value)
        {
            bool result = false;
            int count = 0;
            MethodInfo[] minfs = value.GetType().GetMethods();
            foreach(MethodInfo minf in minfs)
            {
                if (minf.IsStatic) ++count;
            }

            

            switch (typeCompare)
            {
                case TypeCompare.Equal:
                    if (count.Equals(num)) result = true;
                    break;
                case TypeCompare.Less:
                    if (count < num) result = true;
                    break;
                case TypeCompare.More:
                    if (count > num) result = true;
                    break;
                default:
                    new Exception("Bad Type Comporator");
                    break;
            }

            //Console.Read();

            return result;
        }
    }
}
