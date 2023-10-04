using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; }

        public Veiculo(string placa)
        {
            Placa = placa;
        }
    }
}