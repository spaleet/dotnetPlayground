using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void Old()
    {
        Generator.NewUserName();
    }

    [Benchmark]
    public void New()
    {
        GeneratorT.NewUserName();
    }
}
