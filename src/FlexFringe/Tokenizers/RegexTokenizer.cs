using System.Text.RegularExpressions;

namespace FlexFringe;

public class RegexTokenizer : Tokenizer
{
    private readonly Regex Pattern;

    public RegexTokenizer(Regex pattern) => Pattern = pattern;

    public IEnumerable<Word> Tokenize(string line)
    {
        var match = Pattern.Match(line);
        IList<Group> groups = match.Groups;
        return groups.OrderBy(group => group.Index).SelectMany(Tokenize);
    }

    private static IEnumerable<Word> Tokenize(Group group)
    {
        if (!group.Success || group.Name == "0") return Array.Empty<Word>();
        else if (group.Name == nameof(DATE)) return DATE;
        else return Tokenizers.Default.Tokenize(group.Value);
    }
    private static readonly Word[] DATE = { Word.DATE };
}
