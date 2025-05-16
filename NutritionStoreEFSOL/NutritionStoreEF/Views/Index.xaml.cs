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
    
    public partial class Index : Window
    {
        private SuplementoViewModel suplementoViewModel;
        public Index()
        {
            InitializeComponent();
            suplementoViewModel = new SuplementoViewModel();
            this.DataContext = suplementoViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Map mapa = new Map();
            this.Close();
            mapa.Show();
        }
    }
}
