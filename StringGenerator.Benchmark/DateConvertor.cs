using System.Globalization;

namespace StringGenerator.Benchmark;
public static class DateConvertor
{
    private readonly static string[] DaysOfWeek = new string[] { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" };

    public static string GetDayOfWeek(DateTime dt)
    {
        var pc = new PersianCalendar();
        return DaysOfWeek[(int)pc.GetDayOfWeek(dt)];
    }

    public static string GetShortDayOfWeek(DateTime dt)
    {
        var pc = new PersianCalendar();
        return DaysOfWeek[(int)pc.GetDayOfWeek(dt)].Substring(0, 1);
    }
}
