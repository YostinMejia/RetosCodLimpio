using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 public class Program
{
        static void Main(string[] args)
    {

        Taquilla guardia = new Taquilla();
        Console.WriteLine(guardia.verificar_txt_csv("Taller_herencia.txt","6573512"));
        
        
    }
}