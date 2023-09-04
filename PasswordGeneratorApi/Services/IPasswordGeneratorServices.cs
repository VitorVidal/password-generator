using PasswordGenerator;

namespace PasswordGeneratorApi.Services
{
    public interface IPasswordGeneratorServices
    {
        string GenerateNewPassword(int length);
    }
}
