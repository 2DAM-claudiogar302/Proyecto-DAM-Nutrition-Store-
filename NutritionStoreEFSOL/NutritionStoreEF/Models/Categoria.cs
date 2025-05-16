using System;

namespace NutritionStoreEF.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public Categoria(int id, string nombre, string descripcion)
        {
            ID = id;
            Nombre = nombre;
            Descripción = descripcion;
        }
    }
}
