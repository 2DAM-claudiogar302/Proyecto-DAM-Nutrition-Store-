using System;
using NutritionStoreEF.Views;
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
using NutritionStoreEF.ViewModels;

namespace NutritionStoreEF.Views
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
            loginViewModel = new LoginViewModel(this);
            this.DataContext = loginViewModel;

        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = user.Text;
            string passwordText = password.Password;

    
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwordText))
            {
                MessageBox.Show("Por favor, rellene ambos campos: Usuario y Contraseña.", "Campos vacíos");
                return;
            }

            
            if (username.Equals("user") && passwordText.Equals("user"))
            {
                Index index = new Index();
                index.Show();
                this.Close();
            }
            else if (username.Equals("admin") && passwordText.Equals("admin"))
            {
                IndexAdmin indexAdmin = new IndexAdmin();
                indexAdmin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Intente de nuevo.", "Error de autenticación");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Index index = new Index();
            index.Show();
            this.Close();
        }*/

        private void PB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            loginViewModel.Password = ((PasswordBox)sender).Password;
        }
    }
}
