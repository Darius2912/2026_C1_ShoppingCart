using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccess.DAO
{
    public class sqlOperation
    {
        public string ProcedureName { get; set; }

        public List<SqlParameter> Parameters { get; set; }  

        public sqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }

        public void AddStringParam(string paramName, string paramValue) 
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddIntParam(string paramName, int paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddDecimalParam(string paramName, decimal paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddDateTimeParam(string paramName, DateTime paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public static void AddStringParam(string v)
        {
            throw new NotImplementedException();
        }


    }
}
