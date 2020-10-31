module Chapter17

type Nengou = Meiji of int
            | Taisho of int
            | Showa of int
            | Heisei of int

let toSeireki nengou = match nengou with
    | Meiji(n) -> n + 1867
    | Taisho(n) -> n + 1911
    | Showa(n) -> n + 1925
    | Heisei(n) -> n + 1988

let nenrei birthYear currentYear = (toSeireki currentYear) - (toSeireki birthYear)

type Year = January of int
           | February of int
           | March of int
           | April of int
           | May of int
           | June of int
           | July of int
           | August of int
           | September of int
           | October of int
           | November of int
           | December of int

type Seiza = Aries
           | Taurus
           | Gemini
           | Cancer
           | Leo
           | Virgo
           | Libra
           | Scorpio
           | Sagittarius
           | Capricorn
           | Aquarius
           | Pisces

let seiza year = match year with 
  | January (hi) -> if hi <= 19 then Capricorn else Aquarius 
  | February (hi) -> if hi <= 18 then Aquarius else Pisces 
  | March (hi) -> if hi <= 20 then Pisces else Aries 
  | April (hi) -> if hi <= 19 then Aries else Taurus 
  | May (hi) -> if hi <= 20 then Taurus else Gemini 
  | June (hi) -> if hi <= 21 then Gemini else Cancer 
  | July (hi) -> if hi <= 22 then Cancer else Leo 
  | August (hi) -> if hi <= 22 then Leo else Virgo 
  | September (hi) -> if hi <= 22 then Virgo else Libra 
  | October (hi) -> if hi <= 23 then Libra else Scorpio 
  | November (hi) -> if hi <= 21 then Scorpio else Sagittarius 
  | December (hi) -> if hi <= 21 then Sagittarius else Scorpio 