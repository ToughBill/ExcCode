using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    public class BOFactory
    {
        public static BusinessObject GetBO(string bo)
        {
            if (bo == "OBIN")
            {
                return new POOBIN();
            }
            else if (bo == "OWHS")
            {
                return new POOWHS();
            }

            return null;
        }
    }
}
