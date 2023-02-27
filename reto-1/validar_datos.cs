using System;
using System.IO;
//https://learn.microsoft.com/en-us/dotnet/api/system.type?view=net-7.0
namespace Entrada{

    class Validar_datos{   
        public bool verificar_edad(string str_edad){
            int edad = Int32.Parse(str_edad);
            int edad_minima = 18;       

            return edad >= edad_minima;

        }
    public bool verificar_correo(string str_correo){
        
        //que no comienze con un digito
        if ( char.IsDigit(str_correo[0])){
            return false;
        }

        string conector = "@";

        string[] arr_dominios = new string[3];
        arr_dominios[0] = "gmail";
        arr_dominios[1] = "hotmail";
        arr_dominios[2] = "live";

        string[] arr_terminaciones = new string[4];
        arr_terminaciones[0] = ".com";
        arr_terminaciones[1] = ".co";
        arr_terminaciones[2] = ".edu.co";
        arr_terminaciones[3] = ".org";

        string correo_valido;
        //Se selecciona el dominio
        for(int i =0; i<arr_dominios.Length; i++){
            //Se selecciona la terminacion
            for (int j =0; j<arr_terminaciones.Length; j++){
                //Se une el dominio y la terminación 
                correo_valido = $"{conector}{arr_dominios[i]}{arr_terminaciones[j]}";
                //Se verifica si el correo contiene alguna verificacion
                if (str_correo.Contains(correo_valido)){
                    return true;
                }
            }
        }

        return false;
    }

    }
}