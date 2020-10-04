module Chapter08

type Book = {
    Title: string;
    Publisher: string;
    Price: int;
    ISBN: string;
}

type Okozukai = {
    Name: string;
    Price: int;
    Place: string;
    Date: System.DateTime;
}

type BloodType = 
    | A
    | B
    | AB
    | O

type Person = {
    Name: string;
    Height: double;
    Weight: double;
    Date: System.DateTime;
    BloodType: BloodType
}

let tanaka = {Name="田中"; Height=1.6; Weight=60.0; Date=System.DateTime(2000, 1, 1); BloodType=BloodType.A};
let yamada = {Name="山田"; Height=1.7; Weight=50.0; Date=System.DateTime(2000, 2, 1); BloodType=BloodType.B};
let nakata = {Name="中田"; Height=1.8; Weight=40.0; Date=System.DateTime(2000, 3, 1); BloodType=BloodType.O};





