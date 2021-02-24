using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VitalityShop.Domain.Models;
using VitalityShop.Infrastructure.Repository.Helpers;
using VitalityShop.Infrastructure.Repository.Interfaces;

namespace VitalityShop.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly VitalityDbContext dbContext;

        // Constructor
        public UserRepository(VitalityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Method for authenticating a user
        public User AuthenticateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = dbContext.Users.SingleOrDefault(x => x.Email == email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        //Method for getting all users
        public IEnumerable<User> GetAllUsers()
        {
            return dbContext.Users;
        }

        // Method for getting 1 user based on id
        public User GetUser(Guid id)
        {
            return dbContext.Users.Find(id);
        }

        // Method for creating new user
        public User CreateUser(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Indtast password.");

            if (dbContext.Users.Any(x => x.Email == user.Email))
                throw new AppException("En bruger med email \"" + user.Email + "\" er allerede registreret!");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user;
        }

        // Method for updating an already existing user
        public void UpdateUser(User userParam, string password = null)
        {
            var user = dbContext.Users.Find(userParam.UserId);

            if (user == null)
                throw new AppException("Bruger ikke fundet!");

            // update email if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Email) && userParam.Email != user.Email)
            {
                // throw error if the new email is already taken
                if (dbContext.Users.Any(x => x.Email == userParam.Email))
                    throw new AppException("En bruger med email " + userParam.Email + " er allerede registreret.");

                user.Email = userParam.Email;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            user.Phone = userParam.Phone;

            user.Street = userParam.Street;

            user.Housenumber = userParam.Housenumber;

            user.ZipId = userParam.ZipId;

            user.RoleId = userParam.RoleId;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            dbContext.Users.Update(user);
            dbContext.SaveChanges();
        }

        // Method for deleting user
        public void DeleteUser(Guid id)
        {
            var user = dbContext.Users.Find(id);
            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        // HELPER METHOD: 
        // Creates a hashed password so it can't be read in the database
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Passwordet må ikke være tomt.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        // HELPER METHOD:
        // Veryfies the password
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Passwordet må ikke være tomt.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
