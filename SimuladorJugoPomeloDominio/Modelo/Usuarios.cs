using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorJugoPomeloDominio.Modelo
{
    public class Usuarios
    {
        public int Id { get; set; }
        public int NumeroLegajo { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public string ConPassword { get; set; }
    }
}
