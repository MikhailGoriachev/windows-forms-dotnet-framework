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
using System.Windows.Shapes;

namespace WpfFigure.Views
{
    /// <summary>
    /// Interaction logic for ListFiguresWindow.xaml
    /// </summary>
    public partial class ListFiguresWindow : Window
    {
        public ListFiguresWindow()
        {
            InitializeComponent();
        }


        // закрытие окна
        private void Exit_Click(object sender, RoutedEventArgs e) => Close();
    }
}
