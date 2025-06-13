using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoNutritionStoreEF.EntityFramework;
using ProyectoNutritionStoreEF.Models;
using ProyectoNutritionStoreEF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProyectoNutritionStoreEF.Service
{
    public class EjercicioService
    {
        private readonly NutritionStoreContext _context;

        public EjercicioService(NutritionStoreContext context)
        {
            _context = context;
        }

        // Obtener todos los ejercicios
        public ObservableCollection<Ejercicio> GetAllEjercicios()
        {
            return new ObservableCollection<Ejercicio>(_context.Ejercicios.ToList());
        }

        // Obtener ejercicios en tendencia
        public ObservableCollection<Ejercicio> GetEjerciciosTendencia()
        {
            //Puede qe de excepción debido a que la columna foto en base de datos es null.
            return new ObservableCollection<Ejercicio>(_context.Ejercicios.Where(e => e.Tendencia).ToList());
        }

        // Agregar un nuevo ejercicio
        public void AddEjercicio(Ejercicio ejercicio)
        {
            try
            {
                _context.Ejercicios.Add(ejercicio);
                _context.SaveChanges();
                MessageBox.Show("Ejercicio añadido correctamente a la base de datos.");
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Error de BD: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        // Eliminar un ejercicio por ID
        public void RemoveEjercicio(int id)
        {
            var ejercicio = _context.Ejercicios.Find(id);
            if (ejercicio != null)
            {
                _context.Ejercicios.Remove(ejercicio);
                _context.SaveChanges();
            }
        }

        // Actualizar un ejercicio existente
        public void UpdateEjercicio(Ejercicio updatedEjercicio)
        {
            _context.Ejercicios.Update(updatedEjercicio);
            _context.SaveChanges();
        }

        // Obtener ejercicios por grupo muscular
        public ObservableCollection<Ejercicio> GetEjerciciosPorGrupo(string grupoMuscular)
        {
            return new ObservableCollection<Ejercicio>(
                _context.Ejercicios
                .Where(e => e.grupoMuscular.Nombre.Equals(grupoMuscular))
                .ToList()
            );
        }

        // Métodos específicos para cada grupo muscular
        public ObservableCollection<Ejercicio> GetEjerciciosEspalda()
        {
            return GetEjerciciosPorGrupo("Espalda");
        }

        public ObservableCollection<Ejercicio> GetEjerciciosPecho()
        {
            return GetEjerciciosPorGrupo("Pecho");
        }

        public ObservableCollection<Ejercicio> GetEjerciciosPierna()
        {
            return GetEjerciciosPorGrupo("Pierna");
        }

        public ObservableCollection<Ejercicio> GetEjerciciosBrazo()
        {
            return GetEjerciciosPorGrupo("Brazo");
        }

        // Agregar ejercicio favorito
        public void AddEjercicioFavorito(int usuarioId, int ejercicioId)
        {
            bool yaExiste = _context.Usuarios_EjerciciosFavoritos
                .Any(fav => fav.UsuarioID == usuarioId && fav.EjercicioID == ejercicioId);

            if (yaExiste)
            {
                MessageBox.Show("Este ejercicio ya ha sido añadido a favoritos.");
                return;
            }

            _context.Usuarios_EjerciciosFavoritos.Add(new Usuarios_EjerciciosFavoritos(usuarioId, ejercicioId, DateTime.Now));
            _context.SaveChanges();
            MessageBox.Show("Añadido a favoritos.");
        }
        public List<Ejercicio> obtenerEjerciciosFiltro(string value)
        {
            return _context.Ejercicios.Include(e => e.grupoMuscular).Where(e => e.Nombre.ToLower().Contains(value.ToLower())).ToList();
        }
        public List<GrupoMuscular> GetGrupoMuscular()
        {
            return _context.GruposMusculares.ToList();
        }

        public List<Ejercicio> GetEjerciciosFavoritos(int usuarioId)
        {
            return _context.Ejercicios
                .Where(s => _context.Usuarios_EjerciciosFavoritos
                .Any(fav => fav.UsuarioID == usuarioId && fav.EjercicioID == s.ID))
                .ToList();
        }
        public void RemoveEjercicioFavorito(int usuarioId, int ejerciicoId)
        {
            var favorito = _context.Usuarios_EjerciciosFavoritos
                .SingleOrDefault(fav => fav.UsuarioID == usuarioId && fav.EjercicioID == ejerciicoId);

            if (favorito != null)
            {
                _context.Usuarios_EjerciciosFavoritos.Remove(favorito);
                _context.SaveChanges();
                MessageBox.Show("Ejercicio eliminado de favoritos.");
            }
        }
    }
}
