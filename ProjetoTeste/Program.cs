using ProjetoTeste.Contas;
using ProjetoTeste.Excecoes;


ContaCorrente wesley = new ContaCorrente();
ContaCorrente josnei = new ContaCorrente();
try
{
    Console.WriteLine($"Saldo = {wesley.ValorSaldo}");
    wesley.Saque(400);
    Console.WriteLine($"Saldo = {wesley.ValorSaldo}");
    wesley.Deposito(500);
    Console.WriteLine($"Saldo = {wesley.ValorSaldo}");
    Console.WriteLine("");
    wesley.Transferir(500, josnei);
    josnei.Extrato();
}
catch (SaldoInsuficienteException e)
{
    Console.WriteLine(e.Message);
}


