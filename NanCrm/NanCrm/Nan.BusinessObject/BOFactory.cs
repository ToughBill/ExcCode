using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nan.BusinessObjects.BO;

namespace Nan.BusinessObjects
{
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
            bo.Init();
            return bo;
        }
    }
}
