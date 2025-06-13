using ProyectoNutritionStoreEF.Service;
using ProyectoNutritionStoreEF.Views;
using ProyectoNutritionStoreEF.EntityFramework;
using ProyectoNutritionStoreEF.Models;
using System;
using System.ComponentModel;
using System.Windows;

namespace ProyectoNutritionStoreEF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly LoginService loginService;
        private readonly Window ventanaActual;
        //Evento para vaciar el campo de contraseña en la vista
        public event Action SolicitarResetPassword;

        #region Comandos
        public RelayCommand LoginCommand { get; }
        public RelayCommand ReestablecerContrasena { get; }
        public RelayCommand CancelCommand { get; }
        public RelayCommand VolverCommand { get; }
        #endregion

        #region Propiedades
        private string _username;
        private string _password;
        private string _errorMessage;

        public List<string> PreguntasSeguridad { get; } = new List<string>
            {
                "¿Ciudad de nacimiento?",
                "¿Centro de estudios?"
            };

        private string _preguntaSeleccionada;
        public string PreguntaSeleccionada
        {
            get => _preguntaSeleccionada;
            set
            {
                _preguntaSeleccionada = value;
                OnPropertyChanged(nameof(PreguntaSeleccionada));
            }
        }

        private string _respuestaIngresada;
        public string RespuestaIngresada
        {
            get => _respuestaIngresada;
            set
            {
                _respuestaIngresada = value;
                OnPropertyChanged(nameof(RespuestaIngresada));
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            private get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _nuevaContrasena;
        public string NuevaContrasena
        {
            get => _nuevaContrasena;
            set
            {
                _nuevaContrasena = value;
                OnPropertyChanged(nameof(NuevaContrasena));
            }
        }
        private string _confirmarContrasena;
        public string ConfirmarContrasena
        {
            get => _confirmarContrasena;
            set
            {
                _confirmarContrasena = value;
                OnPropertyChanged(nameof(ConfirmarContrasena));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        #endregion

        #region Métodos
        public LoginViewModel(Window ventana, NutritionStoreContext context)
        {
            ventanaActual = ventana;
            loginService = new LoginService(context);

            LoginCommand = new RelayCommand(_ => GoToLogin(), _ => CheckLogin());
            ReestablecerContrasena = new RelayCommand(_ => ReestablecerPass(), _ => true);
            CancelCommand = new RelayCommand(_ => LimpiarFormulario(), _ => true);
            VolverCommand = new RelayCommand(_ => EjecutarVolver(), _ => true);
        }

        private void LimpiarFormulario()
        {
            Username = null;
            PreguntaSeleccionada = null;
            RespuestaIngresada = null;
            ConfirmarContrasena = null;
            NuevaContrasena = null;
            SolicitarResetPassword?.Invoke();
        }

        private void EjecutarVolver()
        {
            new Views.Login().Show();
            this.ventanaActual.Close();
            
        }

        private void ReestablecerPass()
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(PreguntaSeleccionada) ||
                string.IsNullOrWhiteSpace(RespuestaIngresada) ||
                string.IsNullOrWhiteSpace(NuevaContrasena) ||
                string.IsNullOrWhiteSpace(ConfirmarContrasena))
            {
                MessageBox.Show("Completa todos los campos antes de continuar.");
                return;
            }

            if (NuevaContrasena != ConfirmarContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            var usuario = loginService.ObtenerUsuarioPorUsername(Username);
            if (usuario == null)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            if (usuario.PreguntaSeguridad != PreguntaSeleccionada ||
                !usuario.RespuestaSeguridad.Equals(RespuestaIngresada, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La pregunta o la respuesta de seguridad no coinciden.");
                return;
            }

            bool result = loginService.CambiarContrasena(Username, NuevaContrasena);
            if (result)
            {
                MessageBox.Show("Contraseña actualizada correctamente.");
                new Login().Show();
                ventanaActual.Close();
            }
            else
            {
                MessageBox.Show("No se pudo cambiar la contraseña.");
            }
        }



        private void GoToLogin()
        {
            Usuario usuario = loginService.GetUsuarioLogin(Username, Password);

            if (usuario != null)
            {
                ventanaActual.Hide();
                if (usuario.Administrador)
                {
                    new Views.IndexAdmin().Show();
                }
                else
                {
                    try
                    {
                        new Views.Index().Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al abrir la ventana principal: {ex.Message}");
                    }
                }
            }
            else
            {
                ErrorMessage = "Usuario o contraseña incorrectos.";
            }
        }

        private bool CheckLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }
        #endregion

        // Notificación de cambios en la vista
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
