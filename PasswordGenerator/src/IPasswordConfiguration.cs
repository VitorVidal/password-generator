namespace PasswordGenerator;

public interface IPasswordConfiguration
{
    int MinLength
    {
        get;
    }
    
    string Characters
    {
        get;
    }
}