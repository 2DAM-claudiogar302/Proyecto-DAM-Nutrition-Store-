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
    /// Lógica de interacción para IndexAdmin.xaml
    /// </summary>
    public partial class IndexAdmin : Window
    {
        private SuplementoViewModel suplementoViewModel;
        public IndexAdmin()
        {
            InitializeComponent();
            var suplementoService = new SuplementoService(new EntityFramework.NutritionStoreContext());
            suplementoViewModel = new SuplementoViewModel(this, suplementoService);
            this.DataContext = suplementoViewModel;
        }

        private void Gestion(object sender, RoutedEventArgs e)
        {
            GestionSuplementosAdmin ges = new GestionSuplementosAdmin();
            this.Close();
            ges.Show();
        }

       
    }
}
