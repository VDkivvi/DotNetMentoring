namespace WindowsFormsHello
{
    partial class MainForm
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
            this.submitName = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.greetingLabel = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // submitName
            // 
            this.submitName.Location = new System.Drawing.Point(400, 49);
            this.submitName.Name = "submitName";
            this.submitName.Size = new System.Drawing.Size(183, 35);
            this.submitName.TabIndex = 0;
            this.submitName.Text = "Submit Greeting";
            this.submitName.UseVisualStyleBackColor = true;
            this.submitName.Click += new System.EventHandler(this.submitName_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(50, 49);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(303, 22);
            this.userName.TabIndex = 1;
            // 
            // greetingLabel
            // 
            this.greetingLabel.AutoSize = true;
            this.greetingLabel.Location = new System.Drawing.Point(47, 113);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(0, 16);
            this.greetingLabel.TabIndex = 3;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(410, 124);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(67, 33);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 221);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.greetingLabel);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.submitName);
            this.Name = "MainForm";
            this.Text = "Hello Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitName;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label greetingLabel;
        private System.Windows.Forms.Button exitBtn;
    }
}

