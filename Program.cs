using System;
using System.Text;

class Program
{
    const string Digits = "0123456789";
    const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    const string Symbols = " ~`@#$%^&*()_+-=[]{};'\\:\"|,./<>?";

    [Flags]
    public enum PasswordChars
    {
        Digits = 0b0001, 
        Alphabet = 0b0010,
        Symbols = 0b0100
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Введіть довжину пароля: ");
        int passwordLength = int.Parse(Console.ReadLine());
        Console.WriteLine("З чого буде складатися пароль: ");
        Console.WriteLine("1.Цифр");
        Console.WriteLine("2.Букв");
        Console.WriteLine("3.Цифр та букв");
        Console.WriteLine("4.Спец. символів");
        Console.WriteLine("5.Цифр і спец. символів");
        Console.WriteLine("6.Букв і спец. символів");
        Console.WriteLine("7.Букв, цифр и спец. символів");
        Console.Write("Який з наборів ви хочете використовувати: ");
        int charSet = int.Parse(Console.ReadLine());
        Console.WriteLine("Ваш пароль: [{0}]", GeneratePassword((PasswordChars)charSet, passwordLength));
        Console.ReadLine();
    }

    private static string GeneratePassword(PasswordChars passwordChars, int length)
    {
        var random = new Random();
        var resultPassword = new StringBuilder(length);
        var passwordCharSet = string.Empty;
        if (passwordChars.HasFlag(PasswordChars.Alphabet))
        {
            passwordCharSet += Alphabet + Alphabet.ToUpper();
        }
        if (passwordChars.HasFlag(PasswordChars.Digits))
        {
            passwordCharSet += Digits;
        }
        if (passwordChars.HasFlag(PasswordChars.Symbols))
        {
            passwordCharSet += Symbols;
        }
        for (var i = 0; i < length; i++)
        {
            resultPassword.Append(passwordCharSet[random.Next(0, passwordCharSet.Length)]);
        }
        return resultPassword.ToString();
    }
}