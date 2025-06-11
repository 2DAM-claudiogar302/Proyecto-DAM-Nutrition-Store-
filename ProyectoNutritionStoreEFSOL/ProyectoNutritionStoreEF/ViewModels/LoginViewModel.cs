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
        private readonly Window _windowLogin;

        #region Comandos
        public RelayCommand LoginCommand { get; }
        public RelayCommand ReestablecerContrasena { get; }
        public RelayCommand CancelCommand { get; }
        #endregion

        #region Propiedades
        private string _username;
        private string _password;
        private string _errorMessage;
        private string _emailPass;
        private string _fechaNacimiento;

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
        public LoginViewModel(Window ventanaLogin, NutritionStoreContext context)
        {
            _windowLogin = ventanaLogin;
            loginService = new LoginService(context);

            LoginCommand = new RelayCommand(_ => GoToLogin(), _ => CheckLogin());
            ReestablecerContrasena = new RelayCommand(_ => ReestablecerPass(), _ => true);
            CancelCommand = new RelayCommand(_ => LimpiarFormulario(), _ => true);
        }

        private void LimpiarFormulario()
        {
            Username = null;
            ConfirmarContrasena = null;
            NuevaContrasena = null;
        }

        private void ReestablecerPass()
        {
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(NuevaContrasena) && !string.IsNullOrWhiteSpace(ConfirmarContrasena))
            {
                if (NuevaContrasena == ConfirmarContrasena)
                {
                    bool result = loginService.CambiarContrasena(Username, NuevaContrasena);
                    MessageBox.Show(result ? "Contraseña actualizada correctamente." : "Usuario no encontrado. Por favor, verifica la información ingresada.");
                    Login login = new Login();
                    login.Show();
                    this._windowLogin.Close();
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden. Inténtalo nuevamente.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, introduce tu usuario y la nueva contraseña.");
            }
        }


        private void GoToLogin()
        {
            Usuario usuario = loginService.GetUsuarioLogin(Username, Password);

            if (usuario != null)
            {
                _windowLogin.Hide();
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
