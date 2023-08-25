using MeuSuperBanco;

ContaBanco contaA = new ContaBanco("Diogo", 10000);
Console.WriteLine($"A conta {contaA.Numero} do(a) {contaA.Dono} foi criada com {contaA.Saldo}");

contaA.Depositar(100, DateTime.Now, "Recebi um pagamaneto!");
Console.WriteLine("\nDeposito");
Console.WriteLine($"A conta {contaA.Numero} do(a) {contaA.Dono} esta com {contaA.Saldo}");

try
{
    contaA.Sacar(120000, DateTime.Now, "Recebi um pagamaneto!");
    Console.WriteLine("\nSaque");
    Console.WriteLine($"A conta {contaA.Numero} do(a) {contaA.Dono} esta com {contaA.Saldo}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine($"Operação não realizada");
}

Console.WriteLine(contaA.PegarMovimentacoes());
