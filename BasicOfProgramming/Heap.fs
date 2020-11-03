module Heap

let length = ref 0

let create size =
    ref (Array.create size (infinity, Unchecked.defaultof<'b>))

let rec upheap heap ptr =
    if ptr = 0 then
        heap
    else 
        let (key1, value1) = Array.get !heap ptr in
        let (key2, value2) = Array.get !heap ((ptr-1)/2) in
        if key2 < key1 then
            heap
        else
            Array.set !heap ptr (key2, value2)
            Array.set !heap ((ptr-1)/2) (key1, value1)
            upheap heap ((ptr-1)/2)

let rec downheap heap ptr =
    if !length <= ptr then
        heap
    else 
        let (key1, value1) = Array.get !heap ptr in
        let (key2, value2) = if 2*ptr+1 < Array.length !heap then Array.get !heap (2*ptr+1) else (infinity, Unchecked.defaultof<'b>) in
        let (key3, value3) = if 2*ptr+2 < Array.length !heap then Array.get !heap (2*ptr+2) else (infinity, Unchecked.defaultof<'b>) in
        if key2 < key3 then
            if key2 < key1 then
                Array.set !heap (2*ptr+1) (key1, value1)
                Array.set !heap ptr (key2, value2)
                downheap heap (2*ptr+1)
            else
                heap
        else
            if key3 < key1 then
                Array.set !heap (2*ptr+2) (key1, value1)
                Array.set !heap ptr (key3, value3)
                downheap heap (2*ptr+2)
            else 
                heap

let insert heap key value =
    Array.set !heap !length (key, value)
    upheap heap !length |> ignore
    length := !length + 1
    heap

let splitTop heap = 
    let (key, value) = Array.get !heap 0 in
    Array.set !heap 0 (infinity, Unchecked.defaultof<'a>)
    downheap heap 0 |> ignore
    length := !length - 1
    (key, value)

let heapSort lst =
    let heap = List.fold (fun heap v -> insert heap -v v) (create (List.length lst)) lst in
    let rec f n acc =
        if n = 0 then
            acc
        else
            let (k, v) = splitTop heap in f (n - 1) (-k::acc)
    in f (List.length lst) []
