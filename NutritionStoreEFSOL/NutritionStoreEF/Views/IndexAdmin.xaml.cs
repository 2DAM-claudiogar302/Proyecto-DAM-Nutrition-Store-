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
    /// Lógica de interacción para IndexAdmin.xaml
    /// </summary>
    public partial class IndexAdmin : Window
    {
        private SuplementoViewModel suplementoViewModel;
        public IndexAdmin()
        {
            InitializeComponent();
            suplementoViewModel = new SuplementoViewModel();
            this.DataContext = suplementoViewModel;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GestionSuplementosAdmin ges = new GestionSuplementosAdmin();
            this.Close();
            ges.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Se muestra la vista del mapa.", "Mapa.");
            Map mapa = new Map();   
            this.Close();
            mapa.Show();
        }
    }
}
