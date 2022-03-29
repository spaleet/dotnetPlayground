using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void Old()
    {
        DateConvertor.OldToMiladi();
    }

    [Benchmark]
    public void New()
    {
        DateConvertor.NewToMiladi();
    }
}
