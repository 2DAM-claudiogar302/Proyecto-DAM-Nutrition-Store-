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
    /// Lógica de interacción para Entrenamiento.xaml
    /// </summary>
    public partial class Entrenamiento : Window
    {
        private EjercicioViewModel ejercicioViewModel;
        public Entrenamiento()
        {
            InitializeComponent();
            ejercicioViewModel = new EjercicioViewModel();
            this.DataContext = ejercicioViewModel;
        }
    }
}
