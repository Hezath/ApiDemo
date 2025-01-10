using ApiDemo.Data;
using ApiDemo.Interfaces;
using ApiDemo.Models;

namespace ApiDemo.Services
{
    public class UserService : IUserService
    {
        private readonly ApiDbContext _context;

        public UserService(ApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<User> GetAllUsers()
        {
            if (_context.Users == null)
                throw new InvalidOperationException("Users set is not initialized.");

            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            if (_context.Users == null)
                throw new InvalidOperationException("Users set is not initialized.");
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user ?? throw new KeyNotFoundException($"User with ID {id} not found.");
        }

        public void CreateUser(User user)
        {
            if (_context.Users == null)
                throw new InvalidOperationException("Users set is not initialized.");
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.Senha = CreatePassword();
            _context.Users.Add(user);
            _context.SaveChanges(); 
        }


        public void UpdateUser(User user)
        {
            if (_context.Users == null)
                throw new InvalidOperationException("Users set is not initialized.");

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser == null)
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");

            existingUser.Nome = user.Nome;
            existingUser.Email = user.Email;
            _context.Users.Update(existingUser);
            _context.SaveChanges(); 
        }

        public void DeleteUser(int id)
        {
            if (_context.Users == null)
                throw new InvalidOperationException("Users set is not initialized.");

            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} not found.");

            _context.Users.Remove(user);
            _context.SaveChanges(); 
        }

        private string CreatePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
