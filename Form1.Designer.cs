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
            this.Logo_Definition = new System.Windows.Forms.Label();
            this.SplashScreenNextPage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Logo_Definition
            // 
            this.Logo_Definition.AutoSize = true;
            this.Logo_Definition.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Logo_Definition.Location = new System.Drawing.Point(442, 398);
            this.Logo_Definition.Name = "Logo_Definition";
            this.Logo_Definition.Size = new System.Drawing.Size(434, 59);
            this.Logo_Definition.TabIndex = 1;
            this.Logo_Definition.Text = "Kick Ass Train Station";
            this.Logo_Definition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashScreenNextPage
            // 
            this.SplashScreenNextPage.Location = new System.Drawing.Point(530, 509);
            this.SplashScreenNextPage.Name = "SplashScreenNextPage";
            this.SplashScreenNextPage.Size = new System.Drawing.Size(223, 23);
            this.SplashScreenNextPage.TabIndex = 0;
            this.SplashScreenNextPage.Text = "Lets go Brandon !";
            this.SplashScreenNextPage.Click += new System.EventHandler(this.ClearSplashScreen);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 200.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(298, 26);
            this.label1.MaximumSize = new System.Drawing.Size(1000, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(734, 355);
            this.label1.TabIndex = 2;
            this.label1.Text = "KATS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1663, 910);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SplashScreenNextPage);
            this.Controls.Add(this.Logo_Definition);
            this.Name = "Form1";
            this.Text = "KATS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label Logo_Definition;
        private Button SplashScreenNextPage;
        private Label label1;
    }
}