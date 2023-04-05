using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webscraping
{
    internal class web_scraper
    {
        //Envia y recibe una respuesta a la direccion por medio de la url
        public static async Task<string> call_url(string url)
        {
           
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            
            //Retorna todo el html
            return response;
        } 

        //Separar la información
        public static List<List<string>> parse_html(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            //var datos = document.DocumentNode.SelectNodes("tr[@class='simpTblRow']");

            var parsed_data = document.DocumentNode.Descendants("tr").Where(node => node.GetAttributeValue("class","").Contains("simpTblRow")).ToList();

            List<List<string>> book_data = new List<List<string>>();



            foreach ( HtmlNode crypto in parsed_data) 
            {

                var img_link = crypto.Descendants("img").ToList()[0].GetAttributeValue("src","");

                var name = crypto.SelectNodes("td").Where(node => node.GetAttributeValue("aria-label", "").Contains("Name")).ToList()[0].InnerText;

                var price = crypto.SelectNodes("td").Where(node => node.GetAttributeValue("aria-label", "").Contains("Price (Intraday)")).ToList()[0].FirstChild.InnerText;

                var change = crypto.SelectNodes("td").Where(node => node.GetAttributeValue("aria-label", "").Contains("Change")).ToList()[0].FirstChild.FirstChild.InnerText;

                var change_porcentage = crypto.SelectNodes("td").Where(node => node.GetAttributeValue("aria-label", "").Contains("% Change")).ToList()[0].FirstChild.FirstChild.InnerText;

                var market_cap = crypto.SelectNodes("td").Where(node => node.GetAttributeValue("aria-label", "").Contains("Market Cap")).ToList()[0].FirstChild.GetAttributeValue("value","");

                book_data.Add(new List<string>() { name, price, change, change_porcentage, market_cap });

            }
            return book_data;

        
        }
        public static List<List<string>> get_books_data(string url)
        {
            string response = call_url(url).Result;
            List<List<string>>book_data = parse_html(response);
            foreach ( var item in book_data )
            {
                Console.WriteLine(item);
            }
            return book_data;
        }

        


    }


    }

