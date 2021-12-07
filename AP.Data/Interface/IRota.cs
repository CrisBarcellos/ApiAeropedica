using AP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.Data.Interface
{
    public interface IRota
    {
        public Task Cadastrar(Rota r);
        public List<Rota> Listar();
        public List<Rota> ListarPorId(int id);
        public Task Deletar(decimal id);
        public Task Alterar(Rota p);
    }
}
