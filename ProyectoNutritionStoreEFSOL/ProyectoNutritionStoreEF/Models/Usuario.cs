using System;
using System.Windows.Media.Imaging;

namespace ProyectoNutritionStoreEF.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public bool Administrador { get; set; }
        public byte[]? Foto { get; set; }
        public string PreguntaSeguridad { get; set; }
        public string RespuestaSeguridad { get; set; }

        public DateTime FechaRegistro { get; set; }

        public Usuario() { }
        public Usuario(string nombre, string apellido1, string apellido2, string username, string email, string contraseña, bool administrador, byte[] foto, string pregunta, string respuesta, DateTime fechaRegistro)
        {
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Username = username;
            Email = email;
            Contraseña = contraseña;
            Administrador = administrador;
            this.Foto = foto;
            PreguntaSeguridad = pregunta;
            RespuestaSeguridad = respuesta;
            FechaRegistro = fechaRegistro;
        }
    }
}
