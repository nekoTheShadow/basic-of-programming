module Chapter14Test

open Xunit
open Chapter14
open TestUtil

[<Fact>]
let ``問題14.5 evenはリストの偶数の要素のみを集めたリストを作成する`` () =
    isEqual [2; 6; 4] (even [2; 1; 6; 4; 7])
