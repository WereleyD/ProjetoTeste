using ProjetoTeste;
using ProjetoTeste.Contas;
using ProjetoTeste.Excecoes;

ContaCorrente wesley = new ContaCorrente();
wesley.Nome = "Wesley Valmir Dieterich";
ContaCorrente josnei = new ContaCorrente();
josnei.Nome = "Josnei Valdo";

Console.WriteLine("-----Menu Principal-----\n" +
    "\n" +
    " Escolha a conta desejada:\n" +
    $"1 - {wesley.Nome}\n" +
    $"2 - {josnei.Nome}\n");
int op = int.Parse(Console.ReadLine());

switch (op)
{
    case 1:
        switch (MenuItem1())
        {

        }
        break;
    case 2:
        switch (MenuItem1())
        {

        }
        break;
    default: break;
}

int MenuItem1()
{
    Console.WriteLine("Escolha o tipo de conta: \n" + "1 - Conta Corrente\n" + "2 - Conta Poupança\n" + "3 - Conta Investimento\n" + "0 - Voltar");
    return int.Parse(Console.ReadLine());
}
int MenuItem2()
{
    Console.WriteLine("Escolha o tipo de operação:\n" + "1 - Saque\n" + "2 - Depósito\n" + "3 - Transferir\n" + "4 - Extrato\n" + "5 - Alterar dados\n" + "0 - Voltar");
    return int.Parse(Console.ReadLine());
}
/*try
{
    josnei.Saque(100);
    wesley.Transferir(200, josnei);
    josnei.Extrato();

}
catch (SaldoInsuficienteException e)
{
    Console.WriteLine(e.Message);
}*/






