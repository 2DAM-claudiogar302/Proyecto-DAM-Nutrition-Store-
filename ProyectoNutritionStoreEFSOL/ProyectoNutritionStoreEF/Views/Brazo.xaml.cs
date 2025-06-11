
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
    /// Lógica de interacción para Brazo.xaml
    /// </summary>
    public partial class Brazo : Window
    {
        EjercicioViewModel ejercicioViewModel;
        public Brazo()
        {
            InitializeComponent();
            var ejercicioService = new EjercicioService(new NutritionStoreContext());
            ejercicioViewModel = new EjercicioViewModel(this, ejercicioService);
            this.DataContext = ejercicioViewModel;
        }
    }
}
