module Person

type Person = {
    Name: string;
    Height: double;
    Weight: double;
    Date: string;
    BloodType: string
}

let tanaka = {Name="田中"; Height=1.6; Weight=60.0; Date="2020/01/01"; BloodType="A"};
let yamada = {Name="山田"; Height=1.7; Weight=50.0; Date="2020/02/01"; BloodType="B"};
let nakata = {Name="中田"; Height=1.8; Weight=40.0; Date="2020/03/01"; BloodType="O"};

let ketsuekiHyoji {Name=name; Height=height; Weight=weight; Date=date; BloodType=bloodtype} =
    sprintf "%sさんの血液型は%s型です" name bloodtype

