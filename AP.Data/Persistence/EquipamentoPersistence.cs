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
    public class EquipamentoPersistence : DAL, IEquipamento
    {
        public Task Cadastrar(Equipamento e)
        {
            OpenConnection();

            Cmd = new SqlCommand("INSERT INTO ITR_EQPT VALUES(@CD_EQPT, @NM_EQPT, @DC_TIPO_EQPT, @QT_MOTOR, @IC_TIPO_PRPS, @QT_PSGR)", Con);
            Cmd.Parameters.AddWithValue("@CD_EQPT", e.cd_eqpt);
            Cmd.Parameters.AddWithValue("@NM_EQPT", e.nm_eqpt.ToUpper());
            Cmd.Parameters.AddWithValue("@DC_TIPO_EQPT", e.dc_tipo_eqpt.ToUpper());
            Cmd.Parameters.AddWithValue("@QT_MOTOR", e.qt_motor);
            Cmd.Parameters.AddWithValue("@IC_TIPO_PRPS", e.ic_tipo_prps.ToUpper());
            Cmd.Parameters.AddWithValue("@QT_PSGR", e.qt_psgr);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Equipamento> Listar()
        {
            OpenConnection();

            List<Equipamento> lista = new List<Equipamento>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM ITR_EQPT", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Equipamento()
                {
                    cd_eqpt = TratamentoNull.CheckNullFromDB<string>(Dr["CD_EQPT"]),
                    nm_eqpt = TratamentoNull.CheckNullFromDB<string>(Dr["NM_EQPT"]),
                    dc_tipo_eqpt = TratamentoNull.CheckNullFromDB<string>(Dr["DC_TIPO_EQPT"]),
                    qt_motor = TratamentoNull.CheckNullFromDB<decimal>(Dr["QT_MOTOR"]),
                    ic_tipo_prps = TratamentoNull.CheckNullFromDB<string>(Dr["IC_TIPO_PRPS"]),
                    qt_psgr = TratamentoNull.CheckNullFromDB<decimal>(Dr["QT_PSGR"])
                });
            }

            return lista;
        }

        public List<Equipamento> ListarPorId(string id)
        {
            OpenConnection();

            List<Equipamento> lista = new List<Equipamento>();

            Cmd = new SqlCommand("SELECT * FROM ITR_EQPT WHERE CD_EQPT = @CD_EQPT", Con);
            Cmd.Parameters.AddWithValue("@CD_EQPT", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Equipamento()
                {
                    cd_eqpt = TratamentoNull.CheckNullFromDB<string>(Dr["CD_EQPT"]),
                    nm_eqpt = TratamentoNull.CheckNullFromDB<string>(Dr["NM_EQPT"]),
                    dc_tipo_eqpt = TratamentoNull.CheckNullFromDB<string>(Dr["DC_TIPO_EQPT"]),
                    qt_motor = TratamentoNull.CheckNullFromDB<decimal>(Dr["QT_MOTOR"]),
                    ic_tipo_prps = TratamentoNull.CheckNullFromDB<string>(Dr["IC_TIPO_PRPS"]),
                    qt_psgr = TratamentoNull.CheckNullFromDB<decimal>(Dr["QT_PSGR"])
                });
            }

            return lista;
        }
        public Task Deletar(string id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM ITR_EQPT WHERE CD_EQPT = @ID", Con);
            Cmd.Parameters.AddWithValue("@ID", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM ITR_EQPT WHERE CD_EQPT = @ID", Con);
                Cmd.Parameters.AddWithValue("@ID", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Equipamento não encontrado!");

            return Task.CompletedTask;
        }

        public Task Alterar(Equipamento e)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE ITR_EQPT SET NM_EQPT = @NOME, DC_TIPO_EQPT = @TIPO_EQPT, QT_MOTOR = @QT_MOTOR, IC_TIPO_PRPS = @TIPO_PRPS, QT_PSGR = @QT_PSGR WHERE CD_EQPT = @CODIGO", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", e.cd_eqpt);
            Cmd.Parameters.AddWithValue("@NOME", e.nm_eqpt);
            Cmd.Parameters.AddWithValue("@TIPO_EQPT", e.ic_tipo_prps);
            Cmd.Parameters.AddWithValue("@QT_MOTOR", e.qt_motor);
            Cmd.Parameters.AddWithValue("@TIPO_PRPS", e.ic_tipo_prps);
            Cmd.Parameters.AddWithValue("@QT_PSGR", e.qt_psgr);          

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
