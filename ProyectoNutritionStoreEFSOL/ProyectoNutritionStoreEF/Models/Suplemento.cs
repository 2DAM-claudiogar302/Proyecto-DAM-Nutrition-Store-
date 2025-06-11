using System;
using System.Windows.Media.Imaging;

namespace ProyectoNutritionStoreEF.Models
{
    public class Suplemento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaID { get; set; }
        public decimal Precio { get; set; }
        public bool Tendencia { get; set; }
        public DateTime FechaAnadido { get; set; }
        public byte[]? Foto { get; set; }

        public Categoria categoria { get; set; }
        public Suplemento() { }
        public Suplemento(string nombre, string descripcion, int categoriaID, decimal precio, bool tendencia, byte[] foto)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CategoriaID = categoriaID;
            Precio = precio;
            Tendencia = tendencia;
            Foto = foto;
        }
        public Suplemento(string nombre, string descripcion, int categoriaID, decimal precio, bool tendencia, DateTime fechaAnadido, byte[] foto)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CategoriaID = categoriaID;
            Precio = precio;
            Tendencia = tendencia;
            FechaAnadido = fechaAnadido;
            Foto = foto;
        }
    }
}
