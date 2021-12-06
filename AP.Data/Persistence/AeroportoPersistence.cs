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
    public class AeroportoPersistence : DAL, IAeroporto
    {
        public Task Cadastrar(Aeroporto a)
        {
            OpenConnection();

            Cmd = new SqlCommand("INSERT INTO ITR_ARPT VALUES(@CD_ARPT, @CD_PAIS, @SG_UF, @NM_CIDD)", Con);
            Cmd.Parameters.AddWithValue("@CD_ARPT", a.cd_arpt);
            Cmd.Parameters.AddWithValue("@CD_PAIS", a.cd_pais.ToUpper());
            Cmd.Parameters.AddWithValue("@SG_UF", a.sg_uf.ToUpper());
            Cmd.Parameters.AddWithValue("@NM_CIDD", a.nm_cidd.ToUpper());
            
            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Aeroporto> Listar()
        {
            OpenConnection();

            List<Aeroporto> lista = new List<Aeroporto>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM ITR_ARPT", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Aeroporto()
                {
                    cd_arpt = TratamentoNull.CheckNullFromDB<string>(Dr["CD_ARPT"]),
                    cd_pais = TratamentoNull.CheckNullFromDB<string>(Dr["CD_PAIS"]),
                    sg_uf = TratamentoNull.CheckNullFromDB<string>(Dr["SG_UF"]),
                    nm_cidd = TratamentoNull.CheckNullFromDB<string>(Dr["NM_CIDD"])                   
                });
            }

            return lista;
        }

        public List<Aeroporto> ListarPorId(string id)
        {
            OpenConnection();

            List<Aeroporto> lista = new List<Aeroporto>();

            Cmd = new SqlCommand("SELECT * FROM ITR_ARPT WHERE CD_ARPT = @CD_ARPT", Con);
            Cmd.Parameters.AddWithValue("@CD_ARPT", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Aeroporto()
                {
                    cd_arpt = TratamentoNull.CheckNullFromDB<string>(Dr["CD_ARPT"]),
                    cd_pais = TratamentoNull.CheckNullFromDB<string>(Dr["CD_PAIS"]),
                    sg_uf = TratamentoNull.CheckNullFromDB<string>(Dr["SG_UF"]),
                    nm_cidd = TratamentoNull.CheckNullFromDB<string>(Dr["NM_CIDD"])
                });
            }

            return lista;
        }
        public Task Deletar(string id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM ITR_ARPT WHERE CD_ARPT = @ID", Con);
            Cmd.Parameters.AddWithValue("@ID", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM ITR_ARPT WHERE CD_ARPT = @ID", Con);
                Cmd.Parameters.AddWithValue("@ID", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Aeroporto não encontrado!");

            return Task.CompletedTask;
        }

        public Task Alterar(Aeroporto a)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE ITR_ARPT SET CD_PAIS = @PAIS, SG_UF = @UF, NM_CIDD = @CIDADE WHERE CD_ARPT = @CODIGO", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", a.cd_arpt);
            Cmd.Parameters.AddWithValue("@PAIS", a.cd_pais);
            Cmd.Parameters.AddWithValue("@UF", a.sg_uf);
            Cmd.Parameters.AddWithValue("@CIDADE", a.nm_cidd);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
