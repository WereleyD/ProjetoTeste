using ProjetoTeste.Excecoes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Contas
{
    public abstract class Contas
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public double RendaMensal { get; private set; }
        public int Conta { get; private set; }
        public int Agencia { get; private set; }
        public double ValorSaldo { get; private set; }
        public ArrayList Transacoes { get; private set; } = new ArrayList();
        public double LimiteChequeEspecial { get; private set; } = 500;


        //precisa ser protected. Ajustar
        public void setValorSaldo(double valorSaldo)
        {
            ValorSaldo = valorSaldo;
        }

        public abstract void Saque(double valor);
        public void Deposito(double valor)
        {
            if (valor < 0)
            {
                throw new ValorInvalidoException($"Não é possível realizar um depósito no valor de R$ {valor}. Operação cancelada.");
            }
            else
            {
                ValorSaldo = ValorSaldo + valor;
                Transacoes.Add($"Depósito: R$ {valor}. Novo saldo: R$ {ValorSaldo}");
            }
        }
        public double Saldo()
        {
            return ValorSaldo;
        }
        public void Extrato()
        {
            foreach (var item in Transacoes)
            {
                Console.WriteLine(item);
            }
        }
        public abstract void Transferir(double valor, Contas conta);
        public void AlterarDados()
        {

        }
    }
}
