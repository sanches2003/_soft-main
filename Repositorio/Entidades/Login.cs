﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class Login
    {
        public Login()
        {
            this.atendimentos = new HashSet<Atendimento>();
        }

        public int id { get; set; }

        public String login { get; set; }

        public String senha { get; set; }

        public bool ativo { get; set; }

        public int idCargo { get; set; }

        public virtual Cargo cargo { get; set; }

        public virtual ICollection<Atendimento> atendimentos { get; set; }
    }
}
