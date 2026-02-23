using DataAccess.DAO;
using Entities_DTOs;
using System;
using System.Collections.Generic;

namespace DataAccess.CRUD
{
    public class ProductCrudFactory : CrudFactory
    {
        public ProductCrudFactory()
        {
            sqlDAO = sqlDAO.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            var product = baseDTO as Product;
            var sqlOperation = new sqlOperation();
            sqlOperation.ProcedureName = "CRE_PRODUCT_PR";

            sqlOperation.AddStringParam("P_NAME", product.Name);
            sqlOperation.AddStringParam("P_Description", product.Description);
            sqlOperation.AddDecimalParam("P_Price", product.Price);
            sqlOperation.AddIntParam("P_Quantity", product.Quantity);
            sqlOperation.AddStringParam("P_Category", product.Category);

            sqlDAO.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var product = baseDTO as Product;
            var sqlOperation = new sqlOperation();
            sqlOperation.ProcedureName = "DEL_PRODUCT_PR";

            sqlOperation.AddIntParam("P_Id", product.Id);

            sqlDAO.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstResults = new List<T>();
            var operation = new sqlOperation();
            operation.ProcedureName = "RET_ALL_PRODUCT_PR";

            var lstResult = sqlDAO.ExecuteQueryProcedure(operation);

            if (lstResult.Count > 0)
            {
                foreach (var item in lstResult)
                {
                    var product = BuildProduct(item);
                    lstResults.Add((T)Convert.ChangeType(product, typeof(T)));
                }
            }
            return lstResults;
        }

        public override T RetrieveById<T>(int id)
        {
            var operation = new sqlOperation();
            operation.ProcedureName = "RET_PRODUCT_BY_ID_PR";

            operation.AddIntParam("P_Id", id);

            var lstResults = sqlDAO.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                var item = lstResults[0];
                var product = BuildProduct(item);
                return (T)Convert.ChangeType(product, typeof(T));
            }
            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
            var product = baseDTO as Product;
            var sqlOperation = new sqlOperation();
            sqlOperation.ProcedureName = "UPD_PRODUCT_PR";

            sqlOperation.AddIntParam("P_Id", product.Id);
            sqlOperation.AddStringParam("P_NAME", product.Name);
            sqlOperation.AddStringParam("P_Description", product.Description);
            sqlOperation.AddDecimalParam("P_Price", product.Price);
            sqlOperation.AddIntParam("P_Quantity", product.Quantity);
            sqlOperation.AddStringParam("P_Category", product.Category);

            sqlDAO.ExecuteProcedure(sqlOperation);
        }

        // Método que construye el DTO de producto a partir de la data que viene de la consulta en BD
        private Product BuildProduct(Dictionary<string, object> row)
        {
            var product = new Product()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                Name = (string)row["Name"],
                Description = (string)row["Description"],
                Price = (decimal)row["Price"],
                Quantity = (int)row["Quantity"],
                Category = (string)row["Category"]
            };
            return product;
        }
    }
}
