using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public string Aluno { get; set; }
        public string Pacote { get; set; }
        public DateTime Data { get; set; }
    }
}
