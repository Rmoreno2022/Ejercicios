using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface ITipService
    {
        TipDTO Calculate(decimal billAmount, int percentage);
    }
}
