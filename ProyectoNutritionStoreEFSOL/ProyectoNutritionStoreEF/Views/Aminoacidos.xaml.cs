
using ProyectoNutritionStoreEF.EntityFramework;
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
    /// Lógica de interacción para Aminoacidos.xaml
    /// </summary>
    public partial class Aminoacidos : Window
    {
        private SuplementoViewModel suplementoViewModel;
        public Aminoacidos()
        {
            InitializeComponent();
            var suplementoService = new SuplementoService(new NutritionStoreContext());
            suplementoViewModel = new SuplementoViewModel(this, suplementoService);
            this.DataContext = suplementoViewModel;
        }
    }
}
