using AP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Interface
{
    public interface IAeroporto
    {
        public Task Cadastrar(Aeroporto a);
        public List<Aeroporto> Listar();
        public List<Aeroporto> ListarPorId(string id);
        public Task Deletar(string id);
        public Task Alterar(Aeroporto a);
    }
}
