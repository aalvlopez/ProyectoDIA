using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System.ComponentModel;
namespace WindowsFormsApplication1
{
    public class AnadirModificarPersonajesForm : Form
    {
        private Actor actor;
        public String texto;

        public AnadirModificarPersonajesForm(Actor actor)
        {
            this.actor = actor;
            this.texto = actor.Descripcion;
            InitializeComponent();
            this.Show();

        }

        public AnadirModificarPersonajesForm()
        {
            this.actor = null;
            this.texto = "";
            InitializeComponent();
            this.Show();
        }




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
            BuildDialogBorraActor();

            MainMenu Actions = new MainMenu();

            
            MenuItem opEliminar = new MenuItem("&Eliminar");
            opEliminar.Shortcut = Shortcut.CtrlR;
            opEliminar.Click += (sender, e) => BorraActor();

            MenuItem mEditar = new MenuItem("&Editar");
            MenuItem opEditar = new MenuItem("&Editar descripcion");
            opEditar.Shortcut = Shortcut.CtrlE;
            opEditar.Click += delegate(object sender, EventArgs e)
            {
                Program.procesador = new ProcesadorTextos();
                Program.procesador.GuardaPersonaje = "personaje";
                Program.procesador.setTexto(this.texto);


            };

           

           
            mEditar.MenuItems.Add(opEliminar);
            mEditar.MenuItems.Add(opEditar);

            Actions.MenuItems.Add(mEditar);
            Menu = Actions;	


            this.panel1 = new System.Windows.Forms.Panel();
			this.treeView1=new TreeView();
            this.treeView1 = TreeViewCapPer.Actualizar(Program.Book, new TreeView());
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 297);
            this.panel1.TabIndex = 1;
            // 
            // treeView1
            // 

