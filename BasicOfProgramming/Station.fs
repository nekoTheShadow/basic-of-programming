module Station

type Ekimei = {
    Kanji: string;
    Kana: string;
    Romaji: string;
    Shozoku: string;
}

type Ekikan = {
    Kiten: string;
    Shuten: string;
    Keiyu: string;
    Kyori: double;
    Jikan: int
}

type Eki = {
    Namae: string;
    SaitanKyori: double;
    TemaeList : string list;
}

type EkikanTree = Empty
                | Node of EkikanTree * string * (string * float) list * EkikanTree

// http://pllab.is.ocha.ac.jp/~asai/book-data/ex09_9.ml
let globalEkimeiList = [ 
    {Kanji="代々木上原"; Kana="よよぎうえはら"; Romaji="yoyogiuehara"; Shozoku="千代田線"}; 
    {Kanji="代々木公園"; Kana="よよぎこうえん"; Romaji="yoyogikouen"; Shozoku="千代田線"}; 
    {Kanji="明治神宮前"; Kana="めいじじんぐうまえ"; Romaji="meijijinguumae"; Shozoku="千代田線"}; 
    {Kanji="表参道"; Kana="おもてさんどう"; Romaji="omotesandou"; Shozoku="千代田線"}; 
    {Kanji="乃木坂"; Kana="のぎざか"; Romaji="nogizaka"; Shozoku="千代田線"}; 
    {Kanji="赤坂"; Kana="あかさか"; Romaji="akasaka"; Shozoku="千代田線"}; 
    {Kanji="国会議事堂前"; Kana="こっかいぎじどうまえ"; Romaji="kokkaigijidoumae"; Shozoku="千代田線"}; 
    {Kanji="霞ヶ関"; Kana="かすみがせき"; Romaji="kasumigaseki"; Shozoku="千代田線"}; 
    {Kanji="日比谷"; Kana="ひびや"; Romaji="hibiya"; Shozoku="千代田線"}; 
    {Kanji="二重橋前"; Kana="にじゅうばしまえ"; Romaji="nijuubasimae"; Shozoku="千代田線"}; 
    {Kanji="大手町"; Kana="おおてまち"; Romaji="otemachi"; Shozoku="千代田線"}; 
    {Kanji="新御茶ノ水"; Kana="しんおちゃのみず"; Romaji="shin-ochanomizu"; Shozoku="千代田線"}; 
    {Kanji="湯島"; Kana="ゆしま"; Romaji="yushima"; Shozoku="千代田線"}; 
    {Kanji="根津"; Kana="ねづ"; Romaji="nedu"; Shozoku="千代田線"}; 
    {Kanji="千駄木"; Kana="せんだぎ"; Romaji="sendagi"; Shozoku="千代田線"}; 
    {Kanji="西日暮里"; Kana="にしにっぽり"; Romaji="nishinippori"; Shozoku="千代田線"}; 
    {Kanji="町屋"; Kana="まちや"; Romaji="machiya"; Shozoku="千代田線"}; 
    {Kanji="北千住"; Kana="きたせんじゅ"; Romaji="kitasenjyu"; Shozoku="千代田線"}; 
    {Kanji="綾瀬"; Kana="あやせ"; Romaji="ayase"; Shozoku="千代田線"}; 
    {Kanji="北綾瀬"; Kana="きたあやせ"; Romaji="kitaayase"; Shozoku="千代田線"}; 
    {Kanji="浅草"; Kana="あさくさ"; Romaji="asakusa"; Shozoku="銀座線"}; 
    {Kanji="田原町"; Kana="たわらまち"; Romaji="tawaramachi"; Shozoku="銀座線"}; 
    {Kanji="稲荷町"; Kana="いなりちょう"; Romaji="inaricho"; Shozoku="銀座線"}; 
    {Kanji="上野"; Kana="うえの"; Romaji="ueno"; Shozoku="銀座線"}; 
    {Kanji="上野広小路"; Kana="うえのひろこうじ"; Romaji="uenohirokoji"; Shozoku="銀座線"}; 
    {Kanji="末広町"; Kana="すえひろちょう"; Romaji="suehirocho"; Shozoku="銀座線"}; 
    {Kanji="神田"; Kana="かんだ"; Romaji="kanda"; Shozoku="銀座線"}; 
    {Kanji="三越前"; Kana="みつこしまえ"; Romaji="mitsukoshimae"; Shozoku="銀座線"}; 
    {Kanji="日本橋"; Kana="にほんばし"; Romaji="nihonbashi"; Shozoku="銀座線"}; 
    {Kanji="京橋"; Kana="きょうばし"; Romaji="kyobashi"; Shozoku="銀座線"}; 
    {Kanji="銀座"; Kana="ぎんざ"; Romaji="ginza"; Shozoku="銀座線"}; 
    {Kanji="新橋"; Kana="しんばし"; Romaji="shinbashi"; Shozoku="銀座線"}; 
    {Kanji="虎ノ門"; Kana="とらのもん"; Romaji="toranomon"; Shozoku="銀座線"}; 
    {Kanji="溜池山王"; Kana="ためいけさんのう"; Romaji="tameikesannou"; Shozoku="銀座線"}; 
    {Kanji="赤坂見附"; Kana="あかさかみつけ"; Romaji="akasakamitsuke"; Shozoku="銀座線"}; 
    {Kanji="青山一丁目"; Kana="あおやまいっちょうめ"; Romaji="aoyamaicchome"; Shozoku="銀座線"}; 
    {Kanji="外苑前"; Kana="がいえんまえ"; Romaji="gaienmae"; Shozoku="銀座線"}; 
    {Kanji="表参道"; Kana="おもてさんどう"; Romaji="omotesando"; Shozoku="銀座線"}; 
    {Kanji="渋谷"; Kana="しぶや"; Romaji="shibuya"; Shozoku="銀座線"}; 
    {Kanji="渋谷"; Kana="しぶや"; Romaji="shibuya"; Shozoku="半蔵門線"}; 
    {Kanji="表参道"; Kana="おもてさんどう"; Romaji="omotesandou"; Shozoku="半蔵門線"}; 
    {Kanji="青山一丁目"; Kana="あおやまいっちょうめ"; Romaji="aoyama-itchome"; Shozoku="半蔵門線"}; 
    {Kanji="永田町"; Kana="ながたちょう"; Romaji="nagatacho"; Shozoku="半蔵門線"}; 
    {Kanji="半蔵門"; Kana="はんぞうもん"; Romaji="hanzomon"; Shozoku="半蔵門線"}; 
    {Kanji="九段下"; Kana="くだんした"; Romaji="kudanshita"; Shozoku="半蔵門線"}; 
    {Kanji="神保町"; Kana="じんぼうちょう"; Romaji="jinbocho"; Shozoku="半蔵門線"}; 
    {Kanji="大手町"; Kana="おおてまち"; Romaji="otemachi"; Shozoku="半蔵門線"}; 
    {Kanji="三越前"; Kana="みつこしまえ"; Romaji="mitsukoshimae"; Shozoku="半蔵門線"}; 
    {Kanji="水天宮前"; Kana="すいてんぐうまえ"; Romaji="suitengumae"; Shozoku="半蔵門線"}; 
    {Kanji="清澄白河"; Kana="きよすみしらかわ"; Romaji="kiyosumi-shirakawa"; Shozoku="半蔵門線"}; 
    {Kanji="住吉"; Kana="すみよし"; Romaji="sumiyoshi"; Shozoku="半蔵門線"}; 
    {Kanji="錦糸町"; Kana="きんしちょう"; Romaji="kinshicho"; Shozoku="半蔵門線"}; 
    {Kanji="押上"; Kana="おしあげ"; Romaji="oshiage"; Shozoku="半蔵門線"}; 
    {Kanji="中目黒"; Kana="なかめぐろ"; Romaji="nakameguro"; Shozoku="日比谷線"}; 
    {Kanji="恵比寿"; Kana="えびす"; Romaji="ebisu"; Shozoku="日比谷線"}; 
    {Kanji="広尾"; Kana="ひろお"; Romaji="hiro"; Shozoku="日比谷線"}; 
    {Kanji="六本木"; Kana="ろっぽんぎ"; Romaji="roppongi"; Shozoku="日比谷線"}; 
    {Kanji="神谷町"; Kana="かみやちょう"; Romaji="kamiyacho"; Shozoku="日比谷線"}; 
    {Kanji="霞ヶ関"; Kana="かすみがせき"; Romaji="kasumigaseki"; Shozoku="日比谷線"}; 
    {Kanji="日比谷"; Kana="ひびや"; Romaji="hibiya"; Shozoku="日比谷線"}; 
    {Kanji="銀座"; Kana="ぎんざ"; Romaji="ginza"; Shozoku="日比谷線"}; 
    {Kanji="東銀座"; Kana="ひがしぎんざ"; Romaji="higashiginza"; Shozoku="日比谷線"}; 
    {Kanji="築地"; Kana="つきじ"; Romaji="tsukiji"; Shozoku="日比谷線"}; 
    {Kanji="八丁堀"; Kana="はっちょうぼり"; Romaji="hacchobori"; Shozoku="日比谷線"}; 
    {Kanji="茅場町"; Kana="かやばちょう"; Romaji="kayabacho"; Shozoku="日比谷線"}; 
    {Kanji="人形町"; Kana="にんぎょうちょう"; Romaji="ningyomachi"; Shozoku="日比谷線"}; 
    {Kanji="小伝馬町"; Kana="こでんまちょう"; Romaji="kodemmacho"; Shozoku="日比谷線"}; 
    {Kanji="秋葉原"; Kana="あきはばら"; Romaji="akihabara"; Shozoku="日比谷線"}; 
    {Kanji="仲御徒町"; Kana="なかおかちまち"; Romaji="nakaokachimachi"; Shozoku="日比谷線"}; 
    {Kanji="上野"; Kana="うえの"; Romaji="ueno"; Shozoku="日比谷線"}; 
    {Kanji="入谷"; Kana="いりや"; Romaji="iriya"; Shozoku="日比谷線"}; 
    {Kanji="三ノ輪"; Kana="みのわ"; Romaji="minowa"; Shozoku="日比谷線"}; 
    {Kanji="南千住"; Kana="みなみせんじゅ"; Romaji="minamisenju"; Shozoku="日比谷線"}; 
    {Kanji="北千住"; Kana="きたせんじゅ"; Romaji="kitasenju"; Shozoku="日比谷線"}; 
    {Kanji="池袋"; Kana="いけぶくろ"; Romaji="ikebukuro"; Shozoku="丸ノ内線"}; 
    {Kanji="新大塚"; Kana="しんおおつか"; Romaji="shinotsuka"; Shozoku="丸ノ内線"}; 
    {Kanji="茗荷谷"; Kana="みょうがだに"; Romaji="myogadani"; Shozoku="丸ノ内線"}; 
    {Kanji="後楽園"; Kana="こうらくえん"; Romaji="korakuen"; Shozoku="丸ノ内線"}; 
    {Kanji="本郷三丁目"; Kana="ほんごうさんちょうめ"; Romaji="hongosanchome"; Shozoku="丸ノ内線"}; 
    {Kanji="御茶ノ水"; Kana="おちゃのみず"; Romaji="ochanomizu"; Shozoku="丸ノ内線"}; 
    {Kanji="淡路町"; Kana="あわじちょう"; Romaji="awajicho"; Shozoku="丸ノ内線"}; 
    {Kanji="大手町"; Kana="おおてまち"; Romaji="otemachi"; Shozoku="丸ノ内線"}; 
    {Kanji="東京"; Kana="とうきょう"; Romaji="tokyo"; Shozoku="丸ノ内線"}; 
    {Kanji="銀座"; Kana="ぎんざ"; Romaji="ginza"; Shozoku="丸ノ内線"}; 
    {Kanji="霞ヶ関"; Kana="かすみがせき"; Romaji="kasumigaseki"; Shozoku="丸ノ内線"}; 
    {Kanji="国会議事堂前"; Kana="こっかいぎじどうまえ"; Romaji="kokkaigijidomae"; Shozoku="丸ノ内線"}; 
    {Kanji="赤坂見附"; Kana="あかさかみつけ"; Romaji="akasakamitsuke"; Shozoku="丸ノ内線"}; 
    {Kanji="四ツ谷"; Kana="よつや"; Romaji="yotsuya"; Shozoku="丸ノ内線"}; 
    {Kanji="四谷三丁目"; Kana="よつやさんちょうめ"; Romaji="yotsuyasanchome"; Shozoku="丸ノ内線"}; 
    {Kanji="新宿御苑前"; Kana="しんじゅくぎょえんまえ"; Romaji="shinjuku-gyoemmae"; Shozoku="丸ノ内線"}; 
    {Kanji="新宿三丁目"; Kana="しんじゅくさんちょうめ"; Romaji="shinjuku-sanchome"; Shozoku="丸ノ内線"}; 
    {Kanji="新宿"; Kana="しんじゅく"; Romaji="shinjuku"; Shozoku="丸ノ内線"}; 
    {Kanji="西新宿"; Kana="にししんじゅく"; Romaji="nishi-shinjuku"; Shozoku="丸ノ内線"}; 
    {Kanji="中野坂上"; Kana="なかのさかうえ"; Romaji="nakano-sakaue"; Shozoku="丸ノ内線"}; 
    {Kanji="新中野"; Kana="しんなかの"; Romaji="shin-nakano"; Shozoku="丸ノ内線"}; 
    {Kanji="東高円寺"; Kana="ひがしこうえんじ"; Romaji="higashi-koenji"; Shozoku="丸ノ内線"}; 
    {Kanji="新高円寺"; Kana="しんこうえんじ"; Romaji="shin-koenji"; Shozoku="丸ノ内線"}; 
    {Kanji="南阿佐ヶ谷"; Kana="みなみあさがや"; Romaji="minami-asagaya"; Shozoku="丸ノ内線"}; 
    {Kanji="荻窪"; Kana="おぎくぼ"; Romaji="ogikubo"; Shozoku="丸ノ内線"}; 
    {Kanji="中野新橋"; Kana="なかのしんばし"; Romaji="nakano-shimbashi"; Shozoku="丸ノ内線"}; 
    {Kanji="中野富士見町"; Kana="なかのふじみちょう"; Romaji="nakano-fujimicho"; Shozoku="丸ノ内線"}; 
    {Kanji="方南町"; Kana="ほうなんちょう"; Romaji="honancho"; Shozoku="丸ノ内線"}; 
    {Kanji="四ツ谷"; Kana="よつや"; Romaji="yotsuya"; Shozoku="南北線"}; 
    {Kanji="永田町"; Kana="ながたちょう"; Romaji="nagatacho"; Shozoku="南北線"}; 
    {Kanji="溜池山王"; Kana="ためいけさんのう"; Romaji="tameikesanno"; Shozoku="南北線"}; 
    {Kanji="六本木一丁目"; Kana="ろっぽんぎいっちょうめ"; Romaji="roppongiitchome"; Shozoku="南北線"}; 
    {Kanji="麻布十番"; Kana="あざぶじゅうばん"; Romaji="azabujuban"; Shozoku="南北線"}; 
    {Kanji="白金高輪"; Kana="しろかねたかなわ"; Romaji="shirokanetaKanawa"; Shozoku="南北線"}; 
    {Kanji="白金台"; Kana="しろかねだい"; Romaji="shirokanedai"; Shozoku="南北線"}; 
    {Kanji="目黒"; Kana="めぐろ"; Romaji="meguro"; Shozoku="南北線"}; 
    {Kanji="市ヶ谷"; Kana="いちがや"; Romaji="ichigaya"; Shozoku="南北線"}; 
    {Kanji="飯田橋"; Kana="いいだばし"; Romaji="idabashi"; Shozoku="南北線"}; 
    {Kanji="後楽園"; Kana="こうらくえん"; Romaji="korakuen"; Shozoku="南北線"}; 
    {Kanji="東大前"; Kana="とうだいまえ"; Romaji="todaimae"; Shozoku="南北線"}; 
    {Kanji="本駒込"; Kana="ほんこまごめ"; Romaji="honkomagome"; Shozoku="南北線"}; 
    {Kanji="駒込"; Kana="こまごめ"; Romaji="komagome"; Shozoku="南北線"}; 
    {Kanji="西ヶ原"; Kana="にしがはら"; Romaji="nishigahara"; Shozoku="南北線"}; 
    {Kanji="王子"; Kana="おうじ"; Romaji="oji"; Shozoku="南北線"}; 
    {Kanji="王子神谷"; Kana="おうじかみや"; Romaji="ojikamiya"; Shozoku="南北線"}; 
    {Kanji="志茂"; Kana="しも"; Romaji="shimo"; Shozoku="南北線"}; 
    {Kanji="赤羽岩淵"; Kana="あかばねいわぶち"; Romaji="akabaneiwabuchi"; Shozoku="南北線"}; 
    {Kanji="西船橋"; Kana="にしふなばし"; Romaji="nishi-funabashi"; Shozoku="東西線"}; 
    {Kanji="原木中山"; Kana="ばらきなかやま"; Romaji="baraki-nakayama"; Shozoku="東西線"}; 
    {Kanji="妙典"; Kana="みょうでん"; Romaji="myoden"; Shozoku="東西線"}; 
    {Kanji="行徳"; Kana="ぎょうとく"; Romaji="gyotoku"; Shozoku="東西線"}; 
    {Kanji="南行徳"; Kana="みなみぎょうとく"; Romaji="minami-gyotoku"; Shozoku="東西線"}; 
    {Kanji="浦安"; Kana="うらやす"; Romaji="urayasu"; Shozoku="東西線"}; 
    {Kanji="葛西"; Kana="かさい"; Romaji="kasai"; Shozoku="東西線"}; 
    {Kanji="西葛西"; Kana="にしかさい"; Romaji="nishi-kasai"; Shozoku="東西線"}; 
    {Kanji="南砂町"; Kana="みなみすなまち"; Romaji="minami-sunamachi"; Shozoku="東西線"}; 
    {Kanji="東陽町"; Kana="とうようちょう"; Romaji="touyoucho"; Shozoku="東西線"}; 
    {Kanji="木場"; Kana="きば"; Romaji="kiba"; Shozoku="東西線"}; 
    {Kanji="門前仲町"; Kana="もんぜんなかちょう"; Romaji="monzen-nakacho"; Shozoku="東西線"}; 
    {Kanji="茅場町"; Kana="かやばちょう"; Romaji="kayabacho"; Shozoku="東西線"}; 
    {Kanji="日本橋"; Kana="にほんばし"; Romaji="nihonbashi"; Shozoku="東西線"}; 
    {Kanji="大手町"; Kana="おおてまち"; Romaji="otemachi"; Shozoku="東西線"}; 
    {Kanji="竹橋"; Kana="たけばし"; Romaji="takebashi"; Shozoku="東西線"}; 
    {Kanji="九段下"; Kana="くだんした"; Romaji="kudanshita"; Shozoku="東西線"}; 
    {Kanji="飯田橋"; Kana="いいだばし"; Romaji="iidabashi"; Shozoku="東西線"}; 
    {Kanji="神楽坂"; Kana="かぐらざか"; Romaji="kagurazaka"; Shozoku="東西線"}; 
    {Kanji="早稲田"; Kana="わせだ"; Romaji="waseda"; Shozoku="東西線"}; 
    {Kanji="高田馬場"; Kana="たかだのばば"; Romaji="takadanobaba"; Shozoku="東西線"}; 
    {Kanji="落合"; Kana="おちあい"; Romaji="ochiai"; Shozoku="東西線"}; 
    {Kanji="中野"; Kana="なかの"; Romaji="nakano"; Shozoku="東西線"}; 
    {Romaji="shinkiba"; Kana="しんきば"; Kanji="新木場"; Shozoku="有楽町線"}; 
    {Romaji="tatsumi"; Kana="たつみ"; Kanji="辰巳"; Shozoku="有楽町線"}; 
    {Romaji="toyosu"; Kana="とよす"; Kanji="豊洲"; Shozoku="有楽町線"}; 
    {Romaji="tsukishima"; Kana="つきしま"; Kanji="月島"; Shozoku="有楽町線"}; 
    {Romaji="shintomityou"; Kana="しんとみちょう"; Kanji="新富町"; Shozoku="有楽町線"}; 
    {Romaji="ginzaittyoume"; Kana="ぎんざいっちょうめ"; Kanji="銀座一丁目"; Shozoku="有楽町線"}; 
    {Romaji="yuurakutyou"; Kana="ゆうらくちょう"; Kanji="有楽町"; Shozoku="有楽町線"}; 
    {Romaji="sakuradamon"; Kana="さくらだもん"; Kanji="桜田門"; Shozoku="有楽町線"}; 
    {Romaji="nagatacho"; Kana="ながたちょう"; Kanji="永田町"; Shozoku="有楽町線"}; 
    {Romaji="koujimachi"; Kana="こうじまち"; Kanji="麹町"; Shozoku="有楽町線"}; 
    {Romaji="ichigaya"; Kana="いちがや"; Kanji="市ヶ谷"; Shozoku="有楽町線"}; 
    {Romaji="iidabashi"; Kana="いいだばし"; Kanji="飯田橋"; Shozoku="有楽町線"}; 
    {Kanji="江戸川橋"; Kana="えどがわばし"; Romaji="edogawabasi"; Shozoku="有楽町線"}; 
    {Kanji="護国寺"; Kana="ごこくじ"; Romaji="gokokuji"; Shozoku="有楽町線"}; 
    {Kanji="東池袋"; Kana="ひがしいけぶくろ"; Romaji="higasiikebukuro"; Shozoku="有楽町線"}; 
    {Kanji="池袋"; Kana="いけぶくろ"; Romaji="ikebukuro"; Shozoku="有楽町線"}; 
    {Kanji="要町"; Kana="かなめちょう"; Romaji="Kanametyou"; Shozoku="有楽町線"}; 
    {Kanji="千川"; Kana="せんかわ"; Romaji="senkawa"; Shozoku="有楽町線"}; 
    {Kanji="小竹向原"; Kana="こたけむかいはら"; Romaji="kotakemukaihara"; Shozoku="有楽町線"}; 
    {Kanji="氷川台"; Kana="ひかわだい"; Romaji="hikawadai"; Shozoku="有楽町線"}; 
    {Kanji="平和台"; Kana="へいわだい"; Romaji="heiwadai"; Shozoku="有楽町線"}; 
    {Kanji="営団赤塚"; Kana="えいだんあかつか"; Romaji="eidanakakuka"; Shozoku="有楽町線"}; 
    {Kanji="営団成増"; Kana="えいだんなります"; Romaji="eidannarimasu"; Shozoku="有楽町線"}; 
    {Kanji="和光市"; Kana="わこうし"; Romaji="wakousi"; Shozoku="有楽町線"}; 
] 

