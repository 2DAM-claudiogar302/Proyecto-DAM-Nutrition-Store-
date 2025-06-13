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
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        private UsuarioViewModel usuarioViewModel;
        public Registro()
        {
            InitializeComponent();
            usuarioViewModel = new UsuarioViewModel(this, new Service.UsuarioService(new EntityFramework.NutritionStoreContext()));
            this.DataContext = usuarioViewModel;
            usuarioViewModel.SolicitarResetPassword += () => contraseña.Password = string.Empty;
            usuarioViewModel.InicializarUsuarios();
        }

        private void contrasena(object sender, RoutedEventArgs e)
        {
            usuarioViewModel.Contraseña = ((PasswordBox)sender).Password;
        }
    }
}
