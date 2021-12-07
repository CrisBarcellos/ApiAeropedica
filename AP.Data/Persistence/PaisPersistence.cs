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
    public class PaisPersistence : DAL, IPais
    {
        public Task Cadastrar(Pais p)
        {
            OpenConnection();

            Cmd = new SqlCommand("INSERT INTO ITR_PAIS VALUES(@CD_PAIS, @NM_PAIS, @QT_PPLC_PAIS)", Con);
            Cmd.Parameters.AddWithValue("@CD_PAIS", p.cd_pais);
            Cmd.Parameters.AddWithValue("@NM_PAIS", p.nm_pais.ToUpper());
            Cmd.Parameters.AddWithValue("@QT_PPLC_PAIS", p.qt_pplc_pais);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Pais> Listar()
        {
            OpenConnection();

            List<Pais> lista = new List<Pais>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM ITR_PAIS", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Pais()
                {
                    cd_pais = TratamentoNull.CheckNullFromDB<string>(Dr["CD_PAIS"]),
                    nm_pais = TratamentoNull.CheckNullFromDB<string>(Dr["NM_PAIS"]),
                    qt_pplc_pais = TratamentoNull.CheckNullFromDB<decimal>(Dr["QT_PPLC_PAIS"])
                });
            }

            return lista;
        }

        public List<Pais> ListarPorId(string id)
        {
            OpenConnection();

            List<Pais> lista = new List<Pais>();

            Cmd = new SqlCommand("SELECT * FROM ITR_PAIS WHERE CD_PAIS = @CD_PAIS", Con);
            Cmd.Parameters.AddWithValue("@CD_PAIS", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Pais()
                {
                    cd_pais = TratamentoNull.CheckNullFromDB<string>(Dr["CD_PAIS"]),
                    nm_pais = TratamentoNull.CheckNullFromDB<string>(Dr["NM_PAIS"]),
                    qt_pplc_pais = TratamentoNull.CheckNullFromDB<decimal>(Dr["QT_PPLC_PAIS"])
                });
            }

            return lista;
        }
        public Task Deletar(string id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM ITR_PAIS WHERE CD_PAIS = @CD_PAIS", Con);
            Cmd.Parameters.AddWithValue("@CD_PAIS", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM ITR_PAIS WHERE CD_PAIS = @CD_PAIS", Con);
                Cmd.Parameters.AddWithValue("@CD_PAIS", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Pais não encontrado!");

            return Task.CompletedTask;
        }

        public Task Alterar(Pais p)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE ITR_PAIS SET NM_PAIS = @NOME, QT_PPLC_PAIS = @QUANTIDADE WHERE CD_PAIS = @CD_PAIS", Con);
            Cmd.Parameters.AddWithValue("@CD_PAIS", p.cd_pais);
            Cmd.Parameters.AddWithValue("@NOME", p.nm_pais);
            Cmd.Parameters.AddWithValue("@QUANTIDADE", p.qt_pplc_pais);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
