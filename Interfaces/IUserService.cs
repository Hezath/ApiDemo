using ApiDemo.Models;

namespace ApiDemo.Interfaces
{
    public interface IUserService 
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
