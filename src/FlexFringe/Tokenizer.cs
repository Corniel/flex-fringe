namespace FlexFringe;

public interface Tokenizer
{
    [Pure]
    IEnumerable<Word> Tokenize(string line);
}
