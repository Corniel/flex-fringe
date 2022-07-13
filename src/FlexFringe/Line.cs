namespace FlexFringe;

public sealed class Line : IReadOnlyList<Word>
{
    public Line(IEnumerable<Word> words) => Words = words.ToArray();

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly Word[] Words;

    public Word this[int index] => Words[index];

    public int Count => Words.Length;

    /// <inheritdoc />
    [Pure]
    public IEnumerator<Word> GetEnumerator() => ((IEnumerable<Word>)Words).GetEnumerator();

    /// <inheritdoc />
    [Pure]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <inheritdoc />
    [Pure]
    public override string ToString() => string.Join(' ', Words);
}
