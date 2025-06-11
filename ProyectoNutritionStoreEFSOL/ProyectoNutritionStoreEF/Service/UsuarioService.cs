using System;
using System.Collections.ObjectModel;
using System.Linq;
using ProyectoNutritionStoreEF.Models;
using ProyectoNutritionStoreEF.EntityFramework;
using System.Windows;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Data;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using Font = iTextSharp.text.Font;
using Paragraph = iTextSharp.text.Paragraph;
using DocumentFormat.OpenXml.InkML;

namespace ProyectoNutritionStoreEF.Service
{
    public class UsuarioService
    {
        private readonly NutritionStoreContext dbContext;

        public UsuarioService(NutritionStoreContext context)
        {
            dbContext = context;
        }

        public ObservableCollection<Usuario> GetAllUsuarios()
        {
            var listaUsuarios = new ObservableCollection<Usuario>(dbContext.Usuarios.ToList());
            return listaUsuarios;
        }

        public void AddUsuario(Usuario usuario)
        {
            //Encriptamos la contraseña de forma segura.
            usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);
            dbContext.Usuarios.Add(usuario);
            dbContext.SaveChanges();
        }

        public void RemoveUsuario(int id)
        {
            var usuario = dbContext.Usuarios.Find(id);
            if (usuario != null)
            {
                dbContext.Usuarios.Remove(usuario);
                dbContext.SaveChanges();
            }
        }

        public void UpdateUsuario(Usuario updatedUsuario)
        {
            dbContext.Usuarios.Update(updatedUsuario);
            dbContext.SaveChanges();
        }

        public List<Usuario> obtenerUsuariosFiltro(string value)
        {
            return dbContext.Usuarios.Where(e => e.Nombre.ToLower().Contains(value.ToLower())).ToList();
        }

