using FlexFringe;
using System.Text.RegularExpressions;

namespace Tokenizers.Regex_specs;

public class Parses
{
    [Test]
    public async Task Apache()
    {
        var tokenizer = new RegexTokenizer(new Regex(@"^(?<DATE>\[.+?\]) (.+)$", RegexOptions.Compiled));

        using var stream = TestData.Apache();
        var lines = await Parser.Lines(stream, tokenizer);

        foreach(var line in lines)
        {
            Console.WriteLine(line);
        }

        lines.Should().HaveCount(2000);
        //lines.Should().AllSatisfy(line => line.Should().NotBeEmpty());
        //lines.Should().AllSatisfy(line => line.First().Should().Be(Word.DATE));
    }
}
