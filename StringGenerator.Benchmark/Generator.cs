using System.Text;

namespace StringGenerator.Benchmark;
public class Generator
{
    #region Code

    public static string Code()
    {
        return Guid.NewGuid().ToString().ToUpper().Substring(0, 5);
    }

    #endregion

    #region IssueTrackingCode

    public static string NewIssueTrackingCode()
    {
        ReadOnlySpan<char> numbers = "0123456789";

        var sb = new StringBuilder();

        Random random = new();

        for (int i = 0; i < 4; i++)
        {
            sb.Append(numbers[random.Next(0, numbers.Length)]);
        }

        sb.Append('-');

        for (int i = 0; i < 4; i++)
        {
            sb.Append(numbers[random.Next(0, numbers.Length)]);
        }

        return sb.ToString().ToUpper();
    }

    #endregion

    #region UserName

    public static string UserName()
    {
        ReadOnlySpan<char> numbers = "0123456789";
        ReadOnlySpan<char> letters = "ABCDEFGHJKMNPQRSTUVWXYZ";

        string result = "";

        int l = letters.Length;
        int n = numbers.Length;

        Random random = new();

        for (int i = 0; i < 4; i++)
        {
            string character = letters[random.Next(0, l)].ToString();

            while (result.Contains(character))
                character = letters[random.Next(0, l)].ToString().ToUpper();

            result += character;
        }

        for (int i = 0; i < 4; i++)
        {
            string character = numbers[random.Next(0, n)].ToString();

            while (result.Contains(character))
                character = numbers[random.Next(0, n)].ToString().ToUpper();

            result += character;
        }

        return result;
    }

    public static string NewUserName()
    {
        ReadOnlySpan<char> numbers = "0123456789";
        ReadOnlySpan<char> letters = "ABCDEFGHJKMNPQRSTUVWXYZ";

        var sb = new StringBuilder();

        Random random = new();

        for (int i = 0; i < 4; i++)
            sb.Append(letters[random.Next(0, letters.Length)]);

        for (int i = 0; i < 4; i++)
            sb.Append(numbers[random.Next(0, numbers.Length)]);

        return sb.ToString().ToUpper();
    }


    #endregion
}