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
        Console.Write("Enter the password length: ");
        int passwordLength = int.Parse(Console.ReadLine());
        Console.WriteLine("What should the password consist of: ");
        Console.WriteLine("1. Digits");
        Console.WriteLine("2. Letters");
        Console.WriteLine("3. Digits and Letters");
        Console.WriteLine("4. Special Symbols");
        Console.WriteLine("5. Digits and Special Symbols");
        Console.WriteLine("6. Letters and Special Symbols");
        Console.WriteLine("7. Letters, Digits, and Special Symbols");
        Console.Write("Which character set do you want to use: ");
        int charSet = int.Parse(Console.ReadLine());
        Console.WriteLine("Your password: [{0}]", GeneratePassword((PasswordChars)charSet, passwordLength));
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
