using AP.Data.Interface;
using AP.Data.Utiil;
using AP.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AP.Data.Persistence
{
    public class ReservaPersistence : DAL, IReserva
    {
        public Task Cadastrar(Reserva r)
        {

            OpenConnection();

            Cmd = new SqlCommand("INSERT INTO ITR_RESV VALUES(@CD_PSGR, @NR_VOO, @DT_SAIDA_VOO, @PC_DESC_PASG)", Con);
            Cmd.Parameters.AddWithValue("@CD_PSGR", r.cd_psgr);
            Cmd.Parameters.AddWithValue("@NR_VOO", r.nr_voo);
            Cmd.Parameters.AddWithValue("@DT_SAIDA_VOO", r.dt_saida_voo);
            Cmd.Parameters.AddWithValue("@PC_DESC_PASG", r.pc_desc_pasg);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Reserva> Listar()
        {
            OpenConnection();

            List<Reserva> lista = new List<Reserva>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM ITR_RESV", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Reserva()
                {
                    cd_psgr = TratamentoNull.CheckNullFromDB<decimal>(Dr["CD_PSGR"]),
                    nr_voo = TratamentoNull.CheckNullFromDB<decimal>(Dr["NR_VOO"]),
                    dt_saida_voo = Convert.ToDateTime(Dr["DT_SAIDA_VOO"]).ToString("dd/MM/yyyy"),
                    pc_desc_pasg = TratamentoNull.CheckNullFromDB<decimal>(Dr["PC_DESC_PASG"])
                });
            }

            return lista;
        }

        public List<Reserva> ListarPorId(decimal cd_psgr, decimal nr_voo, string data)
        {
            OpenConnection();

            List<Reserva> lista = new List<Reserva>();

            Cmd = new SqlCommand("SELECT * FROM ITR_RESV WHERE CD_PSGR = @CD_PSGR AND NR_VOO = @VOO AND DT_SAIDA_VOO = @SAIDA", Con);
            Cmd.Parameters.AddWithValue("@CD_PSGR", cd_psgr);
            Cmd.Parameters.AddWithValue("@VOO", nr_voo);
            Cmd.Parameters.AddWithValue("@SAIDA", Convert.ToDateTime(data).ToString("yyyy/MM/dd"));
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Reserva()
                {
                    cd_psgr = TratamentoNull.CheckNullFromDB<decimal>(Dr["CD_PSGR"]),
                    nr_voo = TratamentoNull.CheckNullFromDB<decimal>(Dr["NR_VOO"]),
                    dt_saida_voo = Convert.ToDateTime(Dr["DT_SAIDA_VOO"]).ToString("dd/MM/yyyy"),
                    pc_desc_pasg = TratamentoNull.CheckNullFromDB<decimal>(Dr["PC_DESC_PASG"])
                });
            }

            return lista;
        }
        public Task Deletar(decimal cd_psgr, decimal nr_voo, string data)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM ITR_RESV WHERE CD_PSGR = @CD_PSGR AND NR_VOO = @VOO AND DT_SAIDA_VOO = @SAIDA", Con);
            Cmd.Parameters.AddWithValue("@CD_PSGR", cd_psgr);
            Cmd.Parameters.AddWithValue("@VOO", nr_voo);
            Cmd.Parameters.AddWithValue("@SAIDA", Convert.ToDateTime(data).ToString("yyyy/MM/dd"));
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM ITR_RESV WHERE CD_PSGR = @CD_PSGR AND NR_VOO = @VOO AND DT_SAIDA_VOO = @SAIDA", Con);
                Cmd.Parameters.AddWithValue("@CD_PSGR", cd_psgr);
                Cmd.Parameters.AddWithValue("@VOO", nr_voo);
                Cmd.Parameters.AddWithValue("@SAIDA", Convert.ToDateTime(data).ToString("yyyy/MM/dd"));

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Reserva não encontrada!");

            return Task.CompletedTask;
        }

        public Task Alterar(Reserva r)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE ITR_RESV SET CD_PSGR = @CODIGO, NR_VOO = @VOO, DT_SAIDA_VOO = @SAIDA, PC_DESC_PASG = @DESCONTO WHERE CD_PSGR = @CODIGO AND NR_VOO = @VOO AND DT_SAIDA_VOO = @SAIDA", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", r.cd_psgr);
            Cmd.Parameters.AddWithValue("@VOO", r.nr_voo);
            Cmd.Parameters.AddWithValue("@SAIDA", Convert.ToDateTime(r.dt_saida_voo).ToString("yyyy/MM/dd"));
            Cmd.Parameters.AddWithValue("@DESCONTO", r.pc_desc_pasg);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
