using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoNutritionStoreEF.Models
{
    public class Usuarios_SuplementosFavoritos
    {
        public int UsuarioID { get; set; }

        public int SuplementoID { get; set; }

        public DateTime FechaAgregado { get; set; } = DateTime.Now;
        public Usuario Usuario { get; set; }
        public Suplemento Suplemento { get; set; }

        public Usuarios_SuplementosFavoritos() { }

        public Usuarios_SuplementosFavoritos(int usuarioID, int suplementoID, DateTime fechaAgregado)
        {
            UsuarioID = usuarioID;
            SuplementoID = suplementoID;
            FechaAgregado = fechaAgregado;
        }
    }
}
