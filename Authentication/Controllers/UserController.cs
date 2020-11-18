using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Services;
using Entites;
using Entites.Models;
using Entities.Models;
using Infraestructure.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Authentication.Controllers
{

    [Produces("application/json")]
    [Route("api")]
    public class UserController : Controller
    {
        private readonly IUserService _IUserService;
        public UserController(IUserService IUserService)
        {
            _IUserService = IUserService;
        }

        [HttpGet]
        [Route("me")]
        [Authorize]
        public async Task<IActionResult> LoginByHeader([FromHeader(Name = "Authorization")] string authorization)
        {

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var usuario = await _IUserService.GetUser(Convert.ToInt64(id));


            return Ok(new
            {
                Id = usuario.Id,
                FirstName = usuario.FirstName,
                LastName = usuario.LastName,
                Email = usuario.Email,
                PassWord = usuario.PassWord,
                Created_At = usuario.Created_At,
                Last_Login = usuario.Last_Login,
                Phones = usuario.Phones
            });
        }


        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                Random random = new Random();

                var usuario = await _IUserService.CreateUser(new User
                {
                    Id = random.Next(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PassWord = user.PassWord,
                    Created_At = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture)
                }, user.Phones);

                return Ok(new { message = "user " + usuario.FirstName + " successfully created" });


            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message ?? "Could not create user", erroCorde = "400" });
            }
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            try
            {
                var usuario = await _IUserService.Login(user);

                if (usuario == null)
                {
                    return NotFound(new { message = "Invalid e-mail or password" });
                }

                usuario.PassWord = "";
                var getToken = TokenService.SetToken(usuario);

                return Ok(new
                {
                    Id = usuario.Id,
                    FirstName = usuario.FirstName,
                    LastName = usuario.LastName,
                    Email = usuario.Email,
                    PassWord = usuario.PassWord,
                    Created_At = usuario.Created_At,
                    Last_Login = usuario.Last_Login,
                    Phones = usuario.Phones
            ,
                    token = getToken,
                    message = "User logged in successfully!"
                });

            }
            catch
            {
                return Json(new { message = "Unable to login", erroCorde = "400" });
            }
        }
    }
}
