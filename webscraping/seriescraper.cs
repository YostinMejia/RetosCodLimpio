using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Drawing;

namespace webscraping
{
    internal class serie:pelicula
    {
        //Envia y recibe una respuesta a la direccion por medio de la url
        public static async Task<string> call_url(string url)
        {

            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);

            //Retorna todo el html
            return response;
        }


        private static List<List<string>> ActoresPrincipales(string html)
        {
            return pelicula.ActoresPrincipales(html);
        }

        //los comentarios estan en las sesiones y no en la pagina principal
        //Hay que mirar si el link contiene s## que indica el numero de la serie para saber si se pueden mirar los comentarios o no
        private static List<List<string>> ComentariosCriticos(string url)
        {

            if (!url.Contains("/s"))
            {
                Console.WriteLine(  "Los comentarios están en las paginas de las temporadas, no en la principal");
                return new List<List<string>>();
            }


            return pelicula.ComentariosCriticos(url);


        }
        private static List<List<string>> ComentariosUsuarios(string url)
        {
            
            if(! url.Contains("/s"))
            {
                Console.WriteLine("Los comentarios están en las paginas de las temporadas, no en la principal");

                return new List<List<string>>();
            }
            
            return pelicula.ComentariosUsuarios(url, false);
        }


        private static List<List<string>> PlataformasDisponibles(string html)
        {
            return pelicula.PlataformasDisponibles(html);

        }


        private static List<List<string>> Calificacion(string url, string html)
        {

            if (!url.Contains("/s"))
            {
                Console.WriteLine("los contadores están en las paginas de las temporadas, no en la principal");

                return pelicula.Calificacion(html, false);
            }

            return pelicula.Calificacion(html, false);

        }

        private static List<List<string>> DatosPrincipales(string url, string html )
        {
            
            if (! url.Contains("/s"))
            {

                return pelicula.DatosPrincipales(html, false, false);
            }

            return pelicula.DatosPrincipales(html, false, true);

        }
        public static List<string> DatosPelicula(string url)
        {
            string response = call_url(url).Result;
            //serie
            List<List<string>> comentarios_criticos = ComentariosCriticos(url);
            List<List<string>> comentarios_verificados = ComentariosUsuarios(url);
            List<List<string>> plataformas = PlataformasDisponibles(response);
            List<List<string>> actores = ActoresPrincipales(response);
            List<List<string>> calificacion = Calificacion(url,response);
            List<List<string>> datos_princi = DatosPrincipales(url, response);


            List<string> datos = new List<string>();

            return datos;
        }




    }


}

