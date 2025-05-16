using NutritionStoreEF.ViewModels;
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

namespace NutritionStoreEF.Views
{
    /// <summary>
    /// Lógica de interacción para AddAdmin.xaml
    /// </summary>
    public partial class GestionSuplementosAdmin : Window
    {
        private SuplementoViewModel suplementoViewModel;
        public GestionSuplementosAdmin()
        {
            InitializeComponent();
            suplementoViewModel = new SuplementoViewModel();
            this.DataContext = suplementoViewModel;
        }

        private void listaUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
