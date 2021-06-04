using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimuladorJugoPomeloModelo.Modelo;

namespace SimuladorJugoPomeloController.Controllers
{
    
    public class ControlllerExprimidor
    {
        ConectaBD conexion = new ConectaBD();
        public string Insertar( ExprimidorModels datos)
        {
            string respuesta;
            conexion = new ConectaBD();
            bool bandera = false;
            string sql = "INSERT INTO exprimidor (Fecha, Vides, LitrosJugo, LitrosPulpa) VALUES ('" + datos.Feha + "',  '" + datos.Vides + "', '" + datos.LitrosJugo + "', '" + datos.LitrosPulpa + "')";
            bandera = conexion.Conecta(sql);
            if (bandera)
            {
                respuesta = "Se Guardo la Producción con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar Guardar el Registro";
            }
            return respuesta;
        }

        public ExprimidorModels Buscar(string fecha)
        {
            MySqlDataReader reader;
            ExprimidorModels _ex = new ExprimidorModels();
            string sql;
            sql = "SELECT Id, Fecha, Vides, LitrosJugo, LitrosPulpa FROM exprimidor WHERE Fecha = '" + fecha + "' ";
            try
            {
                conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    _ex.Id = int.Parse(reader.GetString(0));
                    _ex.Feha = reader[1].ToString();
                    _ex.Vides = int.Parse(reader.GetString(2));
                    _ex.LitrosJugo = int.Parse(reader.GetString(3));
                    _ex.LitrosPulpa = int.Parse(reader.GetString(4));
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return _ex;
        }
    }
}
