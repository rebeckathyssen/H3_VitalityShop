using System;
using System.Collections.Generic;
using System.Text;
using VitalityShop.Domain.Models;

namespace VitalityShop.Application.Interfaces
{
    public interface IUserService
    {
        User AuthenticateUser(string username, string password);
        IEnumerable<User> GetAllUsers();
        User GetUser(Guid id);
        User CreateUser(User user, string password);
        void UpdateUser(User user, string password = null);
        void DeleteUser(Guid id);
    }
}
