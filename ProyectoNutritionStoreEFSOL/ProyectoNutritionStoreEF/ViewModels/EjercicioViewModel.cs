using Microsoft.Win32;
using ProyectoNutritionStoreEF.Views;
using ProyectoNutritionStoreEF.Models;
using ProyectoNutritionStoreEF.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using ProyectoNutritionStoreEF.EntityFramework;
using Microsoft.IdentityModel.Tokens;

namespace ProyectoNutritionStoreEF.ViewModels
{
    public class EjercicioViewModel : INotifyPropertyChanged
    {
        #region Variables
        NutritionStoreContext context;
        LoginService _loginService;
        byte[] ejercicioImg;
        private bool imagenSubida = false;
        private Window ventanaActual;
        private string grupoActual;

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
        public RelayCommand VistaSuplementos { get; }
        public RelayCommand VistaSuplementosAdmin { get; }
        public RelayCommand VistaGestionEntrenamiento { get; }
        public RelayCommand VistaEspalda { get; }
        public RelayCommand VistaPecho { get; }
        public RelayCommand VistaBrazo { get; }
        public RelayCommand VistaPierna { get; }
        public RelayCommand VistaFavoritos { get; }
        public RelayCommand LoadImagenCommand { get; }
        public RelayCommand AddEjercicioFavorito { get; }
        public RelayCommand RemoveEjercFavorito { get; }

        public RelayCommand SearchCommand { get; }
        public RelayCommand SearchCommandGrupo { get; }


        #endregion

        #region Propiedades

        //Botón seleccionado
        private string _botonSeleccionado;
        public string BotonSeleccionado
        {
            get => _botonSeleccionado;
            set
            {
                _botonSeleccionado = value;
                OnPropertyChanged(nameof(BotonSeleccionado));
            }
        }


        private ObservableCollection<Ejercicio> _ejerciciosFavoritos;
        public ObservableCollection<Ejercicio> EjerciciosFavoritos
        {
            get => _ejerciciosFavoritos;
            set
            {
                _ejerciciosFavoritos = value;
                OnPropertyChanged(nameof(EjerciciosFavoritos));
            }
        }

        private ObservableCollection<GrupoMuscular> _listaEjercicios;
        public ObservableCollection<GrupoMuscular> ListaEjercicios
        {
            get => _listaEjercicios;
            set
            {
                _listaEjercicios = value;
                OnPropertyChanged(nameof(ListaEjercicios));
            }
        }

        private string _nombreGrupo;
        public string NombreGrupo
        {
            get => _nombreGrupo;
            set
            {
                _nombreGrupo = value;
                OnPropertyChanged(nameof(NombreGrupo));
            }
        }

        private GrupoMuscular _grupoSeleccionado;
        public GrupoMuscular GrupoSeleccionado
        {
            get => _grupoSeleccionado;
            set
            {
                _grupoSeleccionado = value;
                if (_grupoSeleccionado != null)
                {
                    GrupoMuscularId = _grupoSeleccionado.ID;
                }
                else
                {
                    GrupoMuscularId = 0;
                }
                OnPropertyChanged(nameof(GrupoSeleccionado));
            }
        }


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

        private ObservableCollection<Ejercicio> _espalda { get; set; }
        public ObservableCollection<Ejercicio> Espalda
        {
            get => _espalda;
            set
            {
                if (_espalda == value)
                {
                    return;
                }
                _espalda = value;
                OnPropertyChanged(nameof(Espalda));
            }
        }

        private ObservableCollection<Ejercicio> _pecho { get; set; }
        public ObservableCollection<Ejercicio> Pecho
        {
            get => _pecho;
            set
            {
                if (_pecho == value)
                {
                    return;
                }
                _pecho = value;
                OnPropertyChanged(nameof(Pecho));
            }
        }

        private ObservableCollection<Ejercicio> _brazo { get; set; }
        public ObservableCollection<Ejercicio> Brazo
        {
            get => _brazo;
            set
            {
                if (_brazo == value)
                {
                    return;
                }
                _brazo = value;
                OnPropertyChanged(nameof(Brazo));
            }
        }

