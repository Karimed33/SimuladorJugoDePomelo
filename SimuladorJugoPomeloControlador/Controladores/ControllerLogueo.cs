using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimuladorJugoPomeloDominio.Modelo;


namespace SimuladorJugoPomeloControlador.Controladores
{
    public class ControllerLogueo
    {
        ConectaBD conexion = new ConectaBD();
        public string Login(string usuario, string password)
        {
            string repuesta = "";
            Usuarios datoUsurio;

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
                    ControllerUsuario user = new ControllerUsuario();
                    if (datoUsurio.Password != user.GenerarSHA1(password))
                    {
                        repuesta = "El Usuario y/o Contraseña no Coinciden";

                    }
                    else
                    {
                        Sesion.Id2 = datoUsurio.Id;
                        Sesion.Usuario2 = datoUsurio.Usuario1;
                        Sesion.NumeroLegajo2 = datoUsurio.NumeroLegajo;
                        Sesion.IdTipoUsuario2 = datoUsurio.IdTipoUsuario;
                    }
                }
            }
            return repuesta;
        }


        public Usuarios VerUsuario(string usuario)
        {

            MySqlDataReader reader;
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "SELECT Id, Usuario, Contraseña, LegajoEmpleado, IdTipoUsuario FROM usuarios WHERE  Usuario Like @Usuario ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            comando.Parameters.AddWithValue("@Usuario", usuario);

            reader = comando.ExecuteReader();

            Usuarios usr = null;
            while (reader.Read())
            {
                usr = new Usuarios
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Usuario1 = reader["Usuario"].ToString(),
                    Password = reader["Contraseña"].ToString(),
                    NumeroLegajo = int.Parse(reader["LegajoEmpleado"].ToString()),
                    IdTipoUsuario = int.Parse(reader["IdTipoUsuario"].ToString())
                };

            }
            return usr;
        }
    }
}
