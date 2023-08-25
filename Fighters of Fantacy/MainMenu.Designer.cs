using DevExpress.XtraEditors;

namespace Fighters_of_Fantacy
{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(228, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fighters of Fantacy";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.simpleButton5);
            this.groupBox1.Controls.Add(this.simpleButton4);
            this.groupBox1.Controls.Add(this.simpleButton3);
            this.groupBox1.Controls.Add(this.simpleButton2);
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Location = new System.Drawing.Point(271, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 269);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.AutoSize = true;
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton1.Location = new System.Drawing.Point(3, 16);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.simpleButton1.Size = new System.Drawing.Size(194, 50);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "New Fighter";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.AutoSize = true;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton2.Location = new System.Drawing.Point(3, 66);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.simpleButton2.Size = new System.Drawing.Size(194, 50);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Instant Fight";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.AutoSize = true;
            this.simpleButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton3.Location = new System.Drawing.Point(3, 116);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.simpleButton3.Size = new System.Drawing.Size(194, 50);
            this.simpleButton3.TabIndex = 2;
            this.simpleButton3.Text = "Delete Fighter";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.AutoSize = true;
            this.simpleButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton4.Location = new System.Drawing.Point(3, 166);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.simpleButton4.Size = new System.Drawing.Size(194, 50);
            this.simpleButton4.TabIndex = 3;
            this.simpleButton4.Text = "Help";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.simpleButton5.Appearance.Options.UseFont = true;
            this.simpleButton5.AutoSize = true;
            this.simpleButton5.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton5.Location = new System.Drawing.Point(3, 216);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.simpleButton5.Size = new System.Drawing.Size(194, 50);
            this.simpleButton5.TabIndex = 4;
            this.simpleButton5.Text = "Exit";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private SimpleButton simpleButton5;
        private SimpleButton simpleButton4;
        private SimpleButton simpleButton3;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton1;
    }
}

