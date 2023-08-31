using PasswordGenerator;

namespace Tests;

public class PasswordGeneratorTests
{
    [Theory]
    [ClassData(typeof(ManyConfigurations))] 
    public void GeneratePassword_NotNullOrtEmpty(PasswordConfiguration configuration, int length)
    {
        var generator = new DefaultGenerator(configuration);
        var pass = generator.Generate(length);
        Assert.NotNull(pass);
        Assert.NotEmpty(pass);
    }
    
    [Theory]
    [ClassData(typeof(ManyConfigurations))] 
    public void GeneratePassword_GreatOrEqualMinimalLength(PasswordConfiguration configuration, int length)
    {
        var generator = new DefaultGenerator(configuration);
        var pass = generator.Generate(length);
        Assert.True(pass.Length >= configuration.MinLength);
    }
    
    [Theory]
    [ClassData(typeof(ManyConfigurations))] 
    public void GeneratePassword_DistinctPasswords(PasswordConfiguration configuration, int length)
    {
        var passes = new string[length];
        var generator = new DefaultGenerator(configuration);
        for (var i = 0; i < length; i++)
        {
            passes[i] = generator.Generate(length);
        }
        
        var s = new HashSet<string>(passes);
        
        Assert.Equal(s.Count ,passes.Length);
    }

    private class ManyConfigurations : TheoryData<PasswordConfiguration, int>
    {
        public ManyConfigurations()
        {
            Add(new PasswordConfiguration(), 8);
            Add(new PasswordConfiguration(), 12);
            Add(new PasswordConfiguration(), 7);
            Add(new PasswordConfiguration(8), 8);
            Add(new PasswordConfiguration(8), 12);
            Add(new PasswordConfiguration(8), 7);
            Add(new PasswordConfiguration(8,""), 8);
            Add(new PasswordConfiguration(8,"abcdefghijklmnopqrstuvzx"), 8);
            Add(new PasswordConfiguration(8,"aaaaabbbbbbcccccc"), 8);
            Add(new PasswordConfiguration(8,"ABCDEFGHIJKLMNOPQRSTUVXZabcdefghijklmnopqrstuvxz!@#$%&*-_?"), 8);
            Add(new PasswordConfiguration("abcdefghijklmnopqrstuvzx"), 8);
            Add(new PasswordConfiguration("aaaaabbbbbbcccccc"), 8);
            Add(new PasswordConfiguration("ABCDEFGHIJKLMNOPQRSTUVXZabcdefghijklmnopqrstuvxz!@#$%&*-_?"), 8);
        }
    }
    
    
}