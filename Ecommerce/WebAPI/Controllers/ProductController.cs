using AppCore;
using Entities_DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // CREATE (POST)
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Product p)
        {
            try
            {
                var pm = new ProductManager();
                pm.Create(p);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // RETRIEVE ALL (GET)
        [HttpGet]
        [Route("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var pm = new ProductManager();
                var lstResults = pm.RetrieveAll();
                return Ok(lstResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // RETRIEVE BY ID (GET)
        [HttpGet]
        [Route("RetrieveById")]
        public ActionResult RetrieveById(Product p)
        {
            try
            {
                var pm = new ProductManager();
                var pResult = pm.RetrieveById(p.Id);
                return Ok(pResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // UPDATE (PUT)
        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Product p)
        {
            try
            {
                var pm = new ProductManager();
                pm.Update(p);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE (DELETE)
        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(Product p)
        {
            try
            {
                var pm = new ProductManager();
                pm.Delete(p);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
