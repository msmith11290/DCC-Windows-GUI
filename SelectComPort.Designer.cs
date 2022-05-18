namespace Kats
{
    partial class SelectComPort
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCom1 = new System.Windows.Forms.RadioButton();
            this.rbCom7 = new System.Windows.Forms.RadioButton();
            this.rbCom6 = new System.Windows.Forms.RadioButton();
            this.rbCom5 = new System.Windows.Forms.RadioButton();
            this.rbCom4 = new System.Windows.Forms.RadioButton();
            this.rbCom3 = new System.Windows.Forms.RadioButton();
            this.rbCom2 = new System.Windows.Forms.RadioButton();
            this.locoAddressLbl = new System.Windows.Forms.Label();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.rbCom1);
            this.groupBox1.Controls.Add(this.rbCom7);
            this.groupBox1.Controls.Add(this.rbCom6);
            this.groupBox1.Controls.Add(this.rbCom5);
            this.groupBox1.Controls.Add(this.rbCom4);
            this.groupBox1.Controls.Add(this.rbCom3);
            this.groupBox1.Controls.Add(this.rbCom2);
            this.groupBox1.Location = new System.Drawing.Point(34, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 202);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Com Port";
            // 
            // rbCom1
            // 
            this.rbCom1.AutoSize = true;
            this.rbCom1.Location = new System.Drawing.Point(17, 26);
            this.rbCom1.Name = "rbCom1";
            this.rbCom1.Size = new System.Drawing.Size(60, 19);
            this.rbCom1.TabIndex = 7;
            this.rbCom1.Text = "Com 1";
            this.rbCom1.UseVisualStyleBackColor = true;
            this.rbCom1.CheckedChanged += new System.EventHandler(this.SelectCom_1);
            // 
            // rbCom7
            // 
            this.rbCom7.AutoSize = true;
            this.rbCom7.Location = new System.Drawing.Point(17, 172);
            this.rbCom7.Name = "rbCom7";
            this.rbCom7.Size = new System.Drawing.Size(60, 19);
            this.rbCom7.TabIndex = 6;
            this.rbCom7.Text = "Com 7";
            this.rbCom7.UseVisualStyleBackColor = true;
            this.rbCom7.Click += new System.EventHandler(this.SelectCom_7);
            // 
            // rbCom6
            // 
            this.rbCom6.AutoSize = true;
            this.rbCom6.Location = new System.Drawing.Point(17, 147);
            this.rbCom6.Name = "rbCom6";
            this.rbCom6.Size = new System.Drawing.Size(60, 19);
            this.rbCom6.TabIndex = 5;
            this.rbCom6.Text = "Com 6";
            this.rbCom6.UseVisualStyleBackColor = true;
            this.rbCom6.Click += new System.EventHandler(this.SelectCom_6);
            // 
            // rbCom5
            // 
            this.rbCom5.AutoSize = true;
            this.rbCom5.Location = new System.Drawing.Point(17, 122);
            this.rbCom5.Name = "rbCom5";
            this.rbCom5.Size = new System.Drawing.Size(60, 19);
            this.rbCom5.TabIndex = 4;
            this.rbCom5.Text = "Com 5";
            this.rbCom5.UseVisualStyleBackColor = true;
            this.rbCom5.Click += new System.EventHandler(this.SelectCom_5);
            // 
            // rbCom4
            // 
            this.rbCom4.AutoSize = true;
            this.rbCom4.Location = new System.Drawing.Point(17, 97);
            this.rbCom4.Name = "rbCom4";
            this.rbCom4.Size = new System.Drawing.Size(60, 19);
            this.rbCom4.TabIndex = 3;
            this.rbCom4.Text = "Com 4";
            this.rbCom4.UseVisualStyleBackColor = true;
            this.rbCom4.Click += new System.EventHandler(this.SelectCom_4);
            // 
            // rbCom3
            // 
            this.rbCom3.AutoSize = true;
            this.rbCom3.Location = new System.Drawing.Point(17, 72);
            this.rbCom3.Name = "rbCom3";
            this.rbCom3.Size = new System.Drawing.Size(60, 19);
            this.rbCom3.TabIndex = 2;
            this.rbCom3.Text = "Com 3";
            this.rbCom3.UseVisualStyleBackColor = true;
            this.rbCom3.Click += new System.EventHandler(this.SelectCom_3);
            // 
            // rbCom2
            // 
            this.rbCom2.AutoSize = true;
            this.rbCom2.Location = new System.Drawing.Point(17, 47);
            this.rbCom2.Name = "rbCom2";
            this.rbCom2.Size = new System.Drawing.Size(60, 19);
            this.rbCom2.TabIndex = 1;
            this.rbCom2.Text = "Com 2";
            this.rbCom2.UseVisualStyleBackColor = true;
            this.rbCom2.CheckedChanged += new System.EventHandler(this.SelectCom_2);
            // 
            // locoAddressLbl
            // 
            this.locoAddressLbl.AutoSize = true;
            this.locoAddressLbl.Location = new System.Drawing.Point(196, 36);
            this.locoAddressLbl.Name = "locoAddressLbl";
            this.locoAddressLbl.Size = new System.Drawing.Size(165, 15);
            this.locoAddressLbl.TabIndex = 4;
            this.locoAddressLbl.Text = "Enter the Locomotive Address";
            // 
            // DoneBtn
            // 
            this.DoneBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DoneBtn.Location = new System.Drawing.Point(227, 159);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(75, 43);
            this.DoneBtn.TabIndex = 14;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = false;
            this.DoneBtn.Click += new System.EventHandler(this.DoneComPort);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(237, 58);
            this.numericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(53, 23);
            this.numericUpDown.TabIndex = 15;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.LocoAddrChanged);
            // 
            // SelectComPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 272);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.locoAddressLbl);
            this.Controls.Add(this.groupBox1);
            this.Name = "SelectComPort";
            this.Text = "USB";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rbCom7;
        private RadioButton rbCom6;
        private RadioButton rbCom5;
        private RadioButton rbCom4;
        private RadioButton rbCom3;
        private RadioButton rbCom2;
        private RadioButton rbCom1;
        private Label locoAddressLbl;
        private Button DoneBtn;
        private NumericUpDown numericUpDown;
        private RadioButton rBtnDummy;
    }
}