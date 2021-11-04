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
            Con = new SqlConnection("Data Source=prd-sql-avantti.kxc.com.br;Initial Catalog=AEROPEDICA;Persist Security Info=True;User ID=prisma;Password=avanttisql;MultipleActiveResultSets=True;");
            Con.Open();
        }
    }
}
