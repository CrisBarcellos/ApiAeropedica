using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data
{
    public class DAL
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;
        protected SqlTransaction Tr;
        protected void OpenConnection()
        {   
            Con = new SqlConnection("Data Source=34.151.197.105;Initial Catalog=AEROPEDICA;Persist Security Info=True;User ID=sqlserver;Password=270298cm");
            Con.Open();
        }
    }
}
