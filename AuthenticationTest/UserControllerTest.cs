using Authentication.Controllers;
using Domain.Interfaces;
using Entites;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace AuthenticationTest
{
    public class UserControllerTest : Controller
    {

        private readonly UserController _controller;
        private readonly IUserService _service;
        private readonly User _ObjUser;


        public UserControllerTest()
        {
            _service = new UserServiceTest();
            _controller = new UserController(_service);
            _ObjUser = new User
            {
                Id = 21423432,
                FirstName = "lorran",
                LastName = "mendes",
                Email = "lorran.mendes@pitang.com",
                PassWord = "1234",
                Created_At = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                Last_Login = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                Phones = null,
            };

        }

        [Fact]
        public async Task CriaUsuarioTest()
        {

            var messageExpected = "user lorran successfully created";

            var okResult = await _controller.CreateUser(_ObjUser) as OkObjectResult;

            var msgRetorno = (string)okResult.Value.GetType().GetProperty("message").GetValue(okResult.Value);

            Assert.Equal(messageExpected, msgRetorno);
        }

        [Fact]
        public async Task LoginUserTest()
        {
            string messageExpected = "User logged in successfully!";

            UserLogin UserLogin = new UserLogin();

            UserLogin.Email = "lorran.mendes@pitang.com";
            UserLogin.PassWord = "1234";

            var okResult = await _controller.Login(UserLogin) as OkObjectResult;
            var textReturn = (string)okResult.Value.GetType().GetProperty("message").GetValue(okResult.Value);
            User usuario = (User)okResult.Value.GetType().GetProperty("usuario").GetValue(okResult.Value);

            Assert.Equal(messageExpected, textReturn);
            Assert.Equal(usuario.Id, _ObjUser.Id);
            Assert.Equal(usuario.FirstName, _ObjUser.FirstName);
            Assert.Equal(usuario.LastName, _ObjUser.LastName);
            Assert.Equal(usuario.Created_At, _ObjUser.Created_At);
            Assert.Equal(usuario.Last_Login, _ObjUser.Last_Login);
        }

        [Fact]
        public async Task LoginByHeader()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
              new Claim(ClaimTypes.NameIdentifier, "21423432"),
             }, "mock"));


            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var okResult = await _controller.LoginByHeader("sdfsdfsdffew43545re4t536er4t54ert45") as OkObjectResult;
            long id = (long)okResult.Value.GetType().GetProperty("Id").GetValue(okResult.Value);
            string firstName = (string)okResult.Value.GetType().GetProperty("FirstName").GetValue(okResult.Value);
            string lastName = (string)okResult.Value.GetType().GetProperty("LastName").GetValue(okResult.Value);
            string created_At = (string)okResult.Value.GetType().GetProperty("Created_At").GetValue(okResult.Value);
            string last_Login = (string)okResult.Value.GetType().GetProperty("Last_Login").GetValue(okResult.Value);

            Assert.Equal(id, _ObjUser.Id);
            Assert.Equal(firstName, _ObjUser.FirstName);
            Assert.Equal(lastName, _ObjUser.LastName);
            Assert.Equal(created_At, _ObjUser.Created_At);
            Assert.Equal(last_Login, _ObjUser.Last_Login);
        }

    }
}
