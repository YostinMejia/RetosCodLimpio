using System;
using System.IO;

namespace Entrada{

    class Gestor_Archivo{
    
	public string[] gestionar_txt_csv(string path,string id)
	{
        String line;
        try{

        
        //Pass the file path and file name to the StreamReader constructor
        StreamReader sr = new StreamReader(path);
        //Read the first line of text
        line = sr.ReadLine();
        //Donde se almacenará la información
        string[] subs = new string[4];

        //Continue to read until you reach end of file
        while (line != null)
        {   
             if (path.Contains(".csv")){
                subs = line.Split(",");
            }else if(path.Contains(".txt"))
            {
                subs = line.Split();
            }
            // else{
            //     Console.WriteLine("ese archivo no existe");
            // }
            //Si se encuentra a laguien con el id 
            if (subs[1] == id){
                return subs;
            }
     
            //Read the next line
            line = sr.ReadLine();
        }
        //Se cambian los valores del ultimo de la lista por null, para luego verificar que no está invitado 
        subs[0] = null;
        subs[1] = null;
        subs[2] = null;
        subs[3] = null;
        return subs;

        
        //close the file
        sr.Close();
    }catch(Exception e){
        Console.WriteLine(e.Message);
        string[] subs = new string[4];
        subs[0] = null;
        subs[1] = null;
        subs[2] = null;
        subs[3] = null;
        return subs;

    }
    }
    }

}