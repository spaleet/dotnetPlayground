using Playground.MathFormulas.Utils;
using Playground.MathFormulas.Variance_Calculator;

var c = new VarianceCalc();

var x = new List<double>
{
    1, 3, 5, 7, 8, 5, 6, 21
};

Console.WriteLine(StatisticsUtils.GetMean(x));
Console.ReadLine();