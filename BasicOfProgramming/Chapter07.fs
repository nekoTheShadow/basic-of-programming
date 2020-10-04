module Chapter07

open System

let goukeiToHeikin japanese math english science society = 
    let sum = japanese+math+english+science+society
    let avg = sum/5
    (sum, avg)

let seiseki (name, grade) = 
   name + "さんの評価は" + grade + "です"

let taishoX (x, y) = (x, -y)

let chuten (x1, y1) (x2, y2) = ((x1+x2)/2.0, (y1+y2)/2.0)
