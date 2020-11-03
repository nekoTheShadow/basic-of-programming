module Chapter22

let count = ref -1
let getnsym s =
    count := !count + 1
    sprintf "%s%d" s !count