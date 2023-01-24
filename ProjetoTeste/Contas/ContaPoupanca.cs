using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Contas
{
    public class ContaPoupanca : Contas
    {
        public override void Saque(double valor)
        {
            throw new NotImplementedException();
        }

        public override void Transferir(double valor, Contas conta)
        {
            throw new NotImplementedException();
        }
    }
}