// http://pllab.is.ocha.ac.jp/~asai/book-data/ex09_10.ml
let globalEkikanList = [ 
    {Kiten="代々木上原"; Shuten="代々木公園"; Keiyu="千代田線"; Kyori=1.0; Jikan=2}; 
    {Kiten="代々木公園"; Shuten="明治神宮前"; Keiyu="千代田線"; Kyori=1.2; Jikan=2}; 
    {Kiten="明治神宮前"; Shuten="表参道"; Keiyu="千代田線"; Kyori=0.9; Jikan=2}; 
    {Kiten="表参道"; Shuten="乃木坂"; Keiyu="千代田線"; Kyori=1.4; Jikan=3}; 
    {Kiten="乃木坂"; Shuten="赤坂"; Keiyu="千代田線"; Kyori=1.1; Jikan=2}; 
    {Kiten="赤坂"; Shuten="国会議事堂前"; Keiyu="千代田線"; Kyori=0.8; Jikan=1}; 
    {Kiten="国会議事堂前"; Shuten="霞ヶ関"; Keiyu="千代田線"; Kyori=0.7; Jikan=1}; 
    {Kiten="霞ヶ関"; Shuten="日比谷"; Keiyu="千代田線"; Kyori=1.2; Jikan=2}; 
    {Kiten="日比谷"; Shuten="二重橋前"; Keiyu="千代田線"; Kyori=0.7; Jikan=1}; 
    {Kiten="二重橋前"; Shuten="大手町"; Keiyu="千代田線"; Kyori=0.7; Jikan=1}; 
    {Kiten="大手町"; Shuten="新御茶ノ水"; Keiyu="千代田線"; Kyori=1.3; Jikan=2}; 
    {Kiten="新御茶ノ水"; Shuten="湯島"; Keiyu="千代田線"; Kyori=1.2; Jikan=2}; 
    {Kiten="湯島"; Shuten="根津"; Keiyu="千代田線"; Kyori=1.2; Jikan=2}; 
    {Kiten="根津"; Shuten="千駄木"; Keiyu="千代田線"; Kyori=1.0; Jikan=2}; 
    {Kiten="千駄木"; Shuten="西日暮里"; Keiyu="千代田線"; Kyori=0.9; Jikan=1}; 
    {Kiten="西日暮里"; Shuten="町屋"; Keiyu="千代田線"; Kyori=1.7; Jikan=2}; 
    {Kiten="町屋"; Shuten="北千住"; Keiyu="千代田線"; Kyori=2.6; Jikan=3}; 
    {Kiten="北千住"; Shuten="綾瀬"; Keiyu="千代田線"; Kyori=2.5; Jikan=3}; 
    {Kiten="綾瀬"; Shuten="北綾瀬"; Keiyu="千代田線"; Kyori=2.1; Jikan=4}; 
    {Kiten="浅草"; Shuten="田原町"; Keiyu="銀座線"; Kyori=0.8; Jikan=2}; 
    {Kiten="田原町"; Shuten="稲荷町"; Keiyu="銀座線"; Kyori=0.7; Jikan=1}; 
    {Kiten="稲荷町"; Shuten="上野"; Keiyu="銀座線"; Kyori=0.7; Jikan=2}; 
    {Kiten="上野"; Shuten="上野広小路"; Keiyu="銀座線"; Kyori=0.5; Jikan=2}; 
    {Kiten="上野広小路"; Shuten="末広町"; Keiyu="銀座線"; Kyori=0.6; Jikan=1}; 
    {Kiten="末広町"; Shuten="神田"; Keiyu="銀座線"; Kyori=1.1; Jikan=2}; 
    {Kiten="神田"; Shuten="三越前"; Keiyu="銀座線"; Kyori=0.7; Jikan=1}; 
    {Kiten="三越前"; Shuten="日本橋"; Keiyu="銀座線"; Kyori=0.6; Jikan=2}; 
    {Kiten="日本橋"; Shuten="京橋"; Keiyu="銀座線"; Kyori=0.7; Jikan=2}; 
    {Kiten="京橋"; Shuten="銀座"; Keiyu="銀座線"; Kyori=0.7; Jikan=1}; 
    {Kiten="銀座"; Shuten="新橋"; Keiyu="銀座線"; Kyori=0.9; Jikan=2}; 
    {Kiten="新橋"; Shuten="虎ノ門"; Keiyu="銀座線"; Kyori=0.8; Jikan=2}; 
    {Kiten="虎ノ門"; Shuten="溜池山王"; Keiyu="銀座線"; Kyori=0.6; Jikan=2}; 
    {Kiten="溜池山王"; Shuten="赤坂見附"; Keiyu="銀座線"; Kyori=0.9; Jikan=2}; 
    {Kiten="赤坂見附"; Shuten="青山一丁目"; Keiyu="銀座線"; Kyori=1.3; Jikan=2}; 
    {Kiten="青山一丁目"; Shuten="外苑前"; Keiyu="銀座線"; Kyori=0.7; Jikan=2}; 
    {Kiten="外苑前"; Shuten="表参道"; Keiyu="銀座線"; Kyori=0.7; Jikan=1}; 
    {Kiten="表参道"; Shuten="渋谷"; Keiyu="銀座線"; Kyori=1.3; Jikan=1}; 
    {Kiten="渋谷"; Shuten="表参道"; Keiyu="半蔵門線"; Kyori=1.3; Jikan=2}; 
    {Kiten="表参道"; Shuten="青山一丁目"; Keiyu="半蔵門線"; Kyori=1.4; Jikan=2}; 
    {Kiten="青山一丁目"; Shuten="永田町"; Keiyu="半蔵門線"; Kyori=1.3; Jikan=2}; 
    {Kiten="永田町"; Shuten="半蔵門"; Keiyu="半蔵門線"; Kyori=1.0; Jikan=2}; 
    {Kiten="半蔵門"; Shuten="九段下"; Keiyu="半蔵門線"; Kyori=1.6; Jikan=2}; 
    {Kiten="九段下"; Shuten="神保町"; Keiyu="半蔵門線"; Kyori=0.4; Jikan=1}; 
    {Kiten="神保町"; Shuten="大手町"; Keiyu="半蔵門線"; Kyori=1.7; Jikan=3}; 
    {Kiten="大手町"; Shuten="三越前"; Keiyu="半蔵門線"; Kyori=0.7; Jikan=1}; 
    {Kiten="三越前"; Shuten="水天宮前"; Keiyu="半蔵門線"; Kyori=1.3; Jikan=2}; 
    {Kiten="水天宮前"; Shuten="清澄白河"; Keiyu="半蔵門線"; Kyori=1.7; Jikan=3}; 
    {Kiten="清澄白河"; Shuten="住吉"; Keiyu="半蔵門線"; Kyori=1.9; Jikan=3}; 
    {Kiten="住吉"; Shuten="錦糸町"; Keiyu="半蔵門線"; Kyori=1.; Jikan=2}; 
    {Kiten="錦糸町"; Shuten="押上"; Keiyu="半蔵門線"; Kyori=1.4; Jikan=2}; 
    {Kiten="中目黒"; Shuten="恵比寿"; Keiyu="日比谷線"; Kyori=1.; Jikan=2}; 
    {Kiten="恵比寿"; Shuten="広尾"; Keiyu="日比谷線"; Kyori=1.5; Jikan=3}; 
    {Kiten="広尾"; Shuten="六本木"; Keiyu="日比谷線"; Kyori=1.7; Jikan=3}; 
    {Kiten="六本木"; Shuten="神谷町"; Keiyu="日比谷線"; Kyori=1.5; Jikan=3}; 
    {Kiten="神谷町"; Shuten="霞ヶ関"; Keiyu="日比谷線"; Kyori=1.3; Jikan=2}; 
    {Kiten="霞ヶ関"; Shuten="日比谷"; Keiyu="日比谷線"; Kyori=1.2; Jikan=2}; 
    {Kiten="日比谷"; Shuten="銀座"; Keiyu="日比谷線"; Kyori=0.4; Jikan=1}; 
    {Kiten="銀座"; Shuten="東銀座"; Keiyu="日比谷線"; Kyori=0.4; Jikan=1}; 
    {Kiten="東銀座"; Shuten="築地"; Keiyu="日比谷線"; Kyori=0.6; Jikan=2}; 
    {Kiten="築地"; Shuten="八丁堀"; Keiyu="日比谷線"; Kyori=1.; Jikan=2}; 
    {Kiten="八丁堀"; Shuten="茅場町"; Keiyu="日比谷線"; Kyori=0.5; Jikan=1}; 
    {Kiten="茅場町"; Shuten="人形町"; Keiyu="日比谷線"; Kyori=0.9; Jikan=2}; 
    {Kiten="人形町"; Shuten="小伝馬町"; Keiyu="日比谷線"; Kyori=0.6; Jikan=1}; 
    {Kiten="小伝馬町"; Shuten="秋葉原"; Keiyu="日比谷線"; Kyori=0.9; Jikan=2}; 
    {Kiten="秋葉原"; Shuten="仲御徒町"; Keiyu="日比谷線"; Kyori=1.; Jikan=1}; 
    {Kiten="仲御徒町"; Shuten="上野"; Keiyu="日比谷線"; Kyori=0.5; Jikan=1}; 
    {Kiten="上野"; Shuten="入谷"; Keiyu="日比谷線"; Kyori=1.2; Jikan=2}; 
    {Kiten="入谷"; Shuten="三ノ輪"; Keiyu="日比谷線"; Kyori=1.2; Jikan=2}; 
    {Kiten="三ノ輪"; Shuten="南千住"; Keiyu="日比谷線"; Kyori=0.8; Jikan=2}; 
    {Kiten="南千住"; Shuten="北千住"; Keiyu="日比谷線"; Kyori=1.8; Jikan=3}; 
    {Kiten="池袋"; Shuten="新大塚"; Keiyu="丸ノ内線"; Kyori=1.8; Jikan=3}; 
    {Kiten="新大塚"; Shuten="茗荷谷"; Keiyu="丸ノ内線"; Kyori=1.2; Jikan=2}; 
    {Kiten="茗荷谷"; Shuten="後楽園"; Keiyu="丸ノ内線"; Kyori=1.8; Jikan=2}; 
    {Kiten="後楽園"; Shuten="本郷三丁目"; Keiyu="丸ノ内線"; Kyori=0.8; Jikan=1}; 
    {Kiten="本郷三丁目"; Shuten="御茶ノ水"; Keiyu="丸ノ内線"; Kyori=0.8; Jikan=1}; 
    {Kiten="御茶ノ水"; Shuten="淡路町"; Keiyu="丸ノ内線"; Kyori=0.8; Jikan=1}; 
    {Kiten="淡路町"; Shuten="大手町"; Keiyu="丸ノ内線"; Kyori=0.9; Jikan=2}; 
    {Kiten="大手町"; Shuten="東京"; Keiyu="丸ノ内線"; Kyori=0.6; Jikan=1}; 
    {Kiten="東京"; Shuten="銀座"; Keiyu="丸ノ内線"; Kyori=1.1; Jikan=2}; 
    {Kiten="銀座"; Shuten="霞ヶ関"; Keiyu="丸ノ内線"; Kyori=1.0; Jikan=2}; 
    {Kiten="霞ヶ関"; Shuten="国会議事堂前"; Keiyu="丸ノ内線"; Kyori=0.7; Jikan=1}; 
    {Kiten="国会議事堂前"; Shuten="赤坂見附"; Keiyu="丸ノ内線"; Kyori=0.9; Jikan=2}; 
    {Kiten="赤坂見附"; Shuten="四ツ谷"; Keiyu="丸ノ内線"; Kyori=1.3; Jikan=2}; 
    {Kiten="四ツ谷"; Shuten="四谷三丁目"; Keiyu="丸ノ内線"; Kyori=1.0; Jikan=2}; 
    {Kiten="四谷三丁目"; Shuten="新宿御苑前"; Keiyu="丸ノ内線"; Kyori=0.9; Jikan=1}; 
    {Kiten="新宿御苑前"; Shuten="新宿三丁目"; Keiyu="丸ノ内線"; Kyori=0.7; Jikan=1}; 
    {Kiten="新宿三丁目"; Shuten="新宿"; Keiyu="丸ノ内線"; Kyori=0.3; Jikan=1}; 
    {Kiten="新宿"; Shuten="西新宿"; Keiyu="丸ノ内線"; Kyori=0.8; Jikan=1}; 
    {Kiten="西新宿"; Shuten="中野坂上"; Keiyu="丸ノ内線"; Kyori=1.1; Jikan=2}; 
    {Kiten="中野坂上"; Shuten="新中野"; Keiyu="丸ノ内線"; Kyori=1.1; Jikan=2}; 
    {Kiten="新中野"; Shuten="東高円寺"; Keiyu="丸ノ内線"; Kyori=1.0; Jikan=1}; 
    {Kiten="東高円寺"; Shuten="新高円寺"; Keiyu="丸ノ内線"; Kyori=0.9; Jikan=1}; 
    {Kiten="新高円寺"; Shuten="南阿佐ヶ谷"; Keiyu="丸ノ内線"; Kyori=1.2; Jikan=2}; 
    {Kiten="南阿佐ヶ谷"; Shuten="荻窪"; Keiyu="丸ノ内線"; Kyori=1.5; Jikan=2}; 
    {Kiten="中野坂上"; Shuten="中野新橋"; Keiyu="丸ノ内線"; Kyori=1.3; Jikan=2}; 
    {Kiten="中野新橋"; Shuten="中野富士見町"; Keiyu="丸ノ内線"; Kyori=0.6; Jikan=1}; 
    {Kiten="中野富士見町"; Shuten="方南町"; Keiyu="丸ノ内線"; Kyori=1.3; Jikan=2}; 
    {Kiten="市ヶ谷"; Shuten="四ツ谷"; Keiyu="南北線"; Kyori=1.0; Jikan=2}; 
    {Kiten="四ツ谷"; Shuten="永田町"; Keiyu="南北線"; Kyori=1.3; Jikan=3}; 
    {Kiten="永田町"; Shuten="溜池山王"; Keiyu="南北線"; Kyori=0.9; Jikan=1}; 
    {Kiten="溜池山王"; Shuten="六本木一丁目"; Keiyu="南北線"; Kyori=0.9; Jikan=2}; 
    {Kiten="六本木一丁目"; Shuten="麻布十番"; Keiyu="南北線"; Kyori=1.2; Jikan=2}; 
    {Kiten="麻布十番"; Shuten="白金高輪"; Keiyu="南北線"; Kyori=1.3; Jikan=2}; 
    {Kiten="白金高輪"; Shuten="白金台"; Keiyu="南北線"; Kyori=1.0; Jikan=2}; 
    {Kiten="白金台"; Shuten="目黒"; Keiyu="南北線"; Kyori=1.3; Jikan=2}; 
    {Kiten="市ヶ谷"; Shuten="飯田橋"; Keiyu="南北線"; Kyori=1.1 ; Jikan=2}; 
    {Kiten="飯田橋"; Shuten="後楽園"; Keiyu="南北線"; Kyori=1.4 ; Jikan=2}; 
    {Kiten="後楽園"; Shuten="東大前"; Keiyu="南北線"; Kyori=1.3 ; Jikan=3}; 
    {Kiten="東大前"; Shuten="本駒込"; Keiyu="南北線"; Kyori=0.9 ; Jikan=2}; 
    {Kiten="本駒込"; Shuten="駒込"; Keiyu="南北線"; Kyori=1.4; Jikan=2}; 
    {Kiten="駒込"; Shuten="西ヶ原"; Keiyu="南北線"; Kyori=1.4; Jikan=2}; 
    {Kiten="西ヶ原"; Shuten="王子"; Keiyu="南北線"; Kyori=1.0; Jikan=2}; 
    {Kiten="王子"; Shuten="王子神谷"; Keiyu="南北線"; Kyori=1.2; Jikan=2}; 
    {Kiten="王子神谷"; Shuten="志茂"; Keiyu="南北線"; Kyori=1.6; Jikan=3}; 
    {Kiten="志茂"; Shuten="赤羽岩淵"; Keiyu="南北線"; Kyori=1.1; Jikan=2}; 
    {Kiten="西船橋" ; Shuten="原木中山"; Keiyu="東西線"; Kyori=1.9; Jikan=3}; 
    {Kiten="原木中山"; Shuten="妙典"; Keiyu="東西線"; Kyori=2.1 ; Jikan=2}; 
    {Kiten="妙典"; Shuten="行徳"; Keiyu="東西線"; Kyori=1.3 ; Jikan=2}; 
    {Kiten="行徳"; Shuten="南行徳"; Keiyu="東西線"; Kyori=1.5 ; Jikan=2}; 
    {Kiten="南行徳"; Shuten="浦安" ; Keiyu="東西線"; Kyori=1.2 ; Jikan=2}; 
    {Kiten="浦安" ; Shuten="葛西"; Keiyu="東西線"; Kyori=1.9 ; Jikan=2}; 
    {Kiten="葛西"; Shuten="西葛西"; Keiyu="東西線"; Kyori=1.2 ; Jikan=2}; 
    {Kiten="西葛西"; Shuten="南砂町"; Keiyu="東西線"; Kyori=2.7 ; Jikan=2}; 
    {Kiten="南砂町"; Shuten="東陽町"; Keiyu="東西線"; Kyori=1.2 ; Jikan=2}; 
    {Kiten="東陽町"; Shuten="木場" ; Keiyu="東西線"; Kyori=0.9 ; Jikan=1}; 
    {Kiten="木場"; Shuten="門前仲町"; Keiyu="東西線"; Kyori=1.1 ; Jikan=1}; 
    {Kiten="門前仲町"; Shuten="茅場町"; Keiyu="東西線"; Kyori=1.8 ; Jikan=2}; 
    {Kiten="茅場町"; Shuten="日本橋"; Keiyu="東西線"; Kyori=0.5 ; Jikan=1}; 
    {Kiten="日本橋"; Shuten="大手町"; Keiyu="東西線"; Kyori=0.8 ; Jikan=1}; 
    {Kiten="大手町"; Shuten="竹橋"; Keiyu="東西線"; Kyori=1.0; Jikan=2}; 
    {Kiten="竹橋"; Shuten="九段下"; Keiyu="東西線"; Kyori=1.0; Jikan=1}; 
    {Kiten="九段下"; Shuten="飯田橋"; Keiyu="東西線"; Kyori=0.7; Jikan=1}; 
    {Kiten="飯田橋"; Shuten="神楽坂"; Keiyu="東西線"; Kyori=1.2; Jikan=2}; 
    {Kiten="神楽坂"; Shuten="早稲田"; Keiyu="東西線"; Kyori=1.2; Jikan=2}; 
    {Kiten="早稲田"; Shuten="高田馬場"; Keiyu="東西線"; Kyori=1.7; Jikan=3}; 
    {Kiten="高田馬場"; Shuten="落合"; Keiyu="東西線"; Kyori=1.9; Jikan=3}; 
    {Kiten="落合"; Shuten="中野"; Keiyu="東西線"; Kyori=2.0; Jikan=3}; 
    {Kiten="新木場"; Shuten="辰巳"; Keiyu="有楽町線"; Kyori=1.5; Jikan=2}; 
    {Kiten="辰巳"; Shuten="豊洲"; Keiyu="有楽町線"; Kyori=1.7; Jikan=2}; 
    {Kiten="豊洲"; Shuten="月島"; Keiyu="有楽町線"; Kyori=1.4; Jikan=2}; 
    {Kiten="月島"; Shuten="新富町"; Keiyu="有楽町線"; Kyori=1.3; Jikan=2}; 
    {Kiten="新富町"; Shuten="銀座一丁目"; Keiyu="有楽町線"; Kyori=0.7; Jikan=1}; 
    {Kiten="銀座一丁目"; Shuten="有楽町"; Keiyu="有楽町線"; Kyori=0.5; Jikan=1}; 
    {Kiten="有楽町"; Shuten="桜田門"; Keiyu="有楽町線"; Kyori=1.0; Jikan=1}; 
    {Kiten="桜田門"; Shuten="永田町"; Keiyu="有楽町線"; Kyori=0.9; Jikan=2}; 
    {Kiten="永田町"; Shuten="麹町"; Keiyu="有楽町線"; Kyori=0.9; Jikan=1}; 
    {Kiten="麹町"; Shuten="市ヶ谷"; Keiyu="有楽町線"; Kyori=0.9; Jikan=1}; 
    {Kiten="市ヶ谷"; Shuten="飯田橋"; Keiyu="有楽町線"; Kyori=1.1; Jikan=2}; 
    {Kiten="飯田橋"; Shuten="江戸川橋"; Keiyu="有楽町線"; Kyori=1.6; Jikan=3}; 
    {Kiten="江戸川橋"; Shuten="護国寺"; Keiyu="有楽町線"; Kyori=1.3; Jikan=2}; 
    {Kiten="護国寺"; Shuten="東池袋"; Keiyu="有楽町線"; Kyori=1.1; Jikan=2}; 
    {Kiten="東池袋"; Shuten="池袋"; Keiyu="有楽町線"; Kyori=2.0; Jikan=2}; 
    {Kiten="池袋"; Shuten="要町"; Keiyu="有楽町線"; Kyori=1.2; Jikan=2}; 
    {Kiten="要町"; Shuten="千川"; Keiyu="有楽町線"; Kyori=1.0; Jikan=1}; 
    {Kiten="千川"; Shuten="小竹向原"; Keiyu="有楽町線"; Kyori=1.0; Jikan=2}; 
    {Kiten="小竹向原"; Shuten="氷川台"; Keiyu="有楽町線"; Kyori=1.5; Jikan=2}; 
    {Kiten="氷川台"; Shuten="平和台"; Keiyu="有楽町線"; Kyori=1.4; Jikan=2}; 
    {Kiten="平和台"; Shuten="営団赤塚"; Keiyu="有楽町線"; Kyori=1.8; Jikan=2}; 
    {Kiten="営団赤塚"; Shuten="営団成増"; Keiyu="有楽町線"; Kyori=1.5; Jikan=2}; 
    {Kiten="営団成増"; Shuten="和光市"; Keiyu="有楽町線"; Kyori=2.1; Jikan=3}; 
] 

