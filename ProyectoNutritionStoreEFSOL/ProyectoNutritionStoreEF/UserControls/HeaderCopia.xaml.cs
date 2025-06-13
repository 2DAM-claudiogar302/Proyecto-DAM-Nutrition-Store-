

using ProyectoNutritionStoreEF.Views;
using ProyectoNutritionStoreEF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoNutritionStoreEF.UserControls
{
    /// <summary>
    /// Lógica de interacción para Header.xaml
    /// </summary>
    public partial class HeaderCopia : UserControl
    {
        private EjercicioViewModel ejercicioViewModel;
        private Window ventanaActual;

        public HeaderCopia()
        {
            InitializeComponent();
        }
    }
}
