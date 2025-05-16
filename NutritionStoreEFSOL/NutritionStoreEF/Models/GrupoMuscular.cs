using System;

namespace NutritionStoreEF.Models
{
    public class GrupoMuscular
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public GrupoMuscular(int id, string nombre, string descripcion)
        {
            ID = id;
            Nombre = nombre;
            Descripción = descripcion;
        }
    }
}
