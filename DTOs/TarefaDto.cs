using ApiDemo.Enums;
using ApiDemo.Models;

namespace ApiDemo.DTOs
{
    public class TarefaDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public required User Criador { get; set; }
        public required DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        private TimeSpan? Periodo => CalcularPeriodo();
        public required StatusTarefaEnum Status { get; set; }




        private TimeSpan? CalcularPeriodo()
        {
            if (!DataFim.HasValue)
            {
                return null;
            }
            return DataFim.Value - DataInicio;
        }
    }
}
