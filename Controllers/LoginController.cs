using LMSProject.Models;
using LMSProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginDTO userDTO)
        {
            var result = _loginService.Login(userDTO);
            if (result != null)
                return Ok(result);
            return BadRequest("Invalid username or password");
        }
        [HttpPost]
        [Route("Register")]
        /*public ActionResult Register(Login user)
        {
            var result = _loginService.Register(user);
            if (result)
                return Ok("User Registered");
            return BadRequest("Could not register user");
        }*/
        public ActionResult Register(UserPassDTO user)
        {
            var result = _loginService.Register(user);
            if (result != null)
                return Ok(result);
            return BadRequest("Could not register user");
        }

    }
}
