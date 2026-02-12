using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Data.SqlClient;
using System.Data;

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
        private sqlDAO() {
            connectionString = @"Data Source=DESKTOP-OAPB7LG;Initial Catalog=2026C1-ecommerce;Integrated Security=True;Trust Server Certificate=True";
        }


        //Paso 3: Metodo que expone la instancia de la clase
        public static sqlDAO GetInstance() {
            if (instance == null) {
                instance = new sqlDAO();
            }
            return instance;
        }

        //Metodo para ejecutar SP sin retorno de datos
        public void ExecuteProcedure(sqlOperation operation) {

            using (var conn=new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(operation.ProcedureName, conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                     //set de los parametros
                    {
                    foreach (var param in operation.Parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    //Ejecutar el SP contra la base de datos
                    conn.Open();    
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
