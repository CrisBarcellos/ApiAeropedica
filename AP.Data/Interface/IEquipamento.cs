using AP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Interface
{
    public interface IEquipamento
    {
        public Task Cadastrar(Equipamento e);
        public List<Equipamento> Listar();
        public List<Equipamento> ListarPorId(string id);
        public Task Deletar(string id);
        public Task Alterar(Equipamento e);
    }
}
