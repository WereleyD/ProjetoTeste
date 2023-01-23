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
    public class ContaCorrente : Contas
    {
        public override void Saque(double valor)
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
        public override void Transferir(double valor, Contas conta)
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
