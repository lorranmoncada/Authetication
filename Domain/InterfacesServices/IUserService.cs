using Entites;
using Entites.Models;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user, List<Telephone> phones);

        Task<bool> VerifyEmail(string email);

        Task<User> Login(UserLogin user);

        public List<Telephone> GetUserPhones(long userId);

        public Task<User> GetUser(long userId);
    }
}
