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
    public class EjercicioService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        ObservableCollection<Ejercicio> listaEjercicios;
        ObservableCollection<Ejercicio> listaEjerciciosTendencia;

        public ObservableCollection<Ejercicio> GetAllEjercicios()
        {
            listaEjercicios = new ObservableCollection<Ejercicio>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = @"SELECT ID, Nombre, GrupoMuscularID, Descripcion, Tendencia, FechaAñadido FROM Ejercicios";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string nombre = reader["Nombre"].ToString();
                            int gurpoMuscularId = Convert.ToInt32(reader["GrupoMuscularID"]);
                            string descripcion = reader["Descripcion"].ToString();
                            bool tendencia = Convert.ToBoolean(reader["Tendencia"]);
                            DateTime fechaAnadido = Convert.ToDateTime(reader["FechaAñadido"]);
                            Ejercicio ejercicio = new Ejercicio(id, nombre, gurpoMuscularId, descripcion, tendencia, fechaAnadido);

                            listaEjercicios.Add(ejercicio);
                        }
                    }
                }
            }
            return listaEjercicios;
        }

        public ObservableCollection<Ejercicio> GetEjerciciosTendencia()
        {
            listaEjerciciosTendencia = new ObservableCollection<Ejercicio>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = @"SELECT ID, Nombre, GrupoMuscularID, Descripcion, Tendencia, FechaAñadido 
                                 FROM Ejercicios 
                                 WHERE Tendencia = 1"; 

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string nombre = reader["Nombre"].ToString();
                            int gurpoMuscularId = Convert.ToInt32(reader["GrupoMuscularID"]);
                            string descripcion = reader["Descripcion"].ToString();
                            bool tendencia = Convert.ToBoolean(reader["Tendencia"]);
                            DateTime fechaAnadido = Convert.ToDateTime(reader["FechaAñadido"]);
                            Ejercicio ejercicio = new Ejercicio(id, nombre, gurpoMuscularId, descripcion, tendencia, fechaAnadido);

                            listaEjerciciosTendencia.Add(ejercicio);
                        }
                    }
                }
            }
            return listaEjerciciosTendencia;
        }

        public void AddEjercicio(Ejercicio ejercicio)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string query = @"INSERT INTO Ejercicios (Nombre, GrupoMuscularID, Descripción, Tendencia) 
                         VALUES (@nombre, @grupoMuscularID, @descripcion, @tendencia)";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", ejercicio.Nombre);
                    cmd.Parameters.AddWithValue("@grupoMuscularID", ejercicio.GrupoMuscularID);
                    cmd.Parameters.AddWithValue("@descripcion", ejercicio.Descripcion);
                    cmd.Parameters.AddWithValue("@tendencia", ejercicio.Tendencia);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveEjercicio(Ejercicio ejercicio)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string query = @"DELETE FROM Ejercicios WHERE ID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", ejercicio.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEjercicio(Ejercicio updatedEjercicio)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string query = @"UPDATE Ejercicios 
                         SET Nombre = @nombre, GrupoMuscularID = @grupoMuscularID, 
                             Descripción = @descripcion, Tendencia = @tendencia 
                         WHERE ID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", updatedEjercicio.ID);
                    cmd.Parameters.AddWithValue("@nombre", updatedEjercicio.Nombre);
                    cmd.Parameters.AddWithValue("@grupoMuscularID", updatedEjercicio.GrupoMuscularID);
                    cmd.Parameters.AddWithValue("@descripcion", updatedEjercicio.Descripcion);
                    cmd.Parameters.AddWithValue("@tendencia", updatedEjercicio.Tendencia);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
