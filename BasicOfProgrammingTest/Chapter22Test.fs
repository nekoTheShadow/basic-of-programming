module Chapter22Test

open Chapter22
open Xunit

[<Fact>]
let ``問題22.1 gensymは文字列に順番にsuffixをつける``() =
    Assert.Equal("a0", getnsym "a")
    Assert.Equal("b1", getnsym "b")
    Assert.Equal("c2", getnsym "c")
    