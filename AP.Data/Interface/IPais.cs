using AP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Interface
{
    public interface IPais
    {
        public Task Cadastrar(Pais p);
        public List<Pais> Listar();
        public List<Pais> ListarPorId(string id);
        public Task Deletar(string id);
        public Task Alterar(Pais p);
    }
}
