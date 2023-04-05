
using System.Collections.Generic;

namespace webscraping
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine( web_scraper.call_url("https://finance.yahoo.com/crypto/").Result);
            //Console.WriteLine( web_scraper.get_books_data("https://www.goodreads.com/choiceawards/best-science-fiction-books-2022"));
            List<List<string>> cryptos = web_scraper.get_books_data("https://finance.yahoo.com/crypto/");

         
        }
    }
}