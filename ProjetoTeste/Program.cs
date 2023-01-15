using ProjetoTeste.Contas;
using ProjetoTeste.Excecoes;


ContaCorrente wesley = new ContaCorrente();
try
{
    Console.WriteLine(wesley.ValorSaldo);
    wesley.Deposito(500);
    wesley.Saque(100);
    wesley.Extrato();
}
catch (SaldoInsuficienteException e)
{
    Console.WriteLine(e.Message);
}


