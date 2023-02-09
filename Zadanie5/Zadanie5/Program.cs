using System;
using System.Xml;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Zadanie2
{
    internal class Program
    {
        public static void zadanie2()
        {
            int numb = 0;
            try
            {
                string tekst = System.IO.File.ReadAllText(@"C:\test\test_jak_kan.txt");
                foreach (char c in tekst)
                {
                    if (c == 'a') { numb++; }
                }
                Console.Write("Ilość występowania w pliku litery a(poza nazwą): ");
                Console.WriteLine(numb);
                System.Console.ReadKey();
            } catch
            {
                Console.WriteLine("Problemy z plikiem");
            }
        }
        public static void zadanie3(){ 
            try
            {
                Console.Write("Ścieżka pliku(wraz z nazwą i rozszerzeniem): ");
                string s = Console.ReadLine();
                string kontent = File.ReadAllText(s);
                kontent = kontent.Replace("praca", "job");
                DateTime data = DateTime.Now;
                string Date = (data.Year).ToString() + (data.Month).ToString() + (data.Day).ToString();
                s = s + "_changed-" + Date;
                File.WriteAllText(s, kontent);
                System.Console.ReadKey();
            } catch
            {
                Console.WriteLine("Błąd lokalizacji lub odczytu pliku");
            }
        }
        public static void zadanie4(){
            
            Random rand = new Random();
            int buffor;
            string line;
            string sciezka;
            line = "LP, Imię, Nazwisko, Rok_urodzenia\n";
            Console.Write("Ścieżka do zapisania pliku: ");
            sciezka = Console.ReadLine();
            sciezka = sciezka + "/lista.csv";
            using (File.Create(sciezka))
            {
                for (int i = 1; i <= 100; i++)
                {
                    buffor = rand.Next(1, 4);
                    line += i;
                    line += ",";
                    switch (buffor)
                    {
                        case 1:
                            line += "Ania";
                            break;
                        case 2:
                            line += "Kasia";
                            break;
                        case 3:
                            line += "Basia";
                            break;
                        case 4:
                            line += "Zosia";
                            break;
                        default:
                            break;
                    }
                    line += ",";
                    buffor = rand.Next(1, 100);
                    buffor = buffor % 2;
                    switch (buffor)
                    {
                        case 0:
                            line += "Kowalska";
                            break;
                        case 1:
                            line += "Nowak";
                            break;
                        default:
                            break;
                    }
                    line += ",";
                    buffor = rand.Next(1990, 2000);
                    line += buffor;
                    line += "\n";
                }
            }
            File.WriteAllText(sciezka, line);
        }
        public static void zadanie5()
        {
            Console.Write("PLN: ");
            string slote = Console.ReadLine(); ;
            double Zlote = Convert.ToDouble(slote, System.Globalization.CultureInfo.InvariantCulture);

            string KursLink = "http://api.nbp.pl/api/exchangerates/rates/c/usd/today/?format=xml";
            XmlDocument KursXML = new XmlDocument();
            KursXML.Load(KursLink);

            XmlNode Lista = KursXML.SelectSingleNode("/ExchangeRatesSeries/Rates/Rate/Bid"); 
            string kursWalut = Lista.InnerText;
            double Wynik = Convert.ToDouble(kursWalut, System.Globalization.CultureInfo.InvariantCulture);
            Wynik = (Zlote / Wynik);

            Console.Write("USD: ");
            Console.Write( String.Format("{0:N2}", Wynik));
            Console.Read();
        }
        static void Main(string[] args)
        {
            zadanie2();
            zadanie3();
            zadanie4();
            zadanie5();
        }
    }
}
