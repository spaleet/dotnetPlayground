using StringGenerator.Benchmark;

//BenchmarkRunner.Run<Benchy>();
var dt = DateTime.Now;

Console.WriteLine(dt.ToShamsiDate());
Console.WriteLine(dt.ToShortShamsiDate());
Console.WriteLine(dt.ToLongShamsiDate());

Console.ReadKey();