using System;

namespace NutritionStoreEF.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Usuername { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public bool Administrador { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Usuario(int id, string nombre, string apellido1, string apellido2, string usuername, string email, string contraseña, bool administrador, DateTime fechaRegistro)
        {
            ID = id;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Usuername = usuername;
            Email = email;
            Contraseña = contraseña;
            Administrador = administrador;
            FechaRegistro = fechaRegistro;
        }
    }
}
