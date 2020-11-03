module HeapTest

open Xunit
open Heap
open TestUtil

[<Fact>]
let TestHeap() =
    let heap = create 1000

    insert heap 4.0 "B" |> ignore
    insert heap 2.0 "A" |> ignore
    Assert.Equal((2.0, "A"), splitTop heap)

    insert heap 3.0 "C" |> ignore
    insert heap 1.0 "D" |> ignore
    Assert.Equal((1.0, "D"), splitTop heap)
    Assert.Equal((3.0, "C"), splitTop heap)
    Assert.Equal((4.0, "B"), splitTop heap)

[<Fact>]
let TestHeapSort() =
    isEqual [1.0; 2.0; 3.0; 4.0; 5.0] (heapSort [3.0; 2.0; 5.0; 1.0; 4.0])