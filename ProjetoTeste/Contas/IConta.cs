using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Contas
{
    public interface IConta
    {
        public string Nome { get; }
        public string Cpf { get; }
        public double RendaMensal { get; }
        public int Conta { get; }
        public int Agencia { get; }
        public double ValorSaldo { get; }

        public void Saque(double valor);
        public void Deposito(double valor);
        public double Saldo();
        public void Extrato();
        public void Transferir(double valor, ContaCorrente conta);
        public void AlterarDados();

    }
}
