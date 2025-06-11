using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNutritionStoreEF.Models
{
    public class Usuarios_EjerciciosFavoritos
    {
        public int UsuarioID { get; set; }
        public int EjercicioID { get; set; }

        public DateTime FechaAgregado { get; set; } = DateTime.Now;
        public Usuario Usuario { get; set; }
        public Ejercicio Ejercicio { get; set; }

        public Usuarios_EjerciciosFavoritos() { }

        public Usuarios_EjerciciosFavoritos(int usuarioID, int ejercicioID, DateTime fechaAgregado)
        {
            UsuarioID = usuarioID;
            EjercicioID = ejercicioID;
            FechaAgregado = fechaAgregado;
        }
    }
}
