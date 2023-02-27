using System;
using System.IO;
//https://learn.microsoft.com/en-us/dotnet/api/system.type?view=net-7.0

namespace Entrada{

    public class Taquilla
    {   
        public string Iniciar_entrada(string id_invitado, string file_path ){
        
            // Si el nombre es null significa que no se encontro nunguno que coicida con el id
            Validacion validacion = new Validacion();
            return( validacion.Validar_usuario(file_path, id_invitado) );

        }   
}
}
