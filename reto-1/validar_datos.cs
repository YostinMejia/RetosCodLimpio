using System;
using System.IO;
//https://learn.microsoft.com/en-us/dotnet/api/system.type?view=net-7.0
namespace Entrada{

  


    class Validacion{   

        public bool verificar_edad(string str_edad){
            int edad = Int32.Parse(str_edad);
            int edad_minima = 18;       

            return edad >= edad_minima;

        }
    public string Validar_usuario(string file_path, string id_invitado){

        Gestor_Archivo gestor_Archivo = new Gestor_Archivo();
        string[] datos_invitado = gestor_Archivo.gestionar_txt_csv(file_path, id_invitado);

        string invitado_nombre = datos_invitado[0];
        string  invitado_id = datos_invitado[1];
        string  invitado_correo = datos_invitado[2];
        string  invitado_edad = datos_invitado[3];
        
        if (invitado_nombre == null){
                return "ese un@ colad@";
            }

            //Se verifica que sea mayor de edad
            bool mayoria_edad = this.verificar_edad(invitado_edad);

            //Si no es mayor de edad se termina la función
            if (! (mayoria_edad)){
                return "Es menor de edad"; 
            }

            //Se verifica que el primer caracter del correo no sea un número

            if (! (this.verificar_correo(invitado_correo)) ){
                return "Su correo no cumple los requisitos";
            }
            //Si no se ejecuto ningún return significa que cumple con todos los requisitos
            return $"Que pase el desgraciado {invitado_nombre}";
            
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