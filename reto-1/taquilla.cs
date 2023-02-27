using System;
using System.IO;
//https://learn.microsoft.com/en-us/dotnet/api/system.type?view=net-7.0

namespace Entrada{

    public class Taquilla
    {   
        public string validar_entrada(string id_invitado, string file_path ){
            Gestor_Archivo gestor_Archivo = new Gestor_Archivo();
            string[] datos_invitado = gestor_Archivo.gestionar_txt_csv(file_path, id_invitado);
                    // Si el nombre es null significa que no se encontro nunguno que coicida con el id
            
            string invitado_nombre = datos_invitado[0];
            string  invitado_id = datos_invitado[1];
            string  invitado_correo = datos_invitado[2];
            string  invitado_edad = datos_invitado[3];
            
            if (invitado_nombre == null){
                return "ese un@ colad@";
            }

            Validar_datos validar = new Validar_datos();
            //Se verifica que sea mayor de edad
            bool mayoria_edad = validar.verificar_edad(invitado_edad);

            //Si no es mayor de edad se termina la función
            if (! (mayoria_edad)){
                return "Es menor de edad"; 
            }

            //Se verifica que el primer caracter del correo no sea un número

            if (! (validar.verificar_correo(invitado_correo)) ){
                return "Su correo no cumple los requisitos";
            }
            //Si no se ejecuto ningún return significa que cumple con todos los requisitos
            return $"Que pase el desgraciado {invitado_nombre}";
            }   

    }
}
