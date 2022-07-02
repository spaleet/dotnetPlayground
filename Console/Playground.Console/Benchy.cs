using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public static void OldTask()
    {
        var dt = DateTime.Now;
    }

    [Benchmark]
    public static void NewTask()
    {
        var dt = DateTime.Now;
    }
}
