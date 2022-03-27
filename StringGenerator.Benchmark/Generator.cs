﻿using System.Text;
using System.Text.RegularExpressions;

namespace StringGenerator.Benchmark;
public class Generator
{
    #region Constants

    private readonly static char[] Letters = "ABCDEFGHJKMNPQRSTUVWXYZ".ToCharArray();

    private readonly static char[] Numbers = "0123456789".ToCharArray();

    private readonly static char[] Chars = "$%#@!*?;:abcdefghijklmnopqrstuvxxyzABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();

    #endregion

    #region Code

    public static string Code()
    {
        return Guid.NewGuid().ToString().ToUpper().Substring(0, 5);
    }

    #endregion

    #region IssueTrackingCode

    public static string OldIssueTrackingCode()
    {
        string section1 = "";
        string section2 = "";

        int n = Numbers.Length;

        Random random = new Random();

        for (int i = 0; i < 4; i++)
        {
            string character = Numbers[random.Next(0, n)].ToString();

            while (section1.Contains(character))
                character = Numbers[random.Next(0, n)].ToString().ToUpper();

            section1 += character;
        }

        for (int i = 0; i < 4; i++)
        {
            string character = Numbers[random.Next(0, n)].ToString();

            while (section2.Contains(character))
                character = Numbers[random.Next(0, n)].ToString().ToUpper();

            section2 += character;
        }

        return $"{section1}-{section2}";
    }

    public static string NewIssueTrackingCode()
    {
        var sb = new StringBuilder();

        Random random = new();

        for (int i = 0; i < 4; i++)
        {
            sb.Append(Numbers[random.Next(0, Numbers.Length)]);
        }

        sb.Append('-');

        for (int i = 0; i < 4; i++)
        {
            sb.Append(Numbers[random.Next(0, Numbers.Length)]);
        }

        return sb.ToString();
    }

    #endregion

    #region UserName

    public static string UserName()
    {
        string result = "";

        int l = Letters.Length;
        int n = Numbers.Length;

        Random random = new();

        for (int i = 0; i < 4; i++)
        {
            string character = Letters[random.Next(0, l)].ToString();

            while (result.Contains(character))
                character = Letters[random.Next(0, l)].ToString().ToUpper();

            result += character;
        }

        for (int i = 0; i < 4; i++)
        {
            string character = Numbers[random.Next(0, n)].ToString();

            while (result.Contains(character))
                character = Numbers[random.Next(0, n)].ToString().ToUpper();

            result += character;
        }

        return result;
    }

    #endregion

    #region Password

    public static string Password()
    {
        var random = new Random();
        var password = Guid.NewGuid().ToString().Substring(4, 9);

        var regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$");

        while (!regex.IsMatch(password))
            password += Chars[random.Next(Chars.Length)].ToString();

        return password;
    }

    #endregion
}
