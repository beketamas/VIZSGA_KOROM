using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIZSGA_KOROM.Models
{
    public class Auto
    {
        string sorszam;
        string marka;
        string model;
        string gyartasiEv;
        string feher;
        int eladottDarabSzam;
        double atlagosEladasiAr;

        public Auto(string[] tomb)
        {
            this.sorszam = tomb[0];
            this.marka = tomb[1];
            this.model = tomb[2];
            this.gyartasiEv = tomb[3];
            this.feher = tomb[4];
            this.eladottDarabSzam = int.Parse(tomb[5]);
            this.atlagosEladasiAr = double.Parse(tomb[6]);
        }


        public string Sorszam { get => sorszam; set => sorszam = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string GyartasiEv { get => gyartasiEv; set => gyartasiEv = value; }
        public string Feher { get => feher; set => feher = value; }
        public int EladottDarabSzam { get => eladottDarabSzam; set => eladottDarabSzam = value; }
        public double AtlagosEladasiAr { get => atlagosEladasiAr; set => atlagosEladasiAr = value; }

        public static List<Auto> ReadCSV(string nev) => [.. File.ReadLines(nev).Skip(1).Select(x => new Auto(x.Split(";")))];
    }
}
