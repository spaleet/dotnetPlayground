using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void OldToLongShamsiDate()
    {
        var dt = DateTime.Now;
        var s = dt.ToLongShamsiDate();
    }

    [Benchmark]
    public void NewToLongShamsiDate()
    {
        var dt = DateTime.Now;
        var s = dt.ToNewLongShamsiDate();
    }
}
