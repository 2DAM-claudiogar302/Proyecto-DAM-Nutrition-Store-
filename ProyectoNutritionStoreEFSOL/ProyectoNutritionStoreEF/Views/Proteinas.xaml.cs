
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
    /// Lógica de interacción para Proteinas.xaml
    /// </summary>
    public partial class Proteinas : Window
    {
        private SuplementoViewModel suplementoViewModel;
        public Proteinas()
        {
            InitializeComponent();
            var suplementoService = new SuplementoService(new EntityFramework.NutritionStoreContext());  
            suplementoViewModel = new SuplementoViewModel(this, suplementoService);
            this.DataContext = suplementoViewModel;
        }
    }
}
