using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Operators.Int_Extension
{
    internal static class Extension
    // When U Make Any Method in class => Extension Method
    // Must Class => Static + Non Generic
    // How To Make Extension Method:
    // Put in paramter this
    {
        // Method To Reverse Number:
        public static int Reverse_Integer(this int Number)
        {
            int reverse = 0, Remainder = 0;
            while (Number > 0)
            {
                Remainder = Number % 10;
                reverse = reverse * 10 + Remainder;
                Number /= 10;
            }
            return reverse;
        }
    }
}
