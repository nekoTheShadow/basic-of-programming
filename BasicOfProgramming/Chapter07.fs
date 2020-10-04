module Chapter07

open System

let goukeiToHeikin japanese math english science society = 
    let sum = japanese+math+english+science+society
    let avg = sum/5
    (sum, avg)

let seiseki (name, grade) = 
   name + "さんの評価は" + grade + "です"