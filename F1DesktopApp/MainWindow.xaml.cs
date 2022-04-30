﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
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
using System.Net.Sockets;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;


namespace F1DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _port;
        private readonly string ipAddress;
        private string str_x = "test";
        private string str_y = "test";
        private double Value;

        public MainWindow()
        {
            InitializeComponent();

            Value = 160;
            Angular_Gauge1.Value = Value;
            //UdpClient udpClient = new UdpClient();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ChangeValueOnClick(object sender, RoutedEventArgs e)
        {
            Value = new Random().Next(50, 250);
            Angular_Gauge1.Value = Value;
            lbl_test1.Content = Value.ToString();
        }

    }

}
