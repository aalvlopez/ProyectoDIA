using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System.ComponentModel;

namespace Planificacion
{
	/// <summary>
	/// Esta clase ofrece una implementación de la interfaz <see cref="IUserInterface"/>
	/// con la que el usuario interactuará con el sistema.
	/// </summary>
	public class EventsWinForms: Form, IUserInterface
	{
		/// <summary>
		/// Referencia a la clase <see cref="Planificacion.ListEvent"/> en la que se guardan los <see cref="Planificacion.Event"/> en memoria.
		/// </summary>
		private ListEvent LEvents;

		/// <summary>
		/// Crea una nueva instancia de la clase <see cref="Planificacion.EventsGUI"/>.
		/// </summary>
		/// <param name='LEvents'>
		/// <see cref="Planificacion.ListEvent"/> en la que se almacenan los <see cref="Planificacion.Event"/>.
		/// </param>
		public EventsWinForms (ListEvent LEvents)
		{
			this.LEvents = LEvents;

			this.BuildGUI();
		}

		/// <summary>
		/// Método con el que se inicializa la <see cref="Planificacion.EventsWinForms"/>, 
		/// mostrandole al usuario una lista con los <see cref="Planificacion.Event"/> ya creados.
		/// </summary>
		private void BuildGUI ()
		{
			this.SuspendLayout();

			this.ListEvents();
			this.FillList();

			this.Text = "Planificación de eventos";

			this.ResumeLayout(false);
		}

		/// <summary>
		/// Método con el que se le muestra al usuario, mediante WinForms, el <see cref="Planificacion.Event"/>.
		/// </summary>
		/// <param name='e'>
		/// <see cref="Planificacion.Event"/> que se le pasa para que se muestren sus propiedades.
		/// </param>
		public void DisplayEvent (Event e)
		{
			this.MaximumSize = new Size ( 435, 185 ); 
			this.MinimumSize = new Size ( 600, 450 ); 

			this.label1 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
            this.panel1 = new Panel();
            this.tbTitulo = new TextBox();
            this.panel2 = new Panel();
            this.rtbDescription = new RichTextBox();
            this.label2 = new Label();
			this.tpickerStart  = new DateTimePicker();
			this.tpickerFinish  = new DateTimePicker();
            this.button1 = new Button();
            this.menu = new MenuStrip();
            this.tsItem1 = new ToolStripMenuItem();
            this.tsItem2 = new ToolStripMenuItem();
            this.tsItem3 = new ToolStripMenuItem();
            this.button2 = new Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(17, 5);
            this.label1.Size = new Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Título";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbTitulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(12, 25);
            this.panel1.Size = new Size(461, 47);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.tbTitulo.Location = new Point(20, 25);
            this.tbTitulo.ReadOnly = true;
            this.tbTitulo.Size = new Size(388, 20);
            this.tbTitulo.TabIndex = 1;
			this.tbTitulo.Text = e.Title;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbDescription);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new Point(12, 72);
            this.panel2.Size = new Size(257, 287);
            this.panel2.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.rtbDescription.Location = new Point(20, 21);
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new Size(224, 251);
            this.rtbDescription.TabIndex = 1;
            this.rtbDescription.Text = e.Description;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(17, 5);
            this.label2.Size = new Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripción";
            // 
            // button1
            // 
            this.button1.Location = new Point(397, 336);
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new Point(305, 336);
            this.button2.Size = new Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Borrar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menu.Items.AddRange(new ToolStripItem[] {
            this.tsItem1});
            this.menu.Location = new Point(0, 0);
            this.menu.Size = new Size(491, 24);
            this.menu.TabIndex = 7;
            this.menu.Text = "menuStrip1";
            // 
            // tsItem1
            // 
            this.tsItem1.DropDownItems.AddRange(new ToolStripItem[] {
	            this.tsItem2,
	            this.tsItem3
			});
            this.tsItem1.Size = new Size(60, 20);
            this.tsItem1.Text = "Archivo";
            // 
            // tsItem2
            // 
            this.tsItem2.Size = new Size(152, 22);
            this.tsItem2.Text = "Cerrar";
            // 
            // salirToolStripMenuItem
            // 
            this.tsItem3.Size = new Size(152, 22);
            this.tsItem3.Text = "Salir";

