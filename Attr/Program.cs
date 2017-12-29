using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Attr.AttrSet;

namespace Attr
{
    class Program
    {
        static void Main(string[] args)
        {


            /*bool res;
            var data = new TestData()
            {
                SomeValue = "dvf"
            };

            var prop = data.GetType().GetProperty(nameof(TestData.SomeValue));

            var prop1 = data.GetType().GetMethods();
           
            foreach (var attr in prop.GetCustomAttributes())
            {
                if (attr is VerifiableAttribute)
                {
                    var vAttr = attr as VerifiableAttribute;

                    Console.Write(vAttr.Verify(data.SomeValue));
                }
                
            }*/

            //Checker.CheckerClasses.Check(new TestData());

            Console.Write(Checker.CheckerMethods.Check(new TestData()));
            Console.Read();

        }
    }
}
