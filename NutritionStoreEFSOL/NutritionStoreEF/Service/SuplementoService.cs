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
    public class SuplementoService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        ObservableCollection<Suplemento> listaSupl;
        ObservableCollection<Suplemento> listaSuplTend;
        ObservableCollection<Suplemento> listaAminoacidos;
        ObservableCollection<Suplemento> listaProteinas;
        ObservableCollection<Suplemento> listaVitaminas;

        public ObservableCollection<Suplemento> GetAllSuplementos()
        {
            listaSupl = new ObservableCollection<Suplemento>();
            Suplemento suplemento = null;
            using (Microsoft.Data.SqlClient.SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = @"SELECT Id, Nombre, Descripcion, CategoriaID, Precio, Tendencia, FechaAñadido 
                           FROM Suplementos";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id = Convert.ToInt32(reader["Id"]);
                            string Nombre = reader["Nombre"].ToString();
                            string Descripcion = reader["Descripcion"].ToString();
                            int CategoriaId = Convert.ToInt32(reader["CategoriaId"]);
                            double Precio = Convert.ToInt32(reader["Precio"]);
                            bool Tendencia = Convert.ToBoolean(reader["Tendencia"]);
                            DateTime FechaAnadido = Convert.ToDateTime(reader["FechaAñadido"]);
                            suplemento = new Suplemento(Id, Nombre, Descripcion, CategoriaId, Precio, Tendencia, FechaAnadido);
                            listaSupl.Add(suplemento);
                        }

                    }
                }
            }
            return listaSupl;
        }

        public ObservableCollection<Suplemento> GetSuplementosEnTendencia()
        {
            listaSuplTend = new ObservableCollection<Suplemento>();
            using (Microsoft.Data.SqlClient.SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = @"SELECT Id, Nombre, Descripcion, CategoriaID, Precio, Tendencia, FechaAñadido 
                         FROM Suplementos 
                         WHERE Tendencia = 1";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id = Convert.ToInt32(reader["Id"]);
                            string Nombre = reader["Nombre"].ToString();
                            string Descripcion = reader["Descripcion"].ToString();
                            int CategoriaId = Convert.ToInt32(reader["CategoriaId"]);
                            double Precio = Convert.ToDouble(reader["Precio"]);
                            bool Tendencia = Convert.ToBoolean(reader["Tendencia"]);
                            DateTime FechaAnadido = Convert.ToDateTime(reader["FechaAñadido"]);

                            Suplemento suplemento = new Suplemento(Id, Nombre, Descripcion, CategoriaId, Precio, Tendencia, FechaAnadido);

                            listaSuplTend.Add(suplemento);
                        }
                    }
                }
            }
            return listaSuplTend;
        }

        public void AddSuplemento(Suplemento suplemento)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string query = @"INSERT INTO Suplementos (Nombre, Descripción, CategoriaID, Precio, Tendencia) 
                         VALUES (@nombre, @descripcion, @categoriaID, @precio, @tendencia)";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", suplemento.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", suplemento.Descripcion);
                    cmd.Parameters.AddWithValue("@categoriaID", suplemento.CategoriaID);
                    cmd.Parameters.AddWithValue("@precio", suplemento.Precio);
                    cmd.Parameters.AddWithValue("@tendencia", suplemento.Tendencia);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveSuplemento(int suplementoID)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string query = @"DELETE FROM Suplementos WHERE ID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", suplementoID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSuplemento(Suplemento updatedSuplemento)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string query = @"UPDATE Suplementos 
                         SET Nombre = @nombre, Descripción = @descripcion, 
                             CategoriaID = @categoriaID, Precio = @precio, Tendencia = @tendencia 
                         WHERE ID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", updatedSuplemento.ID);
                    cmd.Parameters.AddWithValue("@nombre", updatedSuplemento.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", updatedSuplemento.Descripcion);
                    cmd.Parameters.AddWithValue("@categoriaID", updatedSuplemento.CategoriaID);
                    cmd.Parameters.AddWithValue("@precio", updatedSuplemento.Precio);
                    cmd.Parameters.AddWithValue("@tendencia", updatedSuplemento.Tendencia);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ObservableCollection<Suplemento> GetAminoacidos()
        {
            listaAminoacidos = new ObservableCollection<Suplemento>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = @"SELECT Id, Nombre, Descripcion, CategoriaID, Precio, Tendencia, FechaAñadido 
                         FROM Suplementos 
                         WHERE CategoriaID = (SELECT ID FROM Categorias WHERE Nombre = 'Aminoácidos')";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Suplemento suplemento = new Suplemento(
                                Convert.ToInt32(reader["Id"]),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                Convert.ToInt32(reader["CategoriaID"]),
                                Convert.ToDouble(reader["Precio"]),
                                Convert.ToBoolean(reader["Tendencia"]),
                                Convert.ToDateTime(reader["FechaAñadido"])
                            );
                            listaAminoacidos.Add(suplemento);
                        }
                    }
                }
            }
            return listaAminoacidos;
        }

        public ObservableCollection<Suplemento> GetProteinas()
        {
            listaProteinas = new ObservableCollection<Suplemento>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = @"SELECT Id, Nombre, Descripcion, CategoriaID, Precio, Tendencia, FechaAñadido 
                         FROM Suplementos 
                         WHERE CategoriaID = (SELECT ID FROM Categorias WHERE Nombre = 'Proteínas')";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Suplemento suplemento = new Suplemento(
                                Convert.ToInt32(reader["Id"]),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                Convert.ToInt32(reader["CategoriaID"]),
                                Convert.ToDouble(reader["Precio"]),
                                Convert.ToBoolean(reader["Tendencia"]),
                                Convert.ToDateTime(reader["FechaAñadido"])
                            );
                            listaProteinas.Add(suplemento);
                        }
                    }
                }
            }
            return listaProteinas;
        }

        public ObservableCollection<Suplemento> GetVitaminas()
        {
            listaVitaminas = new ObservableCollection<Suplemento>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = @"SELECT Id, Nombre, Descripcion, CategoriaID, Precio, Tendencia, FechaAñadido 
                         FROM Suplementos 
                         WHERE CategoriaID = (SELECT ID FROM Categorias WHERE Nombre = 'Vitaminas')";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Suplemento suplemento = new Suplemento(
                                Convert.ToInt32(reader["Id"]),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                Convert.ToInt32(reader["CategoriaID"]),
                                Convert.ToDouble(reader["Precio"]),
                                Convert.ToBoolean(reader["Tendencia"]),
                                Convert.ToDateTime(reader["FechaAñadido"])
                            );
                            listaVitaminas.Add(suplemento);
                        }
                    }
                }
            }
            return listaVitaminas;
        }


    }
}
