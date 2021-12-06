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
    public class UFPersistence : DAL, IUF
    {
        public Task Cadastrar(UF uf)
        {
            OpenConnection();

            Cmd = new SqlCommand("INSERT INTO ITR_UF VALUES(@SG_UF, @NM_UF)", Con);
            Cmd.Parameters.AddWithValue("@SG_UF", uf.sg_uf);
            Cmd.Parameters.AddWithValue("@NM_UF", uf.nm_uf.ToUpper());

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<UF> Listar()
        {
            OpenConnection();

            List<UF> lista = new List<UF>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM ITR_UF", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new UF()
                {
                    sg_uf = TratamentoNull.CheckNullFromDB<string>(Dr["SG_UF"]),
                    nm_uf = TratamentoNull.CheckNullFromDB<string>(Dr["NM_UF"])
                });
            }

            return lista;
        }

        public List<UF> ListarPorId(string id)
        {
            OpenConnection();

            List<UF> lista = new List<UF>();

            Cmd = new SqlCommand("SELECT * FROM ITR_UF WHERE SG_UF = @SG_UF", Con);
            Cmd.Parameters.AddWithValue("@SG_UF", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new UF()
                {
                    sg_uf = TratamentoNull.CheckNullFromDB<string>(Dr["SG_UF"]),
                    nm_uf = TratamentoNull.CheckNullFromDB<string>(Dr["NM_UF"])
                });
            }

            return lista;
        }
        public Task Deletar(string id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM ITR_UF WHERE SG_UF = @SG_UF", Con);
            Cmd.Parameters.AddWithValue("@SG_UF", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM ITR_UF WHERE SG_UF = @SG_UF", Con);
                Cmd.Parameters.AddWithValue("@SG_UF", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("UF não encontrada!");

            return Task.CompletedTask;
        }

        public Task Alterar(UF uf)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE ITR_UF SET NM_UF = @NOME WHERE SG_UF = @SG_UF", Con);
            Cmd.Parameters.AddWithValue("@SG_UF", uf.sg_uf);
            Cmd.Parameters.AddWithValue("@NOME", uf.nm_uf);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
