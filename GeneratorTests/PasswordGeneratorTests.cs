using Generator;

namespace GeneratorTests;

public class PasswordGeneratorTests
{
    [Fact]
    public void GeneratePassword_defaultConfiguration_happyPath()
    {
        IPasswordGenerator passwordGenerator = new PasswordGenerator(new PasswordGenerator());
        
    }
}