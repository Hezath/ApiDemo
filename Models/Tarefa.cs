using ApiDemo.Enums;

namespace ApiDemo.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public required User Criador { get; set; } 
        public required DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public required StatusTarefaEnum Status { get; set; }

    }
}
