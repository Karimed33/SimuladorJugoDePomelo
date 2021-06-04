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
    public partial class Pasteurizador : Form
    {
        readonly DateTime hoy = DateTime.Now;
        public Pasteurizador()
        {
            InitializeComponent();
            fLPPasteurizar.Visible = false;
            Iniciar(); 

        }

     

        public void Iniciar()
        {
            string _fecha = hoy.ToShortDateString();
            ExprimidorModels exprimidor = new ExprimidorModels();
            ControlllerExprimidor _ex = new ControlllerExprimidor();
            exprimidor = _ex.Buscar(_fecha);
            if (exprimidor.Feha==null)
            {
                MessageBox.Show("No hay produccion de Jugos para Pasteurizar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int jugoTotal = exprimidor.LitrosJugo + exprimidor.LitrosPulpa;
                CargarPasteurizado(jugoTotal);
                fLPPasteurizar.Visible = true;
            }
        }

        public void CargarPasteurizado(int jugoTotal)
        {
            int rojo = 0;
            int verde = 0;
            List<Pasteurizar> lista = new List<Pasteurizar>();
            lista = PasteurizarJugo(jugoTotal);
            foreach (var a in lista)
            {
                var control = new UserPasteurizador(a.Hora, a.Resultado, a.Estado, a.JugoAgregado);
                fLPPasteurizar.Controls.Add(control);
                llenarTanque();
                if(a.Estado=="rojo")
                {
                    rojo = rojo + 1;
                }
                else
                {
                    verde = verde + 1;
                }
            }
            txtRojo.Text = rojo.ToString();
            txtTotalVerde.Text = verde.ToString();
        }

        public void llenarTanque( )
        {
            int _jugoTotal = int.Parse(txtTotalJugo.Text)*236;
            btnJugoGris.Height = 236 - _jugoTotal / 100000;
        }

        public List<Pasteurizar> PasteurizarJugo(int jugoTotal)
        {
            List<Pasteurizar> lista = new List<Pasteurizar>();
            Distribuciones u = new Distribuciones();
            double caudal;
            int EstadoRojo = 0;
            int EstadoVerde= 0;
            string estado;
            string respuesta = "";
            double jugoAgregado = 0;
            txtTotalJugo.Text = jugoTotal.ToString();
            for (int hora = 1; hora <= 10; hora++)
            {
                if (hora >= 2)
                {
                    double binom = u.GeneradorGUAdictivo();
                    if (binom <= 0.85)
                    {
                        EstadoRojo = 1;
                        estado = "rojo";
                        EstadoVerde = 0;
                        caudal = u.Uniforme(6500, 7500);
                        if (6800 <= caudal && caudal < 7100)
                        {
                            jugoAgregado = int.Parse(txtTotalJugo.Text) * 0.04;
                            respuesta = "Cantidad de Jugo que se debe Agregar:" + jugoAgregado;
                          
                        }
                        else
                        {
                            if (6500 <= caudal && caudal < 6800)
                            {
                                jugoAgregado = int.Parse(txtTotalJugo.Text) * 0.06;
                                respuesta = "Cantidad de Jugo que se debe Agregar:" + jugoAgregado;
                               
                            }
                            else
                            {
                                if (6500 < caudal)
                                {
                                    jugoAgregado = int.Parse(txtTotalJugo.Text) * 0.10;
                                    respuesta = "Cantidad de Jugo que se debe Agregar:" + jugoAgregado;
                              
                                }
                            }
                        }
                    }
                    else
                    {
                        caudal = u.Uniforme(7100,7500);
                        estado = "verde";
                        EstadoVerde = 1;
                        jugoAgregado = 0;
                        EstadoRojo = 0;
                        respuesta = "Caudal Exitoso";
                    }


                }
                else
                {
                    caudal = u.Uniforme(7100,7500);
                    estado = "verde";
                    EstadoVerde = 1;
                    jugoAgregado = 0;
                    EstadoRojo = 0;
                    respuesta = "Caudal Exitoso";
                }

                Pasteurizar pasteurizar = new Pasteurizar();
                pasteurizar.EstadoVerde = EstadoVerde;
                pasteurizar.EstadoRojo = EstadoRojo;
                pasteurizar.JugoAgregado = Math.Truncate(jugoAgregado);
                pasteurizar.Estado = estado;
                pasteurizar.Hora = hora;
                pasteurizar.Resultado = respuesta;
                pasteurizar.JugoTotal = jugoAgregado + jugoTotal;
                lista.Add(pasteurizar);
            }
            return lista;
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

                          
    }
}
