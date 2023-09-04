using PasswordGenerator;

namespace PasswordGeneratorApi.Services
{
    public class PasswordGeneratorService : IPasswordGeneratorServices
    {
        private readonly ILogger _logger;
        private readonly IGenerator _generator;
        public PasswordGeneratorService(ILogger<PasswordGeneratorService> logger, IGenerator passwordGenerator) 
        {
            this._logger = logger;
            this._generator = passwordGenerator;
        }
        public string GenerateNewPassword(int length)
        {
            return this._generator.Generate(length);
        }
    }
}