let hyoji ekimei =
    sprintf "%s, %s(%s)" ekimei.Shozoku ekimei.Kanji ekimei.Kana

let rec romajiToKanji romaji ekimeiList =
    match ekimeiList with
    | [] -> ""
    | e::es -> if e.Romaji = romaji then e.Kanji else (romajiToKanji romaji es)

let rec getEkikanKyori kanji1 kanji2 ekikanList =
    match ekikanList with
    | [] -> infinity
    | {Kiten=kiten; Shuten=shuten; Kyori=kyori}::es -> 
        if (kiten=kanji1 && shuten=kanji2) || (kiten=kanji2 && shuten=kanji1) then
            kyori
        else
            getEkikanKyori kanji1 kanji2 es
            
let rec kyoriWoHyoji romaji1 romaji2 ekimeiList ekikanList = 
    let kanji1 = romajiToKanji romaji1 ekimeiList in
    let kanji2 = romajiToKanji romaji2 ekimeiList in
        if kanji1="" then 
            sprintf "%sという駅は存在しません" romaji1
        else if kanji2="" then
            sprintf "%sという駅は存在しません" romaji2
        else 
            let kyori = getEkikanKyori kanji1 kanji2 ekikanList in
                if kyori = infinity then 
                    sprintf "%s駅と%s駅はつながっていません" kanji1 kanji2
                else 
                    sprintf "%s駅から%s駅までは%0.1fkmです" kanji1 kanji2 kyori

