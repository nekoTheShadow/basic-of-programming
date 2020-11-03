module Chapter22Test

open Chapter22
open Xunit

[<Fact>]
let ``問題22.1 gensymは文字列に順番にsuffixをつける``() =
    Assert.Equal("a0", getnsym "a")
    Assert.Equal("b1", getnsym "b")
    Assert.Equal("c2", getnsym "c")

[<Fact>]
let ``問題22.2 fibArrayは配列にフィボナッチ数列を代入する``() =
    Assert.True(Array.forall2 (=) [|0; 1; 1; 2; 3; 5; 8; 13; 21; 34;|] (fibArray [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0;|]))