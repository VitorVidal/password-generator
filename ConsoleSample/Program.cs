// See https://aka.ms/new-console-template for more information

using PasswordGenerator;

Console.WriteLine("Password Generator sample");

var passes = new string[10];
var generator = new DefaultGenerator(new PasswordConfiguration());
for (var i = 0; i < 10; i++)
{
    Console.WriteLine($"Password:{generator.Generate(12)}");
}
Console.ReadKey();