        public void obtenerDatoslUser(int idUser)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Title = "Obtener historial del usuario",
                    Filter = "Archivos Excel (*.xlsx)|*.xlsx*",
                    FileName = "HistorialObtenidoUser.xlsx"
                };

                if (save.ShowDialog() == true)
                {
                    string ruta = save.FileName;

                    using (var conexion = new SqlConnection(dbContext.Database.GetConnectionString()))
                    {
                        conexion.Open();

                        string query = @"SELECT ID, Username, Nombre, Apellido1, Apellido2, Email, FechaRegistro FROM Usuarios WHERE ID = @iduser";

                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@iduser", idUser);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                if (dataTable.Rows.Count > 0)
                                {
                                    using (XLWorkbook wb = new XLWorkbook())
                                    {
                                        var folio = wb.Worksheets.Add(dataTable, "Usuarios");
                                        folio.Columns().AdjustToContents();
                                        folio.Row(1).Style.Font.Bold = true;

                                        var lastColumn = folio.LastColumnUsed().ColumnNumber();
                                        var lastRow = folio.LastRowUsed().RowNumber();

                                        folio.Range(1, 1, 1, lastColumn).Style.Fill.SetBackgroundColor(XLColor.BlueGreen);
                                        folio.Range(2, 1, lastRow, lastColumn).Style.Fill.SetBackgroundColor(XLColor.Almond);

                                        wb.SaveAs(ruta);
                                        MessageBox.Show("Historial del usuario exportado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se encontraron datos para el usuario especificado.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos del usuario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void ExportarDatosUsuarioPDF(int idUser)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Title = "Guardar historial del usuario",
                    Filter = "Archivos PDF (*.pdf)|*.pdf",
                    FileName = "HistorialUsuario.pdf"
                };

                if (save.ShowDialog() == true)
                {
                    string ruta = save.FileName;

                    using (var conexion = new SqlConnection(dbContext.Database.GetConnectionString()))
                    {
                        conexion.Open();

                        string query = @"SELECT ID, Username, Nombre, Apellido1, Apellido2, Email, FechaRegistro FROM Usuarios WHERE ID = @iduser";

                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@iduser", idUser);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                if (dataTable.Rows.Count > 0)
                                {
                                    Document document = new Document();
                                    PdfWriter.GetInstance(document, new FileStream(ruta, FileMode.Create));

                                    document.Open();

                                    // **Encabezado**
                                    Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                                    Paragraph title = new Paragraph("Historial del Usuario", titleFont);
                                    title.Alignment = Element.ALIGN_CENTER;
                                    document.Add(title);
                                    document.Add(new Paragraph("\n"));

                                    // **Datos del usuario**
                                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                                    Font contentFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                                    PdfPTable table = new PdfPTable(dataTable.Columns.Count);
                                    table.WidthPercentage = 100;

                                    foreach (DataColumn col in dataTable.Columns)
                                    {
                                        PdfPCell headerCell = new PdfPCell(new Phrase(col.ColumnName, headerFont));
                                        headerCell.BackgroundColor = new BaseColor(100, 149, 237);
                                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        table.AddCell(headerCell);
                                    }

                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        foreach (var item in row.ItemArray)
                                        {
                                            PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), contentFont));
                                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                            table.AddCell(dataCell);
                                        }
                                    }

                                    document.Add(table);
                                    document.Close();

                                    MessageBox.Show("Historial exportado a PDF correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se encontraron datos para el usuario especificado.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void ExportarDatosUsuarioFavoritosPDF(int idUser)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Title = "Guardar historial del usuario",
                    Filter = "Archivos PDF (*.pdf)|*.pdf",
                    FileName = "HistorialUsuarioFavoritos.pdf"
                };

                if (save.ShowDialog() == true)
                {
                    string ruta = save.FileName;

                    using (var conexion = new SqlConnection(dbContext.Database.GetConnectionString()))
                    {
                        conexion.Open();

                        // **Consulta de ejercicios favoritos**
                        string queryEjercicios = @"SELECT e.Nombre FROM Ejercicios e
                                           INNER JOIN Usuarios_EjerciciosFavoritos ue ON e.ID = ue.EjercicioID
                                           WHERE ue.UsuarioID = @iduser";

                        // **Consulta de suplementos favoritos**
                        string querySuplementos = @"SELECT s.Nombre FROM Suplementos s
                                            INNER JOIN Usuarios_SuplementosFavoritos us ON s.ID = us.SuplementoID
                                            WHERE us.UsuarioID = @iduser";

                        using (SqlCommand cmdEjercicios = new SqlCommand(queryEjercicios, conexion))
                        using (SqlCommand cmdSuplementos = new SqlCommand(querySuplementos, conexion))
                        {
                            cmdEjercicios.Parameters.AddWithValue("@iduser", idUser);
                            cmdSuplementos.Parameters.AddWithValue("@iduser", idUser);

                            using (SqlDataAdapter adapterEjercicios = new SqlDataAdapter(cmdEjercicios))
                            using (SqlDataAdapter adapterSuplementos = new SqlDataAdapter(cmdSuplementos))
                            {
                                DataTable dataEjercicios = new DataTable();
                                DataTable dataSuplementos = new DataTable();

                                adapterEjercicios.Fill(dataEjercicios);
                                adapterSuplementos.Fill(dataSuplementos);

                                // **Nueva validación: verificar si hay ejercicios o suplementos favoritos**
                                if (dataEjercicios.Rows.Count > 0 || dataSuplementos.Rows.Count > 0)
                                {
                                    Document document = new Document();
                                    PdfWriter.GetInstance(document, new FileStream(ruta, FileMode.Create));

                                    document.Open();

                                    // **Encabezado**
                                    Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                                    Paragraph title = new Paragraph("Ejercicios y Suplementos Favoritos", titleFont);
                                    title.Alignment = Element.ALIGN_CENTER;
                                    document.Add(title);
                                    document.Add(new Paragraph("\n"));

                                    // **Ejercicios Favoritos**
                                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                                    Font contentFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                                    document.Add(new Paragraph("Ejercicios Favoritos:", headerFont));
                                    if (dataEjercicios.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dataEjercicios.Rows)
                                        {
                                            document.Add(new Paragraph("- " + row["Nombre"].ToString(), contentFont));
                                        }
                                    }
                                    else
                                    {
                                        document.Add(new Paragraph("No hay ejercicios favoritos registrados.", contentFont));
                                    }
                                    document.Add(new Paragraph("\n"));

                                    // **Suplementos Favoritos**
                                    document.Add(new Paragraph("Suplementos Favoritos:", headerFont));
                                    if (dataSuplementos.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dataSuplementos.Rows)
                                        {
                                            document.Add(new Paragraph("- " + row["Nombre"].ToString(), contentFont));
                                        }
                                    }
                                    else
                                    {
                                        document.Add(new Paragraph("No hay suplementos favoritos registrados.", contentFont));
                                    }

                                    document.Close();

                                    MessageBox.Show("Historial de favoritos exportado a PDF correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se encontraron ejercicios ni suplementos favoritos para el usuario especificado.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



    }
}
