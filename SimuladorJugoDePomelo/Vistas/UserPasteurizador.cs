using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorJugoDePomelo.Vistas
{
    public partial class UserPasteurizador : UserControl
    {
        private int _hora;
       // private int _id;
        private string _resultado;
        private double _litrosAgregados;
        public UserPasteurizador()
        {
            InitializeComponent();
        }


        public UserPasteurizador(int hora, string resultado, string estado, double litrosAgregados) : this()
        {
            _hora = hora;
            _resultado = resultado;
            lbSolucion.Text = _resultado;
            _litrosAgregados = litrosAgregados;
            txtLitrosAgregados.Text = _litrosAgregados.ToString();
            label1.Text = "Hora:" + _hora;
            
            if(estado=="verde")
            {
                pbEstadoVerde.Image = SimuladorJugoDePomelo.Properties.Resources.correcto4;
            }
            else
            {
                pbEstadoVerde.Image = SimuladorJugoDePomelo.Properties.Resources.mal1;
            }

        }

      

        private void pbEstado_Click(object sender, EventArgs e)
        {

        }
    }
}
