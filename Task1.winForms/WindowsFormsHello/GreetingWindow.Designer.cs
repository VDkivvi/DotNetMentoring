namespace WindowsFormsHello
{
    partial class GreetingWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.greetingNewWindow = new System.Windows.Forms.Label();
            this.exitForm2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // greetingNewWindow
            // 
            this.greetingNewWindow.AutoSize = true;
            this.greetingNewWindow.Location = new System.Drawing.Point(104, 15);
            this.greetingNewWindow.Name = "greetingNewWindow";
            this.greetingNewWindow.Size = new System.Drawing.Size(0, 20);
            this.greetingNewWindow.TabIndex = 0;
            // 
            // exitForm2
            // 
            this.exitForm2.Location = new System.Drawing.Point(276, 149);
            this.exitForm2.Name = "exitForm2";
            this.exitForm2.Size = new System.Drawing.Size(285, 47);
            this.exitForm2.TabIndex = 1;
            this.exitForm2.Text = "Exit";
            this.exitForm2.UseVisualStyleBackColor = true;
            this.exitForm2.Click += new System.EventHandler(this.exitForm2_Click);
            // 
            // GreetingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 234);
            this.Controls.Add(this.exitForm2);
            this.Controls.Add(this.greetingNewWindow);
            this.Name = "GreetingWindow";
            this.Text = "GreetingWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label greetingNewWindow;
        private System.Windows.Forms.Button exitForm2;
    }
}