			this.tsItem2.ShortcutKeys = Keys.Alt | Keys.C;
			this.tsItem2.ShortcutKeyDisplayString = "Alt+C";

			this.tsItem3.ShortcutKeys = Keys.Alt | Keys.W;
			this.tsItem3.ShortcutKeyDisplayString = "Alt+W";

            // 
            // tpickerStart
            // 
            this.tpickerStart.Location = new Point(291, 144);
            this.tpickerStart.Size = new Size(210, 20);
            this.tpickerStart.TabIndex = 9;
			this.tpickerStart.Value = e.DateStart;
			this.tpickerStart.Enabled = false;
            // 
            // tpickerFinish
            // 
            this.tpickerFinish.Location = new Point(291, 210);
            this.tpickerFinish.Size = new Size(210, 20);
            this.tpickerFinish.TabIndex = 10;
			this.tpickerFinish.Value = e.DateFinish;
			this.tpickerFinish.Enabled = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(291, 117);
            this.label3.Size = new Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Data Inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(291, 188);
            this.label4.Size = new Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Data Finalización";

			// 
            // Config
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(491, 371);
			this.Controls.Clear();
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tpickerStart);
			this.Controls.Add(this.tpickerFinish);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menu;
            this.Text = "Eventos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.PerformLayout();

			this.ResumeLayout(false);

			//Eventos
			this.tsItem2.Click += delegate(object sender, EventArgs eA) {
				this.Controls.Clear();
				this.ListEvents();
				this.FillList();
			};

			this.tsItem3.Click += delegate(object sender, EventArgs eA) {
				this.Close();
			};

			this.button2.Click += delegate(object sender, EventArgs eA) {
				this.LEvents.RemoveEventByID(e.Id);
				MessageBox.Show("El evento se ha eliminado correctamente");
				this.Controls.Clear();
				this.ListEvents();
				this.FillList();
			};

