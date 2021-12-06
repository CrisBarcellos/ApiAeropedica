using AP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.Data.Interface
{
    public interface IUF
    {
        public Task Cadastrar(UF uf);
        public List<UF> Listar();
        public List<UF> ListarPorId(string id);
        public Task Deletar(string id);
        public Task Alterar(UF uf);
    }
}
