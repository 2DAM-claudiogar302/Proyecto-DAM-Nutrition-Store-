using System;

namespace NutritionStoreEF.Models
{
    public class Ejercicio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int GrupoMuscularID { get; set; }
        public string Descripcion { get; set; }
        public bool Tendencia { get; set; }
        public DateTime FechaAnadido { get; set; }

        public Ejercicio(string nombre, int grupoMuscularID, string descripcion, bool tendencia)
        {
            
            Nombre = nombre;
            GrupoMuscularID = grupoMuscularID;
            Descripcion = descripcion;
            Tendencia = tendencia;
        }

        public Ejercicio(int id, string nombre, int grupoMuscularID, string descripcion, bool tendencia, DateTime fechaAnadido)
        {
            ID = id;
            Nombre = nombre;
            GrupoMuscularID = grupoMuscularID;
            Descripcion = descripcion;
            Tendencia = tendencia;
            FechaAnadido = fechaAnadido;
        }
    }
}
