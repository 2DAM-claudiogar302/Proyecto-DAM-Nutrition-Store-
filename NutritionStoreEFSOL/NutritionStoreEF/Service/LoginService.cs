using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NutritionStoreEF.Models;

namespace NutritionStoreEF.Service
{
    public class LoginService
    {
        // Cadena de conexión.
        private string connection = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        // Usuario en sesión.
        private static Usuario usuarioSesion = null;

        // Método para obtener el usuario según las credenciales introducidas.
        public Usuario GetUsuarioLogin(string username, string password)
        {
            using (SqlConnection conexion = new SqlConnection(connection))
            {
                conexion.Open();
                string query = @"SELECT ID, Nombre, Apellido1, Apellido2, Username, Email, Contraseña, Administrador, FechaRegistro 
                                 FROM Usuarios WHERE Username = @username";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string passHash = reader["Contraseña"].ToString();

                            if (password != passHash)
                            {
                                return null;
                            }

                            int id = Convert.ToInt32(reader["ID"]);
                            string nombre = reader["Nombre"].ToString();
                            string apellido1 = reader["Apellido1"].ToString();
                            string apellido2 = reader["Apellido2"].ToString();
                            string email = reader["Email"].ToString();
                            bool administrador = Convert.ToBoolean(reader["Administrador"]);
                            DateTime fechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);

                            usuarioSesion = new Usuario(id, nombre, apellido1, apellido2, username, email, passHash, administrador, fechaRegistro);
                        }
                    }
                }
            }
            return usuarioSesion;
        }

        // Obtener el usuario de la sesión.
        public Usuario GetUserSesion()
        {
            if (usuarioSesion == null)
            {
                throw new Exception("No hay usuario en sesión. Llama a GetUsuarioLogin() primero.");
            }
            return usuarioSesion;
        }
    }
}
