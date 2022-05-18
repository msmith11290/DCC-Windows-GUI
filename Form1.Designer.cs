namespace Kats
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Logo = new System.Windows.Forms.Label();
            this.Logo_Definition = new System.Windows.Forms.Label();
            this.SplashScreenNextPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Logo.AutoSize = true;
            this.Logo.Font = new System.Drawing.Font("Calibri", 500F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Logo.Location = new System.Drawing.Point(-43, -23);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(1649, 814);
            this.Logo.TabIndex = 0;
            this.Logo.Text = "KATS";
            this.Logo.Click += new System.EventHandler(this.Logo_Click);
            // 
            // Logo_Definition
            // 
            this.Logo_Definition.AutoSize = true;
            this.Logo_Definition.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Logo_Definition.Location = new System.Drawing.Point(598, 767);
            this.Logo_Definition.Name = "Logo_Definition";
            this.Logo_Definition.Size = new System.Drawing.Size(434, 59);
            this.Logo_Definition.TabIndex = 1;
            this.Logo_Definition.Text = "Kick Ass Train Station";
            // 
            // SplashScreenNextPage
            // 
            this.SplashScreenNextPage.Location = new System.Drawing.Point(700, 843);
            this.SplashScreenNextPage.Name = "SplashScreenNextPage";
            this.SplashScreenNextPage.Size = new System.Drawing.Size(223, 23);
            this.SplashScreenNextPage.TabIndex = 0;
            this.SplashScreenNextPage.Text = "Lets go Brandon !";
            this.SplashScreenNextPage.Click += new System.EventHandler(this.ClearSplashScreen);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1663, 910);
            this.Controls.Add(this.SplashScreenNextPage);
            this.Controls.Add(this.Logo_Definition);
            this.Controls.Add(this.Logo);
            this.Name = "Form1";
            this.Text = "KATS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Logo;
        private Label Logo_Definition;
        private Button SplashScreenNextPage;
    }
}