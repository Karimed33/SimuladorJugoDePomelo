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
    public partial class Citric : Form
    {
        readonly DateTime hoy = DateTime.Now;
        public Citric()
        {
            InitializeComponent();
            txtHora.Text = hoy.ToShortTimeString();
            txtFecha.Text = hoy.ToLongDateString();
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelContenedor.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panelContenedor.Controls.Add(formulario);
                panelContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["Exprimidor"] == null)
            {
                btnProduccion.BackColor = Color.FromArgb(26, 32, 40);
            }
<<<<<<< HEAD
            else
            {
                if (Application.OpenForms["Pasteurizador"] == null)
                {
                    btnPasteurizacion.BackColor = Color.FromArgb(26, 32, 40);
                }
                else
                {
                    if (Application.OpenForms["Envasado"] == null)
                    {
                        btnEnvasado.BackColor = Color.FromArgb(26, 32, 40);
                    }
                }
            }
=======
>>>>>>> 7e5032fc93ef8253c2cbb262cd1d1410a7380917
        }

            private void pbHome_Click(object sender, EventArgs e)
        {
            AbrirFormulario<InicioContenedor>();
        }

        private void txtHora_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Usuarios>();
            btnUsuario.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Exprimidor>();
            btnProduccion.BackColor = Color.FromArgb(12, 61, 92);
        }
<<<<<<< HEAD

        private void btnPasteurizacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Pasteurizador>();
            btnProduccion.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnEnvasado_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Envasado>();
            btnEnvasado.BackColor = Color.FromArgb(12, 61, 92);
        }
=======
>>>>>>> 7e5032fc93ef8253c2cbb262cd1d1410a7380917
    }
}
