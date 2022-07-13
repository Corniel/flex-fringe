using FlexFringe;

namespace Word_specs;

public class Has
{
    [TestCase("flex-fringe", 1590277902)]
    [TestCase("hello_world", 1209170522)]
    [TestCase("{GUID}", /* */ 282556188)]
    public void deterministic_hash_code(string word, int hash)
        => Word.New(word).GetHashCode().Should().Be(hash);
}

#if DEBUG
public class Has_in_DEBUG_mode
{
    [Test]
    public void size_of_16() => System.Runtime.InteropServices.Marshal.SizeOf(typeof(Word)).Should().Be(16);

    [Test]
    public void string_display_of_hash() => TestData.Word.ToString().Should().Be("flex-fringe");
}
#endif

#if RELEASE
public class Has_in_RELEASE_mode
{
    [Test]
    public void size_of_4() => System.Runtime.InteropServices.Marshal.SizeOf(typeof(Word)).Should().Be(4);

    [Test]
    public void string_display_of_hash() => TestData.Word.ToString().Should().Be("-557205746");
}
#endif