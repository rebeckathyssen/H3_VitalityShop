using System;
using System.Collections.Generic;
using System.Text;
using VitalityShop.Application.Interfaces;
using VitalityShop.Domain.Models;
using VitalityShop.Infrastructure.Repository.Interfaces;

namespace VitalityShop.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        // Constructor
        public UserService(IUserRepository productRepository)
        {
            this.userRepository = productRepository;
        }


        User IUserService.AuthenticateUser(string username, string password)
        {
            return userRepository.AuthenticateUser(username, password);
        }

        IEnumerable<User> IUserService.GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        User IUserService.GetUser(Guid id)
        {
            return userRepository.GetUser(id);
        }

        public User CreateUser(User user, string password)
        {
            return userRepository.CreateUser(user, password);
        }

        public void UpdateUser(User user, string password = null)
        {
            userRepository.UpdateUser(user, password);
        }

        void IUserService.DeleteUser(Guid id)
        {
            userRepository.DeleteUser(id);
        }
    }
}
