using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimuladorJugoPomeloDominio.Modelo;

namespace SimuladorJugoPomeloControlador.Controladores
{
   public  class ControllerUsuario
    {
        ConectaBD conexion = new ConectaBD();
        public string Registro(Usuarios usuarios)
        {
            string repuesta;
            if (string.IsNullOrEmpty(usuarios.Usuario1) || string.IsNullOrEmpty(usuarios.Password) || string.IsNullOrEmpty(usuarios.ConPassword))
            {
                repuesta = "Debe llenar todos los campos";
            }
            else
            {
                if (usuarios.Password == usuarios.ConPassword)
                {
                    if (ExisteUsuario(usuarios.Usuario1))
                    {
                        repuesta = "El Usuario ya Existe";
                    }
                    else
                    {
                        usuarios.Password = GenerarSHA1(usuarios.Password);
                        Registro(usuarios);
                        repuesta = "Usuario Registrado con Exito";
                    }
                }
                else
                {
                    repuesta = "Las contraseñas no Coinciden";
                }
            }

            return repuesta;
        }


        public string GenerarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString();
        }

        public string CambioPassword(Usuarios usuarios)
        {

            string respuesta;
            if (string.IsNullOrEmpty(usuarios.Password) || string.IsNullOrEmpty(usuarios.ConPassword))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                if (usuarios.Password == usuarios.ConPassword)
                {

                    usuarios.Password = GenerarSHA1(usuarios.Password);
                    Registrar(usuarios);
                    respuesta = "Nueva Contraseña Registrada";
                }
                else
                {
                    respuesta = "Las contraseñas no Coinciden";
                }
            }

            return respuesta;
        }


        public void CrearUsuario(Usuarios usuario)
        {
            if (usuario.TipoUsuario == "Administrador")
            {
                usuario.IdTipoUsuario = 1;
            }
            else
            {
                if (usuario.TipoUsuario == "Autoridad")
                {
                    usuario.IdTipoUsuario = 2;
                }
                else
                {
                    if (usuario.TipoUsuario == "Auxiliar")
                    {
                        usuario.IdTipoUsuario = 7;
                    }
                    else
                    {
                        if (usuario.TipoUsuario == "Comsión de Trabajo")
                        {
                            usuario.IdTipoUsuario = 3;
                        }
                        else
                        {
                            if (usuario.TipoUsuario == "Secretaria")
                            {
                                usuario.IdTipoUsuario = 6;
                            }
                            else
                            {
                                if (usuario.TipoUsuario == "Mesa de Entrada")
                                {
                                    usuario.IdTipoUsuario = 4;
                                }
                                else
                                {
                                    if (usuario.TipoUsuario == "Sala Presidencia")
                                    {
                                        usuario.IdTipoUsuario = 5;
                                    }
                                    else
                                    {
                                        usuario.IdTipoUsuario = 8;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        public int Registrar(Usuarios usuario)
        {
            
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "INSERT INTO usuarios (Usuario, Contraseña, LegajoEmpleado, IdTipoUsuario) VALUE (@Usuario, @Contraseña, @LegajoEmpleado, @IdTipoUsuario)";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            comando.Parameters.AddWithValue("@Usuario", usuario.Usuario1);
            comando.Parameters.AddWithValue("@Contraseña", usuario.Password);
            comando.Parameters.AddWithValue("@LegajoEmpleado", usuario.NumeroLegajo);
            comando.Parameters.AddWithValue("@IdTipoUsuario", usuario.IdTipoUsuario);

            int resultado = comando.ExecuteNonQuery();

            return resultado;


        }

        public bool ExisteUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "SELECT Id FROM usuarios WHERE  Usuario = @Usuario ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            comando.Parameters.AddWithValue("@Usuario", usuario);

            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
