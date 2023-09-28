using System.Xml.Linq;

// Load exchange rate data from the NBP (National Bank of Poland) API in XML format
XDocument apiRates = XDocument.Load("https://api.nbp.pl/api/exchangerates/tables/a/?format=xml");

// Extract exchange rate information from the XML data
var rates = apiRates.Descendants("Rate");
float usdplnRate = 0;


foreach (var rate in rates)
{

    if (rate.Element("Code").Value == "USD")
    {   // Parse the exchange rate value as a float, using the InvariantCulture to handle decimal points
        usdplnRate = float.Parse(rate.Element("Mid").Value, System.Globalization.CultureInfo.InvariantCulture);
    }
}
Console.WriteLine("Today's average exchange rate for the US Dollar is " + usdplnRate.ToString());

char selection;
do
{

    Console.WriteLine("What would you like to do?");
    Console.WriteLine("Exchange PLN / USD (p)");
    Console.WriteLine("Exchange USD / PLN (u)");
    Console.WriteLine("Exit the program (q)");

    // Read the user's selection
    selection = Console.ReadKey().KeyChar;
    Console.Clear();

    if (selection == 'p')
    {   // Prompt the user to enter the amount in PLN to exchange for USD
        Console.WriteLine("Enter the amount in PLN to exchange for USD");
        float pln = float.Parse(Console.ReadLine());


        float usd = pln / usdplnRate;
        Console.WriteLine("You will receive " + Math.Round(usd, 2).ToString() + " USD");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    if (selection == 'u')
    {
        Console.WriteLine("Enter the amount in USD to exchange for PLN");
        float usd = float.Parse(Console.ReadLine());
        float pln = usd * usdplnRate;
        Console.WriteLine("You will receive " + Math.Round(pln, 2).ToString() + " PLN");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    Console.Clear();
} while (selection != 'q');