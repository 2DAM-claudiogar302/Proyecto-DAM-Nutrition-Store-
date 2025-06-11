using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using ProyectoNutritionStoreEF.EntityFramework;
using ProyectoNutritionStoreEF.Models;
using ProyectoNutritionStoreEF.Service;
using ProyectoNutritionStoreEF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Index = ProyectoNutritionStoreEF.Views.Index;

namespace ProyectoNutritionStoreEF.ViewModels
{
    public class SuplementoViewModel : INotifyPropertyChanged
    {

        #region Variables
        private readonly SuplementoService suplementoService;
        private readonly LoginService loginService;
        private ObservableCollection<Models.Suplemento> suplementosTendencia {  get; set; }
        byte[] suplementoImg;
        private bool imagenSubida = false;
        private Window ventanaActual;
        #endregion

        #region Comandos

        public RelayCommand obtenerSuplementos { get; }
        public RelayCommand obtenerSuplementosTendencia { get; }
        public RelayCommand AddSuplemento { get; }
        public RelayCommand UpdateSuplemento { get; }
        public RelayCommand DeleteSuplemento { get; }

        public RelayCommand CancelCommand { get; }

        public RelayCommand VistaIndex { get; }
        public RelayCommand VistaFavoritos { get; }
        public RelayCommand VistaProteinas {  get; }
        public RelayCommand VistaVitaminas {  get; }
        public RelayCommand VistaAminoacidos {  get; }
        public RelayCommand LoadImagenCommand { get; }
        public RelayCommand AddSuplemFavorito { get; }
        public RelayCommand RemoveSuplemFavorito { get; }

        public RelayCommand SearchCommand { get; }
        #endregion

        #region Propiedades

        private ObservableCollection<Suplemento> _suplementosFavoritos;
        public ObservableCollection<Suplemento> SuplementosFavoritos
        {
            get => _suplementosFavoritos;
            set
            {
                _suplementosFavoritos = value;
                OnPropertyChanged(nameof(SuplementosFavoritos));
            }
        }


        private ObservableCollection<Categoria> _listaCategorias;
        public ObservableCollection<Categoria> ListaCategorias
        {
            get => _listaCategorias;
            set
            {
                _listaCategorias = value;
                OnPropertyChanged(nameof(ListaCategorias));
            }
        }

        private Categoria _categoriaSeleccionada;
        public Categoria CategoriaSeleccionada
        {
            get => _categoriaSeleccionada;
            set
            {
                _categoriaSeleccionada = value;
                CategoriaId = _categoriaSeleccionada.ID;
                OnPropertyChanged(nameof(CategoriaSeleccionada));
            }
        }

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

