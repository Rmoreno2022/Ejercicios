namespace Ejercicios.Web.DTOs
{
    public class CurrencyConverterDTO
    {
        public decimal Amount { get; set; } = 1;
        public string FromCurrency { get; set; } = "USD";
        public string ToCurrency { get; set; } = "EUR";

        public decimal ConvertedAmount { get; set; }
    }
}
