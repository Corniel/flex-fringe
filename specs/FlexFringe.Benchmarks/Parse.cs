using BenchmarkDotNet.Attributes;
using Specs.Tools;
using System.Text.RegularExpressions;

namespace FlexFringe.Benchmarks;

public class Parse
{
    [Benchmark]
    public async Task<IReadOnlyCollection<Line>> Apache()
    {
        using var stream = TestData.Apache();
        return await Parser.Lines(stream, apache);
    }

    private static readonly Tokenizer apache = new RegexTokenizer(new Regex(@"^(?<DATE>\[.+?\]) (.+)$", RegexOptions.Compiled));
}
