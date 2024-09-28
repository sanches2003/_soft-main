using AutoMapper;
using Repositorio.Contexto;
using Repositorio.Entidades;
using Repositorio;

namespace CompusoftAtendimento.Models
{
    public class AtendimentoViewModel
    {
        public AtendimentoModel Atendimento { get; set; }
        public IEnumerable<AtendimentoModel> Atendimentos { get; set; }

    }
}

