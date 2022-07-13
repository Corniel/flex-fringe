namespace FlexFringe.Benchmarks;

internal class Program
{
    static void Main(string[] args)
    {
        _ = BenchmarkRunner.Run<Parse>();
    }
}