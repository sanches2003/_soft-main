using Repositorio.Contexto;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class AtendimentoRepositorio : BaseRepositorio<Atendimento> // criar entidade!!!
    {
        public AtendimentoRepositorio(SoftContexto contexto)
            : base(contexto) { }
    }
}
