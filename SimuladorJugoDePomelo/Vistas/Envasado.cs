using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimuladorJugoPomeloModelo.Modelo;
using SimuladorJugoPomeloController.Controllers;
using SimuladorJugoDePomelo.Vistas;

namespace SimuladorJugoDePomelo.Vistas
{
    public partial class Envasado : Form
    {
        readonly DateTime hoy = DateTime.Now;
        public Envasado()
        {
            InitializeComponent();
            Iniciar();
        }

        public void Iniciar()
        {
            
                string _fecha = hoy.ToShortDateString();
                ExprimidorModels exprimidor = new ExprimidorModels();
                ControlllerExprimidor _ex = new ControlllerExprimidor();
                exprimidor = _ex.Buscar(_fecha);
                if (exprimidor.Feha == null)
                {
                    MessageBox.Show("No hay produccion de Jugos para Pasteurizar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int jugoTotal = exprimidor.LitrosJugo + exprimidor.LitrosPulpa;
                    MostrarEnvasado(jugoTotal);
                    
                }
        }

        public void MostrarEnvasado(int jugo)
        {
            double jugoTotal = 0;
            List<Pasteurizar> lista = new List<Pasteurizar>();
            Pasteurizador paste = new Pasteurizador();
            lista = paste.PasteurizarJugo(jugo);
            foreach (var a in lista)
            {
                jugoTotal = a.JugoTotal + jugoTotal;
            }
            LlenarVista(jugoTotal);
        }

        private void LlenarVista(double jugo)
        {
            double CantidadJugo500, CantidadJugo1lt;
            CantidadJugo1lt = (jugo * 60) / 100;
            CantidadJugo500 = (jugo * 40) / 100;
            Distribuciones dis = new Distribuciones();
            double u;
            CargarJugo500(CantidadJugo500);
            CargarJugo1lt(CantidadJugo1lt);

        }

        public void CargarJugo1lt(double cantidadJugo1lt)
        {
            Distribuciones dis = new Distribuciones();
            double u, perdida1lt, cantidadProducida1, jugo1lt;
            u = dis.Uniforme(0.003, 0.005);
            perdida1lt = Math.Round(cantidadJugo1lt * u / 100);
            jugo1lt = Math.Round(cantidadJugo1lt - perdida1lt);
            cantidadProducida1 = Math.Truncate(jugo1lt);
            txtCantidadProducido1lt.Text = jugo1lt.ToString();
            txtJugoDesperdiciado2.Text = perdida1lt.ToString();
        }
        public void CargarJugo500(double CantidadJugo500)
        {
            Distribuciones dis = new Distribuciones();
            double u, perdida500,jugo500,cantidadProducida500;
            u = dis.Uniforme(0.005, 0.007);
            perdida500 =Math.Round(CantidadJugo500 * u / 100);
            jugo500 = Math.Round(CantidadJugo500 - perdida500);
            cantidadProducida500 = Math.Truncate((jugo500 * 1000) / 500);
            txtCantidad500ml.Text = jugo500.ToString();
            txtJugoDesperdiciado.Text = perdida500.ToString();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
