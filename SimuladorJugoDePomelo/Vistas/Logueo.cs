using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimuladorJugoPomeloController.Controllers;



namespace SimuladorJugoDePomelo.Vistas
{
    public partial class Logueo : Form
    {
        public Logueo()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        public void Ingresar()
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            try
            {
                 ControllerLogueo crtl = new ControllerLogueo();
                string respuesta = crtl.Login(usuario, password);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Citric simulador = new Citric();
                    simulador.Visible = true;
                    this.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
