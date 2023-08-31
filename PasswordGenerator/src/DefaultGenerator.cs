using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator;

public class DefaultGenerator:IGenerator
{
    private readonly IPasswordConfiguration _passwordConfiguration;
    public DefaultGenerator(IPasswordConfiguration passwordConfiguration)
    {
        this._passwordConfiguration = passwordConfiguration;
    }
    public string Generate(int length)
    {
        if (length < _passwordConfiguration.MinLength)
            length = _passwordConfiguration.MinLength;
        
        var pass = new StringBuilder(length);
        for (var i = 0; i < length; i++)
        {
           var index = RandomNumberGenerator.GetInt32(_passwordConfiguration.Characters.Length-1);
           pass.Append(_passwordConfiguration.Characters[index]);
        }

        return pass.ToString();
    }
}