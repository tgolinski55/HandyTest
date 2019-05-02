﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    internal static class TaxOfficeCodes
    {
        public static string[] Codes = new[]
        {
            "101", // Dolnośląski Urząd Skarbowy we Wrocławiu
            "102", // Kujawsko-Pomorski Urząd Skarbowy w Bydgoszczy
            "103", // Lubelski Urząd Skarbowy w Lublinie
            "104", // Lubuski Urząd Skarbowy w Zielonej Górze
            "105", // Łódzki Urząd Skarbowy w Łodzi
            "106", // Małopolski Urząd Skarbowy w Krakowie
            "107", // Pierwszy Mazowiecki Urząd Skarbowy w Warszawie
            "108", // Drugi Mazowiecki Urząd Skarbowy w Warszawie
            "109", // Trzeci Mazowiecki Urząd Skarbowy w Radomiu
            "111", // Urząd Skarbowy Warszawa-Mokotów
            "112", // Urząd Skarbowy Warszawa-Bemowo
            "113", // Urząd Skarbowy Warszawa-Praga
            "114", // Urząd Skarbowy Warszawa-Targówek
            "115", // Pierwszy Urząd Skarbowy Warszawa-Śródmieście
            "116", // Drugi Urząd Skarbowy Warszawa-Śródmieście
            "117", // Urząd Skarbowy Warszawa-Wola
            "118", // Urząd Skarbowy Warszawa-Bielany
            "119", // Urząd Skarbowy w Grodzisku Mazowieckim
            "121", // Urząd Skarbowy w Nowym Dworze Mazowieckim
            "122", // Urząd Skarbowy w Otwocku
            "123", // Urząd Skarbowy w Piasecznie
            "124", // Urząd Skarbowy w Pruszkowie
            "125", // Urząd Skarbowy w Wołominie
            "126", // Urząd Skarbowy w Białej Podlaskiej
            "127", // Urząd Skarbowy w Parczewie
            "128", // Urząd Skarbowy w Radzyniu Podlaskim
            "129", // Pierwszy Urząd Skarbowy w Białymstoku
            "131", // Urząd Skarbowy w Bielsku Podlaskim
            "132", // Urząd Skarbowy w Mońkach
            "133", // Urząd Skarbowy w Siemiatyczach
            "134", // Urząd Skarbowy w Sokółce
            "135", // Pierwszy Urząd Skarbowy w Bielsku-Białej
            "136", // Urząd Skarbowy w Cieszynie
            "137", // Urząd Skarbowy w Oświęcimiu
            "138", // Urząd Skarbowy w Suchej Beskidzkiej
            "139", // Urząd Skarbowy w Wadowicach
            "141", // Urząd Skarbowy w Żywcu
            "142", // Pierwszy Urząd Skarbowy w Bydgoszczy
            "143", // Urząd Skarbowy w Chojnicach
            "144", // Urząd Skarbowy w Inowrocławiu
            "145", // Urząd Skarbowy w Mogilnie
            "146", // Urząd Skarbowy w Nakle nad Notecią
            "147", // Urząd Skarbowy w Świeciu
            "148", // Urząd Skarbowy w Tucholi
            "149", // Urząd Skarbowy w Żninie
            "151", // Urząd Skarbowy w Chełmie
            "152", // Urząd Skarbowy w Krasnymstawie
            "153", // Urząd Skarbowy we Włodawie
            "154", // Urząd Skarbowy w Ciechanowie
            "155", // Urząd Skarbowy w Działdowie
            "156", // Urząd Skarbowy w Mławie
            "157", // Urząd Skarbowy w Płońsku
            "158", // Urząd Skarbowy w Pułtusku
            "159", // Pierwszy Urząd Skarbowy w Częstochowie
            "161", // Urząd Skarbowy w Kłobucku
            "162", // Urząd Skarbowy w Lublińcu
            "163", // Urząd Skarbowy w Myszkowie
            "164", // Urząd Skarbowy w Oleśnie
            "165", // Urząd Skarbowy w Braniewie
            "166", // Urząd Skarbowy w Elblągu
            "167", // Urząd Skarbowy w Kwidzynie
            "168", // Urząd Skarbowy w Malborku
            "169", // Pierwszy Urząd Skarbowy w Gdańsku
            "171", // Drugi Urząd Skarbowy w Gdańsku
            "172", // Pierwszy Urząd Skarbowy w Gdyni
            "173", // Urząd Skarbowy w Kartuzach
            "174", // Urząd Skarbowy w Kościerzynie
            "175", // Urząd Skarbowy w Pucku
            "176", // Urząd Skarbowy w Sopocie
            "177", // Urząd Skarbowy w Starogardzie Gdańskim
            "178", // Urząd Skarbowy w Tczewie
            "179", // Urząd Skarbowy w Wejherowie
            "181", // Urząd Skarbowy w Choszcznie
            "182", // Urząd Skarbowy w Gorzowie Wielkopolskim
            "183", // Urząd Skarbowy w Myśliborzu
            "184", // Urząd Skarbowy w Międzychodzie
            "185", // Urząd Skarbowy w Międzyrzeczu
            "186", // Urząd Skarbowy w Słubicach
            "187", // Urząd Skarbowy w Bolesławcu
            "188", // Urząd Skarbowy w Jeleniej Górze
            "189", // Urząd Skarbowy w Kamiennej Górze
            "191", // Urząd Skarbowy w Lubaniu
            "192", // Urząd Skarbowy w Lwówku Śląskim
            "193", // Urząd Skarbowy w Zgorzelcu
            "194", // Urząd Skarbowy w Jarocinie
            "195", // Pierwszy Urząd Skarbowy w Kaliszu
            "196", // Urząd Skarbowy w Kępnie
            "197", // Urząd Skarbowy w Krotoszynie
            "198", // Urząd Skarbowy w Ostrowie Wielkopolskim
            "199", // Urząd Skarbowy w Będzinie
            "201", // Opolski Urząd Skarbowy w Opolu
            "202", // Podkarpacki Urząd Skarbowy w Rzeszowie
            "203", // Podlaski Urząd Skarbowy w Białymstoku
            "204", // Pomorski Urząd Skarbowy w Gdańsku
            "205", // Pierwszy Śląski Urząd Skarbowy w Sosnowcu
            "206", // Drugi Śląski Urząd Skarbowy w Bielsku-Białej
            "207", // Świętokrzyski Urząd Skarbowy w Kielcach
            "208", // Warmińsko-Mazurski Urząd Skarbowy w Olsztynie
            "209", // Pierwszy Wielkopolski Urząd Skarbowy w Poznaniu
            "211", // Urząd Skarbowy w Bytomiu
            "212", // Urząd Skarbowy w Chorzowie
            "213", // Urząd Skarbowy w Chrzanowie
            "214", // Urząd Skarbowy w Czechowicach-Dziedzicach
            "215", // Urząd Skarbowy w Dąbrowie Górniczej
            "216", // Pierwszy Urząd Skarbowy w Gliwicach
            "217", // Urząd Skarbowy w Jastrzębiu-Zdroju
            "218", // Urząd Skarbowy w Jaworznie
            "219", // Pierwszy Urząd Skarbowy w Katowicach
            "221", // Urząd Skarbowy w Mikołowie
            "222", // Urząd Skarbowy w Mysłowicach
            "223", // Urząd Skarbowy w Olkuszu
            "224", // Urząd Skarbowy w Pszczynie
            "225", // Urząd Skarbowy w Raciborzu
            "226", // Urząd Skarbowy w Rudzie Śląskiej
            "227", // Urząd Skarbowy w Rybniku
            "228", // Urząd Skarbowy w Siemianowicach Śląskich
            "229", // Urząd Skarbowy w Sosnowcu
            "231", // Urząd Skarbowy w Tarnowskich Górach
            "232", // Urząd Skarbowy w Tychach
            "233", // Urząd Skarbowy w Wodzisławiu Śląskim
            "234", // Urząd Skarbowy w Zabrzu
            "235", // Urząd Skarbowy w Zawierciu
            "236", // Urząd Skarbowy w Żorach
            "237", // Urząd Skarbowy w Busku-Zdroju
            "238", // Urząd Skarbowy w Jędrzejowie
            "239", // Pierwszy Urząd Skarbowy w Kielcach
            "241", // Urząd Skarbowy w Końskich
            "242", // Urząd Skarbowy w Miechowie
            "243", // Urząd Skarbowy w Ostrowcu Świętokrzyskim
            "244", // Urząd Skarbowy w Pińczowie
            "245", // Urząd Skarbowy w Starachowicach
            "246", // Urząd Skarbowy w Skarżysku-Kamiennej
            "247", // Urząd Skarbowy w Kole
            "248", // Urząd Skarbowy w Koninie
            "249", // Urząd Skarbowy w Słupcy
            "251", // Urząd Skarbowy w Turku
            "252", // Urząd Skarbowy w Białogardzie
            "253", // Urząd Skarbowy w Drawsku Pomorskim
            "254", // Urząd Skarbowy w Kołobrzegu
            "255", // Pierwszy Urząd Skarbowy w Koszalinie
            "256", // Urząd Skarbowy w Szczecinku
            "257", // Urząd Skarbowy Kraków-Krowodrza
            "258", // Urząd Skarbowy Kraków-Nowa Huta
            "259", // Urząd Skarbowy Kraków-Podgórze
            "261", // Urząd Skarbowy w Kraków-Śródmieście
            "262", // Urząd Skarbowy w Kraków-Stare Miasto
            "263", // Urząd Skarbowy w Myślenicach
            "264", // Urząd Skarbowy w Proszowicach
            "265", // Urząd Skarbowy w Wieliczce
            "266", // Urząd Skarbowy w Brzozowie
            "267", // Urząd Skarbowy w Jaśle
            "268", // Urząd Skarbowy w Krośnie
            "269", // Urząd Skarbowy w Lesku
            "271", // Urząd Skarbowy w Sanoku
            "272", // Urząd Skarbowy w Ustrzykach Dolnych
            "273", // Urząd Skarbowy w Głogowie
            "274", // Urząd Skarbowy w Jaworze
            "275", // Urząd Skarbowy w Legnicy
            "276", // Urząd Skarbowy w Lubinie
            "277", // Urząd Skarbowy w Złotoryi
            "278", // Urząd Skarbowy w Gostyniu
            "279", // Urząd Skarbowy w Kościanie
            "281", // Urząd Skarbowy w Lesznie
            "282", // Urząd Skarbowy w Rawiczu
            "283", // Urząd Skarbowy w Kraśniku
            "284", // Urząd Skarbowy w Lubartowie
            "285", // Pierwszy Urząd Skarbowy w Lublinie
            "286", // Drugi Urząd Skarbowy w Lublinie
            "287", // Urząd Skarbowy w Opolu Lubelskim
            "288", // Urząd Skarbowy w Puławach
            "289", // Urząd Skarbowy w Grajewie
            "291", // Urząd Skarbowy w Kolnie
            "292", // Urząd Skarbowy w Łomży
            "293", // Urząd Skarbowy w Wysokiem Mazowieckim
            "294", // Urząd Skarbowy w Zambrowie
            "295", // Urząd Skarbowy w Głownie
            "296", // Pierwszy Urząd Skarbowy Łódź-Bałuty
            "297", // Pierwszy Urząd Skarbowy Łódź-Górna
            "298", // Urząd Skarbowy Łódź-Polesie
            "301", // Drugi Wielkopolski Urząd Skarbowy w Kaliszu
            "302", // Zachodniopomorski Urząd Skarbowy w Szczecinie
            "311", // Urząd Skarbowy Łódź-Śródmieście
            "312", // Urząd Skarbowy Łódź-Widzew
            "313", // Urząd Skarbowy w Pabianicach
            "314", // Urząd Skarbowy w Zgierzu
            "315", // Urząd Skarbowy w Gorlicach
            "316", // Urząd Skarbowy w Limanowej
            "317", // Urząd Skarbowy w Nowym Sączu
            "318", // Urząd Skarbowy w Nowym Targu
            "319", // Urząd Skarbowy w Zakopanem
            "321", // Urząd Skarbowy w Bartoszycach
            "322", // Urząd Skarbowy w Iławie
            "323", // Urząd Skarbowy w Kętrzynie
            "324", // Urząd Skarbowy w Olsztynie
            "325", // Urząd Skarbowy w Ostródzie
            "326", // Urząd Skarbowy w Szczytnie
            "327", // Urząd Skarbowy w Brzegu
            "328", // Urząd Skarbowy w Głubczycach
            "329", // Urząd Skarbowy w Kędzierzynie-Koźlu
            "331", // Urząd Skarbowy w Kluczborku
            "332", // Urząd Skarbowy w Namysłowie
            "333", // Urząd Skarbowy w Nysie
            "334", // Pierwszy Urząd Skarbowy w Opolu
            "335", // Urząd Skarbowy w Prudniku
            "336", // Urząd Skarbowy w Strzelcach Opolskich
            "337", // Urząd Skarbowy w Makowie Mazowieckim
            "338", // Urząd Skarbowy w Ostrołęce
            "339", // Urząd Skarbowy w Ostrowi Mazowieckiej
            "341", // Urząd Skarbowy w Przasnyszu
            "342", // Urząd Skarbowy w Wyszkowie
            "343", // Urząd Skarbowy w Czarnkowie
            "344", // Urząd Skarbowy w Pile
            "345", // Urząd Skarbowy w Wałczu
            "346", // Urząd Skarbowy w Wągrowcu
            "347", // Urząd Skarbowy w Złotowie
            "348", // Urząd Skarbowy w Bełchatowie
            "349", // Urząd Skarbowy w Opocznie
            "351", // Urząd Skarbowy w Piotrkowie Trybunalskim
            "352", // Urząd Skarbowy w Radomsku
            "353", // Urząd Skarbowy w Tomaszowie Mazowieckim
            "354", // Urząd Skarbowy w Kutnie
            "355", // Urząd Skarbowy w Płocku
            "356", // Urząd Skarbowy w Sierpcu
            "357", // Urząd Skarbowy w Gnieźnie
            "358", // Urząd Skarbowy w Nowym Tomyślu
            "359", // Urząd Skarbowy Poznań-Grunwald
            "361", // Urząd Skarbowy Poznań-Jeżyce
            "362", // Urząd Skarbowy Poznań-Nowe Miasto
            "363", // Pierwszy Urząd Skarbowy Poznań
            "364", // Urząd Skarbowy Poznań-Śródmieście
            "365", // Urząd Skarbowy Poznań-Wilda
            "366", // Urząd Skarbowy w Szamotułach
            "367", // Urząd Skarbowy w Śremie
            "368", // Urząd Skarbowy w Środzie Wielkopolskiej
            "369", // Urząd Skarbowy we Wrześni
            "371", // Urząd Skarbowy w Jarosławiu
            "372", // Urząd Skarbowy w Lubaczowie
            "373", // Urząd Skarbowy w Przemyślu
            "374", // Urząd Skarbowy w Przeworsku
            "375", // Urząd Skarbowy w Białobrzegach
            "376", // Urząd Skarbowy w Grójcu
            "377", // Urząd Skarbowy w Kozienicach
            "378", // Pierwszy Urząd Skarbowy w Radomiu
            "379", // Urząd Skarbowy w Szydłowcu
            "381", // Urząd Skarbowy w Zwoleniu
            "382", // Urząd Skarbowy w Kolbuszowej
            "383", // Urząd Skarbowy w Leżajsku
            "384", // Urząd Skarbowy w Łańcucie
            "385", // Urząd Skarbowy w Mielcu
            "386", // Urząd Skarbowy w Ropczycach
            "387", // Urząd Skarbowy w Rzeszowie
            "388", // Urząd Skarbowy w Strzyżowie
            "389", // Urząd Skarbowy w Garwolinie
            "391", // Urząd Skarbowy w Łukowie
            "392", // Urząd Skarbowy w Mińsku Mazowieckim
            "393", // Urząd Skarbowy w Siedlcach
            "394", // Urząd Skarbowy w Sokołowie Podlaskim
            "395", // Urząd Skarbowy w Węgrowie
            "396", // Urząd Skarbowy w Łasku
            "397", // Urząd Skarbowy w Poddębicach
            "398", // Urząd Skarbowy w Sieradzu
            "399", // Urząd Skarbowy w Wieluniu
            "411", // Urząd Skarbowy w Zduńskiej Woli
            "412", // Urząd Skarbowy w Brzezinach
            "413", // Urząd Skarbowy w Łowiczu
            "414", // Urząd Skarbowy w Rawie Mazowieckiej
            "415", // Urząd Skarbowy w Skierniewicach
            "416", // Urząd Skarbowy w Sochaczewie
            "417", // Urząd Skarbowy w Żyrardowie
            "418", // Urząd Skarbowy w Bytowie
            "419", // Urząd Skarbowy w Człuchowie
            "421", // Urząd Skarbowy w Lęborku
            "422", // Urząd Skarbowy w Słupsku
            "423", // Urząd Skarbowy w Augustowie
            "424", // Urząd Skarbowy w Ełku
            "425", // Urząd Skarbowy w Giżycku
            "426", // Urząd Skarbowy w Olecku
            "427", // Urząd Skarbowy w Piszu
            "428", // Urząd Skarbowy w Suwałkach
            "429", // Urząd Skarbowy w Goleniowie
            "431", // Urząd Skarbowy w Gryficach
            "432", // Urząd Skarbowy w Gryfinie
            "433", // Urząd Skarbowy w Pyrzycach
            "434", // Urząd Skarbowy w Stargardzie Szczecińskim
            "435", // Pierwszy Urząd Skarbowy w Szczecinie
            "436", // Drugi Urząd Skarbowy w Szczecinie
            "437", // Urząd Skarbowy w Świnoujściu
            "438", // Urząd Skarbowy w Janowie Lubelskim
            "439", // Urząd Skarbowy w Opatowie
            "441", // Urząd Skarbowy w Sandomierzu
            "442", // Urząd Skarbowy w Stalowej Woli
            "443", // Urząd Skarbowy w Staszowie
            "444", // Urząd Skarbowy w Tarnobrzegu
            "445", // Urząd Skarbowy w Bochni
            "446", // Urząd Skarbowy w Brzesku
            "447", // Urząd Skarbowy w Dąbrowie Tarnowskiej
            "448", // Urząd Skarbowy w Dębicy
            "449", // Pierwszy Urząd Skarbowy w Tarnowie
            "451", // Urząd Skarbowy w Brodnicy
            "452", // Urząd Skarbowy w Chełmnie
            "453", // Urząd Skarbowy w Grudziądzu
            "454", // Urząd Skarbowy w Nowym Mieście Lubawskim
            "455", // Drugi Urząd Skarbowy w Toruniu
            "456", // Urząd Skarbowy w Wąbrzeźnie
            "457", // Urząd Skarbowy w Bystrzycy Kłodzkiej
            "458", // Urząd Skarbowy w Dzierżoniowie
            "459", // Urząd Skarbowy w Kłodzku
            "461", // Urząd Skarbowy w Nowej Rudzie
            "462", // Urząd Skarbowy w Świdnicy
            "463", // Urząd Skarbowy w Wałbrzychu
            "464", // Urząd Skarbowy w Ząbkowicach Śląskich
            "465", // Urząd Skarbowy w Aleksandrowie Kujawskim
            "466", // Urząd Skarbowy w Lipnie
            "467", // Urząd Skarbowy w Radziejowie
            "468", // Urząd Skarbowy w Rypinie
            "469", // Urząd Skarbowy we Włocławku
            "471", // Urząd Skarbowy Wrocław-Fabryczna
            "472", // Urząd Skarbowy Wrocław-Krzyki
            "473", // Urząd Skarbowy Wrocław-Psie Pole
            "474", // Urząd Skarbowy Wrocław-Stare Miasto
            "475", // Pierwszy Urząd Skarbowy we Wrocławiu
            "476", // Drugi Urząd Skarbowy Wrocław-Śródmieście
            "477", // Urząd Skarbowy w Miliczu
            "478", // Urząd Skarbowy w Oleśnicy
            "479", // Urząd Skarbowy w Oławie
            "481", // Urząd Skarbowy w Strzelnie
            "482", // Urząd Skarbowy w Środzie Śląskiej
            "483", // Urząd Skarbowy w Trzebnicy
            "484", // Urząd Skarbowy w Biłgoraju
            "485", // Urząd Skarbowy w Hrubieszowie
            "486", // Urząd Skarbowy w Tomaszowie Lubelskim
            "487", // Urząd Skarbowy w Zamościu
            "488", // Urząd Skarbowy w Krośnie Odrzańskim
            "489", // Urząd Skarbowy w Nowej Soli
            "491", // Urząd Skarbowy w Świebodzinie
            "492", // Urząd Skarbowy w Wolsztynie
            "493", // Pierwszy Urząd Skarbowy w Zielonej Górze
            "494", // Urząd Skarbowy w Żaganiu
            "495", // Urząd Skarbowy w Żarach
            "496", // Urząd Skarbowy w Łosicach
            "497", // Urząd Skarbowy w Łosicach
            "498", // Urząd Skarbowy w Piekarach Śląskich
            "499", // Drugi Urząd Skarbowy w Koszalinie
            "501", // Urząd Skarbowy W Górze
            "502", // Urząd Skarbowy W Polkowicach
            "503", // Urząd Skarbowy W Golubiu-Dobrzyniu
            "504", // Urząd Skarbowy W Sepólnie Krajeńskim
            "505", // Urząd Skarbowy W Łęcznej
            "506", // Urząd Skarbowy W Rykach
            "507", // Urząd Skarbowy W Łęczycy
            "508", // Urząd Skarbowy W Pajęcznie
            "509", // Urząd Skarbowy W Lipsku
            "511", // Urząd Skarbowy w Żurominie
            "512", // Urząd Skarbowy w Żurominie
            "513", // Urząd Skarbowy w Lesznie
            "514", // Urząd Skarbowy w Ostrzeszowie
            "516", // Urząd Skarbowy w Ostrzeszowie
            "519", // Urząd Skarbowy w Legionowie
            "521", // Urząd Skarbowy Warszawa-Mokotów
            "522", // Urząd Skarbowy Warszawa-Bemowo
            "523", // Urząd Skarbowy Warszawa-Praga
            "524", // Urząd Skarbowy Warszawa-Targówek
            "525", // Pierwszy Urząd Skarbowy Warszawa-Śródmieście
            "526", // Drugi Urząd Skarbowy Warszawa-Śródmieście
            "527", // Urząd Skarbowy Warszawa-Wola
            "528", // Urząd Skarbowy Warszawa-Bielany
            "529", // Urząd Skarbowy w Grodzisku Mazowieckim
            "531", // Urząd Skarbowy w Nowym Dworze Mazowieckim
            "532", // Urząd Skarbowy w Otwocku
            "533", // Urząd Skarbowy w Piasecznie
            "534", // Urząd Skarbowy w Pruszkowie
            "535", // Urząd Skarbowy w Wołominie
            "536", // Urząd Skarbowy w Legionowie
            "537", // Urząd Skarbowy w Białej Podlaskiej
            "538", // Urząd Skarbowy w Radzyniu Podlaskim
            "539", // Urząd Skarbowy w Parczewie
            "541", // Filia US w Białej Podlaskiej/Łosice
            "542", // Pierwszy Urząd Skarbowy w Białymstoku
            "543", // Urząd Skarbowy w Bielsku Podlaskim
            "544", // Urząd Skarbowy w Siemiatyczach
            "545", // Urząd Skarbowy w Sokółce
            "546", // Urząd Skarbowy w Mońkach
            "547", // Pierwszy Urząd Skarbowy w Bielsku-Białej
            "548", // Urząd Skarbowy w Cieszynie
            "549", // Urząd Skarbowy w Oświęcimiu
            "551", // Urząd Skarbowy w Wadowicach
            "552", // Urząd Skarbowy w Suchej Beskidzkiej
            "553", // Urząd Skarbowy w Żywcu
            "554", // Pierwszy Urząd Skarbowy w Bydgoszczy
            "555", // Urząd Skarbowy w Chojnicach
            "556", // Urząd Skarbowy w Inowrocławiu
            "557", // Urząd Skarbowy w Mogilnie
            "558", // Urząd Skarbowy w Nakle nad Notecią
            "559", // Urząd Skarbowy w Świeciu
            "561", // Urząd Skarbowy w Tucholi
            "562", // Urząd Skarbowy w Żninie
            "563", // Urząd Skarbowy w Chełmie
            "564", // Urząd Skarbowy w Krasnymstawie
            "565", // Urząd Skarbowy we Włodawie
            "566", // Urząd Skarbowy w Ciechanowie
            "567", // Urząd Skarbowy w Płońsku
            "568", // Urząd Skarbowy w Pułtusku
            "569", // Urząd Skarbowy w Mławie
            "571", // Urząd Skarbowy w Działdowie
            "572", // Filia US w Mławie/Żuromin
            "573", // Pierwszy Urząd Skarbowy w Częstochowie
            "574", // Urząd Skarbowy w Kłobucku
            "575", // Urząd Skarbowy w Lublińcu
            "576", // Urząd Skarbowy w Oleśnie
            "577", // Urząd Skarbowy w Myszkowie
            "578", // Urząd Skarbowy w Elblągu
            "579", // Urząd Skarbowy w Malborku
            "581", // Urząd Skarbowy w Kwidzynie
            "582", // Urząd Skarbowy w Braniewie
            "583", // Pierwszy Urząd Skarbowy w Gdańsku
            "584", // Drugi Urząd Skarbowy w Gdańsku
            "585", // Urząd Skarbowy w Sopocie
            "586", // Pierwszy Urząd Skarbowy w Gdyni
            "587", // Urząd Skarbowy w Pucku
            "588", // Urząd Skarbowy w Wejherowie
            "589", // Urząd Skarbowy w Kartuzach
            "591", // Urząd Skarbowy w Kościerzynie
            "592", // Urząd Skarbowy w Starogardzie Gdańskim
            "593", // Urząd Skarbowy w Tczewie
            "594", // Urząd Skarbowy w Choszcznie
            "595", // Urząd Skarbowy w Międzychodzie
            "596", // Urząd Skarbowy w Międzyrzeczu
            "597", // Urząd Skarbowy w Myśliborzu
            "598", // Urząd Skarbowy w Słubicach
            "599", // Urząd Skarbowy w Gorzowie Wielkopolskim
            "601", // Urząd Skarbowy w Przysusze
            "602", // Urząd Skarbowy w Nisku
            "603", // Urząd Skarbowy w Hajnówce
            "604", // Urząd Skarbowy w Pruszczu Gdańskim
            "605", // Urząd Skarbowy w Kazimierzy Wielkiej
            "606", // Urząd Skarbowy w Obornikach
            "607", // Urząd Skarbowy w Chodzieży
            "608", // Urząd Skarbowy w Pleszewie
            "609", // Urząd Skarbowy we Włoszczowie
            "611", // Urząd Skarbowy w Jeleniej-Górze
            "612", // Urząd Skarbowy w Bolesławcu
            "613", // Urząd Skarbowy w Lubaniu
            "614", // Urząd Skarbowy w Kamiennej-Górze
            "615", // Urząd Skarbowy w Zgorzelcu
            "616", // Urząd Skarbowy w Lwówku ŚLąskim
            "617", // Urząd Skarbowy w Jarocinie
            "618", // Pierwszy Urząd Skarbowy w Kaliszu
            "619", // Urząd Skarbowy w Kępnie
            "621", // Urząd Skarbowy w Krotoszynie
            "622", // Urząd Skarbowy w Ostrowie Wielkopolskim
            "623", // Urząd Skarbowy w Piekarach Śląskich
            "624", // Drugi Urząd Skarbowy w Koszalinie
            "625", // Urząd Skarbowy w Będzinie
            "626", // Urząd Skarbowy w Bytomiu
            "627", // Urząd Skarbowy w Chorzowie
            "628", // Urząd Skarbowy w Chrzanowie
            "629", // Urząd Skarbowy w Dąbrowie Górniczej
            "631", // Pierwszy Urząd Skarbowy w Gliwicach
            "632", // Urząd Skarbowy w Jaworznie
            "633", // Urząd Skarbowy w Jastrzębiu-Zdroju
            "634", // Pierwszy Urząd Skarbowy w Katowicach
            "635", // Urząd Skarbowy w Mikołowie
            "636", // Urząd Skarbowy w Mysłowicach
            "637", // Urząd Skarbowy w Olkuszu
            "638", // Urząd Skarbowy w Pszczynie
            "639", // Urząd Skarbowy w Raciborzu
            "641", // Urząd Skarbowy w Rudzie Śląskiej
            "642", // Urząd Skarbowy w Rybniku
            "643", // Urząd Skarbowy w Siemianowicach Śląskich
            "644", // Urząd Skarbowy w Sosnowcu
            "645", // Urząd Skarbowy w Tarnowskich Górach
            "646", // Urząd Skarbowy w Tychach
            "647", // Urząd Skarbowy w Wodzisławiu Śląskim
            "648", // Urząd Skarbowy w Zabrzu
            "649", // Urząd Skarbowy w Zawierciu
            "651", // Urząd Skarbowy w Żorach
            "652", // Urząd Skarbowy w Czechowicach Dziedzicach
            "653", // Urząd Skarbowy Tarnowskie Góry filia Piekary Śląskie
            "654", // Filia US w Będzinie/Czeladź
            "655", // Urząd Skarbowy w Busku-Zdroju
            "656", // Urząd Skarbowy w Jędrzejowie
            "657", // Pierwszy Urząd Skarbowy w Kielcach
            "658", // Urząd Skarbowy w Końskich
            "659", // Urząd Skarbowy w Miechowie
            "661", // Urząd Skarbowy w Ostrowcu Świętokrzyskim
            "662", // Urząd Skarbowy w Pińczowie
            "663", // Urząd Skarbowy w Skarżysku Kamiennej
            "664", // Urząd Skarbowy w Starachowicach
            "665", // Urząd Skarbowy w Koninie
            "666", // Urząd Skarbowy w Kole
            "667", // Urząd Skarbowy w Słupcy
            "668", // Urząd Skarbowy w Turku
            "669", // Pierwszy Urząd Skarbowy w Koszalinie
            "671", // Urząd Skarbowy w Kołobrzegu
            "672", // Urząd Skarbowy w Białogardzie
            "673", // Urząd Skarbowy w Szczecinku
            "674", // Urząd Skarbowy w Drawsku Pomorskim
            "675", // Urząd Skarbowy Kraków-Śródmieście
            "676", // Urząd Skarbowy Kraków-Stare Miasto
            "677", // Urząd Skarbowy Kraków-Krowodrza
            "678", // Urząd Skarbowy Kraków-Nowa Huta
            "679", // Urząd Skarbowy Kraków-Podgórze
            "681", // Urząd Skarbowy w Myślenicach
            "682", // Urząd Skarbowy w Proszowicach
            "683", // Urząd Skarbowy w Wieliczce
            "684", // Urząd Skarbowy w Krośnie
            "685", // Urząd Skarbowy w Jaśle
            "686", // Urząd Skarbowy w Brzozowie
            "687", // Urząd Skarbowy w Sanoku
            "688", // Urząd Skarbowy w Lesku
            "689", // Urząd Skarbowy w Ustrzykach Dolnych
            "691", // Urząd Skarbowy w Legnicy
            "692", // Urząd Skarbowy w Lubinie
            "693", // Urząd Skarbowy w Głogowie
            "694", // Urząd Skarbowy w Złotoryi
            "695", // Urząd Skarbowy w Jaworze
            "696", // Urząd Skarbowy w Gostyniu
            "697", // Urząd Skarbowy w Lesznie
            "698", // Urząd Skarbowy w Kościanie
            "699", // Urząd Skarbowy w Rawiczu
            "701", // Trzeci Urząd Skarbowy Warszawa-Śródmieście
            "711", // Urząd Skarbowy w Lesznie
            "712", // Pierwszy Urząd Skarbowy w Lublinie
            "713", // Drugi Urząd Skarbowy w Lublinie
            "714", // Urząd Skarbowy w Lubartowie
            "715", // Urząd Skarbowy w Kraśniku
            "716", // Urząd Skarbowy w Puławach
            "717", // Urząd Skarbowy w Opolu Lubelskim
            "718", // Urząd Skarbowy w Łomży
            "719", // Urząd Skarbowy w Grajewie
            "721", // Urząd Skarbowy w Kolnie
            "722", // Urząd Skarbowy w Wysokiem Mazowieckiem
            "723", // Urząd Skarbowy w Zambrowie
            "724", // Pierwszy Urząd Skarbowy Łódź-Śródmieście
            "725", // Urząd Skarbowy Łódź-Śródmieście
            "726", // Pierwszy Urząd Skarbowy Łódź-Bałuty
            "727", // Urząd Skarbowy Łódź-Polesie
            "728", // Urząd Skarbowy Łódź-Widzew
            "729", // Pierwszy Urząd Skarbowy Łódź-Górna
            "731", // Urząd Skarbowy w Pabianicach
            "732", // Urząd Skarbowy w Zgierzu
            "733", // Urząd Skarbowy w Głownie
            "734", // Urząd Skarbowy w Nowym Sączu
            "735", // Urząd Skarbowy w Nowym Targu
            "736", // Urząd Skarbowy w Zakopanem
            "737", // Urząd Skarbowy w Limanowej
            "738", // Urząd Skarbowy w Gorlicach
            "739", // Urząd Skarbowy w Olsztynie
            "741", // Urząd Skarbowy w Ostródzie
            "742", // Urząd Skarbowy w Kętrzynie
            "743", // Urząd Skarbowy w Bartoszycach
            "744", // Urząd Skarbowy w Iławie
            "745", // Urząd Skarbowy w Szczytnie
            "746", // Filia US w Szczytnie/Nidzica
            "747", // Urząd Skarbowy w Brzegu
            "748", // Urząd Skarbowy w Głubczycach
            "749", // Urząd Skarbowy w Kędzierzynie-Koźlu
            "751", // Urząd Skarbowy w Kluczborku
            "752", // Urząd Skarbowy w Namysłowie
            "753", // Urząd Skarbowy w Nysie
            "754", // Pierwszy Urząd Skarbowy w Opolu
            "755", // Urząd Skarbowy w Prudniku
            "756", // Urząd Skarbowy w Strzelcach Opolskich
            "757", // Urząd Skarbowy w Makowie Mazowieckim
            "758", // Urząd Skarbowy w Ostrołęce
            "759", // Urząd Skarbowy w Ostrowi Mazowieckiej
            "761", // Urząd Skarbowy w Przasnyszu
            "762", // Urząd Skarbowy w Wyszkowie
            "763", // Urząd Skarbowy w Czarnkowie
            "764", // Urząd Skarbowy w Pile
            "765", // Urząd Skarbowy w Wałczu
            "766", // Urząd Skarbowy w Wągrowcu
            "767", // Urząd Skarbowy w Złotowie
            "768", // Urząd Skarbowy w Opocznie
            "769", // Urząd Skarbowy w Bełchatowie
            "771", // Urząd Skarbowy w Piotrkowie Trybunalskim
            "772", // Urząd Skarbowy w Radomsku
            "773", // Urząd Skarbowy w Tomaszowie Mazowieckim
            "774", // Urząd Skarbowy w Płocku
            "775", // Urząd Skarbowy w Kutnie
            "776", // Urząd Skarbowy w Sierpcu
            "777", // Pierwszy Urząd Skarbowy Poznań
            "778", // Urząd Skarbowy Poznań-Śródmieście
            "779", // Urząd Skarbowy Poznań-Grunwald
            "781", // Urząd Skarbowy Poznań-Jeżyce
            "782", // Urząd Skarbowy Poznań-Nowe Miasto
            "783", // Urząd Skarbowy Poznań-Wilda
            "784", // Urząd Skarbowy w Gnieźnie
            "785", // Urząd Skarbowy w Śremie
            "786", // Urząd Skarbowy w Środzie Wielkopolskiej
            "787", // Urząd Skarbowy w Szamotułach
            "788", // Urząd Skarbowy w Nowym Tomyślu
            "789", // Urząd Skarbowy we Wrześni
            "791", // Filia US w Nowym Tomyślu/Grodzisk Wlkp.
            "792", // Urząd Skarbowy w Jarosławiu
            "793", // Urząd Skarbowy w Lubaczowie
            "794", // Urząd Skarbowy w Przeworsku
            "795", // Urząd Skarbowy w Przemyślu
            "796", // Pierwszy Urząd Skarbowy w Radomiu
            "797", // Urząd Skarbowy w Grójcu
            "798", // Urząd Skarbowy w Białobrzegach
            "799", // Urząd Skarbowy w Szydłowcu
            "811", // Urząd Skarbowy w Zwoleniu
            "812", // Urząd Skarbowy w Kozienicach
            "813", // Urząd Skarbowy w Rzeszowie
            "814", // Urząd Skarbowy w Kolbuszowej
            "815", // Urząd Skarbowy w Łańcucie
            "816", // Urząd Skarbowy w Leżajsku
            "817", // Urząd Skarbowy w Mielcu
            "818", // Urząd Skarbowy w Ropczycach
            "819", // Urząd Skarbowy w Strzyżowie
            "821", // Urząd Skarbowy w Siedlcach
            "822", // Urząd Skarbowy w Mińsku Mazowieckim
            "823", // Urząd Skarbowy w Sokołowie Podlaskim
            "824", // Urząd Skarbowy w Węgrowie
            "825", // Urząd Skarbowy w Łukowie
            "826", // Urząd Skarbowy w Garwolinie
            "827", // Urząd Skarbowy w Sieradzu
            "828", // Urząd Skarbowy w Poddębicach
            "829", // Urząd Skarbowy w Zduńskiej Woli
            "831", // Urząd Skarbowy w Łasku
            "832", // Urząd Skarbowy w Wieluniu
            "833", // Urząd Skarbowy w Brzezinach
            "834", // Urząd Skarbowy w Łowiczu
            "835", // Urząd Skarbowy w Rawie Mazowieckiej
            "836", // Urząd Skarbowy w Skierniewicach
            "837", // Urząd Skarbowy w Sochaczewie
            "838", // Urząd Skarbowy w Żyrardowie
            "839", // Urząd Skarbowy w Słupsku
            "841", // Urząd Skarbowy w Lęborku
            "842", // Urząd Skarbowy w Bytowie
            "843", // Urząd Skarbowy w Człuchowie
            "844", // Urząd Skarbowy w Suwałkach
            "845", // Urząd Skarbowy w Giżycku
            "846", // Urząd Skarbowy w Augustowie
            "847", // Urząd Skarbowy w Olecku
            "848", // Urząd Skarbowy w Ełku
            "849", // Urząd Skarbowy w Piszu
            "851", // Pierwszy Urząd Skarbowy w Szczecinie
            "852", // Drugi Urząd Skarbowy w Szczecinie
            "853", // Urząd Skarbowy w Pyrzycach
            "854", // Urząd Skarbowy w Starogardzie Szczecińskim
            "855", // Urząd Skarbowy w Świnoujściu
            "856", // Urząd Skarbowy w Goleniowie
            "857", // Urząd Skarbowy w Gryficach
            "858", // Urząd Skarbowy w Gryfinie
            "859", // Filia US w Goleniowie/Nowogard
            "861", // Filia US w Gryficach/Kamień Pom.
            "862", // Urząd Skarbowy w Janowie Lubelskim
            "863", // Urząd Skarbowy w Opatowie
            "864", // Urząd Skarbowy w Sandomierzu
            "865", // Urząd Skarbowy w Stalowej Woli
            "866", // Urząd Skarbowy w Staszowie
            "867", // Urząd Skarbowy w Tarnobrzegu
            "868", // Urząd Skarbowy w Bochni
            "869", // Urząd Skarbowy w Brzesku
            "871", // Urząd Skarbowy w Dąbrowie Tarnowskiej
            "872", // Urząd Skarbowy w Dębicy
            "873", // Pierwszy Urząd Skarbowy w Tarnowie
            "874", // Urząd Skarbowy w Brodnicy
            "875", // Urząd Skarbowy w Chełmnie
            "876", // Urząd Skarbowy w Grudziądzu
            "877", // Urząd Skarbowy w Nowym Mieście Lubawskim
            "878", // Urząd Skarbowy w Wąbrzeźnie
            "879", // Drugi Urząd Skarbowy w Toruniu
            "881", // Urząd Skarbowy w Bystrzycy Kłodzkiej
            "882", // Urząd Skarbowy w Dzierżoniowie
            "883", // Urząd Skarbowy w Kłodzku
            "884", // Urząd Skarbowy w Świdnicy
            "885", // Urząd Skarbowy w Nowej Rudzie
            "886", // Urząd Skarbowy w Wałbrzychu
            "887", // Urząd Skarbowy w Ząbkowicach Śląskich
            "888", // Urząd Skarbowy w Włocławku
            "889", // Urząd Skarbowy w Radziejowie
            "891", // Urząd Skarbowy w Aleksandrowie Kujawskim
            "892", // Urząd Skarbowy w Rypinie
            "893", // Urząd Skarbowy w Lipnie
            "894", // Urząd Skarbowy Wrocław-Fabryczna
            "895", // Urząd Skarbowy Wrocław-Psie Pole
            "896", // Pierwszy Urząd Skarbowy we Wrocławiu
            "897", // Urząd Skarbowy Wrocław-Stare Miasto
            "898", // Drugi Urząd Skarbowy Wrocław-Śródmieście
            "899", // Urząd Skarbowy Wrocław-Krzyki
            "911", // Urząd Skarbowy w Oleśnicy
            "912", // Urząd Skarbowy w Oławie
            "913", // Urząd Skarbowy w Środzie Wielkopolskiej
            "914", // Urząd Skarbowy w Strzelnie
            "915", // Urząd Skarbowy w Trzebnicy
            "916", // Urząd Skarbowy w Miliczu
            "917", // Filia US w Trzebnicy/Wołów
            "918", // Urząd Skarbowy w Biłgoraju
            "919", // Urząd Skarbowy w Hrubieszowie
            "921", // Urząd Skarbowy w Tomaszowie Lubelskim
            "922", // Urząd Skarbowy w Zamościu
            "923", // Urząd Skarbowy w Wolsztynie
            "924", // Urząd Skarbowy w Żaganiu
            "925", // Urząd Skarbowy w Nowej Soli
            "926", // Urząd Skarbowy w Krośnie Odrzańskim
            "927", // Urząd Skarbowy w Świebodzinie
            "928", // Urząd Skarbowy w Żarach
            "929", // Pierwszy Urząd Skarbowy w Zielonej Górze
            "931", // Urząd Skarbowy Warszawa-Ursynów
            "932", // Urząd Skarbowy Warszawa-Wawer
            "933", // Drugi Urząd Skarbowy w Bydgoszczy
            "934", // Drugi Urząd Skarbowy w Katowicach
            "935", // Trzeci Urząd Skarbowy w Szczecinie
            "936", // Pierwszy Urząd Skarbowy w Toruniu
            "937", // Drugi Urząd Skarbowy w Bielsku-Białej
            "938", // Drugi Urząd Skarbowy w Bielsku-Białej
            "939", // Drugi Urząd Skarbowy w Częstochowie
            "941", // Trzeci Urząd Skarbowy w Gdańsku
            "942", // Drugi Urząd Skarbowy w Gdyni
            "943", // Drugi Urząd Skarbowy w Kielcach
            "944", // Urząd Skarbowy Kraków-Dębniki
            "945", // Urząd Skarbowy Kraków-Prądnik
            "946", // Trzeci Urząd Skarbowy w Lublinie
            "947", // Drugi Urząd Skarbowy Łódź-Bałuty
            "948", // Drugi Urząd Skarbowy w Radomiu
            "949", // Drugi Urząd Skarbowy w Częstochowie
            "951", // Urząd Skarbowy Warszawa-Ursynów
            "952", // Urząd Skarbowy Warszawa-Wawer
            "953", // Drugi Urząd Skarbowy w Bydgoszczy
            "954", // Drugi Urząd Skarbowy w Katowicach
            "955", // Trzeci Urząd Skarbowy w Szczecinie
            "956", // Pierwszy Urząd Skarbowy w Toruniu
            "957", // Trzeci Urząd Skarbowy w Gdańsku
            "958", // Drugi Urząd Skarbowy w Gdyni
            "959", // Drugi Urząd Skarbowy w Kielcach
            "961", // Urząd Skarbowy Kraków-Dębniki
            "962", // Urząd Skarbowy Kraków-Prądnik
            "963", // Trzeci Urząd Skarbowy w Lublinie
            "964", // Drugi Urząd Skarbowy Łódź-Bałuty
            "965", // Drugi Urząd Skarbowy w Radomiu
            "966", // Drugi Urząd Skarbowy w Białymstoku
            "967", // Trzeci Urząd Skarbowy w Bydgoszczy
            "968", // Drugi Urząd Skarbowy w Kaliszu
            "969", // Drugi Urząd Skarbowy w Gliwicach
            "971", // Urząd Skarbowy w Gostyninie
            "972", // Urząd Skarbowy Poznań-Winogrady
            "973", // Drugi Urząd Skarbowy w Zielonej-Górze
            "974", // Drugi Urząd Skarbowy w Białymstoku
            "975", // Trzeci Urząd Skarbowy w Bydgoszczy
            "976", // Drugi Urząd Skarbowy w Bydgoszczy
            "977", // Drugi Urząd Skarbowy w Gliwicach
            "978", // Urząd Skarbowy w Gostyninie
            "979", // Urząd Skarbowy Poznań-Winogrady
            "981", // Drugi Urząd Skarbowy w Zielonej Górze
            "982", // Drugi Urząd Skarbowy Łódź-Górna
            "983", // Drugi Urząd Skarbowy Łódź-Górna
            "984", // Urząd Skarbowy w Nidzicy
            "985", // Urząd Skarbowy w Nidzicy
            "986", // Urząd Skarbowy w Kamieniu Pomorskim
            "987", // Urząd Skarbowy w Kamieniu Pomorskim
            "988", // Urząd Skarbowy w Wołowie
            "989", // Urząd Skarbowy w Wołowie
            "991", // Drugi Urząd Skarbowy w Opolu
            "992", // Drugi Urząd Skarbowy w Opolu
            "993", // Drugi Urząd Skarbowy w Tarnowie
            "994", // Drugi Urząd Skarbowy w Tarnowie
            "995", // Urząd Skarbowy w Grodzisku Wielkopolskim
            "996", // Urząd Skarbowy w Grodzisku Wielkopolskim
            "997", // Urząd Skarbowy Wieluń lokalizacja w Wieruszowie
            "998", // Urząd Skarbowy Wieluń lokalizacja w Wieruszowie
        };
    }
}