let makeEkiList ekimeiList =
    List.map (fun ekimei -> {Namae=ekimei.Kanji; SaitanKyori=infinity; TemaeList=[]}) ekimeiList

let shokika ekimeiList kiten =
    List.map (fun e -> if e.Namae = kiten then {Namae=e.Namae; SaitanKyori=0.0; TemaeList=[]} else e) ekimeiList

let makeInitialEkiList ekimeiList kiten = 
    List.map (fun ekimei -> 
        if ekimei.Kanji = kiten then
            {Namae=ekimei.Kanji; SaitanKyori=0.0; TemaeList=[ekimei.Kanji]}
        else
            {Namae=ekimei.Kanji; SaitanKyori=infinity; TemaeList=[]}
    ) ekimeiList

let rec ekimeiInsert ekimeiList ekimei =
    match ekimeiList with
    | [] -> [ekimei]
    | e::es -> 
        if ekimei.Kana = e.Kana then
            ekimeiList
        else if ekimei.Kana < e.Kana then
            ekimei::ekimeiList
        else
            e::(ekimeiInsert es ekimei)

let rec seiretsu ekimeiList =
    match ekimeiList with
    | [] -> []
    | e::es -> ekimeiInsert (seiretsu es) e

let koushin p v ekikanList =
    List.map (fun q ->
        let kyori = getEkikanKyori p.Namae q.Namae ekikanList in
        if kyori = infinity || p.SaitanKyori + kyori >= q.SaitanKyori then
            q
        else
            {Namae=q.Namae; SaitanKyori=p.SaitanKyori + kyori; TemaeList=q.Namae::p.TemaeList}
    ) v


