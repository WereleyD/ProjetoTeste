using ProjetoTeste.Excecoes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        public double LimiteChequeEspecial { get; private set; } = 500;

        public void Saque(double valor)
        {
            if (valor >= ValorSaldo)
            {
                ChequeEspecial(valor);
            }
            else
            {
                ValorSaldo -= valor;
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
        public void Transferir(double valor, ContaCorrente conta)
        {
            if (valor >= ValorSaldo)
            {
                ChequeEspecial(valor);
            }
            else
            {
                ValorSaldo -= valor;
                conta.ValorSaldo += valor;
            }
        }
        public void AlterarDados()
        {

        }
        public void ChequeEspecial(double valor)
        {
            double saldoTotal = LimiteChequeEspecial + ValorSaldo;
            if(saldoTotal >= valor)
            {
                double limite = LimiteChequeEspecial;
                ValorSaldo -= valor;
                Transacoes.Add($"Saque: R$ {valor}. Novo saldo: R$ {ValorSaldo - (limite - LimiteChequeEspecial)}");
            }
            else
            {
                throw new SaldoInsuficienteException("Saldo insuficiente.");
            }
        }
        //ContaCorrente conta não está recebendo valor quando é utilizado ChequeEspecial - Corrigir
        public void ChequeEspecial(double valor, ContaCorrente conta)
        {
            double saldoTotal = LimiteChequeEspecial + ValorSaldo;
            if (saldoTotal >= valor)
            {
                double limite = LimiteChequeEspecial;
                ValorSaldo -= valor;
                Transacoes.Add($"Saque: R$ {valor}. Novo saldo: R$ {ValorSaldo - (limite - LimiteChequeEspecial)}");
            }
            else
            {
                throw new SaldoInsuficienteException("Saldo insuficiente.");
            }
        }
    }
}
