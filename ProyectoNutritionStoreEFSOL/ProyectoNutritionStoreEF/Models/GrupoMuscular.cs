using System;

namespace ProyectoNutritionStoreEF.Models
{
    public class GrupoMuscular
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public GrupoMuscular() { }
        public GrupoMuscular(int id, string nombre, string descripcion)
        {
            ID = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
