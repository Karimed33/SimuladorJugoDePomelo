using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorJugoPomeloModelo.Modelo
{
    public class User
    {
        public int Id { get; set; }
        public int Legajo { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public int TipoUsuario { get; set; }
        public string ConPassword { get; set; }
    }
}
