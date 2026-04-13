

namespace GLS_CLI
{
    public class Program
    {
        public static List<AutoAdatok> autoAdatok = new List<AutoAdatok>();
        static void Main(string[] args)
        {
            Beolvas();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat6();
            Feladat7();
        }

        private static void Feladat7() {
            Dictionary<string, int> statisztika = new Dictionary<string, int>();
            foreach (var item in autoAdatok)
            {
                if (!statisztika.ContainsKey(item.SoforNev))
                {
                    statisztika.Add(item.SoforNev, 1);
                }
                else
                {
                    statisztika[item.SoforNev]++;
                }
            }
            var rendezett = statisztika.OrderByDescending(s => s.Value).ToList();
            Console.WriteLine($"A legtöbbet vezető sofőr: {rendezett[0].Key}, napok száma: {rendezett[0].Value}");
        }

        private static void Feladat6() {
            double haviAtlag = autoAdatok.Average(a => AtlagFogyasztas(a.NapiKilometer, a.NapiFogyasztas));
            Console.WriteLine($"Átlagos fogyasztás: {haviAtlag} liter/100 km");
        }

        public static double AtlagFogyasztas(int megtettKilometer, int fogyasztas) {
            if (megtettKilometer <= 0 || fogyasztas <= 0)
            {
                return 0;
            }
            else
            {
                double atlag = (double)fogyasztas / ((double)megtettKilometer / 100);
                return atlag;
            }
        }

        private static void Feladat4() {
            int osszesKm = autoAdatok.Sum(a => a.NapiKilometer);
            Console.WriteLine($"Az összes megtett kilóméter: {osszesKm} km");
        }

        private static void Feladat3() {
            //Linq
            List<AutoAdatok> szurt = autoAdatok.Where(a => a.NapiFogyasztas > 10).ToList();
            List<string> nev = autoAdatok.Select(a => a.SoforNev).Distinct().ToList();
            int max = autoAdatok.Max(a => a.NapiFogyasztas);
            List<DateTime> maxDatum = autoAdatok.Where(a => a.NapiFogyasztas == max).Select(a => a.Datum).ToList();

            //Hagyományos
            List<string> nev2 = new List<string>();
            foreach (var item in autoAdatok)
            {
                if (!nev2.Contains(item.SoforNev))
                {
                    nev2.Add(item.SoforNev);
                }
            }
            Console.WriteLine($"Különböző sofőrök száma: {nev2.Count}");
        }

        private static void Feladat2() {
            Console.WriteLine($"Az autó használatban töltött napjainak száma: {autoAdatok.Count}");
        }

        public static void Beolvas() {
            StreamReader sr = new("GLS.txt");
            while (!sr.EndOfStream)
            {
                autoAdatok.Add(new AutoAdatok(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}