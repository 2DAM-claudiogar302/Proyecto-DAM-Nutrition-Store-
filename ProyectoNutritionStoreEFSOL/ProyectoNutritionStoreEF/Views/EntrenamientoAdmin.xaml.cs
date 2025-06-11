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
    /// Lógica de interacción para Entrenamiento.xaml
    /// </summary>
    public partial class EntrenamientoAdmin : Window
    {
        private EjercicioViewModel ejercicioViewModel;
        public EntrenamientoAdmin()
        {
            InitializeComponent();
            var ejercicioService = new EjercicioService(new EntityFramework.NutritionStoreContext());
            ejercicioViewModel = new EjercicioViewModel(this, ejercicioService);
            this.DataContext = ejercicioViewModel;
        }
    }
}
