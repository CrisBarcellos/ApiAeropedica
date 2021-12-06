using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Utiil
{
    public class TratamentoNull
    {
        // Do BD para o C#
        public static T CheckNullFromDB<T>(object param)
        {
            if (param == DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)param;
            }
        }

        // Do C# para BD
        public static object CheckNullToDB<T>(T param)
        {
            if (param == null)
            {
                return DBNull.Value;
            }
            else
            {
                return param;
            }
        }
    }
}
