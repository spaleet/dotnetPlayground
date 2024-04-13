using Playground.MathFormulas.Variance_Calculator;

var c = new VarianceCalc();

var s = c.Calculate(new List<double>
{
    1, 3, 5, 7, 9
});

Console.WriteLine(s);
Console.ReadLine();