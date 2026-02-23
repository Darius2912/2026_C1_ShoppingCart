using AppCore;
using Entities_DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
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
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public IActionResult RetrieveAll()
        {
            try
            {
                var pm = new ProductManager();
                var lstResults = pm.RetrieveAll();
                return Ok(lstResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("RetrieveById")]
        public IActionResult RetrieveById(int id)
        {
            try
            {
                var pm = new ProductManager();
                var pResult = pm.RetrieveById(id);
                return Ok(pResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Product p)
        {
            try
            {
                var pm = new ProductManager();
                pm.Update(p);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Product p)
        {
            try
            {
                var pm = new ProductManager();
                pm.Delete(p);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
