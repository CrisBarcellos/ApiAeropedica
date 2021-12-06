using AP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Interface
{
    public interface IPassageiro
    {
        public Task Cadastrar(Passageiro p);
        public List<Passageiro> Listar();
        public List<Passageiro> ListarPorId(int id);
        public Task Deletar(decimal id);
        public Task Alterar(Passageiro p);
    }
}
