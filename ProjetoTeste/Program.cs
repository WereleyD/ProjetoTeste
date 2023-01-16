using ProjetoTeste.Contas;
using ProjetoTeste.Excecoes;


ContaCorrente wesley = new ContaCorrente();
try
{
    Console.WriteLine($"Saldo = {wesley.ValorSaldo}");
    wesley.Saque(400);
    Console.WriteLine($"Saldo = {wesley.ValorSaldo}");
    wesley.Saque(50);
    Console.WriteLine($"Saldo = {wesley.ValorSaldo}");
    wesley.Saque(50);
    Console.WriteLine($"Saldo = {wesley.ValorSaldo}");
    wesley.Deposito(1000);
    Console.WriteLine($"Saldo = {wesley.ValorSaldo}");
}
catch (SaldoInsuficienteException e)
{
    Console.WriteLine(e.Message);
}


