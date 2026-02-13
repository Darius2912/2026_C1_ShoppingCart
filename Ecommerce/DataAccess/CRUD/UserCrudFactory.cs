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
            sqlOperation.AddStringParam("P_Last_Name ", user.LastName);
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

            sqlOperation.AddIntParam("P_ID", user.id);
           
            sqlDAO.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            var user = baseDTO as User;
            //Ejecucion del SP
            var sqlOperation = new sqlOperation();
            sqlOperation.ProcedureName = "UPD_USER_PR";

            sqlOperation.AddIntParam("P_ID", user.id);
            sqlOperation.AddStringParam("P_NAME ", user.Name);
            sqlOperation.AddStringParam("P_Last_Name ", user.LastName);
            sqlOperation.AddStringParam("P_Password", user.Password);
            sqlOperation.AddStringParam("P_Email ", user.Email);
            sqlOperation.AddDateTimeParam("P_BIRTH_DATE", user.BirthDate);
            sqlOperation.AddStringParam("P_Status", user.Status);

            sqlDAO.ExecuteProcedure(sqlOperation);
        }
    }
}
