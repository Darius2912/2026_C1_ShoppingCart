using AppCore;
using Entities_DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager _userManager;

        // El contenedor de dependencias inyecta UserManager automáticamente
        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

        // CREATE asociado al POST
        [HttpPost("Create")]
        public IActionResult Create(User u)
        {
            try
            {
                _userManager.Create(u);
                return Ok(new { message = "Usuario creado y correo enviado", user = u });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var lstResults = _userManager.RetrieveAll();
                return Ok(lstResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("RetrieveById/{id}")]
        public ActionResult RetrieveUserById(int id)
        {
            try
            {
                var uResult = _userManager.RetriveUserById(id);
                return Ok(uResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public ActionResult Update(User u)
        {
            try
            {
                _userManager.Update(u);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(User u)
        {
            try
            {
                _userManager.Delete(u);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
