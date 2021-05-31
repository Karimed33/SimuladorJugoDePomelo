using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SimuladorJugoPomeloControlador.Controladores
{
    public class ConectaBD
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
    }
}
