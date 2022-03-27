using BenchmarkDotNet.Attributes;

namespace StringGenerator.Benchmark;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public void OldIssueTrackingCode()
    {
        Generator.OldIssueTrackingCode();
    }

    [Benchmark]
    public void NewIssueTrackingCode()
    {
        Generator.NewIssueTrackingCode();
    }
}
