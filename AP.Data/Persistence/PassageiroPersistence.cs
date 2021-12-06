using AP.Data.Interface;
using AP.Data.Utiil;
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

        public List<Passageiro> Listar() {
            OpenConnection();

            List<Passageiro> lista = new List<Passageiro>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM ITR_PSGR", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Passageiro()
                {
                    cd_psgr = TratamentoNull.CheckNullFromDB<decimal>(Dr["CD_PSGR"]),
                    nm_psgr = TratamentoNull.CheckNullFromDB<string>(Dr["NM_PSGR"]),
                    ic_sexo_psgr = TratamentoNull.CheckNullFromDB<string>(Dr["IC_SEXO_PSGR"]),
                    dt_nasc_psgr = TratamentoNull.CheckNullFromDB<string>(Dr["DT_NASC_PSGR"]),
                    cd_pais = TratamentoNull.CheckNullFromDB<string>(Dr["CD_PAIS"]),
                    ic_estd_civil = TratamentoNull.CheckNullFromDB<string>(Dr["IC_ESTD_CIVIL"]),
                    cd_psgr_resp = TratamentoNull.CheckNullFromDB<decimal>(Dr["CD_PSGR_RESP"])
                });
            }

            return lista;
        }

        public List<Passageiro> ListarPorId(int id)
        {
            OpenConnection();

            List<Passageiro> lista = new List<Passageiro>();

            Cmd = new SqlCommand("SELECT * FROM ITR_PSGR WHERE CD_PSGR = @CD_PSGR", Con);
            Cmd.Parameters.AddWithValue("@CD_PSGR", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Passageiro()
                {
                    cd_psgr = TratamentoNull.CheckNullFromDB<decimal>(Dr["CD_PSGR"]),
                    nm_psgr = TratamentoNull.CheckNullFromDB<string>(Dr["NM_PSGR"]),
                    ic_sexo_psgr = TratamentoNull.CheckNullFromDB<string>(Dr["IC_SEXO_PSGR"]),
                    dt_nasc_psgr = TratamentoNull.CheckNullFromDB<string>(Dr["DT_NASC_PSGR"]),
                    cd_pais = TratamentoNull.CheckNullFromDB<string>(Dr["CD_PAIS"]),
                    ic_estd_civil = TratamentoNull.CheckNullFromDB<string>(Dr["IC_ESTD_CIVIL"]),
                    cd_psgr_resp = TratamentoNull.CheckNullFromDB<decimal>(Dr["CD_PSGR_RESP"])
                });
            }

            return lista;
        }
        public Task Deletar(decimal id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM ITR_PSGR WHERE CD_PSGR = @ID", Con);
            Cmd.Parameters.AddWithValue("@ID", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM ITR_PSGR WHERE CD_PSGR = @ID", Con);
                Cmd.Parameters.AddWithValue("@ID", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Passageiro não encontrado!");

            return Task.CompletedTask;
        }

        public Task Alterar(Passageiro p) 
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE ITR_PSGR SET NM_PSGR = @NOME, IC_SEXO_PSGR = @SEXO, DT_NASC_PSGR = @DT_NASC, CD_PAIS = @PAIS, IC_ESTD_CIVIL = @ESTD_CIVIL, CD_PSGR_RESP = @RESP WHERE CD_PSGR = @CODIGO", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", p.cd_psgr);
            Cmd.Parameters.AddWithValue("@NOME", p.nm_psgr);
            Cmd.Parameters.AddWithValue("@SEXO", p.ic_sexo_psgr);
            Cmd.Parameters.AddWithValue("@DT_NASC", p.dt_nasc_psgr);
            Cmd.Parameters.AddWithValue("@PAIS", p.cd_pais);
            Cmd.Parameters.AddWithValue("@ESTD_CIVIL", p.ic_estd_civil);
            if(p.cd_psgr_resp == 0)
                Cmd.Parameters.AddWithValue("@RESP", DBNull.Value);
            else
                Cmd.Parameters.AddWithValue("@RESP", p.cd_psgr_resp);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
