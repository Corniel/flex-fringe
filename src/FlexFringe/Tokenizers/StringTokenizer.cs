using System.Globalization;

namespace FlexFringe;

public class StringTokenizer : Tokenizer
{
    [Pure]
    public IEnumerable<Word> Tokenize(string line)
        => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Sub);

    [Pure]
    private static Word Sub(string str)
    {
        if (int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out _))
        {
            return Word.INT;
        }
        else if (decimal.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out _))
        {
            return Word.NUM;
        }
        else if (Guid.TryParse(str, out _))
        {
            return Word.GUID;
        }
        else if(DateTime.TryParse(str, out _))
        {
            return Word.DATE;
        }
        else return Word.New(str);
    }
}