        private ObservableCollection<Ejercicio> _pierna { get; set; }
        public ObservableCollection<Ejercicio> Pierna
        {
            get => _pierna;
            set
            {
                if (_pierna == value)
                {
                    return;
                }
                _pierna = value;
                OnPropertyChanged(nameof(Pierna));
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
                    Id = _ejercicioSeleccionado.ID;
                    Nombre = _ejercicioSeleccionado.Nombre;
                    GrupoMuscularId = _ejercicioSeleccionado.GrupoMuscularID;
                    Descripcion = _ejercicioSeleccionado.Descripcion;
                    Tendencia = _ejercicioSeleccionado.Tendencia;
                    FechaAnadido = _ejercicioSeleccionado.FechaAnadido;
                    Foto = ConvertirByteAImagen(_ejercicioSeleccionado.Foto);
                    imagenSubida = _ejercicioSeleccionado.Foto != null;
                    //Para que se muestre el nombre en el comboBox
                    GrupoSeleccionado = ListaEjercicios.FirstOrDefault(g => g.ID == _ejercicioSeleccionado.GrupoMuscularID);
                    OnPropertyChanged(nameof(Id));
                    OnPropertyChanged(nameof(Nombre));
                    OnPropertyChanged(nameof(GrupoMuscularId));
                    OnPropertyChanged(nameof(Descripcion));
                    OnPropertyChanged(nameof(Tendencia));
                    OnPropertyChanged(nameof(FechaAnadido));
                }
            }
        }
        private BitmapImage _foto;
        public BitmapImage Foto
        {
            get => _foto ?? new BitmapImage(new Uri("pack://application:,,,/Resources/favorito.png"));
            set
            {
                _foto = value;
                OnPropertyChanged(nameof(Foto));
            }
        }


        private string _value;
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        #endregion

