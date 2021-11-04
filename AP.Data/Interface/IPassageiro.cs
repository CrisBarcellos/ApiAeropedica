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
    }
}
