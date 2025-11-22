using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface IPasswordGeneratorService
    {
        string Generate(PasswordGeneratorDTO settings);
    }
}
