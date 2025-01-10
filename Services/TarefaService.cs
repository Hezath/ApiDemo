using ApiDemo.Data;
using ApiDemo.Interfaces;
using ApiDemo.Models;

namespace ApiDemo.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ApiDbContext _context;

        public TarefaService(ApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void CreateTarefa(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteTarefa(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tarefa> GetAllTarefas()
        {
            throw new NotImplementedException();
        }

        public List<Tarefa> GetAllUserTarefas(int id)
        {
            if (_context.Tarefas == null)
                throw new InvalidOperationException("Users set is not initialized.");
            return [.. _context.Tarefas.Where(t => t.Id == id)];
            //return _context.Tarefas.Where(t => t.Id == id).ToList();   é mesma coisa da linha 35 porém não simplificado
        }

        public User GetTarefaById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTarefa(User user)
        {
            throw new NotImplementedException();
        }

    }
}
