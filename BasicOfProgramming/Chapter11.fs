module Chapter11

let rec sumOfSquare n = 
    if n = 0 then
        0
    else 
        (n * n) + sumOfSquare (n - 1)

let rec a n =
    if n = 0 then
        3
    else 
        2*a(n-1)-1