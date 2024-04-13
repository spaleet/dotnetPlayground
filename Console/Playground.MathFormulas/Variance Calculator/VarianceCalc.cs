namespace Playground.MathFormulas.Variance_Calculator;

public class VarianceCalc
{
    public double Calculate(List<double> data)
    {
        var average = data.Average();

        double numbersMinsAvgPow2 = 0;

        for (int i = 0; i < data.Count; i++)
        {
            var x = Math.Pow(data[i] - average, 2);
            numbersMinsAvgPow2 = numbersMinsAvgPow2 + x;
        }

        var n = (data.Count - 1);

        return (numbersMinsAvgPow2 / n);
    }
}
