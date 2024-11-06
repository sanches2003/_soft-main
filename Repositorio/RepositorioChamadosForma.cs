using Repositorio.Contexto;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioChamadosForma : BaseRepositorio<ViewTotalChamadosPorForma>
    {
        public RepositorioChamadosForma(SoftContexto contexto)
    : base(contexto) { }
    }
}
