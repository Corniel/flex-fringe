using System.IO;

namespace FlexFringe;

public static class Parser
{
    [Pure]
    public static async Task<IReadOnlyCollection<Line>> Lines(Stream stream, Tokenizer tokenizer)
    {
        var lines = new List<Line>();
        using var reader = new StreamReader(stream);

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            var words = tokenizer.Tokenize(line!);
            lines.Add(new Line(words));
        }
        return lines;
    }
}
