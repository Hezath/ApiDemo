using ApiDemo.Models;

namespace ApiDemo.Interfaces
{
    public interface ITarefaService
    {
        List<User> GetAllTarefas();
        List<User> GetAllUserTarefas(int id);
        User GetTarefaById(int id);
        void CreateTarefa(User user);
        void UpdateTarefa(User user);
        void DeleteTarefa(int id);
    }
}
