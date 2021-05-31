using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimuladorJugoPomeloModelo.Modelo;

namespace SimuladorJugoPomeloController.Controllers
{
   public class ControllerLogueo
    {
        public string Login(string usuario, string password)
        {
            string repuesta = "";
            User datoUsurio;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                repuesta = "Debe llenar todo los campos";
            }
            else
            {
                datoUsurio = VerUsuario(usuario);
                if (datoUsurio == null)
                {
                    repuesta = "El Usuario no Existe";
                }
                else
                {
                     ControllerUsuarios user = new ControllerUsuarios();
                    if (datoUsurio.Password != user.GenerarSHA1(password))
                    {
                        repuesta = "El Usuario y/o Contraseña no Coinciden";

                    }
                    else
                    {
                        Sesion.Id = datoUsurio.Id;
                        Sesion.Usuario = datoUsurio.Usuario1;
                        Sesion.Legajo = datoUsurio.Legajo;
                        Sesion.IdTipoUsuario = datoUsurio.TipoUsuario;
                    }
                }
            }
            return repuesta;
        }

        
        public User VerUsuario(string usuarios)
        {
            ConectaBD conexion = new ConectaBD();
            MySqlDataReader reader;
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "SELECT Id, Usuario, Contraseña, Legajo, TipoUsuario FROM usuario WHERE  Usuario = '"+usuarios+"' ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            //comando.Parameters.AddWithValue("@Usuario", usuarios);

            reader = comando.ExecuteReader();

            User usr = null;
            while (reader.Read())
            {
                usr = new User
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Usuario1 = reader["Usuario"].ToString(),
                    Password = reader["Contraseña"].ToString(),
                    Legajo = int.Parse(reader["Legajo"].ToString()),
                    TipoUsuario = int.Parse(reader["TipoUsuario"].ToString()),
                };

            }
            return usr;
        }
    }
}
