using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorJugoPomeloController.Controllers
{
    class ConectaBD
    {
        public MySqlConnection Conectar()
        {
            string cadenaConexion = @"Data Source=localhost; Database = citric; User Id=new";
            try
            {
                MySqlConnection ConexionBD = new MySqlConnection(cadenaConexion);

                return ConexionBD;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }

        public bool Conecta(string sql)
        {
            bool bandera = false;
            try
            {
                MySqlConnection conexionBD = Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
                conexionBD.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                bandera = false;
            }
            return bandera;
        }
    }
}
