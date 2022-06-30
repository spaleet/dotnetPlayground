using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public static void OldToShortShamsiDate()
    {
        var dt = DateTime.Now;
    }

    [Benchmark]
    public static void NewToShortShamsiDate()
    {
        var dt = DateTime.Now;
    }
}
