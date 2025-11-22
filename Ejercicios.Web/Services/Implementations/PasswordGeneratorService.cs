using System.Text;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Services.Implementations
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        public string Generate(PasswordGeneratorDTO settings)
        {
            var upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lower = "abcdefghijklmnopqrstuvwxyz";
            var numbers = "0123456789";
            var symbols = "!@$#%&*?";

            var validChars = new StringBuilder();

            if (settings.IncludeUppercase) validChars.Append(upper);
            if (settings.IncludeLowercase) validChars.Append(lower);
            if (settings.IncludeNumbers) validChars.Append(numbers);
            if (settings.IncludeSymbols) validChars.Append(symbols);

            if (validChars.Length == 0)
                return "Seleccione al menos un tipo de carácter.";

            var random = new Random();
            var passwordChars = new char[settings.Length];

            for (int i = 0; i < settings.Length; i++)
            {
                passwordChars[i] = validChars[random.Next(validChars.Length)];
            }

            return new string(passwordChars);
        }
    }
}
