using System.Globalization;

namespace StringGenerator.Benchmark;
public class DateConvertor
{
    public static DateTime OldToMiladi(string persianDate = "1401/01/09 17:38:52")
    {
        persianDate = ToEnglishNumber(persianDate);
        var year = Convert.ToInt32(persianDate.Substring(0, 4));
        var month = Convert.ToInt32(persianDate.Substring(5, 2));
        var day = Convert.ToInt32(persianDate.Substring(8, 2));
        var hour = Convert.ToInt32(persianDate.Substring(11, 2));
        var minute = Convert.ToInt32(persianDate.Substring(14, 2));
        var seconds = Convert.ToInt32(persianDate.Substring(17, 2));

        var miladyDateTime = new DateTime(year, month, day, hour, minute, seconds, new PersianCalendar());

        return miladyDateTime;
    }

    public static DateTime NewToMiladi(string persianDate = "1401/01/09 17:38:52")
    {
        persianDate = ToEnglishNumber(persianDate);
        ReadOnlySpan<char> dateAsText = persianDate;

        var year = int.Parse(dateAsText.Slice(0, 4));
        var month = int.Parse(dateAsText.Slice(5, 2));
        var day = int.Parse(dateAsText.Slice(8, 2));
        var hour = int.Parse(dateAsText.Slice(11, 2));
        var minute = int.Parse(dateAsText.Slice(14, 2));
        var seconds = int.Parse(dateAsText.Slice(17, 2));

        var miladyDateTime = new DateTime(year, month, day, hour, minute, seconds, new PersianCalendar());

        return miladyDateTime;
    }

    private static readonly string[] Pn = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
    private static readonly string[] En = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    private static string ToEnglishNumber(string stringNum)
    {
        var cash = stringNum;
        for (var i = 0; i < 10; i++)
            cash = cash.Replace(Pn[i], En[i]);

        return cash;
    }
}
