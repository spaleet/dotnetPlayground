using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void Old()
    {
        var st = "";
    }
}
