using System;
using System.Windows;

namespace App
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            DataContext = new RegistrationWindowViewModel();
        }
    }
}
