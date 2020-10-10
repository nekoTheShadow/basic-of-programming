module PersonTest

open Xunit
open Person

[<Theory>]
[<InlineData("山田", 1.7, 60.0, "2000/02/01", "B", "山田さんの血液型はB型です")>]
[<InlineData("田中", 1.6, 50.0, "2000/01/01", "A", "田中さんの血液型はA型です")>]
[<InlineData("中田", 1.8, 40.0, "2000/03/01", "O", "中田さんの血液型はO型です")>]
let ``問題8.4 ketsuekiHyojiは「XXさんの血液型はX型です」という文字列を作成する`` (name, height, weight, date, bloodtype, expected) =
    let actual = ketsuekiHyoji {Name=name; Height=height; Weight=weight; Date=date; BloodType=bloodtype}
    Assert.Equal(expected, actual)
