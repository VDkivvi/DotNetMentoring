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

namespace HelloWpf
{
    /// <summary>
    /// Interaction logic for GreetingWindow.xaml
    /// </summary>
    public partial class GreetingWindow : Window
    {
        string _userName;

        public GreetingWindow(string UserName)
        {
            InitializeComponent();
            GreetingText.Text = UserName;
            _userName = UserName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
