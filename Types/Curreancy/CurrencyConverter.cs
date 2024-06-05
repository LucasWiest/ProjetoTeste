using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ProjetoTeste.Types.Curreancy
{
    public class CurrencyConverter : ValueConverter<Currency, decimal>
    {
        public CurrencyConverter()
            : base(
                v => v.Amount,
                v => new Currency(v))
        {
        }
    }
}
