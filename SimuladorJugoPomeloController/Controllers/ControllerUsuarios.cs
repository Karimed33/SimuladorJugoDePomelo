using MySql.Data.MySqlClient;
using SimuladorJugoPomeloModelo.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorJugoPomeloController.Controllers
{
   public class ControllerUsuarios
    {
        ConectaBD conexion = new ConectaBD();
        public List<User> Consulta(string dato)
        {
            MySqlDataReader reader;
            List<User> lista = new List<User>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT Id, Usuario, Contraseña, Legajo, TipoUsuario, IdCargo FROM usuarios ORDER BY Usuario ASC ";
            }
            else
            {
                sql = "SELECT Id, Usuario, Contraseña, Legajo, TipoUsuario, IdCargo FROM usuarios WHERE Usuario LIKE '%" + dato + "%' OR Legajo LIKE '%" + dato + "%'  ORDER BY Usuario ASC ";
            }

            try
            {
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    User _usuario = new User();

                    _usuario.Id = int.Parse(reader.GetString(0));
                    _usuario.Usuario1 = reader[1].ToString();
                    _usuario.Password = reader[2].ToString();
                    _usuario.Legajo = int.Parse(reader.GetString(3));
                    _usuario.TipoUsuario = int.Parse(reader.GetString(4));

                    lista.Add(_usuario);

                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
        }

        public List<TipoUsuario> ConsultaTipoUsuario(string dato)
        {
            MySqlDataReader reader;
            List<TipoUsuario> lista = new List<TipoUsuario>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT Id, TipoUsuario FROM tipousuario ORDER BY TipoUsuario ASC ";
            }
            else
            {
                sql = "SELECT Id, TipoUsuario FROM tipousuario WHERE TipoUsuario LIKE '%" + dato + "%'  ORDER BY TipoUsuario ASC ";
            }

            try
            {
                conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    TipoUsuario _usuario = new TipoUsuario();

                    _usuario.Id = int.Parse(reader.GetString(0));
                    _usuario.tiposUsuarios = reader[1].ToString();

                    lista.Add(_usuario);

                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
        }

        public string Registro(User usuarios) // si lo uso
        {
            string repuesta;
            if (string.IsNullOrEmpty(usuarios.Usuario1) || string.IsNullOrEmpty(usuarios.Password) || string.IsNullOrEmpty(usuarios.TipoUsuario.ToString()) || string.IsNullOrEmpty(usuarios.ConPassword) || string.IsNullOrEmpty(usuarios.Legajo.ToString()))
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
                        Registrar(usuarios);
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

        //Use 1vez en logueo
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




        public int Registrar(User usuario) // si lo uso
        {
            ConectaBD conexion = new ConectaBD();
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "INSERT INTO usuario (Usuario, Contraseña, Legajo, TipoUsuario) VALUE (@Usuario, @Contraseña, @Legajo, @TipoUsuario)";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            comando.Parameters.AddWithValue("@Usuario", usuario.Usuario1);
            comando.Parameters.AddWithValue("@Contraseña", usuario.Password);
            comando.Parameters.AddWithValue("@Legajo", usuario.Legajo);
            comando.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);

            int resultado = comando.ExecuteNonQuery();

            return resultado;


        }

        public bool ExisteUsuario(string usuario) 
        {
            ConectaBD conexion = new ConectaBD();
            MySqlDataReader reader;
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "SELECT Id FROM usuario WHERE  Usuario = @Usuario ";

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

        public string Insertar(TipoUsuario datos)
        {
            string respuesta;
            conexion = new ConectaBD();
            bool bandera = false;
            string sql = "INSERT INTO tipousuario (TipoUsuario) VALUES ('" + datos.tiposUsuarios + "')";
            bandera = conexion.Conecta(sql);
            if (bandera)
            {
                respuesta = "Se Guardo el Tipo de Usuario con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar Guardar el Registro";
            }
            return respuesta;
        }


        /*public string Eliminar(int id)
        {
            string respuesta = "";
            bool bandera = false;
            conexion = new ConectaBD();
            DialogResult resultado = MessageBox.Show("Seguro que desea Eliminar el Usuario?", "Salir", MessageBoxButtons.YesNoCancel);
            if (resultado == DialogResult.Yes)
            {
                string sql = "DELETE FROM usuarios WHERE Id = '" + id + "'";
                bandera = conexion.Conecta(sql);
            }
            if (bandera)
            {
                respuesta = "Usuario Eliminada con Exito";
            }

            return respuesta;
        }*/

        /*public string EliminarTipoUsuario(int id)
        {
            string respuesta = "";
            bool bandera = false;
            conexion = new ConectaBD();
            DialogResult resultado = MessageBox.Show("Seguro que desea Eliminar el Tipo de Usuario?", "Salir", MessageBoxButtons.YesNoCancel);
            if (resultado == DialogResult.Yes)
            {
                string sql = "DELETE FROM tipousuario WHERE Id = '" + id + "'";
                bandera = conexion.Conecta(sql);
            }
            if (bandera)
            {
                respuesta = "Tipo de Usuario Eliminada con Exito";
            }

            return respuesta;
        }*/

        public DataTable MostrarTipoUsuario() //si lo use
        {
            ConectaBD conexion = new ConectaBD();
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();
            DataTable dt = new DataTable();
            try
            {

                string sql = "SELECT Id, tiposUsuarios FROM tipousuario ORDER BY tiposUsuarios ASC";
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataReader reader;
                reader = comando.ExecuteReader();

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("tiposUsuarios", typeof(string));
                dt.Load(reader);

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());

            }
            conexionBD.Close();
            return dt;
        }

        public string CambioPassword(User usuarios)
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

        public int ObtenerIdUser(string dato)// si lo uso
        {
            int Id = 0;
            TipoUsuario _usuario = new TipoUsuario();
            MySqlDataReader reader;
            string sql = "SELECT Id, tiposUsuarios FROM tipousuario WHERE tiposUsuarios = '" + dato + "'  ORDER BY tiposUsuarios ASC ";

            try
            {
                conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    _usuario.Id = int.Parse(reader.GetString(0));
                    _usuario.tiposUsuarios = reader[1].ToString();

                    Id = _usuario.Id;
                }


            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return Id;
        }
    }
}
