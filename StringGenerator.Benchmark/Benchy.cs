using BenchmarkDotNet.Attributes;
using System.Globalization;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void GetShortShamsiYear()
    {
        var dt = DateTime.Now;
        var g = dt.ToString("yy", CultureInfo.CreateSpecificCulture("fa"));
    }

    [Benchmark]
    public void NewGetShortShamsiYear()
    {
        var dt = DateTime.Now;
        var pc = new PersianCalendar();
        var g = pc.GetYear(dt).ToString().Substring(2, 2);
    }
}