let saitanWoBunri lst =  
    match lst with 
    | [] -> ({Namae=""; SaitanKyori=infinity; TemaeList=[]}, [])
    | x::xs -> 
        List.fold 
            (fun (e1, es) e2 -> if e1.SaitanKyori < e2.SaitanKyori then (e1, e2::es) else (e2, e1::es))
            (x, [])
            xs

let rec dijkstraMain ekiList ekikanList = 
    match ekiList with
    | [] -> []
    | e::es ->
        let (f, fs) = saitanWoBunri (e::es) in
        let gs = koushin f fs ekikanList in
        f :: dijkstraMain gs ekikanList


let dijkstra startRomaji endRomaji = 
    let startKanji = romajiToKanji startRomaji (seiretsu globalEkimeiList) in
    let endKanji = romajiToKanji endRomaji (seiretsu globalEkimeiList) in
    let ekiList = dijkstraMain (makeInitialEkiList globalEkimeiList startKanji) globalEkikanList in
    List.find (fun eki -> eki.Namae = endKanji) ekiList

let rec assoc key d = 
    match d with
    | [] -> infinity
    | (k, v)::e -> if k = key then v else (assoc key e)

let insertEkikan ekikanTree ekikan =
    let a = {Kiten=ekikan.Kiten; Shuten=ekikan.Shuten; Keiyu=ekikan.Keiyu; Kyori=ekikan.Kyori; Jikan=ekikan.Jikan} in 
    let b = {Kiten=ekikan.Shuten; Shuten=ekikan.Kiten; Keiyu=ekikan.Keiyu; Kyori=ekikan.Kyori; Jikan=ekikan.Jikan} in 
    let rec insert ekikanTree ekikan = 
        match ekikanTree with
        | Empty -> Node (Empty, ekikan.Kiten, [(ekikan.Shuten, ekikan.Kyori)], Empty) 
        | Node(left, ekimei, lst, right) ->
            if ekikan.Kiten < ekimei then
                Node (insert left ekikan, ekimei, lst, right)
            else if ekikan.Kiten > ekimei then
                Node (left, ekimei, lst, insert right ekikan)
            else
                Node (left, ekimei, (ekikan.Shuten, ekikan.Kyori) :: lst, right)
    in
    insert (insert ekikanTree a) b

let insertsEkikan ekikanTree ekikanList =
    List.fold (insertEkikan) ekikanTree ekikanList