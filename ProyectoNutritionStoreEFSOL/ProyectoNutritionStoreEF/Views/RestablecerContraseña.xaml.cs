using ProyectoNutritionStoreEF.Service;
using ProyectoNutritionStoreEF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoNutritionStoreEF.Views
{
    /// <summary>
    /// Lógica de interacción para RestablecerContraseña.xaml
    /// </summary>
    public partial class RestablecerContraseña : Window
    {
        private LoginViewModel loginViewModel;
        public RestablecerContraseña()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel(this, new EntityFramework.NutritionStoreContext());
            this.DataContext = loginViewModel;
            //Funcion anónima que no recibe parámetros y llama al evento que limpia las contraseñas:
            loginViewModel.SolicitarResetPassword += () =>
            {
                nuevaContraseña.Password = string.Empty;
                confirmarContraseña.Password = string.Empty;
            };


        }

        private void NuevaContrasena_Changed(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.NuevaContrasena = ((PasswordBox)sender).Password;
            }
        }

        private void ConfirmarContrasena_Changed(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.ConfirmarContrasena = ((PasswordBox)sender).Password;
            }
        }

    }
}
