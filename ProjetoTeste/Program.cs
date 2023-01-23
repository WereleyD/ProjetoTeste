using ProjetoTeste;
using ProjetoTeste.Contas;
using ProjetoTeste.Excecoes;

ContaCorrente wesley = new ContaCorrente();
ContaCorrente josnei = new ContaCorrente();

try
{
    josnei.Saque(100);
    wesley.Transferir(200, josnei);
    josnei.Extrato();

}
catch (SaldoInsuficienteException e)
{
    Console.WriteLine(e.Message);
}






