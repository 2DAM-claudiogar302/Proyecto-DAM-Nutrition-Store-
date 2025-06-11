

using ProyectoNutritionStoreEF.Views;
using ProyectoNutritionStoreEF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoNutritionStoreEF.UserControls
{
    /// <summary>
    /// Lógica de interacción para Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        private EjercicioViewModel ejercicioViewModel;
        private Window ventanaActual;

        public Header()
        {
            InitializeComponent();
            ejercicioViewModel = new EjercicioViewModel(null, new Service.EjercicioService(new EntityFramework.NutritionStoreContext()));
            this.Loaded += Header_Loaded;
            this.DataContext = ejercicioViewModel;
        }

        private void Header_Loaded(object sender, RoutedEventArgs e)
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
    }
}
