using DAL.Abstraction;
using DemoAuthAPI.Models;
using DemoAuthAPI.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DemoAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private JWTService _jwt;
        private IUserRepo _repo;

        public AuthController(JWTService jwt, IUserRepo repo)
        {
            _jwt = jwt;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Login(LoginForm f)
        {
            if (string.IsNullOrEmpty(f.Email) || string.IsNullOrEmpty(f.Password))
                return BadRequest();

            try
            {
                UserClient currentUser = new UserClient(_repo.Login(f.Email, f.Password));
                string token = _jwt.GenerateJWT(currentUser);
                return Ok(token);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Authorize("moderatorPolicy")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll().Select(x => new UserClient(x)));
        }
    }
}
