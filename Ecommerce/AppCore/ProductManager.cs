using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;

namespace AppCore
{
    // Clase de negocio con validaciones y acciones para Producto
    public class ProductManager : BaseManager
    {
        // CREATE
        public void Create(Product p)
        {
            try
            {
                ValidateProduct(p);

                var pCrud = new ProductCrudFactory();
                pCrud.Create(p);
            }
            catch (Exception ex)
            {
                ManegerException(ex);
            }
        }

        public void Update(Product p)
        {
            try
            {
                ValidateProduct(p);

                var pCrud = new ProductCrudFactory();
                pCrud.Update(p);
            }
            catch (Exception ex)
            {
                ManegerException(ex);
            }
        }

        public void Delete(Product p)
        {
            try
            {
                var pCrud = new ProductCrudFactory();
                pCrud.Delete(p);
            }
            catch (Exception ex)
            {
                ManegerException(ex);
            }
        }

        public List<Product> RetrieveAll()
        {
            var list = new List<Product>();
            try
            {
                var pCrud = new ProductCrudFactory();
                list = pCrud.RetrieveAll<Product>();
            }
            catch (Exception ex)
            {
                ManegerException(ex);
            }
            return list;
        }

        public Product RetrieveById(int id)
        {
            var product = new Product();
            try
            {
                var pCrud = new ProductCrudFactory();
                product = pCrud.RetrieveById<Product>(id);
            }
            catch (Exception ex)
            {
                ManegerException(ex);
            }
            return product;
        }

        private void ValidateProduct(Product p)
        {
            if (string.IsNullOrWhiteSpace(p.Name))
            {
                throw new Exception("El nombre del producto no puede estar vacío.");
            }
            if (p.Price <= 0)
            {
                throw new Exception("El precio debe ser mayor a 0.");
            }
            if (p.Quantity < 0)
            {
                throw new Exception("La cantidad (stock) no puede ser negativa.");
            }
        }
    }
}
