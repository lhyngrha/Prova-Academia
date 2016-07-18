using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Models
{
    public class Parcela
    {
        public int Id { get; set; }
        public int IdMatricula { get; set;}
        public DateTime Data { get; set; }
        public double Pago { get; set; }
        public double Valor { get; set; }
    }
}
