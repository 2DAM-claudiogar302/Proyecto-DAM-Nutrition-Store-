using System;

namespace ProyectoNutritionStoreEF.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Categoria() { }
        public Categoria(int id, string nombre, string descripcion)
        {
            ID = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
