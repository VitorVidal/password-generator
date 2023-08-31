namespace PasswordGenerator;

public class PasswordConfiguration:IPasswordConfiguration
{
    public int MinLength 
    {
        get;
    } = 8;

    public string Characters
    {
        get;
    } = "ABCDEFGHIJKLMNOPQRSTUVXZabcdefghijklmnopqrstuvxz!@#$%&*-_";

    public PasswordConfiguration()
    {
  
    }
    
    public PasswordConfiguration(int minLength)
    {
        this.MinLength = minLength;
    }
    
    public PasswordConfiguration(string characters)
    {
        this.Characters = ValidateCharacters(characters);
    }
    
    public PasswordConfiguration(int minLength,string characters)
    {
        this.MinLength = minLength;
        this.Characters = ValidateCharacters(characters);
    }

    private string ValidateCharacters(string characters)
    {
        if (string.IsNullOrEmpty(characters) ||
            characters.Length < this.Characters.Length || 
            !HaveDistinctElements(characters)
           ) return this.Characters;
        return characters;
    }

    private static bool HaveDistinctElements(string characters)
    {
        var arr = characters.ToCharArray();
        var s = new HashSet<char>(arr);
        return s.Count != arr.Length;
    }
    
}