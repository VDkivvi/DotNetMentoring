using System;
using System.Windows.Forms;
using System.ComponentModel;
public class HelloWorld : Form
{
    TextBox t;


    public HelloWorld()
    {
        t = new TextBox();
        Button b = new Button();
        b.Click += new EventHandler(Button_Click);
        Controls.Add(b);
    }

    private void Button_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"Hello you! {t.Text}");
    }
}