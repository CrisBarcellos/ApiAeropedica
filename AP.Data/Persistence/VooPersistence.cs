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
    public class VooPersistence : DAL, IVoo
    {
        public Task Cadastrar(Voo v)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT TOP 1 NR_VOO FROM ITR_VOO WHERE DT_SAIDA_VOO NOT IN (@DT_SAIDA_VOO)", Con);
            Cmd.Parameters.AddWithValue("@DT_SAIDA_VOO", Convert.ToDateTime(v.dt_saida_voo).ToString("yyyy/MM/dd"));
            int cd_voo = Convert.ToInt32(Cmd.ExecuteScalar());

            Cmd = new SqlCommand("INSERT INTO ITR_VOO VALUES(@NR_VOO, @DT_SAIDA_VOO, @NR_ROTA_VOO, @CD_ARNV)", Con);
            Cmd.Parameters.AddWithValue("@NR_VOO", cd_voo);
            Cmd.Parameters.AddWithValue("@DT_SAIDA_VOO", v.dt_saida_voo);
            Cmd.Parameters.AddWithValue("@NR_ROTA_VOO", v.nr_rota_voo);
            Cmd.Parameters.AddWithValue("@CD_ARNV", v.cd_arnv);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Voo> Listar()
        {
            OpenConnection();

            List<Voo> lista = new List<Voo>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM ITR_VOO", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Voo()
                {
                    nr_voo = TratamentoNull.CheckNullFromDB<decimal>(Dr["NR_VOO"]),
                    dt_saida_voo = Convert.ToDateTime(Dr["DT_SAIDA_VOO"]).ToString("dd/MM/yyyy"),
                    nr_rota_voo = TratamentoNull.CheckNullFromDB<decimal>(Dr["NR_ROTA_VOO"]),
                    cd_arnv = TratamentoNull.CheckNullFromDB<string>(Dr["CD_ARNV"])
                });
            }

            return lista;
        }

        public List<ListaVoo> ListarDetalhado()
        {
            OpenConnection();

            List<ListaVoo> lista = new List<ListaVoo>();

            string query = @"SELECT TOP 100 V.NR_VOO, ISNULL(V.DT_SAIDA_VOO, '') AS DT_SAIDA_VOO, UFO.NM_UF AS ORIGEM, UFD.NM_UF AS DESTINO, R.VR_PASG AS PRECO, AO.NM_CIDD AS AER_ORIGEM, AD.NM_CIDD AS AER_DESTINO
                           FROM ITR_ROTA_VOO R
                           LEFT JOIN ITR_VOO V ON(R.NR_ROTA_VOO = V.NR_ROTA_VOO)
                           LEFT JOIN ITR_ARPT AO ON(R.CD_ARPT_ORIG = AO.CD_ARPT) 
                           LEFT JOIN ITR_UF UFO ON (AO.SG_UF = UFO.SG_UF)
                           LEFT JOIN ITR_ARPT AD ON(R.CD_ARPT_DEST = AD.CD_ARPT) 
                           LEFT JOIN ITR_UF UFD ON (AD.SG_UF = UFD.SG_UF)";

            Cmd = new SqlCommand(query, Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new ListaVoo()
                {
                    nr_voo = TratamentoNull.CheckNullFromDB<decimal>(Dr["NR_VOO"]),
                    dt_saida = Convert.ToDateTime(Dr["DT_SAIDA_VOO"]).ToString("dd/MM/yyyy"),
                    cidade_origem = TratamentoNull.CheckNullFromDB<string>(Dr["ORIGEM"]),
                    cidade_destino = TratamentoNull.CheckNullFromDB<string>(Dr["DESTINO"]),
                    preco = TratamentoNull.CheckNullFromDB<decimal>(Dr["PRECO"]),
                    aer_origem = TratamentoNull.CheckNullFromDB<string>(Dr["AER_ORIGEM"]),
                    aer_destino = TratamentoNull.CheckNullFromDB<string>(Dr["AER_DESTINO"])
                });
            }

            return lista;
        }

        public List<Voo> ListarPorId(decimal nr_voo, string data)
        {
            OpenConnection();

            List<Voo> lista = new List<Voo>();

            Cmd = new SqlCommand("SELECT * FROM ITR_VOO WHERE NR_VOO = @VOO AND DT_SAIDA_VOO = @SAIDA", Con);
            Cmd.Parameters.AddWithValue("@VOO", nr_voo);
            Cmd.Parameters.AddWithValue("@SAIDA", Convert.ToDateTime(data).ToString("yyyy/MM/dd"));
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Voo()
                {
                    nr_voo = TratamentoNull.CheckNullFromDB<decimal>(Dr["NR_VOO"]),
                    dt_saida_voo = Convert.ToDateTime(Dr["DT_SAIDA_VOO"]).ToString("dd/MM/yyyy"),
                    nr_rota_voo = TratamentoNull.CheckNullFromDB<decimal>(Dr["NR_ROTA_VOO"]),
                    cd_arnv = TratamentoNull.CheckNullFromDB<string>(Dr["CD_ARNV"])
                });
            }

            return lista;
        }

        public List<ListaVoo> ListarPorCidade(string data, string origem, string destino)
        {
            OpenConnection();

            List<ListaVoo> lista = new List<ListaVoo>();

            string query = @"SELECT V.NR_VOO, V.DT_SAIDA_VOO, UFO.NM_UF AS ORIGEM, UFD.NM_UF AS DESTINO, R.VR_PASG AS PRECO, AO.NM_CIDD AS AER_ORIGEM, AD.NM_CIDD AS AER_DESTINO
                           FROM ITR_ROTA_VOO R
                           LEFT JOIN ITR_VOO V ON(R.NR_ROTA_VOO = V.NR_ROTA_VOO)
                           LEFT JOIN ITR_ARPT AO ON(R.CD_ARPT_ORIG = AO.CD_ARPT) 
                           LEFT JOIN ITR_UF UFO ON (AO.SG_UF = UFO.SG_UF)
                           LEFT JOIN ITR_ARPT AD ON(R.CD_ARPT_DEST = AD.CD_ARPT) 
                           LEFT JOIN ITR_UF UFD ON (AD.SG_UF = UFD.SG_UF)
                           WHERE V.DT_SAIDA_VOO = @DATA
                           AND UFO.SG_UF = @ORIGEM
                           AND UFD.SG_UF = @DESTINO";

            Cmd = new SqlCommand(query, Con);
            Cmd.Parameters.AddWithValue("@DATA", Convert.ToDateTime(data).ToString("yyyy/MM/dd"));
            Cmd.Parameters.AddWithValue("@ORIGEM", origem);
            Cmd.Parameters.AddWithValue("@DESTINO", destino);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new ListaVoo()
                {
                    nr_voo = TratamentoNull.CheckNullFromDB<decimal>(Dr["NR_VOO"]),
                    dt_saida = Convert.ToDateTime(Dr["DT_SAIDA_VOO"]).ToString("dd/MM/yyyy"),
                    cidade_origem = Dr["ORIGEM"].ToString(),
                    cidade_destino = Dr["DESTINO"].ToString(),
                    preco = Convert.ToDecimal(Dr["PRECO"]),
                    aer_origem = Dr["AER_ORIGEM"].ToString(),
                    aer_destino = Dr["AER_DESTINO"].ToString()
                });
            }

            return lista;
        }

        public Task Deletar(decimal nr_voo, string data)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM ITR_VOO WHERE NR_VOO = @VOO AND DT_SAIDA_VOO = @SAIDA", Con);
            Cmd.Parameters.AddWithValue("@VOO", nr_voo);
            Cmd.Parameters.AddWithValue("@SAIDA", Convert.ToDateTime(data).ToString("yyyy/MM/dd"));

            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM ITR_VOO WHERE NR_VOO = @VOO AND DT_SAIDA_VOO = @SAIDA", Con);
                Cmd.Parameters.AddWithValue("@VOO", nr_voo);
                Cmd.Parameters.AddWithValue("@SAIDA", Convert.ToDateTime(data).ToString("yyyy/MM/dd"));

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Voo não encontrado!");

            return Task.CompletedTask;
        }

        public Task Alterar(Voo v)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE ITR_VOO SET DT_SAIDA_VOO = @DATA, NR_ROTA_VOO = @ROTA, CD_ARNV = @AERONAVE WHERE NR_VOO = @CODIGO AND DT_SAIDA_VOO = @SAIDA", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", v.nr_voo);
            Cmd.Parameters.AddWithValue("@SAIDA", Convert.ToDateTime(v.dt_saida_voo).ToString("yyyy/MM/dd"));
            Cmd.Parameters.AddWithValue("@DATA", Convert.ToDateTime(v.dt_saida_voo).ToString("yyyy/MM/dd"));
            Cmd.Parameters.AddWithValue("@ROTA", v.nr_rota_voo);
            Cmd.Parameters.AddWithValue("@AERONAVE", v.cd_arnv);         

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
