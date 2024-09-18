﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Complex_Interface_WPF
{
    /// <summary>
    /// Логика взаимодействия для ExpPolarDeg.xaml
    /// </summary>
    public partial class ExpPolarDeg : Page
    {
        public ExpPolarDeg()
        {
            InitializeComponent();
        }

        private void R_Set_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarDegFrame.Navigate(new RealInput_Exponentiation());
        }

        private void C_Set_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarDegFrame.Navigate(new ComplexInput_Exponentiation());
        }

        private void C_Set_PolarDeg_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarDegFrame.Navigate(new ComplexPolarDegInput_Exponentiation());
        }

        private void C_Set_PolarRad_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarDegFrame.Navigate(new ComplexPolarRadInput_Exponentiation());
        }
    }
}
