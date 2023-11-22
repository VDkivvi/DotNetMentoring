using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHello
{
    public partial class GreetingWindow : Form
    {
        public GreetingWindow(string message)
        {
            InitializeComponent();
            greetingNewWindow.Text = message;
        }

        private void exitForm2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