			this.button1.Click += delegate(object sender, EventArgs eA) {
				this.ModifyEvent(e);
			}; 
		}

		/// <summary>
		/// Método con el que se le muestra al usuario mediante WinForms un formulario con el que podrá modificar el
	 	/// <see cref="Planificacion.Event"/> que haya elegido.
		/// </summary>
		/// <param name='e'>
		/// <see cref="Planificacion.Event"/> que el usuario ha elegido para modificar.
		/// </param>
		public void ModifyEvent (Event e)
		{
			this.MaximumSize = new Size ( 435, 185 ); 
			this.MinimumSize = new Size ( 600, 450 );  

			this.label1 = new Label();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.label2 = new Label();
            this.monthCalendar = new MonthCalendar();
            this.button1 = new Button();
            this.menu = new MenuStrip();
            this.tsItem1 = new ToolStripMenuItem();
            this.tsItem2 = new ToolStripMenuItem();
            this.tsItem3 = new ToolStripMenuItem();
            this.tbTitulo = new TextBox();
            this.rtbDescription = new RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(17, 5);
            this.label1.Size = new Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Título";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbTitulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(12, 25);
            this.panel1.Size = new Size(461, 47);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbDescription);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new Point(12, 72);
            this.panel2.Size = new Size(257, 287);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(17, 5);
            this.label2.Size = new Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripción";
            // 
            // monthCalendar1
            // 
            this.monthCalendar.Location = new Point(281, 93);
            this.monthCalendar.TabIndex = 4;
			this.monthCalendar.SelectionStart = e.DateStart;
			this.monthCalendar.SelectionEnd = e.DateFinish;
			this.monthCalendar.MaxSelectionCount = 9999;
            // 
            // button1
            // 
            this.button1.Location = new Point(397, 336);
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new ToolStripItem[] {
            	this.tsItem1
			});
            this.menu.Location = new Point(0, 0);
            this.menu.Size = new Size(491, 24);
            this.menu.TabIndex = 7;
            this.menu.Text = "menuStrip1";
            // 
            // tsItem1
            // 
            this.tsItem1.DropDownItems.AddRange(new ToolStripItem[] {
	            this.tsItem2,
	            this.tsItem3
			});
            this.tsItem1.Size = new Size(60, 20);
            this.tsItem1.Text = "Archivo";
            // 
            // tsItem2
            // 
            this.tsItem2.Size = new Size(152, 22);
            this.tsItem2.Text = "Cerrar";
            // 
            // tsItem3
            // 
            this.tsItem3.Size = new Size(152, 22);
            this.tsItem3.Text = "Salir";

			this.tsItem2.ShortcutKeys = Keys.Alt | Keys.C;
			this.tsItem2.ShortcutKeyDisplayString = "Alt+C";

			this.tsItem3.ShortcutKeys = Keys.Alt | Keys.W;
			this.tsItem3.ShortcutKeyDisplayString = "Alt+W";

            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new Point(20, 25);
            this.tbTitulo.Size = new Size(388, 20);
            this.tbTitulo.TabIndex = 1;
			this.tbTitulo.Text = e.Title;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new Point(20, 21);
            this.rtbDescription.Size = new Size(224, 251);
            this.rtbDescription.TabIndex = 1;
            this.rtbDescription.Text = e.Description;

            // 
            // Config
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(491, 371);
			this.Controls.Clear();
            this.Controls.Add(this.menu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menu;
            this.Text = "Modificar evento";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

			// Events
			this.button1.Click += delegate(object sender, EventArgs eA) {
				if( this.CheckValues(this.tbTitulo.Text, this.monthCalendar.SelectionRange.End) )
					if( this.LEvents.RemoveEventByID(e.Id) )
						this.Add( this.tbTitulo.Text,this.rtbDescription.Text,this.monthCalendar.SelectionRange.Start, 
	                              this.monthCalendar.SelectionRange.End);

			};
				

			this.tsItem2.Click += delegate(object sender, EventArgs eA) {
				this.Controls.Clear();
				this.ListEvents();
				this.FillList();
			};

			this.tsItem3.Click += delegate(object sender, EventArgs eA) {
				this.Close();
			};
		}

		/// <summary>
		/// Método para mostrarle un Form al usuario en el que podrá
		/// introducir los datos para crear un nuevo <see cref="Planificacion.Event"/>.
		/// </summary>
		public void AddEvents()
		{
			this.MaximumSize = new Size ( 435, 185 ); 
			this.MinimumSize = new Size ( 600, 450 );

		 	this.label1 = new Label();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.label2 = new Label();
            this.monthCalendar = new MonthCalendar();
            this.button1 = new Button();
            this.menu = new MenuStrip();
            this.tsItem1 = new ToolStripMenuItem();
            this.tsItem2 = new ToolStripMenuItem();
            this.tsItem3 = new ToolStripMenuItem();
            this.tbTitulo = new TextBox();
            this.rtbDescription = new RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(17, 5);
            this.label1.Size = new Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Título";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbTitulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(12, 25);
            this.panel1.Size = new Size(461, 47);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbDescription);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new Point(12, 72);
            this.panel2.Size = new Size(257, 287);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(17, 5);
            this.label2.Size = new Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripción";
            // 
            // monthCalendar1
            // 
            this.monthCalendar.Location = new Point(281, 93);
            this.monthCalendar.TabIndex = 4;
			this.monthCalendar.MaxSelectionCount = 9999;
            // 
            // button1
            // 
            this.button1.Location = new Point(397, 336);
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new ToolStripItem[] {
            	this.tsItem1
			});
            this.menu.Location = new Point(0, 0);
            this.menu.Size = new Size(491, 24);
            this.menu.TabIndex = 7;
            this.menu.Text = "menuStrip1";
            // 
            // tsItem1
            // 
            this.tsItem1.DropDownItems.AddRange(new ToolStripItem[] {
	            this.tsItem2,
	            this.tsItem3
			});
            this.tsItem1.Size = new Size(60, 20);
            this.tsItem1.Text = "Archivo";
            // 
            // tsItem2
            // 
            this.tsItem2.Size = new Size(152, 22);
            this.tsItem2.Text = "Cerrar";
            // 
            // tsItem3
            // 
            this.tsItem3.Size = new Size(152, 22);
            this.tsItem3.Text = "Salir";

			this.tsItem2.ShortcutKeys = Keys.Alt | Keys.C;
			this.tsItem2.ShortcutKeyDisplayString = "Alt+C";

			this.tsItem3.ShortcutKeys = Keys.Alt | Keys.W;
			this.tsItem3.ShortcutKeyDisplayString = "Alt+W";

            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new Point(20, 25);
            this.tbTitulo.Size = new Size(388, 20);
            this.tbTitulo.TabIndex = 1;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new Point(20, 21);
            this.rtbDescription.Size = new Size(224, 251);
            this.rtbDescription.TabIndex = 1;
            this.rtbDescription.Text = "";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(491, 371);
			this.Controls.Clear();
            this.Controls.Add(this.menu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menu;
            this.Text = "Nuevo Evento";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
			this.PerformLayout();

			// Events
			this.button1.Click += delegate(object sender, EventArgs e) {
				if( this.CheckValues(this.tbTitulo.Text, this.monthCalendar.SelectionRange.End) )
					this.Add( this.tbTitulo.Text, this.rtbDescription.Text, this.monthCalendar.SelectionRange.Start, 
                          this.monthCalendar.SelectionRange.End);

			};
			this.tsItem2.Click += delegate(object sender, EventArgs e) {
				this.Controls.Clear();
				this.ListEvents();
				this.FillList();
			};

			this.tsItem3.Click += delegate(object sender, EventArgs e) {
				this.Close();
			};
		}

		/// <summary>
		/// Método en el que se le muestra al usuario, mediante WinForms, una lista
		/// con los <see cref="Planificacion.Event"/> que tiene creados hasta el momento.
		/// </summary>
		public void ListEvents ()
		{
			this.MinimumSize = new Size ( 960, 450 );
			this.MaximumSize = new Size ( 1024, 768 );

			this.menu = new MenuStrip();
			this.dgList = new DataGridView();

            this.tsItem1 = new ToolStripMenuItem();
            this.tsItem2 = new ToolStripMenuItem();
            this.tsItem3 = new ToolStripMenuItem();
            
            this.Columna0 = new DataGridViewTextBoxColumn();
            this.Columna1 = new DataGridViewTextBoxColumn();
            this.Columna2 = new DataGridViewTextBoxColumn();
            this.Columna3 = new DataGridViewTextBoxColumn();

            this.menu.SuspendLayout();
			this.menu.Dock = DockStyle.Top;
            this.SuspendLayout();

            this.menu.Items.AddRange(new ToolStripItem[] {
            	this.tsItem1
			});
            this.menu.TabIndex = 0;

            this.tsItem1.DropDownItems.AddRange(new ToolStripItem[] {
	            this.tsItem2,
	            this.tsItem3
			});
            this.tsItem1.Text = "Archivo";
            this.tsItem2.Text = "Nuevo Evento";
            this.tsItem3.Text = "Salir";

			this.tsItem2.ShortcutKeys = Keys.Alt | Keys.N;
			this.tsItem2.ShortcutKeyDisplayString = "Alt+N";

			this.tsItem3.ShortcutKeys = Keys.Alt | Keys.W;
			this.tsItem3.ShortcutKeyDisplayString = "Alt+W";

            // 
            // dgList
            // 
			this.dgList.AllowUserToResizeRows = false;
			this.dgList.AllowUserToResizeColumns = true;


			this.dgList.RowHeadersVisible = false;
			this.dgList.MultiSelect = false;
			this.dgList.AllowUserToResizeRows = false;
			this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AllowUserToOrderColumns = true;
			this.dgList.ReadOnly = true;
			this.dgList.BackgroundColor = Color.LightGray;
			this.dgList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgList.ScrollBars = ScrollBars.Vertical;

			this.dgList.Columns.AddRange(new DataGridViewColumn[] {
				this.Columna0,
	            this.Columna1,
	            this.Columna2,
            	this.Columna3
			});

			this.dgList.Height = 300;
            this.dgList.Dock = DockStyle.Top;

            this.Columna0.HeaderText = "#";

            this.Columna1.HeaderText = "Título";
			this.Columna1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.Columna2.HeaderText = "Fecha Inicio";
			this.Columna2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.Columna3.HeaderText = "Fecha Fin";
			this.Columna3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			this.Controls.Clear();
            this.Controls.Add(this.dgList);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;

			this.menu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.menu.PerformLayout();
            this.PerformLayout();

			//Eventos
			this.tsItem2.Click += delegate(object sender, EventArgs e) {
				this.Controls.Clear();
				this.AddEvents();
			};

			this.tsItem3.Click += delegate(object sender, EventArgs e) {
				this.Close();
			};

			this.dgList.CellClick += delegate(object sender, DataGridViewCellEventArgs e) {
				if( e.ColumnIndex == 1 )
				{
					var position = Convert.ToInt16(dgList.Rows[e.RowIndex].Cells[0].Value);
					Event evnt = this.LEvents.GetEventByIndex(position - 1);
					if(evnt != null)
						this.DisplayEvent(evnt);
				}
			};

			this.ResizeWindow();

			this.sbStatus = new StatusBar();
			this.sbStatus.Dock = DockStyle.Bottom;
			this.Controls.Add( this.sbStatus );
		}

		/// <summary>
		/// Método que se llama con el evento Click del botón del formulario de altas, para dar
		/// de alta un nuevo <see cref="Planificacion.Event"/>. En este método se añade el <see cref="Planificacion.Event"/> a la lista
		/// <see cref="Planificacion.ListEvent"/> y se modifica en el fichero XML.
		/// </summary>
		/// <param name='title'>
		/// <see cref="String"/> con el título del <see cref="Event"/>.
		/// </param>
		/// <param name='description'>
		/// <see cref="String"/> con la descripción del <see cref="Event"/>. 
		/// </param>
		/// <param name='dateStart'>
		/// <see cref="DateTime"/> con la fecha de inicio del <see cref="Event"/>.
		/// </param>
		/// <param name='dateFinish'>
		/// <see cref="DateTime"/> con la fecha de finalización del <see cref="Event"/>.
		/// </param>
		private void Add (String title, String description, DateTime dateStart, DateTime dateFinish)
		{
			ArrayList alEvent = new ArrayList ();

			alEvent.Add (title);
			alEvent.Add (description);
			alEvent.Add (dateStart);
			alEvent.Add (dateFinish);

			if (LEvents.AddEvent(alEvent)) 
			{
				MessageBox.Show ("El evento se ha guardado correctamente.");
				this.Controls.Clear();
				this.BuildGUI();
				this.FillList();
			}else
				MessageBox.Show ( "El evento NO ha sido guardado. Inténtelo de nuevo." );
		}

		/// <summary>
		/// Este método verifica que el título que se ha introducido no esté vacio, ni que 
		/// la fecha de finalización del evento, sea anterior a la actual.
		/// </summary>
		/// <returns>
		/// Devuelve <c>FALSE</c> en caso de que alguna de estas condiciones no se cumpla, si se cumplen las dos
		/// devuelve <c>TRUE</c>.
		/// </returns>
		/// <param name='title'>
		/// <see cref="String"/> con el título introducido.
		/// </param>
		/// <param name='dateFinish'>
		/// <see cref="DateTime"/> con la fecha de finalización introducida.
		/// </param>
		private Boolean CheckValues (String title, DateTime dateFinish)
		{
			if (String.IsNullOrEmpty (title) || String.IsNullOrWhiteSpace (title))
			{
				MessageBox.Show ("El evento no ha sido guardado. El evento tiene que debe tener un título.");
				return false;
			}else
				if (dateFinish.CompareTo (DateTime.Today) < 0)
				{
					MessageBox.Show ("El evento no ha sido guardado. La fecha de finalización no puede ser anterior a hoy.");
					return false;
				}

			return true;
		}

		/// <summary>
		/// Método que se llama justo despues de la funcion ListEvents()
		/// para actualizar las filas con el contenido de cada <see cref="Planificacion.Event"/>.
		/// </summary>
		private void FillList()
		{
			for (int i = 0; i < this.LEvents.GetLength(); ++i)
			{
				if ( this.dgList.Rows.Count <= i )
				{
					this.dgList.Rows.Add();
					this.FillRowList( i );
				}
			}
			this.dgList.Sort(this.dgList.Columns[2], ListSortDirection.Ascending);
			this.sbStatus.Text= "Número total de eventos = " + this.LEvents.GetLength();
		}

		/// <summary>
		/// Método que se llama en cada iteración en la función FillList
		/// y con el que se añaden nuevas filas y el contenido de cada <see cref="Planificacion.Event"/>
		/// a cada una de las filas que se añaden.
		/// </summary>
		/// <param name='rowIndex'>
		/// <see cref="int"/> con el índice de la fila que va a ser añadida en ese momento.
		/// </param>
		private void FillRowList (int rowIndex)
		{
			if (rowIndex < 0
				|| rowIndex > this.dgList.Rows.Count) {
				throw new ArgumentOutOfRangeException ("Row out of bound: " + rowIndex);
			}

			DataGridViewRow row = this.dgList.Rows [rowIndex];
			Event Event = this.LEvents.GetEventByIndex (rowIndex);
			if (Event != null) {
				row.Cells [0].Value = (rowIndex + 1).ToString ().PadLeft (4, ' ');
				row.Cells [1].Value = Event.Title;
				row.Cells [2].Value = Event.DateStart;
				row.Cells [3].Value = Event.DateFinish;
			}
		}

		private void ResizeWindow(){
			// Tomar las nuevas medidas
			int width = this.ClientRectangle.Width;			
			
			// Redimensionar la tabla
			this.dgList.Width = width;
			this.dgList.Columns[ 0 ].Width = 	(int) Math.Floor( width *.05 );	
			this.dgList.Columns[ 1 ].Width =	(int) Math.Floor( width *.20 );	
			this.dgList.Columns[ 2 ].Width =	(int) Math.Floor( width *.35 );	
			this.dgList.Columns[ 3 ].Width =	(int) Math.Floor( width *.20 ); 
		}
	
		//// Elementos
		private Label label1;
        private Label label2;
		private Label label3;
		private Label label4;

		private StatusBar sbStatus;

		private Panel panel1;
        private Panel panel2;
        
		private Button button1;
		private Button button2;

        private MonthCalendar monthCalendar;
        private DateTimePicker tpickerStart;
		private DateTimePicker tpickerFinish;

        private TextBox tbTitulo;
        private RichTextBox rtbDescription;

        private MenuStrip menu;

        private ToolStripMenuItem tsItem1;
        private ToolStripMenuItem tsItem2;
        private ToolStripMenuItem tsItem3;

        private DataGridView dgList;
        private DataGridViewTextBoxColumn Columna0;
        private DataGridViewTextBoxColumn Columna1;
        private DataGridViewTextBoxColumn Columna2;
        private DataGridViewTextBoxColumn Columna3;
	}
}

