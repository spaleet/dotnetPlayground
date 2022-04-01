using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void OldToShortShamsiDate()
    {
        var dt = DateTime.Now;
        var s = dt.ToShortShamsiDate();
    }

    [Benchmark]
    public void NewToShortShamsiDate()
    {
        var dt = DateTime.Now;
        var s = dt.ToNewShortShamsiDate();
    }
}
