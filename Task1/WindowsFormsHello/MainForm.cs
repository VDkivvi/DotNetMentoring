using System;
using System.Windows.Forms;
using SayHello;

namespace WindowsFormsHello
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void submitName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userName.Text))
            {
                greetingLabel.Text = "Enter the userName and click again";
            }
            else
            {
                greetingLabel.Text = Say.GetGreetings(userName.Text);
                GreetingWindow f2 = new GreetingWindow(Say.GetGreetings(userName.Text));
                f2.ShowDialog();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
