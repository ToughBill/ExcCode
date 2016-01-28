using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects
{
    public enum BO 
    {
        Invalid = -1,
        BP,
        Product

    }
    public class BOFactory
    {
        public static BusinessObject GetBO(BOIDEnum boid)
        {
            BusinessObject bo = null;
            switch (boid)
            {
                case BOIDEnum.Country:
                    bo = new BOCountry();
                    break;
                default: break;
            }

            return null;
        }
    }
}
