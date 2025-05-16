using NutritionStoreEF.Models;
using NutritionStoreEF.Service;
using NutritionStoreEF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NutritionStoreEF.ViewModels
{
    public class EjercicioViewModel
    {
        #region Variables
        #endregion

        #region Comandos
        private readonly EjercicioService ejercicioService;
        public RelayCommand obtenerEjercicios {  get; }
        public RelayCommand obtenerEjerciciosTendencia { get; }
        public RelayCommand AddEjercicio {  get; }
        public RelayCommand UpdateEjercicio {  get; }
        public RelayCommand DeleteEjercicio { get; }

        public RelayCommand CancelCommand { get; }
        public RelayCommand VistaEntrenamiento { get; }
        public RelayCommand VistaEntrenamientoAdmin { get; }
        public RelayCommand VistaGestionEntrenamiento { get; }

        #endregion

        #region Propiedades

        private ObservableCollection<Ejercicio> _ejerciciosTotales { get; set; }
        public ObservableCollection<Ejercicio> EjerciciosTotales
        {
            get => _ejerciciosTotales;
            set
            {
                if (_ejerciciosTotales == value)
                {
                    return;
                }
                _ejerciciosTotales = value;
                OnPropertyChanged(nameof(EjerciciosTotales));
            }
        }

        private ObservableCollection<Ejercicio> _ejerciciosTendencia { get; set; }
        public ObservableCollection<Ejercicio> EjerciciosTendencia
        {
            get => _ejerciciosTendencia;
            set
            {
                if (_ejerciciosTendencia == value)
                {
                    return;
                }
                _ejerciciosTendencia = value;
                OnPropertyChanged(nameof(EjerciciosTendencia));
            }
        }

        private string _id;
        public string Id
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

        private int _grupoMuscularId;
        public int GrupoMuscularId
        {
            get => _grupoMuscularId;
            set
            {
                _grupoMuscularId = value;
                OnPropertyChanged(nameof(GrupoMuscularId));
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

        private Ejercicio _ejercicioSeleccionado;
        public Ejercicio EjercicioSeleccionado
        {
            get { return _ejercicioSeleccionado; }
            set
            {
                _ejercicioSeleccionado = value;
                OnPropertyChanged(nameof(EjercicioSeleccionado));

                if (_ejercicioSeleccionado != null)
                {
                    Nombre = _ejercicioSeleccionado.Nombre;
                    GrupoMuscularId = _ejercicioSeleccionado.GrupoMuscularID;
                    Descripcion = _ejercicioSeleccionado.Descripcion;
                    Tendencia = _ejercicioSeleccionado.Tendencia;
                    FechaAnadido = _ejercicioSeleccionado.FechaAnadido;

                }
            }
        }
        #endregion

        #region Constructor
        public EjercicioViewModel()
        {
            ejercicioService = new EjercicioService();

            EjerciciosTendencia = new ObservableCollection<Ejercicio>();
            EjerciciosTotales = new ObservableCollection<Ejercicio>();  

            AddEjercicio = new RelayCommand(
                _=> anadirEjercicio(),
                _ => EjercicioSeleccionado == null
                );

            UpdateEjercicio = new RelayCommand(
                _ => EditEjercicio(),
                _ => EjercicioSeleccionado != null
                );

            DeleteEjercicio = new RelayCommand(
                 _ => eliminarEjercicio(),
                _ => EjercicioSeleccionado != null
                );

            CancelCommand = new RelayCommand(
                _ => LimpiarFormulario(),
                _ => true);

            VistaEntrenamiento = new RelayCommand(
                _ => goToVistaEntrenamiento(),
                _ => true
                );

            VistaEntrenamientoAdmin = new RelayCommand(
                _ => goToVistaEntrenamientoAdmin(),
                _ => true
                );
            VistaGestionEntrenamiento = new RelayCommand(
                _ => goToVistaGestionEntrenamientoAdmin(),
                _ => true
                );


            LoadDataTend();
            LoadData();
        }
        #endregion

        #region Cargar datos

        private void LoadData()
        {
            var suplementos = ejercicioService.GetAllEjercicios();
            EjerciciosTotales.Clear();
            foreach (var supl in suplementos)
            {
                EjerciciosTotales.Add(supl);
            }
        }

        private void LoadDataTend()
        {
            var suplementos = ejercicioService.GetEjerciciosTendencia();
            EjerciciosTendencia.Clear();
            foreach (var supl in suplementos)
            {
                EjerciciosTendencia.Add(supl);
            }
        }

        #endregion

        #region Metodos

        private void goToVistaEntrenamiento()
        {
            Entrenamiento vista = new Entrenamiento();
            vista.ShowDialog();
        }

        private void goToVistaEntrenamientoAdmin()
        {
            EntrenamientoAdmin vista = new EntrenamientoAdmin();
            vista.ShowDialog();
        }

        private void goToVistaGestionEntrenamientoAdmin()
        {
            GestionEntrenamientoAdmin vista = new GestionEntrenamientoAdmin();
            vista.ShowDialog();
        }

        private void anadirEjercicio()
        {
            if (comprobarCampos())
            {
                Ejercicio nuevoEjercicio = new Ejercicio(Nombre, GrupoMuscularId, Descripcion, Tendencia);
                ejercicioService.AddEjercicio(nuevoEjercicio);
                LoadDataTend();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacios.");
            }
        }

        private void EditEjercicio()
        {
            if (EjercicioSeleccionado != null)
            {

                if (comprobarCampos())
                {
                    EjercicioSeleccionado.Nombre = Nombre;
                    EjercicioSeleccionado.GrupoMuscularID = GrupoMuscularId;
                    EjercicioSeleccionado.Descripcion = Descripcion;
                    EjercicioSeleccionado.Tendencia = Tendencia;
                    ejercicioService.UpdateEjercicio(EjercicioSeleccionado);
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

        private void eliminarEjercicio()
        {
            var confirmacion = MessageBox.Show("¿Desea eliminar el ejercicio?",
               "Alerta", MessageBoxButton.OKCancel);
            if (confirmacion == MessageBoxResult.OK)
            {
                ejercicioService.RemoveEjercicio(EjercicioSeleccionado);
                LoadDataTend();
                LimpiarFormulario();
            }
        }

        private bool comprobarCampos()
        {
            bool comprobar = false;
            if (!String.IsNullOrEmpty(Nombre)&& !String.IsNullOrEmpty(Descripcion))
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
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
