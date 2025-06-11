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
using ProyectoNutritionStoreEF.ViewModels;
using ProyectoNutritionStoreEF.Service;

namespace ProyectoNutritionStoreEF.Views
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private LoginViewModel loginViewModel;
        public Login()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel(this, new EntityFramework.NutritionStoreContext());
            this.DataContext = loginViewModel;

        }

        

        private void PB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            loginViewModel.Password = ((PasswordBox)sender).Password;
        }

        private void recuperarPassword(object sender, RoutedEventArgs e)
        {
            RestablecerContraseña vista = new RestablecerContraseña();
            this.Close();
            vista.Show();
        }
    }
}
