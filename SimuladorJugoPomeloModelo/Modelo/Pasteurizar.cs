using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorJugoPomeloModelo.Modelo
{
    public class Pasteurizar
    {
        public int EstadoRojo { get; set; }
        public int EstadoVerde { get; set; }
        public double JugoAgregado { get; set; }
        public string Estado { get; set; }
        public int Hora { set; get; }
        public string Resultado { set; get; }
        public double JugoTotal { set; get; }
    }
}
