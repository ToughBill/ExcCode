using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;

namespace WindowsFormsApplication2
{
    public class POOBIN : BusinessObject
    {
        public override List<ValidValue> GetValieValue(string keyField, string descField)
        {
            List<ValidValue> ret = new List<ValidValue>();
            try
            {
                DataClasses2DataContext ctx = new DataClasses2DataContext();
                IQueryable ret2 = ctx.OBINs.Select("new (" + descField + "," + keyField + ")");
                foreach (var item in ret2)
                {
                    ValidValue vv = new ValidValue();
                    vv.Description = item.GetType().GetProperty(descField).GetValue(item, null).ToString();
                    vv.Value = item.GetType().GetProperty(keyField).GetValue(item, null).ToString();
                    ret.Add(vv);
                }
            }
            catch (System.Exception ex)
            {
                
            }

            return ret;
        }
    }
}
