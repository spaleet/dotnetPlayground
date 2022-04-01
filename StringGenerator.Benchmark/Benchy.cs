using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void OldToShamsiDate()
    {
        var dt = DateTime.Now;
        var s = dt.OldToShamsiDate();

    }

    [Benchmark]
    public void NewToShamsiDate()
    {
        var dt = DateTime.Now;
        var s = dt.NewToShamsiDate();
    }
}
