using System;
using System.Windows.Media.Imaging;

namespace ProyectoNutritionStoreEF.Models
{
    public class Ejercicio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int GrupoMuscularID { get; set; }
        public string Descripcion { get; set; }
        public bool Tendencia { get; set; }
        public DateTime FechaAnadido { get; set; }
        public byte[]? Foto { get; set; }
        public GrupoMuscular grupoMuscular { get; set; }
        public Ejercicio() { }
        public Ejercicio(string nombre, int grupoMuscularID, string descripcion, bool tendencia, byte[] foto)
        {
            
            Nombre = nombre;
            GrupoMuscularID = grupoMuscularID;
            Descripcion = descripcion;
            Tendencia = tendencia;
            Foto = foto;
        }

        public Ejercicio(string nombre, int grupoMuscularID, string descripcion, bool tendencia, DateTime fechaAnadido, byte[] foto)
        {
            Nombre = nombre;
            GrupoMuscularID = grupoMuscularID;
            Descripcion = descripcion;
            Tendencia = tendencia;
            FechaAnadido = fechaAnadido;
            Foto = foto;
        }
    }
}
