using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using ProyectoNutritionStoreEF.Models;
using ProyectoNutritionStoreEF.Service;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProyectoNutritionStoreEF.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        #region Variables
        private UsuarioService _usuarioService;
        private bool imagenSubida = false;
        byte[] usuarioImg;
        #endregion

        #region Propiedades
        private ObservableCollection<Usuario> _usuarios;
        public ObservableCollection<Usuario> Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; OnPropertyChanged(nameof(Usuarios)); }
        }

        private int _id;
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
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

        private string _apellido1;
        public string Apellido1
        {
            get => _apellido1;
            set
            {
                _apellido1 = value;
                OnPropertyChanged(nameof(Apellido1));
            }
        }

        private string _apellido2;
        public string Apellido2
        {
            get => _apellido2;
            set
            {
                _apellido2 = value;
                OnPropertyChanged(nameof(Apellido2));
            }
        }

        private string _usuername;
        public string Usuername
        {
            get => _usuername;
            set
            {
                _usuername = value;
                OnPropertyChanged(nameof(Usuername));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _contraseña;
        public string Contraseña
        {
            get => _contraseña;
            set
            {
                _contraseña = value;
                OnPropertyChanged(nameof(Contraseña));
            }
        }

        private bool _administrador;
        public bool Administrador
        {
            get => _administrador;
            set
            {
                _administrador = value;
                OnPropertyChanged(nameof(Administrador));
            }
        }

        private BitmapImage _foto;
        public BitmapImage Foto
        {
            get => _foto;
            set
            {
                _foto = value;
                OnPropertyChanged(nameof(Foto));
            }
        }

        private DateTime _fechaRegistro;
        public DateTime FechaRegistro
        {
            get => _fechaRegistro;
            set
            {
                _fechaRegistro = value;
                OnPropertyChanged(nameof(FechaRegistro));
            }
        }

        private Usuario _usuarioSeleccionado;
        public Usuario UsuarioSeleccionado
        {
            get { return _usuarioSeleccionado; }
            set
            {
                _usuarioSeleccionado = value;
                OnPropertyChanged(nameof(UsuarioSeleccionado));

                if (_usuarioSeleccionado != null)
                {
                    ID = _usuarioSeleccionado.ID;
                    Nombre = _usuarioSeleccionado.Nombre;
                    Apellido1 = _usuarioSeleccionado.Apellido1;
                    Apellido2 = _usuarioSeleccionado.Apellido2;
                    Usuername = _usuarioSeleccionado.Username;
                    Email = _usuarioSeleccionado.Email;
                    Contraseña = _usuarioSeleccionado.Contraseña;
                    Foto = ConvertirByteAImagen(_usuarioSeleccionado.Foto);
                    FechaRegistro = _usuarioSeleccionado.FechaRegistro;

                }
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

        #region Comandos
        public RelayCommand CargarUsuariosCommand { get; set; }
        public RelayCommand AgregarUsuarioCommand { get; set; }
        public RelayCommand EditarUsuarioCommand { get; set; }
        public RelayCommand EliminarUsuarioCommand { get; set; }
        public RelayCommand CancelCommand { get; }
        public RelayCommand LoadImagenCommand { get; }
        public RelayCommand obtenerDatosUser { get; }
        public RelayCommand FavoritosCommand { get; }
        public RelayCommand SearchCommand { get; }
        #endregion

        #region Constructor
        public UsuarioViewModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            Usuarios = new ObservableCollection<Usuario>(_usuarioService.GetAllUsuarios());
            obtenerDatosUser = new RelayCommand(
                _ => obtenerInformacion(),
                _ => UsuarioSeleccionado != null
                );
            FavoritosCommand = new RelayCommand(
                _ => obtenerInformacionFav(),
                _ => UsuarioSeleccionado != null
                );
            CargarUsuariosCommand = new RelayCommand(
                _ => LoadUsuarios(),
                _ => true);
            AgregarUsuarioCommand = new RelayCommand(
                _ => AddUsuario(),
                _ => true);
            EditarUsuarioCommand = new RelayCommand(
                _ => UpdateUsuario(),
                _ => true);
            EliminarUsuarioCommand = new RelayCommand(
                _ => RemoveUsuario(),
                _ => true);
            CancelCommand = new RelayCommand(
                    _ => LimpiarFormulario(),
                    _ => true);
            LoadImagenCommand = new RelayCommand(
                    _ => cargarImagen(),
                    _ => true
                    );
            SearchCommand = new RelayCommand(
                _ => searchUsuario(),
                _ => true
                );

            LoadUsuarios();
        }
        #endregion

        #region Métodos
        private bool comprobarCampos()
        {
            bool comprobar = false;
            if (!String.IsNullOrEmpty(Nombre) && !String.IsNullOrEmpty(Apellido1) && !String.IsNullOrEmpty(Apellido2)
                && !String.IsNullOrEmpty(Usuername) && !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Contraseña) && imagenSubida)
            {
                comprobar = true;
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacíos.");
            }
            return comprobar;
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
                    usuarioImg = File.ReadAllBytes(archivoSeleccionado);
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

        private void LoadUsuarios()
        {
            var users = _usuarioService.GetAllUsuarios();
            Usuarios.Clear();
            foreach (var user in users)
            {
                Usuarios.Add(user);
            }
        }

        private void AddUsuario()
        {
            if (comprobarCampos())
            {
                Usuario nuevoUsuario = new Usuario(Nombre, Apellido1, Apellido2, Usuername, Email, Contraseña, false, ConvertirImagenAByte(Foto), DateTime.Now);
                _usuarioService.AddUsuario(nuevoUsuario);
                LoadUsuarios();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacios.");
            }
        }

        private void UpdateUsuario()
        {
            if (UsuarioSeleccionado != null)
            {

                if (comprobarCampos())
                {
                    UsuarioSeleccionado.Nombre = Nombre;
                    UsuarioSeleccionado.Apellido1 = Apellido1;
                    UsuarioSeleccionado.Apellido2 = Apellido2;
                    UsuarioSeleccionado.Email = Email;
                    UsuarioSeleccionado.Username = Usuername;
                    UsuarioSeleccionado.Contraseña = Contraseña;
                    UsuarioSeleccionado.Foto = ConvertirImagenAByte(Foto);
                    _usuarioService.UpdateUsuario(new Usuario(Nombre, Apellido1, Apellido2, Usuername, Email, Contraseña, false, ConvertirImagenAByte(Foto), DateTime.Now));
                    MessageBox.Show("Se ha modificado el ejercicio.");
                    LoadUsuarios();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("Los campos no pueden estar vacios.");
                }
            }
        }

        private void RemoveUsuario()
        {
            var confirmacion = MessageBox.Show("¿Desea eliminar el usuario?",
                   "Alerta", MessageBoxButton.OKCancel);
            if (confirmacion == MessageBoxResult.OK)
            {
                _usuarioService.RemoveUsuario(UsuarioSeleccionado.ID);
                LoadUsuarios();
                LimpiarFormulario();
            }
        }

        private byte[] ConvertirImagenAByte(BitmapImage image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(ms);
                return ms.ToArray();
            }
        }

        private BitmapImage ConvertirByteAImagen(byte[] imagenBytes)
        {
            if (imagenBytes == null || imagenBytes.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(imagenBytes))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private void searchUsuario()
        {
            if (!Value.IsNullOrEmpty())
            {
                Usuarios = new ObservableCollection<Usuario>(_usuarioService.obtenerUsuariosFiltro(Value));
            }
            else
            {
                Usuarios = _usuarioService.GetAllUsuarios();
            }
        }

        public void obtenerInformacion()
        {
            _usuarioService.ExportarDatosUsuarioPDF(UsuarioSeleccionado.ID);
        }

        public void obtenerInformacionFav()
        {
            _usuarioService.ExportarDatosUsuarioFavoritosPDF(UsuarioSeleccionado.ID);
        }

        private void LimpiarFormulario()
        {
            Nombre = null;
            Apellido1 = null;
            Apellido2 = null;
            Usuername = null;
            Email = null;
            Contraseña = null;
            Foto = null;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
