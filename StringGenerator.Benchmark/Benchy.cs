using BenchmarkDotNet.Attributes;
using System.Globalization;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void OldMonthName()
    {
        var dt = DateTime.Now;
        var y = dt.ToString("MMMM", CultureInfo.CreateSpecificCulture("fa"));
    }

    [Benchmark]
    public void NewMonthName()
    {
        var dt = DateTime.Now;

        var t = DateConvertor.GetMonth(dt);
    }
}
