using Domain.InterfaceRepositorys;
using Entites;
using Entites.Models;
using Entities.Models;
using Infraestructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IServiceScope _scope;
        private readonly ContextBase _dataBase;
        public UserRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _dataBase = _scope.ServiceProvider.GetRequiredService<ContextBase>();
        }

        public async Task<bool> AddPhones(List<Telephone> phones, long idUser)
        {
            Random random = new Random();
            foreach (var phone in phones)
            {
                phone.UserId = idUser;
                phone.Id = random.Next();
                _dataBase.Telephone.Add(phone);
            }
            var number = await _dataBase.SaveChangesAsync();

            return number >= 1 ? true : false; 
        }

        public async Task<bool> CreateUser(User user)
        {

            _dataBase.User.Add(user);
            var number = await _dataBase.SaveChangesAsync();

            return number == 1 ? true : false;

        }

        public async Task<User> GetUser(long idUser)
        {
            return await _dataBase.User.FirstOrDefaultAsync(t => t.Id == idUser);
        }

        public List<Telephone> GetUserPhones(long idUser)
        {
           return _dataBase.Telephone.Where(t => t.UserId == idUser).ToList();
        }

        public async Task<User> Login(UserLogin user)
        {
            var userLogin = await _dataBase.User.FirstOrDefaultAsync(u => u.Email == user.Email && u.PassWord == user.PassWord);

            return userLogin ?? null;
        }

        public async void UpdateLastLogin(long userId)
        {
            var userLogin = await _dataBase.User.FindAsync(userId);
            if (userLogin != null)
            {
                userLogin.Last_Login = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                await _dataBase.SaveChangesAsync();
            }
        }

        public async Task<bool> VerifyEmail(string email)
        {
            var emailExist = await _dataBase.User.Where(u => u.Email == email).FirstOrDefaultAsync();

            return emailExist != null;
        }
    }
}
