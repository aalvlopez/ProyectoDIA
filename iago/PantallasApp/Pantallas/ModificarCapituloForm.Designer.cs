using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System.ComponentModel;
namespace WindowsFormsApplication1
{
    partial class ModificarCapituloForm
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 231);
            this.panel1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(34, 47);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(207, 108);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = this.cap.Anotacion;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 171);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
			this.button2.Click+=delegate(object sender, EventArgs e) {
				this.Close ();
			};
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
			this.button1.Click+=delegate(object sender, EventArgs e) {
				this.cap.ModificarCapitulo(this.textBox1.Text, this.textBox2.Text);
				TreeViewCapPer.Actualizar(Program.Book,Program.libA.treeView1);
				this.Close ();
			};
			this.button3.Location = new System.Drawing.Point(300, 171);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Borrar escena";
            this.button3.UseVisualStyleBackColor = true;
			this.button3.Click+=delegate(object sender, EventArgs e) {

			};
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = this.cap.Titulo;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(261, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(173, 134);
            this.listBox1.TabIndex = 4;
			foreach(var i  in this.cap.Escenas){
				this.listBox1.Items.Add(i);
			}
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 250);
            this.Controls.Add(this.panel1);
            this.Name = "Form6";
            this.Text = "Form6";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
    }
}