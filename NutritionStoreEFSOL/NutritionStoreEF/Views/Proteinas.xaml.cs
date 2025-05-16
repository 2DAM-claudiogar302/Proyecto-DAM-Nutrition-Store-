using NutritionStoreEF.Service;
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
    /// Lógica de interacción para Proteinas.xaml
    /// </summary>
    public partial class Proteinas : Window
    {
        private SuplementoService suplementoService;
        public Proteinas()
        {
            InitializeComponent();
            suplementoService = new SuplementoService();
            this.DataContext = suplementoService;
        }
    }
}
