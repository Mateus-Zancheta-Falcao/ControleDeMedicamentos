﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos
{
    internal class Paciente : RepositorioMae<Paciente>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CartaoSUS { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
