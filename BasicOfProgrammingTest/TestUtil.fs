module TestUtil

open Xunit

let isEqual lst1 lst2 =
    Assert.True(
        List.length lst1 = List.length lst2 && List.forall2 (( = )) lst1 lst2, 
        sprintf "expected %A, but actual %A" lst1 lst2
    )