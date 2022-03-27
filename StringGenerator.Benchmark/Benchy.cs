using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void NewIssueTrackingCode()
    {
        Generator.NewIssueTrackingCode();
    }
}
