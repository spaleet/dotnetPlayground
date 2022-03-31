using System.Globalization;

namespace StringGenerator.Benchmark;
public static class DateConvertor
{
    private readonly static string[] DaysOfWeek = new string[] { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" };
    private readonly static string[] DaysOfWeekShort = new string[] { "ش", "ی", "د", "س", "چ", "پ", "ج" };
    private readonly static string[] Months = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

    public static string GetDayOfWeek(DateTime dt)
    {
        var pc = new PersianCalendar();
        return DaysOfWeek[(int)pc.GetMonth(dt)];
    }

    public static string GetShortDayOfWeek(DateTime dt)
    {
        var pc = new PersianCalendar();
        return DaysOfWeekShort[(int)pc.GetDayOfWeek(dt)].Substring(0, 1);
    }
}
