namespace FlexFringe;

public readonly struct Word : IEquatable<Word>
{
    public static readonly Word GUID = New("{GUID}");
    public static readonly Word DATE = New("{DATE}");
    public static readonly Word INT = New("{INT}");
    public static readonly Word NUM = New("{NUM}");
    public static readonly Word PATH = New("{PATH}");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly int Hash;

#if DEBUG
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly string? Display;

    private Word(int hash, string display)
    {
        Hash = hash;
        Display = display;
    }

    /// <inheritdoc />
    [Pure]
    public override string ToString() => Display ?? string.Empty;

#else
    private Word(int hash) => Hash = hash;

    /// <inheritdoc />
    [Pure]
    public override string ToString() => Hash.ToString();
#endif

    /// <inheritdoc />
    [Pure] 
    public override bool Equals(object? obj) => obj is Word other && Equals(other);

    /// <inheritdoc />
    [Pure] 
    public bool Equals(Word other) => Hash == other.Hash;

    /// <inheritdoc />
    [Pure] 
    public override int GetHashCode() => Hash;

    [Pure]
    private static int HashCode(string str)
    {
        int hash = 5381;
        foreach (var ch in str)
        {
            hash = unchecked(((hash << 5) + hash) ^ ch);
        }
        return hash & int.MaxValue;
    }

    public static bool operator ==(Word left, Word right) => left.Equals(right);
    public static bool operator !=(Word left, Word right) => !(left == right);

    [Pure]
    public static Word New(string str)
    {
        var code = HashCode(str);
#if DEBUG
        return new(code, str);
#else
        return  new(code);
#endif
    }
}
