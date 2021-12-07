using AP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Interface
{
    public interface IReserva
    {
        public Task Cadastrar(Reserva r);
        public List<Reserva> Listar();
        public List<Reserva> ListarPorId(decimal cd_psgr, decimal nr_voo, string data);
        public Task Deletar(decimal cd_psgr, decimal nr_voo, string data);
        public Task Alterar(Reserva p);
    }
}
