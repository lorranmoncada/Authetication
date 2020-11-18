using Domain.Interfaces;
using Entites;
using Entites.Models;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationTest
{
   public class UserServiceTest: IUserService
    {
        private readonly User _ObjUser;
        public UserServiceTest()
        {
            _ObjUser = new User();

            _ObjUser.Id = 21423432;
            _ObjUser.FirstName = "lorran";
            _ObjUser.LastName = "mendes";
            _ObjUser.Email = "lorran.mendes@pitang.com";
            _ObjUser.PassWord = "1234";
            _ObjUser.Created_At = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
            _ObjUser.Last_Login = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
            _ObjUser.Phones = null;
            
        }

        public async Task<User> CreateUser(User user, List<Telephone> phones)
        {
            return _ObjUser;
        }

        public async Task<User> GetUser(long userId)
        {
            User ObjUser = new User();

            ObjUser.Id = 21423432;
            ObjUser.FirstName = "lorran";
            ObjUser.LastName = "mendes";
            ObjUser.Email = "lorran.mendes@pitang.com";
            ObjUser.PassWord = "1234";
            ObjUser.Created_At = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
            ObjUser.Last_Login = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
            ObjUser.Phones = null;

            return ObjUser;
        }

        public List<Telephone> GetUserPhones(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Login(UserLogin user)
        {
            return _ObjUser;
        }

        public Task<bool> VerifyEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
