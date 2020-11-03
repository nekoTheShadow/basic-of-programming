module Heap

let length = ref 0

let create size =
    ref (Array.create size (infinity, ""))

let rec upheap heap ptr =
    if ptr = 0 then
        heap
    else 
        let (key1, value1) = Array.get !heap ptr in
        let (key2, value2) = Array.get !heap ((ptr-1)/2) in
        if key2 <= key1 then
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
        let (key2, value2) = Array.get !heap (2*ptr+1) in
        let (key3, value3) = Array.get !heap (2*ptr+2) in
        if key2 < key1 && key2 < key3 then
            Array.set !heap (2*ptr+1) (key1, value1)
            Array.set !heap ptr (key2, value2)
            downheap heap (2*ptr+1)
        else if key3 < key1 && key3 < key2 then
            Array.set !heap (2*ptr+2) (key1, value1)
            Array.set !heap ptr (key3, value3)
            downheap heap (2*ptr+2)
        else
            heap

let insert heap key value =
    Array.set !heap !length (key, value)
    upheap heap !length |> ignore
    length := !length + 1

let splitTop heap = 
    let (key, value) = Array.get !heap 0 in
    Array.set !heap 0 (infinity, "")
    downheap heap 0 |> ignore
    length := !length - 1
    (key, value)
