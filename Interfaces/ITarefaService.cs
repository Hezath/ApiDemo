using ApiDemo.Models;

namespace ApiDemo.Interfaces
{
    public interface ITarefaService
    {
        List<Tarefa> GetAllTarefas();
        List<Tarefa> GetAllUserTarefas(int id);
        User GetTarefaById(int id);
        void CreateTarefa(User user);
        void UpdateTarefa(User user);
        void DeleteTarefa(int id);
    }
}
