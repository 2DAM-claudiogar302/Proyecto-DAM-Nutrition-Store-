using Microsoft.EntityFrameworkCore;
using ProyectoNutritionStoreEF.EntityFramework;
using ProyectoNutritionStoreEF.Models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoNutritionStoreEF.Service
{
    public class LoginService
    {
        private readonly NutritionStoreContext _context;
        private static Usuario usuarioSesion;

        //Inyecto la instancia de mi contexto que se conecta a base de datos para tener ese contexto en mi servicio.
        public LoginService(NutritionStoreContext context)
        {
            _context = context;
        }

        // Obtener el usuario según credenciales
        public Usuario GetUsuarioLogin(string username, string password)
        {
            //Pruebas para ver si puede conectar y obtener la tabla Usuarios.
            var value = _context.Database.CanConnect();
            var count = _context.Usuarios.Count();
            var tabla = _context.Usuarios.ToList();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("El nombre de usuario y la contraseña no pueden estar vacíos.");
            }

            //SingleOrDefault me va a devolver un usuario o ninguno(null) en el caso de no tener coincidencias:
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Username == username);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, usuario.Contraseña))
            {
                MessageBox.Show("Usuario no encontrado o contraseña incorrecta.");
                return null;
            }

            usuarioSesion = usuario;
            return usuario;
        }

        // Obtener usuario en sesión
        public Usuario GetUserSesion()
        {
            if (usuarioSesion == null)
            {
                throw new Exception("No hay usuario en sesión.");
            }
            return usuarioSesion;
        }

        // Restablecer contraseña
        public bool CambiarContrasena(string username, string nuevaContrasena)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Username == username);

            if (usuario != null)
            {
                usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);
                _context.SaveChanges();
                return true;
            }

            return false;
        }


    }
}
