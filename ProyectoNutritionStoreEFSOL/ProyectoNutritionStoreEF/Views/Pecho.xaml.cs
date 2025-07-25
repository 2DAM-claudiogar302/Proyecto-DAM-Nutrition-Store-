﻿using ProyectoNutritionStoreEF.Service;
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
    /// Lógica de interacción para Pecho.xaml
    /// </summary>
    public partial class Pecho : Window
    {
        EjercicioViewModel ejercicioViewModel;
        public Pecho()
        {
            InitializeComponent();
            var ejercicioService = new EjercicioService(new EntityFramework.NutritionStoreContext());
            ejercicioViewModel = new EjercicioViewModel(this, ejercicioService);
            this.DataContext = ejercicioViewModel;
        }
    }
}
