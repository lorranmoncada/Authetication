using Domain.InterfaceRepositorys;
using Domain.Interfaces;
using Entites;
using Entites.Models;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _IUserRepository;
        public UserService(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }
        public async Task<User> CreateUser(User user, List<Telephone> phones)
        {

            var firtsName = user.ValidaPropriedadeString(user.FirstName, "firstName");
            var lastName = user.ValidaPropriedadeString(user.LastName, "lastName");
            var password = user.ValidaPropriedadeString(user.PassWord, "password");
            var email = user.ValidaPropriedadeString(user.Email, "email");

            if (firtsName && lastName && password && email)
            {
                bool emailExist = await _IUserRepository.VerifyEmail(user.Email);

                if (emailExist)
                {
                    throw new ArgumentException($"E-mail {user.Email} alredy exist.", nameof(user.Email));
                }

                bool success = await _IUserRepository.CreateUser(user);

                if (success)
                {
                    await _IUserRepository.AddPhones(phones, user.Id);
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new ArgumentException("Missing Fields");
            }
        }

        public List<Telephone> GetUserPhones(long userId)
        {
            return _IUserRepository.GetUserPhones(userId);
        }

        public Task<User> GetUser(long userId)
        {
            return _IUserRepository.GetUser(userId);
        }

        public async Task<User> Login(UserLogin user)
        {
            var email = user.ValidaPropriedadeString(user.Email, "Email");
            var password = user.ValidaPropriedadeString(user.PassWord, "PassWord");

            if (email && password)
            {
                var usuario = await _IUserRepository.Login(user);

                if (usuario != null)
                {
                    _IUserRepository.UpdateLastLogin(usuario.Id);
                }

                return usuario != null ? usuario : null;
            }
            else
            {
                throw new ArgumentException("Missing Fields");
            }        
        }

        public Task<bool> VerifyEmail(string user)
        {
            return _IUserRepository.VerifyEmail(user);
        }
    }
}