			this.treeView1.Location = new System.Drawing.Point(6, 10);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(171, 395);
			this.treeView1.TabIndex = 0;

            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(192, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 266);
            this.panel2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 2;
            if (this.actor == null){
                this.textBox1.Text = "Nombre";
            }
            else{
                this.textBox1.Text = this.actor.Nombre;
            }

          
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(12, 73);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(151, 21);
            this.comboBox2.TabIndex = 4;
            if (this.actor == null)
            {
                this.comboBox2.Text = "Capitulo";
            }
            else
            {
                this.comboBox2.Text = this.actor.Cap;
              
            }
            foreach (var capitulo in Program.Book.Capitulos)
            {
                this.comboBox2.Items.Add(capitulo);
            }

            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(221, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 21);
            this.comboBox1.TabIndex = 3;
            if (this.actor == null)
            {
                this.comboBox1.Text = "Escena";
            }
            else
            {
                this.comboBox1.Text = this.actor.Esc;
            }
            this.comboBox2.TextChanged += delegate(object sender, EventArgs e)
            {
                if (((Capitulo)this.comboBox2.SelectedItem).Escenas.Count > 0)
                {
                    this.rellenaComboEscena();
                }
            };
           
            
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += delegate(object sender, EventArgs e)
            {
                this.Close();
            };
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += delegate(object sender, EventArgs e)
            {
                string nombre = "";
                string cap = "";
                string esc = "";
                
            
                if (this.actor == null)
                {
                    if (this.comboBox2.SelectedItem == null)
                    {
                        MessageBox.Show("Debes seleccionar un capitulo");
                    }
                    else
                    {
                        Capitulo cap1 = (Capitulo)comboBox2.SelectedItem;
                        cap = cap1.Titulo;
                        
                    }
                    if (this.comboBox1.SelectedItem == null)
                    {
                        MessageBox.Show("Debes seleccionar una escena");
                    }
                    else
                    {
                        Escena esc1 = (Escena)comboBox1.SelectedItem;
                        esc = esc1.Titulo;
                        
                    }
                    if (this.textBox1.Text.Equals(""))
                    {
                        MessageBox.Show("Debes poner un nombre");
                    }
                    else
                    {
                        nombre = this.textBox1.Text;
                    }
                    if (this.comboBox1.SelectedItem != null && this.comboBox2.SelectedItem != null)
                    {
                        Program.Book.Actores.Add(new Actor(nombre, cap, this.texto, esc));
                        TreeViewCapPer.Actualizar(Program.Book, Program.libA.treeView1);
                    }
                    this.Close();

                }
                else
                {
                    
                    if (this.comboBox1.SelectedItem == null && this.comboBox2.SelectedItem == null){
                        this.actor.ModificarActor(this.textBox1.Text, this.comboBox1.Text, this.comboBox2.Text,this.texto);
                    }
                    else
                    {
                        Capitulo cap1 = (Capitulo)comboBox2.SelectedItem;
                        Escena esc1 = (Escena)comboBox1.SelectedItem;
                        String idPj = this.actor.Id;
                        Program.Book.Actores.Remove(this.actor);
                        Program.Book.Actores.Add(new Actor(this.textBox1.Text,cap1.Titulo,this.texto,idPj,esc1.Titulo));
                        
                    }
                    TreeViewCapPer.Actualizar(Program.Book, Program.libA.treeView1);
                    this.Close();
                }
            };

           
            

            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 304);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form7";
            this.Text = "Form7";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        

      

        private void rellenaComboEscena()
        {
            this.comboBox1.Items.Clear();
            while (this.comboBox1.Items.Count == 0)
            {
                foreach (var i in Program.Book.Capitulos)
                {
                    if (i.Titulo.Equals(comboBox2.Text))
                    {
                        foreach (var esc in i.Escenas)
                        {
                            this.comboBox1.Items.Add(esc);
                        }
                    }
                    if (this.comboBox1.Items.Count > 0)
                    {
                        break;
                    }
                }
            }
        }

        private void BuildDialogBorraActor()
        {
            this.dlgBorra = new Form();
            this.dlgBorra.SuspendLayout();
            
            var pnlBorra = new TableLayoutPanel();
            pnlBorra.Dock = DockStyle.Fill;
            pnlBorra.SuspendLayout();
            this.dlgBorra.Controls.Add(pnlBorra);

            var pnlActor = new Panel();
            this.cbActor = new ComboBox();
            this.cbActor.FormattingEnabled = true;
            this.cbActor.Text = "Actor";

            this.cbActor.Dock = DockStyle.Fill;

            var lbActor = new Label();
            
            lbActor.Text = "Actor:";
            lbActor.Dock = DockStyle.Left;
           
            pnlActor.Controls.Add(this.cbActor);
            pnlActor.Controls.Add(lbActor);
            pnlActor.Dock = DockStyle.Top;
            pnlActor.MaximumSize = new Size(int.MaxValue, cbActor.Height * 2);
            pnlBorra.Controls.Add(pnlActor);

            var pnlBotones = new TableLayoutPanel();
            pnlBotones.ColumnCount = 2;
            pnlBotones.RowCount = 1;
            var btCierra = new Button();
            btCierra.DialogResult = DialogResult.Cancel;
            btCierra.Text = "&Cancelar";
            var btGuarda = new Button();
            btGuarda.DialogResult = DialogResult.OK;
            btGuarda.Text = "&Guardar";
            pnlBotones.Controls.Add(btGuarda);
            pnlBotones.Controls.Add(btCierra);
            pnlBotones.Dock = DockStyle.Top;
            pnlBorra.Controls.Add(pnlBotones);

            this.dlgBorra.AcceptButton = btGuarda;
            this.dlgBorra.CancelButton = btCierra;
            pnlBorra.ResumeLayout(true);
            this.dlgBorra.ResumeLayout(false);
            this.dlgBorra.Text = "Borra  Actor";
            this.dlgBorra.Size = new Size(400,
                            cbActor.Height +
                            pnlBotones.Height);
            this.dlgBorra.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.dlgBorra.MinimizeBox = false;
            this.dlgBorra.MaximizeBox = false;
            this.dlgBorra.StartPosition = FormStartPosition.CenterParent;
        }

        private void BorraActor()
        {
            Actores toret = Program.Book.Actores;

            

            string Aviso = "Actor borrado";
            string caption = "Alert";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            foreach (Actor actor in toret)
            {
                this.cbActor.Items.Add(actor);
            }

            if (this.dlgBorra.ShowDialog() == DialogResult.OK)
            {



                Actor actorToBorrar = (Actor)cbActor.SelectedItem;
                

                toret.Remove(actorToBorrar);
                if (this.cbActor.SelectedItem == null)
                {
                    Aviso = "No escogio un actor";
                }
                DialogResult result = MessageBox.Show(Aviso, caption, buttons);
                if (result == DialogResult.OK && this.cbActor.SelectedItem != null)
                {
                    this.cbActor.Items.Clear();
                    Program.Book.Actores = toret;
                    TreeViewCapPer.Actualizar(Program.Book, Program.libA.treeView1);
                    TreeViewCapPer.Actualizar(Program.Book, this.treeView1);
                    
                    return;
                }
                else
                {
                    this.cbActor.Items.Clear();
                }

            }

            return;
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Form dlgBorra;
        private System.Windows.Forms.ComboBox cbActor;
       
    }
}