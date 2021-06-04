using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using SimuladorJugoPomeloModelo.Modelo;
using SimuladorJugoPomeloController.Controllers;
=======
>>>>>>> 7e5032fc93ef8253c2cbb262cd1d1410a7380917

namespace SimuladorJugoDePomelo.Vistas
{
    public partial class Exprimidor : Form
    {
        readonly DateTime hoy = DateTime.Now;
        public Exprimidor()
        {
            InitializeComponent();
            cargarCombo();
            txtFecha.Text = hoy.ToShortDateString();
            txtUser.Text = "kmedina";
            
        }

<<<<<<< HEAD
        private void cargarCombo()
        {
            cbVides.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVides.Items.Add("200");
            cbVides.Items.Add("205");
            cbVides.Items.Add("210");
            cbVides.Items.Add("215");
            cbVides.Items.Add("220");
            cbVides.Items.Add("225");
            cbVides.Items.Add("230");
            cbVides.Items.Add("235");
            cbVides.Items.Add("240");
            cbVides.Items.Add("245");
            cbVides.Items.Add("250");

        }

       

=======
        public static double GenerateRandomVariant(double mean, double deviation, System.Random Rand = null, int factor = 1)
        {

            Rand = Rand ?? new Random();
            double randNormal = Math.Round((MathNet.Numerics.Distributions.Normal.Sample(Rand, mean, deviation)), 2);
            return factor * randNormal;

        }

        private void cargarCombo()
        {
            cbVides.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVides.Items.Add("150");
            cbVides.Items.Add("155");
            cbVides.Items.Add("160");
            cbVides.Items.Add("165");
            cbVides.Items.Add("170");
            cbVides.Items.Add("175");
            cbVides.Items.Add("180");
            cbVides.Items.Add("185");
            cbVides.Items.Add("190");
            cbVides.Items.Add("195");
            cbVides.Items.Add("200");

        }

>>>>>>> 7e5032fc93ef8253c2cbb262cd1d1410a7380917
        private void cbVides_SelectionChangeCommitted(object sender, EventArgs e)
        {
            double media = 200;
            double mediap = 25;
            double deviationp = 5;
            double deviation = 15;
            double jugo, pulpa;
            double cant = int.Parse(cbVides.Text);
            cant = int.Parse(cbVides.Text);
<<<<<<< HEAD
            Distribuciones u = new Distribuciones();
            jugo = Math.Round(u.Normal(media, deviation),2);
            txtJugo.Text = (jugo * cant).ToString();
            pulpa = Math.Round(u.Normal(mediap, deviationp));
=======
            //txtCantPom.Text = cant.ToString();
            jugo = GenerateRandomVariant(media, deviation);
            txtJugo.Text = (jugo * cant).ToString();
            pulpa = GenerateRandomVariant(mediap, deviationp);
>>>>>>> 7e5032fc93ef8253c2cbb262cd1d1410a7380917
            txtPulpa.Text = (pulpa * cant).ToString();
            LlenarTanque();

        }

        private void LlenarTanque()
        {
            double tamañoJ; double tamañoP;
            tamañoJ = double.Parse(txtJugo.Text);
            tamañoP = double.Parse(txtPulpa.Text);
            int val1 = Convert.ToInt32(tamañoJ * 250);
            int val2 = Convert.ToInt32(tamañoP * 194);
<<<<<<< HEAD
            btnJugoGris.Height = 250 - val1/100000;
            btnPulpaGris.Height = 194 - val2/20000;
=======
            btnJugoGris.Height = 250 - val1/50000;
            btnPulpaGris.Height = 194 - val2/5000;
>>>>>>> 7e5032fc93ef8253c2cbb262cd1d1410a7380917
        }

        private void btnJugoGris_Click(object sender, EventArgs e)
        {

        }

        private void btnPulpaRosa_Click(object sender, EventArgs e)
        {

        }
<<<<<<< HEAD

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        public void Ingresar()
        {
            string respuesta;
            decimal val1 = Math.Truncate(decimal.Parse(txtJugo.Text));
            decimal val2 = Math.Truncate(decimal.Parse(txtJugo.Text));
            ExprimidorModels _ex = new ExprimidorModels()
            {
                Feha= txtFecha.Text,
                Vides = int.Parse(cbVides.Text),
                LitrosJugo = Convert.ToInt32(val1),
                LitrosPulpa = Convert.ToInt32(val2),
              
            };
            ControlllerExprimidor presentdor = new ControlllerExprimidor();
            respuesta = presentdor.Insertar(_ex);
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
=======
>>>>>>> 7e5032fc93ef8253c2cbb262cd1d1410a7380917
    }
}
