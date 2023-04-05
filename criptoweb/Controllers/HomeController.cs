using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;


namespace criptoweb.Controllers
{
    public class HomeController : Controller
    {
        /* private readonly ILogger<HomeController> _logger;

         public HomeController(ILogger<HomeController> logger)
         {
             _logger = logger;
         }*/

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Peores()
        {
            List<List<string>> cryptos = scrape_data();

            List<List<string>> worst_crypto = new List<List<string>>();

            for (int i = 0; i < cryptos.Count; i++)
            {
                if (cryptos[i][2].StartsWith("-"))
                {
                    worst_crypto.Add(cryptos[i]);
                }

            }

            ViewData["cryptos"] = worst_crypto;
            return View();
        }
        public IActionResult Mejores()
        {
            List<List<string>> cryptos = scrape_data();

            List<List<string>> best_crypto = new List<List<string>>();

            for (int i = 0; i < cryptos.Count; i++)
            {
                if (cryptos[i][2].StartsWith("+"))
                {
                    best_crypto.Add(cryptos[i]);
                }

            }

            ViewData["cryptos"] = best_crypto;

            return View();
        }

        List<List<string>> scrape_data()
        {
            //Envia y recibe una respuesta a la direccion por medio de la url
            async Task<string> call_url(string url)
            {

                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(url);

                //Retorna todo el html
                return response;
            }

            //Separar la información
            List<List<string>> parse_html(string html)
            {
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);

                //LINQ
                var parsed_data = document.DocumentNode.Descendants("tr").Where(node => node.GetAttributeValue("class", "").Contains("simpTblRow")).ToList();

                List<List<string>> crypto_data = new List<List<string>>();

                foreach (HtmlNode crypto in parsed_data)
                {

                    var img_link = crypto.Descendants("img").ToList()[0].GetAttributeValue("src", "");


                    var name = crypto.SelectNodes("td").Where(node => node.GetAttributeValue("aria-label", "").Contains("Name")).ToList()[0].InnerText;

                    var price = crypto.SelectNodes("td").Where(node => node.GetAttributeValue("aria-label", "").Contains("Price (Intraday)")).ToList()[0].FirstChild.InnerText;

                    var change = crypto.SelectNodes("td").Where(node => node.GetAttributeValue("aria-label", "").Contains("Change")).ToList()[0].FirstChild.FirstChild.InnerText;

                    var change_porcentage = crypto.SelectNodes("td").Where(node => node.GetAttributeValue("aria-label", "").Contains("% Change")).ToList()[0].FirstChild.FirstChild.InnerText;

                    var market_cap = crypto.SelectNodes("td").Where(node => node.GetAttributeValue("aria-label", "").Contains("Market Cap")).ToList()[0].FirstChild.GetAttributeValue("value", "");

                    crypto_data.Add(new List<string>() { name, price, change, change_porcentage, market_cap, img_link });

                }
                return crypto_data;


            }

            string url = "https://finance.yahoo.com/crypto?offset=0&count=25";
            string response = call_url(url).Result;
            List<List<string>> crypto_data = parse_html(response);

            return crypto_data;

        }


     

    }
}