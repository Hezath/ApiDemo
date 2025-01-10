using ApiDemo.DTOs;
using ApiDemo.Models;
using AutoMapper;

namespace ApiDemo.Mapping
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, TarefaDto>();
            CreateMap<TarefaDto, Tarefa>();
        }
    }
}