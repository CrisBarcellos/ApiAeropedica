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
    public class RotaPersistence : DAL, IRota
    {
        public Task Cadastrar(Rota r)
        {

            OpenConnection();

            Cmd = new SqlCommand("SELECT MAX(NR_ROTA_VOO + 1) FROM ITR_ROTA_VOO", Con);
            int cd_ultimo = Convert.ToInt32(Cmd.ExecuteScalar());

            Cmd = new SqlCommand("INSERT INTO ITR_ROTA_VOO VALUES(@NR_ROTA_VOO, @CD_ARPT_ORIG, @CD_ARPT_DEST, @VR_PASG)", Con);
            Cmd.Parameters.AddWithValue("@NR_ROTA_VOO", cd_ultimo);
            Cmd.Parameters.AddWithValue("@CD_ARPT_ORIG", r.cd_arpt_orig.ToUpper());
            Cmd.Parameters.AddWithValue("@CD_ARPT_DEST", r.cd_arpt_dest.ToUpper());
            Cmd.Parameters.AddWithValue("@VR_PASG", r.vr_pasg);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Rota> Listar()
        {
            OpenConnection();

            List<Rota> lista = new List<Rota>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM ITR_ROTA_VOO", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Rota()
                {
                    nr_rota_voo = TratamentoNull.CheckNullFromDB<decimal>(Dr["NR_ROTA_VOO"]),
                    cd_arpt_orig = TratamentoNull.CheckNullFromDB<string>(Dr["CD_ARPT_ORIG"]),
                    cd_arpt_dest = TratamentoNull.CheckNullFromDB<string>(Dr["CD_ARPT_DEST"]),
                    vr_pasg = TratamentoNull.CheckNullFromDB<decimal>(Dr["VR_PASG"])         
                });
            }

            return lista;
        }

        public List<Rota> ListarPorId(int id)
        {
            OpenConnection();

            List<Rota> lista = new List<Rota>();

            Cmd = new SqlCommand("SELECT * FROM ITR_ROTA_VOO WHERE NR_ROTA_VOO = @NR_ROTA_VOO", Con);
            Cmd.Parameters.AddWithValue("@NR_ROTA_VOO", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Rota()
                {
                    nr_rota_voo = TratamentoNull.CheckNullFromDB<decimal>(Dr["NR_ROTA_VOO"]),
                    cd_arpt_orig = TratamentoNull.CheckNullFromDB<string>(Dr["CD_ARPT_ORIG"]),
                    cd_arpt_dest = TratamentoNull.CheckNullFromDB<string>(Dr["CD_ARPT_DEST"]),
                    vr_pasg = TratamentoNull.CheckNullFromDB<decimal>(Dr["VR_PASG"])
                });
            }

            return lista;
        }
        public Task Deletar(decimal id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM ITR_ROTA_VOO WHERE NR_ROTA_VOO = @NR_ROTA_VOO", Con);
            Cmd.Parameters.AddWithValue("@NR_ROTA_VOO", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM ITR_ROTA_VOO WHERE NR_ROTA_VOO = @NR_ROTA_VOO", Con);
                Cmd.Parameters.AddWithValue("@NR_ROTA_VOO", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Rota não encontrada!");

            return Task.CompletedTask;
        }

        public Task Alterar(Rota r)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE ITR_ROTA_VOO SET CD_ARPT_ORIG = @AER_ORIG, CD_ARPT_DEST = @AER_DEST, VR_PASG = @VALOR WHERE NR_ROTA_VOO = @CODIGO", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", r.nr_rota_voo);
            Cmd.Parameters.AddWithValue("@AER_ORIG", r.cd_arpt_orig);
            Cmd.Parameters.AddWithValue("@AER_DEST", r.cd_arpt_dest);
            Cmd.Parameters.AddWithValue("@VALOR", r.vr_pasg);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
