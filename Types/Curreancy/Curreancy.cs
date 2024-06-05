using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;

namespace ProjetoTeste.Types.Curreancy;

public readonly struct Currency
{
    public Currency(decimal amount)
        => Amount = amount;

    public decimal Amount { get; }

    public override string ToString()
        => $"R${Amount}";
}
