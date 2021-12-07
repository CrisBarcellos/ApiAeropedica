using AP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Interface
{
    public interface IVoo
    {
        public Task Cadastrar(Voo v);
        public List<Voo> Listar();
        public List<Voo> ListarPorId(decimal nr_voo, string data);
        public List<ListaVoo> ListarPorCidade(string data, string origem, string destino);
        public Task Deletar(decimal nr_voo, string data);
        public Task Alterar(Voo v);
    }
}
