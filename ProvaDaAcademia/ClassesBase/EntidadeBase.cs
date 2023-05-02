﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ClassesBase
{
    internal abstract class EntidadeBase
    {
        public int id { get; set; }
        public abstract void Atualizar(EntidadeBase entidadeAtualizada);

    }
}