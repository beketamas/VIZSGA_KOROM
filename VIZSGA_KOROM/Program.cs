using VIZSGA_KOROM.Models;

namespace VIZSGA_KOROM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = Auto.ReadCSV("autok.csv");

            Console.WriteLine($"5. feladat: {autok.Count} autó található a listában");
            Console.WriteLine($"6. feladat: Az autók esetében az átlagosan eladott darabszám: {string.Format("{0:f1}", autok.Average(x => x.EladottDarabSzam))}");
            Console.WriteLine("7. feladat: Az elmúlt 5 évben gyártott autók:");
            autok.Where(x => int.Parse(x.GyartasiEv) >= DateTime.Now.Year - 5).ToList().ForEach(y => Console.WriteLine($"\t- {y.Marka} {y.Model}: {y.GyartasiEv}"));
            Console.WriteLine("8. feladat: Legsikeresebb márkák listája az eladott darabszám alapján:");
            autok.OrderByDescending(x => x.EladottDarabSzam).GroupBy(x => x.Marka).ToList().ForEach(x => Console.WriteLine($"\t- {x.Key}: {autok.Where(y => y.Marka == x.Key).First().EladottDarabSzam} darab"));

        }


    }
}
