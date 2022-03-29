using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void Old()
    {
        Generator.OldPersianDate();
    }

    [Benchmark]
    public void New()
    {
        Generator.NewPersianDate();
    }
}
