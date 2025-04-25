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

namespace NutritionStorePruebaEF.Views
{
    /// <summary>
    /// Lógica de interacción para IndexAdmin.xaml
    /// </summary>
    public partial class IndexAdmin : Window
    {
        public IndexAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Se muestra la vista para añadir.", "Añadir.");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Se muestra la vista para editar.", "Editar.");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Se muestra la vista para eliminar.", "Eliminar.");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Se muestra la vista del mapa.", "Mapa.");
        }
    }
}
