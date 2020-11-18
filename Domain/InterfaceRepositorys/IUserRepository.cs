using Entites;
using Entites.Models;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfaceRepositorys
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);

        Task<bool> AddPhones(List<Telephone> user, long idUser);

        Task<User> Login(UserLogin user);

        void UpdateLastLogin(long userId);

        List<Telephone> GetUserPhones(long idUser);

        Task<User> GetUser(long idUser);

        Task<bool> VerifyEmail(string email);
    }
}