        #region Constructor
        public EjercicioViewModel(Window ventana, EjercicioService ejer, string grupoAct = null, string botonActivado = null)
        {
            grupoActual = grupoAct;
            ventanaActual = ventana;
            BotonSeleccionado = botonActivado;
            context = new NutritionStoreContext();
            _loginService = new LoginService(context);

            ejercicioService = ejer;
            EjerciciosFavoritos = new ObservableCollection<Ejercicio>(ejercicioService.GetEjerciciosFavoritos(obtenerUsuario()));

            ListaEjercicios = new ObservableCollection<GrupoMuscular>();
            EjerciciosTendencia = new ObservableCollection<Ejercicio>();
            EjerciciosTotales = new ObservableCollection<Ejercicio>();
            Pecho = new ObservableCollection<Ejercicio>();
            Espalda = new ObservableCollection<Ejercicio>();
            Pierna = new ObservableCollection<Ejercicio>();
            Brazo = new ObservableCollection<Ejercicio>();

            AddEjercicio = new RelayCommand(
                _ => anadirEjercicio(),
                //Comprobar si funciona cuando EjercicioSeleccionado == null
                _ => true
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
            VistaEspalda = new RelayCommand(
                _ => goToVistaEspalda(),
                _ => true
                );
            VistaPecho = new RelayCommand(
                _ => goToVistaPecho(),
                _ => true
                );
            VistaPierna = new RelayCommand(
                _ => goToVistaPierna(),
                _ => true
                );
            VistaBrazo = new RelayCommand(
                _ => goToVistaBrazo(),
                _ => true
                );
            LoadImagenCommand = new RelayCommand(
                _ => cargarImagen(),
                _ => true
                );
            AddEjercicioFavorito = new RelayCommand(
                param => AddEjercFavorito(param),
                _ => true
                );
            RemoveEjercFavorito = new RelayCommand(
                param => EliminarEjercicioFavorito(param),
                _ => true
                );
            VistaFavoritos = new RelayCommand(
                _ => goToFavoritos(),
                _ => true
                );
            VistaSuplementos = new RelayCommand(
                _ => goToSuplementos(),
                _ => true
                );
            VistaSuplementosAdmin = new RelayCommand(
                _ => goToSuplementosAdmin(),
                _ => true
                );
            SearchCommand = new RelayCommand(
                _ => searchEjercicio(),
                _ => true
                );
            SearchCommandGrupo = new RelayCommand(
                _ => searchEjercicioGrupo(),
                _ => true
                );

            LoadDataTend();
            LoadData();
            LoadDataPecho();
            LoadDataEspalda();
            LoadDataBrazo();
            LoadDataPierna();
            LoadEjercicios();
        }
        #endregion

        #region Cargar datos
        public BitmapImage ConvertirByteAImagen(byte[] imagenEnBytes)
        {
            if (imagenEnBytes == null || imagenEnBytes.Length == 0)
                return null;

            using (var stream = new MemoryStream(imagenEnBytes))
            {
                var imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.CacheOption = BitmapCacheOption.OnLoad;
                imagen.StreamSource = stream;
                imagen.EndInit();
                imagen.Freeze();
                return imagen;
            }
        }
        private void LoadData()
        {
            var ejercicios = ejercicioService.GetAllEjercicios();
            EjerciciosTotales.Clear();
            foreach (var ejerc in ejercicios)
            {
                EjerciciosTotales.Add(ejerc);
            }
        }

        private void LoadDataTend()
        {
            var ejercicios = ejercicioService.GetEjerciciosTendencia();
            EjerciciosTendencia.Clear();
            foreach (var ejerc in ejercicios)
            {
                EjerciciosTendencia.Add(ejerc);
            }
        }

        private void LoadEjercicios()
        {
            ListaEjercicios = new ObservableCollection<GrupoMuscular>(ejercicioService.GetGrupoMuscular());
        }

        private void LoadDataPecho()
        {
            var ejerciciosPecho = ejercicioService.GetEjerciciosPecho();
            Pecho.Clear();
            foreach (var ejerc in ejerciciosPecho)
            {
                Pecho.Add(ejerc);
            }
        }

        private void LoadDataEspalda()
        {
            var ejerciciosEspalda = ejercicioService.GetEjerciciosEspalda();
            Espalda.Clear();
            foreach (var ejerc in ejerciciosEspalda)
            {
                Espalda.Add(ejerc);
            }
        }

        private void LoadDataPierna()
        {
            var ejerciciosPierna = ejercicioService.GetEjerciciosPierna();
            Pierna.Clear();
            foreach (var ejerc in ejerciciosPierna)
            {
                Pierna.Add(ejerc);
            }
        }

        private void LoadDataBrazo()
        {
            var ejerciciosBrazo = ejercicioService.GetEjerciciosBrazo();
            Brazo.Clear();
            foreach (var ejerc in ejerciciosBrazo)
            {
                Brazo.Add(ejerc);
            }
        }

        #endregion

        #region Metodos


        private byte[] ConvertirImagenAByte(BitmapImage image)
        {
            if (image == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(ms);
                return ms.ToArray();
            }
        }

        //Mirar como pasarle el id
        private void AddEjercFavorito(object ejercicioId)
        {
            if (ejercicioId is int id)
            {
                int idUser = _loginService.GetUserSesion().ID;
                ejercicioService.AddEjercicioFavorito(idUser, id);
            }
        }

        private void EliminarEjercicioFavorito(object suplementoId)
        {
            if (suplementoId is int id)
            {
                int idUser = obtenerUsuario();
                ejercicioService.RemoveEjercicioFavorito(idUser, id);
                CargarEjerciciosFavoritos(obtenerUsuario());
            }
        }

        private void CargarEjerciciosFavoritos(int usuarioId)
        {
            EjerciciosFavoritos = new ObservableCollection<Ejercicio>(ejercicioService.GetEjerciciosFavoritos(usuarioId));
        }

        private int obtenerUsuario()
        {
            var context = new NutritionStoreContext();
            LoginService loginService = new LoginService(context);
            return loginService.GetUserSesion().ID;
        }
        private void goToVistaEntrenamiento()
        {
            this.ventanaActual.Close();
            Entrenamiento vista = new Entrenamiento();
            vista.DataContext = new EjercicioViewModel(vista, ejercicioService, "Inicio", "Inicio");
            vista.ShowDialog();
        }

        private void goToVistaEntrenamientoAdmin()
        {
            if (ventanaActual != null)
            {
                ventanaActual.Close();
            }
            else
            {
                MessageBox.Show("La ventana actual es nula. No se puede cerrar.");
            }

            EntrenamientoAdmin vista = new EntrenamientoAdmin();
            vista.ShowDialog();
        }


        private void goToVistaGestionEntrenamientoAdmin()
        {
            this.ventanaActual.Close();
            GestionEntrenamientoAdmin vista = new GestionEntrenamientoAdmin();
            vista.ShowDialog();
        }

        private void goToVistaEspalda()
        {
            this.ventanaActual.Close();
            Espalda vista = new Views.Espalda();
            vista.DataContext = new EjercicioViewModel(vista, ejercicioService, "Espalda", "Espalda");
            vista.ShowDialog();
        }

        private void goToVistaPecho()
        {
            this.ventanaActual.Close();
            Pecho vista = new Views.Pecho();
            vista.DataContext = new EjercicioViewModel(vista, ejercicioService, "Pecho", "Pecho");
            vista.ShowDialog();
        }

        private void goToVistaPierna()
        {
            this.ventanaActual.Close();
            Pierna vista = new Views.Pierna();
            vista.DataContext = new EjercicioViewModel(vista, ejercicioService, "Pierna", "Pierna");
            vista.ShowDialog();
        }

        private void goToVistaBrazo()
        {
            this.ventanaActual.Close();
            Brazo vista = new Views.Brazo();
            vista.DataContext = new EjercicioViewModel(vista, ejercicioService, "Brazo", "Brazo");
            vista.ShowDialog();
        }

        private void goToFavoritos()
        {
            CargarEjerciciosFavoritos(obtenerUsuario());
            Window ventanaAnterior = ventanaActual;
            ventanaActual = new EjerciciosFavoritos();
            ventanaActual.DataContext = new EjercicioViewModel(ventanaActual, ejercicioService, "Favoritos", "Favoritos");
            ventanaAnterior?.Close();
            ventanaActual.Show();
            
        }

        private void goToSuplementos()
        {
            Window ventanaAnterior = ventanaActual;
            ventanaActual = new Views.Index();
            ventanaAnterior?.Close();
            ventanaActual.Show();
        }

        private void goToSuplementosAdmin()
        {
            Window ventanaAnterior = ventanaActual;
            ventanaActual = new Views.IndexAdmin();
            ventanaAnterior?.Close();
            ventanaActual.Show();
        }

        private void anadirEjercicio()
        {
            if (GrupoMuscularId <= 0)
            {
                MessageBox.Show("Selecciona un grupo muscular válido.");
            }

            if (comprobarCampos())
            {
                ejercicioService.AddEjercicio(new Ejercicio(Nombre, GrupoMuscularId, Descripcion, Tendencia, DateTime.Now, ConvertirImagenAByte(Foto)));
                LoadDataTend();
                LoadData();
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
                    EjercicioSeleccionado.Foto = ConvertirImagenAByte(Foto);
                    EjercicioSeleccionado.GrupoMuscularID = GrupoMuscularId;
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
                ejercicioService.RemoveEjercicio(EjercicioSeleccionado.ID);
                LoadDataTend();
                LoadData();
                LimpiarFormulario();
            }
        }

        public void searchEjercicio()
        {
            if (!Value.IsNullOrEmpty())
            {
                EjerciciosTotales = new ObservableCollection<Ejercicio>(ejercicioService.obtenerEjerciciosFiltro(Value));
            }
            else
            {
                EjerciciosTotales = ejercicioService.GetAllEjercicios();
            }
        }

        private void searchEjercicioGrupo()
        {
            var listaFiltrada = ejercicioService.obtenerEjerciciosFiltro(Value);

            switch (grupoActual)
            {
                case "Pecho":
                    Pecho = new ObservableCollection<Ejercicio>(
                        listaFiltrada.Where(e => e.grupoMuscular?.Nombre == "Pecho"));
                    MessageBox.Show($"Filtrados: {Pecho.Count}");
                    break;
                case "Espalda":
                    Espalda = new ObservableCollection<Ejercicio>(
                        listaFiltrada.Where(e => e.grupoMuscular?.Nombre == "Espalda"));
                    break;
                case "Brazo":
                    Brazo = new ObservableCollection<Ejercicio>(
                        listaFiltrada.Where(e => e.grupoMuscular?.Nombre == "Brazo"));
                    break;
                case "Pierna":
                    Pierna = new ObservableCollection<Ejercicio>(
                        listaFiltrada.Where(e => e.grupoMuscular?.Nombre == "Pierna"));
                    break;
            }
        }


        private bool comprobarCampos()
        {
            bool comprobar = false;

            if (!String.IsNullOrEmpty(Nombre) && !String.IsNullOrEmpty(Descripcion) && GrupoMuscularId > 0) 
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
            Tendencia = false;
            GrupoSeleccionado = null;
            EjercicioSeleccionado = null;
            
        }

        private void cargarImagen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imágenes (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    string archivoSeleccionado = openFileDialog.FileName;
                    ejercicioImg = File.ReadAllBytes(archivoSeleccionado);
                    Foto = new BitmapImage(new Uri(archivoSeleccionado));
                    imagenSubida = true;
                    MessageBox.Show($"Foto cargada correctamente.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
            }

        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
