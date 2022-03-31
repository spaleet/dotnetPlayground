using BenchmarkDotNet.Running;
using StringGenerator.Benchmark;

BenchmarkRunner.Run<Benchy>();

//Console.WriteLine(DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("fa")));

//Console.ReadKey();