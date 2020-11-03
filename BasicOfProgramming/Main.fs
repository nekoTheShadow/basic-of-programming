module Main

open Station4

[<EntryPoint>]
let main args =
    let eki = dijkstra args.[0] args.[1] in
    printEki eki
    0