module Chapter05Test

open Xunit
open Chapter05

[<Theory>]
[<InlineData(1, "午前")>]
[<InlineData(13, "午後")>]
let ``問題5.2 jikanは午後か午前かを判定する`` (hour, expected) = 
    let actual = jikan hour
    Assert.Equal(expected, actual)