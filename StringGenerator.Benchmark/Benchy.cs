using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void UserName()
    {
        Generator.UserName();
    }

    [Benchmark]
    public void NewUserName()
    {
        Generator.NewUserName();
    }
}
