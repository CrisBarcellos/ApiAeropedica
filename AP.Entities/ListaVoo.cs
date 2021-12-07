using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Entities
{
    public class ListaVoo
    {
        public decimal nr_voo { get; set; }
        public string dt_saida { get; set; }
        public string cidade_origem { get; set; }
        public string cidade_destino { get; set; }
        public decimal preco { get; set; }
        public string aer_origem { get; set; }
        public string aer_destino { get; set; }
    }
}
