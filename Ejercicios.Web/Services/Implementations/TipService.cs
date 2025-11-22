using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Services.Implementations
{
    public class TipService : ITipService
    {
        public TipDTO Calculate(decimal billAmount, int percentage)
        {
            decimal tip = Math.Round(billAmount * percentage / 100, 2);
            decimal total = billAmount + tip;

            return new TipDTO
            {
                BillAmount = billAmount,
                TipPercentage = percentage,
                TipAmount = tip,
                TotalToPay = total
            };
        }
    }
}
