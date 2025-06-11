using ProyectoNutritionStoreEF.ViewModels;
using ProyectoNutritionStoreEF.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoNutritionStoreEF.UserControls
{
    /// <summary>
    /// Lógica de interacción para Header.xaml
    /// </summary>
    public partial class HeaderAdmin : UserControl
    {
        private EjercicioViewModel ejercicioViewModel;
        private Window ventanaActual;

        public HeaderAdmin()
        {
            InitializeComponent();
            this.Loaded += HeaderAdmin_Loaded;
            this.DataContext = ejercicioViewModel;
        }

        private void HeaderAdmin_Loaded(object sender, RoutedEventArgs e)
        {
            ventanaActual = Window.GetWindow(this);

            if (ventanaActual != null)
            {
                ejercicioViewModel = new EjercicioViewModel(ventanaActual, new Service.EjercicioService(new EntityFramework.NutritionStoreContext()));
                this.DataContext = ejercicioViewModel;
            }
            else
            {
                MessageBox.Show("No se ha encontrado una ventana asociada.");
            }
        }

        private void cerrarSesion(object sender, RoutedEventArgs e)
        {
            Login ventanaLogin = new Login();
            this.ventanaActual.Close();
            ventanaLogin.ShowDialog();
        }

        private void gestionUser(object sender, RoutedEventArgs e)
        {
            this.ventanaActual.Close();
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            gestionUsuarios.ShowDialog();
        }
    }
}
