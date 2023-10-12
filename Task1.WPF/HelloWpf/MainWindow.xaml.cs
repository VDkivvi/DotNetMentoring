using System.Windows;
using System.Windows.Controls;
using MessageFormer;

namespace HelloWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IMessage message = new StringMessage();
        string userName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            userName = message.FormMessage(UserNameTextBox.Text);
        }


        private void Button_Click_ShowNewWindow(object sender, RoutedEventArgs e)
        {
            if (UserNameTextBox.Text.Length > 0)
            {
                GreetingWindow greetingWind = new GreetingWindow(userName);
                greetingWind.Show();
            }
        }

        private void Button_Click_CloseApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
