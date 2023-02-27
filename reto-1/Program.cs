using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrada{


 public class Program
{
        static void Main(string[] args)
    {
        Console.WriteLine("Bienvenid@ \n ¿Cual es su id?");
        string id_invitado = Console.ReadLine();
        Console.WriteLine("¿Cual es la ruta del archivo?");
        string file_path = Console.ReadLine();
        
        if (file_path != "Taller_herencia.txt" && file_path != "Taller_herencia.csv"){
            Console.WriteLine("Ese archivo no existe ");
        }
        else{
            Taquilla guardia = new Taquilla();
            Console.WriteLine(guardia.Iniciar_entrada(id_invitado,file_path));
        }

    }
}
}