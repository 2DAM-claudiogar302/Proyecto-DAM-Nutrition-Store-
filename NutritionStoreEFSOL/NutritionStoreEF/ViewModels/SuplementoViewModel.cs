using Microsoft.Data.SqlClient;
using NutritionStoreEF.Models;
using NutritionStoreEF.Service;
using NutritionStoreEF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace NutritionStoreEF.ViewModels
{
    public class SuplementoViewModel : INotifyPropertyChanged
    {

        #region Variables
        private ObservableCollection<Models.Suplemento> suplementosTendencia {  get; set; }
        #endregion

        #region Comandos
        private readonly SuplementoService suplementoService;

        public RelayCommand obtenerSuplementos { get; }
        public RelayCommand obtenerSuplementosTendencia { get; }
        public RelayCommand AddSuplemento { get; }
        public RelayCommand UpdateSuplemento { get; }
        public RelayCommand DeleteSuplemento { get; }

        public RelayCommand CancelCommand { get; }
        public RelayCommand VistaProteinas {  get; }
        public RelayCommand VistaVitaminas {  get; }
        public RelayCommand VistaAminoacidos {  get; }
        #endregion

        #region Propiedades

        private ObservableCollection<Models.Suplemento> _suplementosTotales { get; set; }
        public ObservableCollection<Models.Suplemento> SuplementosTotales
        {
            get => _suplementosTotales;
            set
            {
                if (_suplementosTotales == value)
                {
                    return;
                }
                _suplementosTotales = value;
                OnPropertyChanged(nameof(SuplementosTotales));
            }
        }

        private ObservableCollection<Models.Suplemento> _suplementosTendencia { get; set; }
        public ObservableCollection<Models.Suplemento> SuplementosTendencia
        {
            get => _suplementosTendencia;
            set
            {
                if (_suplementosTendencia == value)
                {
                    return;
                }
                _suplementosTendencia = value;
                OnPropertyChanged(nameof(SuplementosTendencia));
            }
        }

        private ObservableCollection<Models.Suplemento> _aminoacidos { get; set; }
        public ObservableCollection<Models.Suplemento> Aminoacidos
        {
            get => _aminoacidos;
            set
            {
                if (_aminoacidos == value)
                {
                    return;
                }
                _aminoacidos = value;
                OnPropertyChanged(nameof(Aminoacidos));
            }
        }

        private ObservableCollection<Models.Suplemento> _proteinas { get; set; }
        public ObservableCollection<Models.Suplemento> Proteinas
        {
            get => _proteinas;
            set
            {
                if (_proteinas == value)
                {
                    return;
                }
                _proteinas = value;
                OnPropertyChanged(nameof(Proteinas));
            }
        }

        private ObservableCollection<Models.Suplemento> _vitaminas { get; set; }
        public ObservableCollection<Models.Suplemento> Vitaminas
        {
            get => _vitaminas;
            set
            {
                if (_vitaminas == value)
                {
                    return;
                }
                _vitaminas = value;
                OnPropertyChanged(nameof(Vitaminas));
            }
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        private string _descripcion;
        public string Descripcion
        {
            get => _descripcion;
            set
            {
                _descripcion = value;
                OnPropertyChanged(nameof(Descripcion));
            }
        }

        private int _categoriaId;
        public int CategoriaId
        {
            get => _categoriaId;
            set
            {
                _categoriaId = value;
                OnPropertyChanged(nameof(CategoriaId));
            }
        }

        private double _precio;
        public double Precio
        {
            get => _precio;
            set
            {
                _precio = value;
                OnPropertyChanged(nameof(Precio));
            }
        }

        private bool _tendencia;
        public bool Tendencia
        {
            get => _tendencia;
            set
            {
                _tendencia = value;
                OnPropertyChanged(nameof(Tendencia));
            }
        }

        private DateTime _fechaAnadido;
        public DateTime FechaAnadido
        {
            get => _fechaAnadido;
            set
            {
                _fechaAnadido = value;
                OnPropertyChanged(nameof(FechaAnadido));
            }
        }

        private Models.Suplemento _suplementoSeleccionado;
        public Models.Suplemento SuplementoSeleccionado
        {
            get { return _suplementoSeleccionado; }
            set
            {
                _suplementoSeleccionado = value;
                OnPropertyChanged(nameof(SuplementoSeleccionado));

                if (_suplementoSeleccionado != null)
                {
                    Id = _suplementoSeleccionado.ID;
                    Nombre = _suplementoSeleccionado.Nombre;
                    Descripcion = _suplementoSeleccionado.Descripcion;
                    CategoriaId = _suplementoSeleccionado.CategoriaID;
                    Precio = _suplementoSeleccionado.Precio;
                    Tendencia = _suplementoSeleccionado.Tendencia;
                    FechaAnadido = _suplementoSeleccionado.FechaAnadido;

                }
            }
        }
        #endregion

        #region Constructor
        public SuplementoViewModel()
        {
            suplementoService = new SuplementoService();

            SuplementosTendencia = new ObservableCollection<Models.Suplemento>();
            SuplementosTotales = new ObservableCollection<Models.Suplemento>();
            Aminoacidos = new ObservableCollection<Models.Suplemento>();
            Proteinas = new ObservableCollection<Models.Suplemento>();
            Vitaminas = new ObservableCollection<Models.Suplemento>();

            AddSuplemento = new RelayCommand(
                _ => anadirSuplemento(),
                _ => SuplementoSeleccionado == null
                );

            UpdateSuplemento = new RelayCommand(
                _ => EditSuplemento(),
                _ => SuplementoSeleccionado != null
                );

            DeleteSuplemento = new RelayCommand(
                _ => eliminarSuplemento(),
               _ => SuplementoSeleccionado != null
               );

            CancelCommand = new RelayCommand(
                _ => LimpiarFormulario(),
                _ => true);

            VistaProteinas = new RelayCommand(
                _ => goToVistaProteinas(),
                _ => true
                );

            VistaVitaminas = new RelayCommand(
                _ => goToVistaVitaminas(),
                _ => true
                );

            VistaAminoacidos = new RelayCommand(
                _ => goToVistaAminoacidos(),
                _ => true
                ); 


            LoadData();
            LoadDataTend();
            LoadAminoacidos();
            LoadProteinas();
            LoadVitaminas();
        }
        #endregion


        #region Cargar datos

        private void LoadData()
        {
            var suplementos = suplementoService.GetAllSuplementos();
            SuplementosTotales.Clear();
            foreach (var supl in suplementos)
            {
                SuplementosTotales.Add(supl);
            }
        }

        private void LoadDataTend()
        {
            var suplementos = suplementoService.GetSuplementosEnTendencia();
            SuplementosTendencia.Clear();
            foreach (var supl in suplementos)
            {
                SuplementosTendencia.Add(supl);
            }
        }

        private void LoadAminoacidos()
        {
            var suplementos = suplementoService.GetAminoacidos();
            Aminoacidos.Clear();
            foreach (var supl in suplementos)
            {
                Aminoacidos.Add(supl);
            }
        }

        private void LoadProteinas()
        {
            var suplementos = suplementoService.GetProteinas();
            Proteinas.Clear();
            foreach (var supl in suplementos)
            {
                Proteinas.Add(supl);
            }
        }

        private void LoadVitaminas()
        {
            var suplementos = suplementoService.GetVitaminas();
            Vitaminas.Clear();
            foreach (var supl in suplementos)
            {
                Vitaminas.Add(supl);
            }
        }

        #endregion

        #region Metodosturn SuplementosTotales;

        private void anadirSuplemento()
        {
            if (comprobarCampos())
            {
                Models.Suplemento nuevoSuplemento = new Models.Suplemento(Nombre, Descripcion, CategoriaId, Precio, Tendencia);
                suplementoService.AddSuplemento(nuevoSuplemento);
                LoadDataTend();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacios.");
            }
        }

        private void EditSuplemento()
        {
            if (SuplementoSeleccionado != null)
            {

                if (comprobarCampos())
                {
                    SuplementoSeleccionado.Nombre = Nombre;
                    SuplementoSeleccionado.Descripcion = Descripcion;
                    SuplementoSeleccionado.CategoriaID = CategoriaId;
                    SuplementoSeleccionado.Precio = Precio;
                    SuplementoSeleccionado.Tendencia = Tendencia;
                    suplementoService.UpdateSuplemento(SuplementoSeleccionado);
                    MessageBox.Show("Se ha modificado el ejercicio.");
                    LoadDataTend();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("Los campos no pueden estar vacios.");
                }
            }
        }

        private void eliminarSuplemento()
        {
            var confirmacion = MessageBox.Show("¿Desea eliminar el ejercicio?",
               "Alerta", MessageBoxButton.OKCancel);
            if (confirmacion == MessageBoxResult.OK)
            {
                suplementoService.RemoveSuplemento(SuplementoSeleccionado.ID);
                LoadDataTend();
                LimpiarFormulario();
            }
        }

        private bool comprobarCampos()
        {
            bool comprobar = false;
            if (!String.IsNullOrEmpty(Nombre) && !String.IsNullOrEmpty(Descripcion) && !String.IsNullOrEmpty(Precio.ToString()))
            {
                comprobar = true;
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacíos.");
            }
            return comprobar;
        }

        private void LimpiarFormulario()
        {
            Nombre = null;
            Descripcion = null;
            Precio = 0;
        }

        private void goToVistaProteinas()
        {
            Proteinas vista = new Proteinas();
            vista.ShowDialog();
        }
        private void goToVistaVitaminas()
        {
            Vitaminas vista = new Views.Vitaminas();
            vista.ShowDialog();
        }
        private void goToVistaAminoacidos()
        {
            Aminoacidos vista = new Views.Aminoacidos();
            vista.ShowDialog();
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
