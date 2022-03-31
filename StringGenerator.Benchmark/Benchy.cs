using BenchmarkDotNet.Attributes;
using System.Globalization;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void OldShortDayOfWeek()
    {
        var dt = DateTime.Now;
        var y = dt.ToString("dddd", CultureInfo.CreateSpecificCulture("fa")).Substring(0, 1);
    }

    [Benchmark]
    public void NewDayOfWeekV1()
    {
        var dt = DateTime.Now;

        var t = DateConvertor.GetDayOfWeek(dt).Substring(0, 1);
    }

    [Benchmark]
    public void NewDayOfWeekV2()
    {
        var dt = DateTime.Now;
        var t = DateConvertor.GetShortDayOfWeek(dt);
    }
}
