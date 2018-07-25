using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.API.Model
{
    public class PacienteInput
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Historico { get; set; }
    }
}
