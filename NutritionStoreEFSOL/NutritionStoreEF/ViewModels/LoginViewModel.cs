using NutritionStoreEF.Models;
using NutritionStoreEF.Service;
using NutritionStoreEF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NutritionStoreEF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        //Service:
        private readonly LoginService loginService;

        private readonly Login _windowLogin;

        #region Comandos
        public RelayCommand LoginCommand { get; }

        public RelayCommand adminView { get; }
        public RelayCommand userView { get; }
        #endregion

        #region Propiedades
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            private get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        #endregion

        #region Metodos
        public LoginViewModel(Login ventanaLogin)
        {
            _windowLogin = ventanaLogin;
            loginService = new Service.LoginService();

            LoginCommand = new RelayCommand(
                  _ => GoToLogin(),
                  _ => checkLogin()
            );
        }

        private void GoToLogin()
        {
            Usuario usuario = loginService.GetUsuarioLogin(Username, Password);

            if (usuario != null)
            {
                if (usuario.Administrador == true)
                {
                    Views.IndexAdmin vistaAdmin = new Views.IndexAdmin();
                    // Cerrar la ventana de login
                    _windowLogin.Close();
                    vistaAdmin.Show();


                }
                else if (usuario.Administrador == false)
                {
                    Views.Index vistaUser = new Views.Index();
                    // Cerrar la ventana de login
                    _windowLogin.Close();

                    vistaUser.Show();

                }
                else
                {
                    MessageBox.Show("Puesto no identificado!");

                }

            }
            else
            {
                ErrorMessage = "Usuario o contraseña incorrectos.";
            }
        }

        private bool checkLogin()
        {
            bool check = false;
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            {
                check = true;
            }
            return check;
        }



        #endregion

        //Para las notificaciones de cambio en la vista.
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
