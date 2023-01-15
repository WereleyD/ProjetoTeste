using ProjetoTeste.Excecoes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Contas
{
    public class ContaCorrente : IConta
    {
        public string Nome { get; }
        public string Cpf { get; }
        public double RendaMensal { get; }
        public int Conta { get; }
        public int Agencia { get; }
        public double ValorSaldo { get; private set; }
        public ArrayList Transacoes { get; private set; } = new ArrayList();

        public void Saque(double valor)
        {
            if (valor > ValorSaldo)
            {
                throw new SaldoInsuficienteException($"Saldo insuficiente para realizar um saque no valor de R$ {valor}.");
            }
            else
            {
                ValorSaldo = ValorSaldo - valor;
                Transacoes.Add($"Saque: R$ {valor}. Novo saldo: R$ {ValorSaldo}");
            }
        }
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
        public void Transferir(double valor, IConta conta)
        {

        }
        public void AlterarDados()
        {

        }
    }
}
