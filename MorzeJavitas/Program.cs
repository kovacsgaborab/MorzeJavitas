using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MorzeJavitas
{
    class Program
    {
        static Dictionary<string, string> abcmorze = new Dictionary<string, string>();
        static Dictionary<string, string> morzeabc = new Dictionary<string, string>();
        static List<Szoveg> idezetek = new List<Szoveg>();
        static void ABCbeovlas()
        {
            StreamReader sr = new StreamReader("morzeabc.txt");

            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string[] a = sr.ReadLine().Split('\t');
                abcmorze.Add(a[0], a[1]);
                morzeabc.Add(a[1], a[0]);
            }

            sr.Close();
        }
        static void Harmadik()
        {
            Console.WriteLine($"3. feladat: A morze abc {morzeabc.Count} db karakter kódját tartalmazza.");
        }
        static void Negyedik()
        {
            Console.Write("4. feladat: Kérek egy karaktert: ");
            string betu = Console.ReadLine();

            if (abcmorze.ContainsKey(betu))
            {
                Console.WriteLine($"\t A {betu} karakter morzekódja: {abcmorze[betu]}");
            }
            else
            {
                Console.WriteLine("\t Nem található a kódtárban ilyen karakter!");
            }
        }
        static void Otodik()
        {
            //idézetek eltárolása
        }
        static string Morze2Szoveg(string kodolt)
        {
            StringBuilder vissza = new StringBuilder();
            string[] szavak = kodolt.Replace("       ", ";").Split(';');

            foreach (var szo in szavak)
            {
                string[] betuk = szo.Trim().Replace("   ", ";").Split(';');

                foreach (var betu in betuk)
                {
                    vissza.Append(morzeabc[betu]);
                }
                vissza.Append(" ");
            }

            return vissza.ToString().Trim();
        }
        static void Main(string[] args)
        {
            ABCbeovlas();
            Harmadik();
            Negyedik();

            

            Console.ReadLine();
        }
    }
}
