using Microsoft.Data.SqlClient;
using NutritionStoreEF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionStoreEF.Service
{
    public class UsuarioService
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        ObservableCollection<Usuario> listaUsuarios;

        public ObservableCollection<Usuario> GetAllUsuarios()
        {
            listaUsuarios = new ObservableCollection<Usuario>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = @"SELECT ID, Nombre, Apellido1, Apellido2, Usuername, Email, ADMINISTRADOR, FechaRegistro FROM Usuarios";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Usuario usuario = new Usuario();

                            //listaUsuarios.Add(usuario);
                        }
                    }
                }
            }
            return listaUsuarios;
        }

        public void AddUsuario(Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string query = @"INSERT INTO Usuarios (Nombre, Apellido1, Apellido2, Usuername, Email, Contraseña, ADMINISTRADOR) 
                        VALUES (@nombre, @apellido1, @apellido2, @username, @email, @password, @administrador)";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@apellido1", usuario.Apellido1);
                    cmd.Parameters.AddWithValue("@apellido2", usuario.Apellido2);
                    cmd.Parameters.AddWithValue("@username", usuario.Usuername);
                    cmd.Parameters.AddWithValue("@email", usuario.Email);
                    cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña));
                    cmd.Parameters.AddWithValue("@administrador", usuario.Administrador);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveUsuario(Usuario usuario)
        {

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string query = @"DELETE FROM Usuarios WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", usuario.ID);
                    cmd.ExecuteNonQuery();

                }

            }

        }

        public void UpdateUsuario(Usuario updatedUsuario)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string query = @"UPDATE Usuarios 
                         SET Nombre = @nombre, Apellido1 = @apellido1, Apellido2 = @apellido2, 
                             Usuername = @username, Email = @email, Contraseña = @password, ADMINISTRADOR = @administrador 
                         WHERE ID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", updatedUsuario.ID);
                    cmd.Parameters.AddWithValue("@nombre", updatedUsuario.Nombre);
                    cmd.Parameters.AddWithValue("@apellido1", updatedUsuario.Apellido1);
                    cmd.Parameters.AddWithValue("@apellido2", updatedUsuario.Apellido2);
                    cmd.Parameters.AddWithValue("@username", updatedUsuario.Usuername);
                    cmd.Parameters.AddWithValue("@email", updatedUsuario.Email);
                    //cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(updatedUsuario.Contraseña));
                    cmd.Parameters.AddWithValue("@administrador", updatedUsuario.Administrador);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}