        private decimal _precio;
        public decimal Precio
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
                    CategoriaSeleccionada = ListaCategorias.FirstOrDefault(c => c.ID == _suplementoSeleccionado.CategoriaID);
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
        public SuplementoViewModel(Window ventana, SuplementoService spl)
        {
            ventanaActual = ventana;

            suplementoService = spl;


            SuplementosFavoritos = new ObservableCollection<Suplemento>(suplementoService.GetSuplementosFavoritos(obtenerUsuario()));
            SuplementosTendencia = new ObservableCollection<Models.Suplemento>();
            SuplementosTotales = new ObservableCollection<Models.Suplemento>();
            Aminoacidos = new ObservableCollection<Models.Suplemento>();
            Proteinas = new ObservableCollection<Models.Suplemento>();
            Vitaminas = new ObservableCollection<Models.Suplemento>();

            AddSuplemento = new RelayCommand(
                _ => anadirSuplemento(),
                _ => true
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
            VistaIndex = new RelayCommand(
                _ => goToIndex(),
                _ => true
                );
            VistaFavoritos= new RelayCommand(
                _ => goToFavoritos(),
                _ => true
                );
            LoadImagenCommand = new RelayCommand(
                _ => cargarImagen(),
                _ => true
                );
            AddSuplemFavorito = new RelayCommand(
                param => AddSuplFavorito(param),
                _ => true
                );
            RemoveSuplemFavorito = new RelayCommand(
                param => EliminarSuplementoFavorito(param),
                _ => true
                );
            SearchCommand = new RelayCommand(
               _ => searchSuplemento(),
               _ => true
               );
            CargarSuplementosFavoritos(obtenerUsuario());

            LoadData();
            LoadDataFav();
            LoadDataTend();
            LoadAminoacidos();
            LoadProteinas();
            LoadVitaminas();
            LoadCategorias();

        }
        #endregion


        #region Cargar datos
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
        private void LoadData()
        {
            var suplementos = suplementoService.GetAllSuplementos();
            SuplementosTotales.Clear();
            foreach (var supl in suplementos)
            {
                SuplementosTotales.Add(supl);
            }
        }

        private void LoadDataFav()
        {
            var suplementos = suplementoService.GetSuplementosFavoritos(obtenerUsuario());
            SuplementosFavoritos.Clear();
            foreach (var supl in suplementos)
            {
                SuplementosFavoritos.Add(supl);
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

        private void LoadCategorias()
        {
            ListaCategorias = new ObservableCollection<Categoria>(suplementoService.GetCategorias());
        }


        #endregion

        #region Metodosturn SuplementosTotales;
        public void AddSuplFavorito(object suplementoId)
        {
            if (suplementoId is int id)
            {
                int idUser = obtenerUsuario();
                suplementoService.AddSuplementoFavorito(idUser, id);
                CargarSuplementosFavoritos(obtenerUsuario());
            }
        }

        public void EliminarSuplementoFavorito(object suplementoId)
        {
            if (suplementoId is int id)
            {
                int idUser = obtenerUsuario();
                suplementoService.RemoveSuplementoFavorito(idUser, id);
                CargarSuplementosFavoritos(obtenerUsuario());
            }
        }
        private int obtenerUsuario()
        {
            var context = new NutritionStoreContext();
            LoginService loginService = new LoginService(context);
            return loginService.GetUserSesion().ID;
        }

        private void anadirSuplemento()
        {
            if (comprobarCampos())
            {
                Models.Suplemento nuevoSuplemento = new Models.Suplemento(Nombre, Descripcion, CategoriaId, Precio, Tendencia, DateTime.Now, ConvertirImagenAByte(Foto));
                suplementoService.AddSuplemento(nuevoSuplemento);
                LoadDataTend();
                LoadData();
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
                    SuplementoSeleccionado.CategoriaID = CategoriaId;
                    SuplementoSeleccionado.Foto = ConvertirImagenAByte(Foto);
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
                LoadData();
                LimpiarFormulario();
            }
        }

        private void searchSuplemento()
        {
            if (!Value.IsNullOrEmpty())
            {
                SuplementosTotales = new ObservableCollection<Suplemento>(suplementoService.obtenerSuplementosFiltro(Value));
            }
            else
            {
                SuplementosTotales = suplementoService.GetAllSuplementos();
            }
        }

        private bool comprobarCampos()
        {
            bool comprobar = false;
            if (!String.IsNullOrEmpty(Nombre) && !String.IsNullOrEmpty(Descripcion) && !String.IsNullOrEmpty(Precio.ToString()) && imagenSubida && CategoriaId > 0)
            {
                comprobar = true;
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacíos.");
            }
            return comprobar;
        }

        private void CargarSuplementosFavoritos(int usuarioId)
        {
            SuplementosFavoritos = new ObservableCollection<Suplemento>(suplementoService.GetSuplementosFavoritos(usuarioId));
        }


        private void LimpiarFormulario()
        {
            Nombre = null;
            Descripcion = null;
            Precio = 0;
            Tendencia = false;
        }

        private void goToVistaProteinas()
        {
            Window ventanaAnterior = ventanaActual;
            ventanaActual = new Proteinas();
            ventanaAnterior?.Close();
            ventanaActual.Show();
        }
        private void goToVistaVitaminas()
        {
            Window ventanaAnterior = ventanaActual;
            ventanaActual = new Vitaminas();
            ventanaAnterior?.Close();
            ventanaActual.Show();
        }
        private void goToVistaAminoacidos()
        {
            Window ventanaAnterior = ventanaActual;
            ventanaActual = new Aminoacidos();
            ventanaAnterior?.Close();
            ventanaActual.Show();
        }

        private void goToIndex()
        {
            Window ventanaAnterior = ventanaActual;
            ventanaActual = new Index();
            ventanaAnterior?.Close();
            ventanaActual.Show();
        }

        private void goToFavoritos()
        {
            CargarSuplementosFavoritos(obtenerUsuario());
            Window ventanaAnterior = ventanaActual;
            ventanaActual = new SuplemetosFavoritos();
            ventanaAnterior?.Close();
            ventanaActual.Show();
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
                    suplementoImg = File.ReadAllBytes(archivoSeleccionado);
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
