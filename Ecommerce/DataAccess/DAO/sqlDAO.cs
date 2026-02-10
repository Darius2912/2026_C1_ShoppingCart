using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataAccess.DAO
{   
    //Vamos usar el patron del singleton
    /*
     * Clase que se encarga de la comunicacion con la base de datos
     * Asegura que solo exista una unica instancia de la clase 
     */
    public class sqlDAO
    {
        //Paso 1: Crear una instancia privada de la misma clase
        private static sqlDAO instance;

        private string connectionString;

        //Paso 2: Redefinir el constructor, para convertirlo en privado

    }
}
