using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    partial class LibroAbiertoForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.abrirToolStripMenuItem = new ToolStripMenuItem();
            this.editarToolStripMenuItem = new ToolStripMenuItem();
            this.crearLibroToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripMenuItem();
            this.panel1 = new Panel();
            this.menuStrip1 = new MenuStrip();
            this.libroToolStripMenuItem = new ToolStripMenuItem();
            this.crearToolStripMenuItem = new ToolStripMenuItem();
            this.abrirToolStripMenuItem1 = new ToolStripMenuItem();
            this.editarToolStripMenuItem1 = new ToolStripMenuItem();
			
			this.saveToolStripMenu = new ToolStripMenuItem();
			this.exitToolStripMenu = new ToolStripMenuItem();
			
            this.referenciasToolStripMenuItem = new ToolStripMenuItem();
            this.nuevaToolStripMenuItem = new ToolStripMenuItem();
            //this.editarToolStripMenuItem2 = new ToolStripMenuItem();
            this.eventosToolStripMenuItem = new ToolStripMenuItem();
            this.verToolStripMenuItem = new ToolStripMenuItem();
            this.panel2 = new Panel();
			this.treeView1 = new TreeView();
            this.panel3 = new Panel();
            this.button3 = new Button();
            this.button2 = new Button();
            this.button1 = new Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.abrirToolStripMenuItem.Text = "Abrir...";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.editarToolStripMenuItem.Text = "Editar";
			this.editarToolStripMenuItem.Click += delegate(object sender, EventArgs e) {
				MessageBox.Show("asfas");
			};
            // 
            // crearLibroToolStripMenuItem
            // 
            this.crearLibroToolStripMenuItem.Name = "crearLibroToolStripMenuItem";
            this.crearLibroToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.crearLibroToolStripMenuItem.Text = "Crear Libro";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.crearLibroToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 432);
            this.panel1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.libroToolStripMenuItem,
            this.referenciasToolStripMenuItem,
            this.eventosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(529, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // libroToolStripMenuItem
            // 
            this.libroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.crearToolStripMenuItem,
            this.abrirToolStripMenuItem1,
            this.editarToolStripMenuItem1,
			this.saveToolStripMenu,
			this.exitToolStripMenu});
            this.libroToolStripMenuItem.Name = "libroToolStripMenuItem";
            this.libroToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.libroToolStripMenuItem.Text = "Archivo";
            // 
            // crearToolStripMenuItem
            // 
            this.crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            this.crearToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.crearToolStripMenuItem.Text = "Nuevo Libro";
			this.crearToolStripMenuItem.Click += delegate(object sender, EventArgs e) {
				Program.nuevoLib = new NuevoLibroForm();
			};
            // 
            // abrirToolStripMenuItem1
            // 
            this.abrirToolStripMenuItem1.Name = "abrirToolStripMenuItem1";
            this.abrirToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.abrirToolStripMenuItem1.Text = "Abrir Libro";
			this.abrirToolStripMenuItem1.Click += delegate(object sender, EventArgs e) {
				openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "XML Files (*.xml)|*.xml";
				openFileDialog.FilterIndex = 0 ;
				openFileDialog.RestoreDirectory = true;
				openFileDialog.FileName = null;
				openFileDialog.Title = "Cargar libro";

				if (openFileDialog.ShowDialog () == DialogResult.OK) {
					String fileName = openFileDialog.FileName;

					// A partir de aquí se debería cargar el xml en memoria...
					Program.persistencia = new XMLPersistencia(fileName);
					Program.Book = Program.persistencia.Leer();
					TreeViewCapPer.Actualizar(Program.Book, Program.libA.treeView1);
					
				Program.libA.referenciasToolStripMenuItem.Enabled=true;
				}
				
				
			};
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.editarToolStripMenuItem1.Text = "Editar";
			this.editarToolStripMenuItem1.Click += delegate(object sender, EventArgs e) {
				Program.nuevoLib = new NuevoLibroForm();
			};
			
			// 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenu.Name = "editarToolStripMenuItem1";
            this.saveToolStripMenu.Size = new System.Drawing.Size(109, 22);
            this.saveToolStripMenu.Text = "Salvar";
			this.saveToolStripMenu.Click += delegate(object sender, EventArgs e) {
				Program.persistencia.Guardar(Program.Book);
			};
			
			// 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenu.Name = "editarToolStripMenuItem1";
            this.exitToolStripMenu.Size = new System.Drawing.Size(109, 22);
            this.exitToolStripMenu.Text = "Salir";
			this.exitToolStripMenu.Click += delegate(object sender, EventArgs e) {
				this.Close ();
			};
			
            // 
            // referenciasToolStripMenuItem
            // 
            this.referenciasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.nuevaToolStripMenuItem,
            /*this.editarToolStripMenuItem2*/});
            this.referenciasToolStripMenuItem.Name = "referenciasToolStripMenuItem";
            this.referenciasToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.referenciasToolStripMenuItem.Text = "Referencias";
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nuevaToolStripMenuItem.Text = "Gestionar Referencias";
			this.nuevaToolStripMenuItem.Click += delegate(object sender, EventArgs e) {
				Program.references=new ReferencesForm();
			};
            // 
            // editarToolStripMenuItem2
            // 
           /* this.editarToolStripMenuItem2.Name = "editarToolStripMenuItem2";
            this.editarToolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.editarToolStripMenuItem2.Text = "Editar";
			this.editarToolStripMenuItem2.Click += delegate(object sender, EventArgs e) {
				MessageBox.Show("Editar referencia...");
			};*/
            // 
            // eventosToolStripMenuItem
            // 
            this.eventosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.verToolStripMenuItem});
            this.eventosToolStripMenuItem.Name = "eventosToolStripMenuItem";
            this.eventosToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.eventosToolStripMenuItem.Text = "Eventos";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.verToolStripMenuItem.Text = "Ver";
			this.verToolStripMenuItem.Click += delegate(object sender, EventArgs e) {
				Program.eventosForm = new EventsWinForms(Program.listEvents);
			};
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Location = new System.Drawing.Point(339, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 401);
            this.panel2.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(171, 395);
            this.treeView1.TabIndex = 0;
			
			treeView1.NodeMouseDoubleClick+=delegate(object sender, TreeNodeMouseClickEventArgs e) {
				if(e.Node.Level == 1){
					Program.modCap = new ModificarCapituloForm(Program.Book.BuscarCapituloId(e.Node.Name));
				}else{
					if(e.Node.Level == 2){
						Program.esc = new EscenasForm(Program.Book.BuscarEscenaId(e.Node.Name));
					}
				}
			};

            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(3, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 401);
            this.panel3.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(48, 261);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(214, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "Nuevo Personaje";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += delegate(object sender, EventArgs e) {
				Program.anPers=new AnadirModificarPersonajesForm();
			};
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(48, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Nueva Escena";
            this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += delegate(object sender, EventArgs e) {
				Program.esc=new EscenasForm();
			};
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Nuevo Capítulo";
            this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += delegate(object sender, EventArgs e) {
				Program.nuevoCap=new NuevoCapituloForm();
			};
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 433);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem crearLibroToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private Panel panel1;
        private Panel panel3;
        public Button button3;
        public Button button2;
        public Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem libroToolStripMenuItem;
        private ToolStripMenuItem crearToolStripMenuItem;
        private ToolStripMenuItem abrirToolStripMenuItem1;
        private ToolStripMenuItem editarToolStripMenuItem1;
		
		private ToolStripMenuItem saveToolStripMenu;
		private ToolStripMenuItem exitToolStripMenu;
		
        public ToolStripMenuItem referenciasToolStripMenuItem;
        public ToolStripMenuItem nuevaToolStripMenuItem;
        //public ToolStripMenuItem editarToolStripMenuItem2;
        private ToolStripMenuItem eventosToolStripMenuItem;
        private ToolStripMenuItem verToolStripMenuItem;
        private Panel panel2;
        public TreeView treeView1;
		private OpenFileDialog openFileDialog;
    }
}

