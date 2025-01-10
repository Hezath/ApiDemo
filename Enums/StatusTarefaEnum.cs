using System.ComponentModel;

namespace ApiDemo.Enums
{
    public enum StatusTarefaEnum
    {
        [Description("Pendente")]
        Pendente = 0,
        [Description("Concluído")]
        Concluido = 1,
        [Description("Em Progresso")]
        EmProgresso = 2,
        [Description("Encerrado")]
        Encerrado = 3,
    }
}
