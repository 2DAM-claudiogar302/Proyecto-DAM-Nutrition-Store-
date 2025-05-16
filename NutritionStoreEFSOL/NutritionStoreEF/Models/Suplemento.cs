using System;

namespace NutritionStoreEF.Models
{
    public class Suplemento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaID { get; set; }
        public double Precio { get; set; }
        public bool Tendencia { get; set; }
        public DateTime FechaAnadido { get; set; }

        public Suplemento(string nombre, string descripcion, int categoriaID, double precio, bool tendencia)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CategoriaID = categoriaID;
            Precio = precio;
            Tendencia = tendencia;
        }
        public Suplemento(int id, string nombre, string descripcion, int categoriaID, double precio, bool tendencia, DateTime fechaAnadido)
        {
            ID = id;
            Nombre = nombre;
            Descripcion = descripcion;
            CategoriaID = categoriaID;
            Precio = precio;
            Tendencia = tendencia;
            FechaAnadido = fechaAnadido;
        }
    }
}
