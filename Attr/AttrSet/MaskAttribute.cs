using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Attr.AttrSet
{
    public class MaskAttribute : VerifiableAttribute
    {
        public string Mask { get; set; }

        public override bool Verify<T>(T value)
        {
            Console.WriteLine("Mask is" + Mask);
            if (value is string)
            {
                var stringval = value as string;
                string Maskval = "@" + "\"" + Mask + "\"";

                Regex regex = new Regex(Mask);
                Console.WriteLine("StringVal is " + stringval);
                Console.WriteLine("regex.IsMatch(stringval)" + regex.IsMatch(stringval));
                if (regex.IsMatch(stringval))
                {

                    return true;
                } else { return false; }
                    
                //throw new Exception("Not conform to the mask");
                
            } else if (value is List<string>)
            {
                var strlist = value as List<string>;
                Regex regex = new Regex(Mask);
                foreach (string elem in strlist)
                {
                    if (!regex.IsMatch(elem))
                    {
                        return false;
                        //throw new Exception("Not all elements conform to the mask"); 
                    }

                }
                return true;
            }
            else
            {
                throw new Exception("Not Applicable");
            }
        }
    }
}
