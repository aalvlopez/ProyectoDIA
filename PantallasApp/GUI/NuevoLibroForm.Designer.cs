using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System.ComponentModel;

namespace DIAScribe
{
    partial class NuevoLibroForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(25, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 156);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Título";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += delegate(object sender, System.EventArgs e) {				
				Core.Book= new Libro(textBox1.Text);
				TreeViewCapPer.Actualizar(Core.Book,Core.libA.treeView1);
				Core.libA.Refresh();
				this.textBox1.Dispose ();
				this.Close ();
				Core.libA.button1.Enabled=true;
				Core.libA.button2.Enabled=true;
				Core.libA.button3.Enabled=true;
				Core.libA.saveAsToolStripMenu.Enabled=true;
				Core.libA.referenciasToolStripMenuItem.Enabled=true;
			};
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += delegate(object sender, EventArgs e) {
				MessageBox.Show("Cancelado... ");
				this.Close();
			};
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 207);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}