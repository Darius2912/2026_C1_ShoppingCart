using DataAccess.DAO;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {

        public UserCrudFactory()
        {
            sqlDAO = sqlDAO.GetInstance();
        }
        public override void Create(BaseDTO baseDTO)
        {
            
            var user = baseDTO as User;
            //Ejecucion del SP
            var sqlOperation = new sqlOperation();
            sqlOperation.ProcedureName = "CRE_USER_PR";

            sqlOperation.AddStringParam("P_NAME ", user.Name);
            sqlOperation.AddStringParam("P_Last_Name ", user._LastName);
            sqlOperation.AddStringParam("P_Password", user.Password);
            sqlOperation.AddStringParam("P_Email ", user.Email);
            sqlOperation.AddDateTimeParam("P_BIRTH_DATE", user.BirthDate);
            sqlOperation.AddStringParam("P_Status", user.Status);

            sqlDAO.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var user = baseDTO as User;
            //Ejecucion del SP
            var sqlOperation = new sqlOperation();
            sqlOperation.ProcedureName = "DEl_USER_PR";

            sqlOperation.AddIntParam("P_ID", user.Id);
           
            sqlDAO.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstResults = new List<T>();

            var operation = new sqlOperation();
            operation.ProcedureName = "RET_ALL_USER_PR";

            var lstResult = sqlDAO.ExecuteQueryProcedure(operation);

            if (lstResult.Count > 0)
            {
               foreach (var item in lstResult)
                {
                    var  user = BuildUser(item);
                    lstResults.Add((T)Convert.ChangeType(user, typeof(T)));
                }
        }
            return lstResults;

        }

        public override T RetrieveById<T>(int id)
        {
            var operation = new sqlOperation();
            operation.ProcedureName = "RET_USER_BY_ID_PR";

            operation.AddIntParam("P_ID", id);

            var lstResults = sqlDAO.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                var item = lstResults[0];

                var user = BuildUser(item);
                return (T)Convert.ChangeType(user, typeof(T));
            }
            return default(T);

        }

        public override void Update(BaseDTO baseDTO)
        {
            var user = baseDTO as User;
            //Ejecucion del SP
            var sqlOperation = new sqlOperation();
            sqlOperation.ProcedureName = "UPD_USER_PR";

            sqlOperation.AddIntParam("P_ID", user.Id);
            sqlOperation.AddStringParam("P_NAME ", user.Name);
            sqlOperation.AddStringParam("P_Last_Name ", user._LastName);
            sqlOperation.AddStringParam("P_Password", user.Password);
            sqlOperation.AddStringParam("P_Email ", user.Email);
            sqlOperation.AddDateTimeParam("P_BIRTH_DATE", user.BirthDate);
            sqlOperation.AddStringParam("P_Status", user.Status);

            sqlDAO.ExecuteProcedure(sqlOperation);
        }

        //metodo que construye el DTO del usuario a partir de la data que viene de la consulta en BD
        private User BuildUser (Dictionary<string, object> row)
        {
            var user = new User()
            {
                Id = (int)row["ID"],
                Created = (DateTime)row["Created"],
                Name = (string)row["Name"],
                _LastName = (string)row["LastName"],
                Password = (string)row["Password"],
                Email = (string)row["Email"],
                BirthDate = (DateTime)row["BirthDate"],
                Status = (string)row["Status"],
            };
            return user;
        }
    }

}
