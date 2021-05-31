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
using SimuladorJugoPomeloModelo.Modelo;

namespace SimuladorJugoDePomelo.Vistas
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            cbTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboCargo();
            Limpiar();
            Ocultar();
        }


        public void ComboCargo()
        {
            ControllerUsuarios pres = new ControllerUsuarios();
            cbTipoUsuario.DataSource = null;
            cbTipoUsuario.Items.Clear();
            DataTable dt = pres.MostrarTipoUsuario();
            cbTipoUsuario.ValueMember = "Id";
            cbTipoUsuario.DisplayMember = "tiposUsuarios";
            cbTipoUsuario.DataSource = dt;
        }

        private void Limpiar()
        {
            txtUsuario.Text = " ";
            txtPassword.Text = " ";
            txtConPassword.Text = " ";
            txtLegajo.Text = " ";
            cbTipoUsuario.SelectedIndex = -1;
        }

        private void Ocultar()
        {
            pbSalir.Visible = false;
            lbEliminar.Visible = false;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {

        }

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
            Limpiar();
            Ocultar();
        }

        public void Agregar()
        {
            string tipouser = cbTipoUsuario.Text;
            User usuario = new User
            {
                Usuario1 = txtUsuario.Text,
                Password = txtPassword.Text,
                ConPassword = txtConPassword.Text,
                Legajo = int.Parse(txtLegajo.Text),
                TipoUsuario = BuscarIdUser(tipouser),
            };
            try
            {

                ControllerUsuarios pres = new ControllerUsuarios();
                string respuesta = pres.Registro(usuario);

                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        public int BuscarIdUser(string tipouser)
        {
            ControllerUsuarios pres = new ControllerUsuarios();
            int idTipo = pres.ObtenerIdUser(tipouser);
            return idTipo;
        }
    }
}
