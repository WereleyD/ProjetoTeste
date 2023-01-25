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
        public string Nome { get; set; }
        public string Cpf { get; private set; }
        public double RendaMensal { get; private set; }
        public int Conta { get; private set; }
        public int Agencia { get; private set; }
        public double ValorSaldo { get; private set; }
        public ArrayList Transacoes { get; private set; } = new ArrayList();
        public double LimiteChequeEspecial { get; private set; } = 500;

        private void setValorSaldo(double valorSaldo)
        {
            ValorSaldo = valorSaldo;
        }

        public void Saque(double valor)
        {
            if (valor >= ValorSaldo)
            {
                ChequeEspecial(valor);
            }
            else
            {
                double novoValor = ValorSaldo - valor;
                setValorSaldo(novoValor);
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
        public void Transferir(double valor, Contas conta)
        {
            if (valor >= ValorSaldo)
            {
                ChequeEspecial(valor, conta);
            }
            else
            {
                setValorSaldo(valor);
                conta.setValorSaldo(valor);
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
        public void AlterarDados()
        {

        }

        public void ChequeEspecial(double valor)
        {
            double saldoTotal = LimiteChequeEspecial + ValorSaldo;
            if (saldoTotal >= valor)
            {
                double limite = LimiteChequeEspecial;
                double novoValor = ValorSaldo - valor;
                setValorSaldo(novoValor);
                Transacoes.Add($"Saque: R$ {valor}. Novo saldo: R$ {ValorSaldo - (limite - LimiteChequeEspecial)}");
            }
            else
            {
                throw new SaldoInsuficienteException("Saldo insuficiente.");
            }
        }

        public void ChequeEspecial(double valor, Contas conta)
        {
            double saldoTotal = LimiteChequeEspecial + ValorSaldo;
            if (saldoTotal >= valor)
            {
                double limite = LimiteChequeEspecial;
                double novoValor = ValorSaldo - valor;
                setValorSaldo(novoValor);
                double novoValorConta = conta.ValorSaldo + valor;
                conta.setValorSaldo(novoValorConta);
                Transacoes.Add($"Transferência env.: R$ {valor}. Novo saldo: R$ {ValorSaldo - (limite - LimiteChequeEspecial)}");
                conta.Transacoes.Add($"Transferência rec.: R$ {valor}. Novo saldo: R$ {conta.ValorSaldo}");
            }
            else
            {
                throw new SaldoInsuficienteException("Saldo insuficiente.");
            }
        }
    }
}
