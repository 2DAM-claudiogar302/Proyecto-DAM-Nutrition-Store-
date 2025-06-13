using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoNutritionStoreEF.EntityFramework;
using ProyectoNutritionStoreEF.Models;
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
    public class SuplementoService
    {
        private readonly NutritionStoreContext _context;

        public SuplementoService(NutritionStoreContext context)
        {
            _context = context;
        }

        // Obtener todos los suplementos
        public ObservableCollection<Suplemento> GetAllSuplementos()
        {
            return new ObservableCollection<Suplemento>(_context.Suplementos.ToList());
        }

        // Obtener suplementos en tendencia
        public ObservableCollection<Suplemento> GetSuplementosEnTendencia()
        {
            return new ObservableCollection<Suplemento>(_context.Suplementos.Where(s => s.Tendencia).ToList());
        }

        // Agregar un nuevo suplemento
        public void AddSuplemento(Suplemento suplemento)
        {
            try
            {
                _context.Suplementos.Add(suplemento);
                _context.SaveChanges();
                MessageBox.Show("Suplemento añadido correctamente a la base de datos.");
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

        // Eliminar un suplemento por ID
        public void RemoveSuplemento(int suplementoID)
        {
            var suplemento = _context.Suplementos.Find(suplementoID);
            if (suplemento != null)
            {
                _context.Suplementos.Remove(suplemento);
                _context.SaveChanges();
            }
        }

        // Actualizar un suplemento existente
        public void UpdateSuplemento(Suplemento updatedSuplemento)
        {
            _context.Suplementos.Update(updatedSuplemento);
            _context.SaveChanges();
        }

        // Obtener suplementos por categoría
        public ObservableCollection<Suplemento> GetSuplementosPorCategoria(int categoriaID)
        {
            return new ObservableCollection<Suplemento>(_context.Suplementos.Where(s => s.CategoriaID == categoriaID).ToList());
        }

        // Obtener suplementos de categorías específicas
        public ObservableCollection<Suplemento> GetAminoacidos()
        {
            return new ObservableCollection<Suplemento>(
                _context.Suplementos.Where(s => s.categoria.Nombre.Equals("Aminoácidos")).ToList()
            );
        }

        public ObservableCollection<Suplemento> GetProteinas()
        {
            return new ObservableCollection<Suplemento>(
                _context.Suplementos.Where(s => s.categoria.Nombre.Equals("Proteínas")).ToList()
            );
        }

        public ObservableCollection<Suplemento> GetVitaminas()
        {
            return new ObservableCollection<Suplemento>(
                _context.Suplementos.Where(s => s.categoria.Nombre.Equals("Vitaminas")).ToList()
            );
        }

        // Agregar suplemento favorito
        public void AddSuplementoFavorito(int usuarioId, int suplementoId)
        {
            bool yaExiste = _context.Usuarios_SuplementosFavoritos
                .Any(fav => fav.UsuarioID == usuarioId && fav.SuplementoID == suplementoId);

            if (yaExiste)
            {
                MessageBox.Show("Este suplemento ya ha sido añadido a favoritos.");
                return;
            }

            _context.Usuarios_SuplementosFavoritos.Add(new Usuarios_SuplementosFavoritos(usuarioId, suplementoId, DateTime.Now));
            _context.SaveChanges();
            MessageBox.Show("Añadido a favoritos.");
        }


        public List<Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

        public List<Suplemento> obtenerSuplementosFiltro(string value)
        {
           return _context.Suplementos.Include(s => s.categoria).Where(e => e.Nombre.ToLower().Contains(value.ToLower())).ToList();
        }

        //Comprobar categorias
        public bool ExisteCategoria(int categoriaId)
        {
            return _context.Categorias.Any(c => c.ID == categoriaId);
        }

        public List<Suplemento> GetSuplementosFavoritos(int usuarioId)
        {
            return _context.Suplementos
                .Where(s => _context.Usuarios_SuplementosFavoritos
                .Any(fav => fav.UsuarioID == usuarioId && fav.SuplementoID == s.ID))
                .ToList();
        }

        public void RemoveSuplementoFavorito(int usuarioId, int suplementoId)
        {
            var favorito = _context.Usuarios_SuplementosFavoritos
                .SingleOrDefault(fav => fav.UsuarioID == usuarioId && fav.SuplementoID == suplementoId);

            if (favorito != null)
            {
                _context.Usuarios_SuplementosFavoritos.Remove(favorito);
                _context.SaveChanges();
                MessageBox.Show("Suplemento eliminado de favoritos.");
            }
        }

    }

}

