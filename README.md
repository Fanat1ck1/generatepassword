# generatepassword
 
This code is a C# program that generates random passwords based on user input. It defines three sets of characters: digits, alphabet (both lowercase and uppercase letters), and special symbols. The program allows the user to specify the length of the password and choose from different character sets to include in the password, such as digits, letters, and special symbols.

The PasswordChars enum is used to represent these character sets using bitwise flags, allowing the user to combine them in various ways.

The program then prompts the user for the desired password length and the character sets they want to include. It uses a random number generator to create a password of the specified length, composed of characters from the selected character sets.

This code is a useful tool for generating random and secure passwords, and it demonstrates the use of enums, string manipulation, and random number generation in C#.

# How to run
If you want to run via .cs:

Open a new terminal (Terminal -> New Terminal)
Type the command: dotnet run
