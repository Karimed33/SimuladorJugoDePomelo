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

        private void cbVides_SelectionChangeCommitted(object sender, EventArgs e)
        {
            double media = 200;
            double mediap = 25;
            double deviationp = 5;
            double deviation = 15;
            double jugo, pulpa;
            double cant = int.Parse(cbVides.Text);
            cant = int.Parse(cbVides.Text);
            //txtCantPom.Text = cant.ToString();
            jugo = GenerateRandomVariant(media, deviation);
            txtJugo.Text = (jugo * cant).ToString();
            pulpa = GenerateRandomVariant(mediap, deviationp);
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
            btnJugoGris.Height = 250 - val1/50000;
            btnPulpaGris.Height = 194 - val2/5000;
        }

        private void btnJugoGris_Click(object sender, EventArgs e)
        {

        }

        private void btnPulpaRosa_Click(object sender, EventArgs e)
        {

        }
    }
}
