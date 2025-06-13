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
    /// Lógica de interacción para GestionUsuarios.xaml
    /// </summary>
    public partial class GestionUsuarios : Window
    {
        private UsuarioViewModel usuarioViewModel;
        public GestionUsuarios()
        {
            var usuarioService = new UsuarioService(new EntityFramework.NutritionStoreContext());
            InitializeComponent();
            usuarioViewModel = new UsuarioViewModel(this, usuarioService);
            this.DataContext = usuarioViewModel;
            usuarioViewModel.SolicitarResetPassword += () => password.Password = string.Empty;
        }

        private void contraseña(object sender, RoutedEventArgs e)
        {
            usuarioViewModel.Contraseña = ((PasswordBox)sender).Password;
        }

    }
}
