using AppCore;
using Entities_DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    //Ruta de acceso al controlador
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //CRUD

        //CREATE ASOCIADO AL POST
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(User u)
        {
            try
            {
                var um = new UserManager();
                um.Create(u);
                return Ok(u);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var um = new UserManager();
                var lstResults = um.RetrieveAll();

                return Ok(lstResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveById")]
        public ActionResult RetrieveUserById(User u)
        {
            try
            {
                var um = new UserManager();

                var uResult = um.RetriveUserById(u.Id);
                return Ok(uResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(User u)
        {
            try
            {
                var um = new UserManager();
                um.Update(u);
                return Ok(u);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(User u)
        {
            try
            {
                var um = new UserManager();
                um.Delete(u);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}