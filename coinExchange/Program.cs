using System.Xml.Linq;

XDocument apiRates = XDocument.Load("https://api.nbp.pl/api/exchangerates/tables/a/?format=xml");
var rates = apiRates.Descendants("Rate");
float usdplnRate = 0;
foreach (var rate in rates)
{

    if (rate.Element("Code").Value == "USD")
    {
        usdplnRate = float.Parse(rate.Element("Mid").Value, System.Globalization.CultureInfo.InvariantCulture);
    }
}
Console.WriteLine("Dzisiejszy średni kurs dolara to " + usdplnRate.ToString());

char selection;
do
{

    Console.WriteLine("Co chcesz zrobić?");
    Console.WriteLine("Wymień PLN / USD (p)");
    Console.WriteLine("Wymień USD / PLN (u)");
    Console.WriteLine("Wyjdź z prgramu (q)");
    selection = Console.ReadKey().KeyChar;
    Console.Clear();
    if (selection == 'p')
    {
        Console.WriteLine("Podaj kwotę w PLN do wymiany na USD");
        float pln = float.Parse(Console.ReadLine());
        float usd = pln / usdplnRate;
        Console.WriteLine("Otrzymujesz " + Math.Round(usd, 2).ToString() + "USD");
        Console.WriteLine("Naciśnij dowolny klawisz");
        Console.ReadKey();
    }
    if (selection == 'u')
    {
        Console.WriteLine("Podaj kwotę w USD do wymiany na PLN");
        float usd = float.Parse(Console.ReadLine());
        float pln = usd * usdplnRate;
        Console.WriteLine("Otrzymujesz " + Math.Round(pln, 2).ToString() + "PLN");
        Console.WriteLine("Naciśnij dowolny klawisz");
        Console.ReadKey();
    }
    Console.Clear();
} while (selection != 'q');