using AP.Data.Interface;
using AP.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Persistence
{
    public class PassageiroPersistence : DAL, IPassageiro
    {
        public Task Cadastrar(Passageiro p) {

            OpenConnection();

            Cmd = new SqlCommand("SELECT MAX(CD_PSGR + 1) FROM ITR_PSGR", Con);
            int cd_ultimo = Convert.ToInt32(Cmd.ExecuteScalar());

            Cmd = new SqlCommand("INSERT INTO ITR_PSGR VALUES(@CD_PSGR, @NM_PSGR, @IC_SEXO_PSGR, @DT_NASC_PSGR, @CD_PAIS, @IC_ESTD_CIVIL, @CD_PSGR_RESP)", Con);
            Cmd.Parameters.AddWithValue("@CD_PSGR", cd_ultimo);
            Cmd.Parameters.AddWithValue("@NM_PSGR", p.nm_psgr.ToUpper());
            Cmd.Parameters.AddWithValue("@IC_SEXO_PSGR", p.ic_sexo_psgr.ToUpper());
            Cmd.Parameters.AddWithValue("@DT_NASC_PSGR", p.dt_nasc_psgr);
            Cmd.Parameters.AddWithValue("@CD_PAIS", p.cd_pais.ToUpper());
            Cmd.Parameters.AddWithValue("@IC_ESTD_CIVIL", p.ic_estd_civil.ToUpper());
            if(p.cd_psgr_resp == 0)
                Cmd.Parameters.AddWithValue("@CD_PSGR_RESP", DBNull.Value);
            else
                Cmd.Parameters.AddWithValue("@CD_PSGR_RESP", p.cd_psgr_resp);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
