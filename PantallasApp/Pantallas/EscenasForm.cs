using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public class EscenasForm : Form
	{
		private Escena escena;

		public Form PantallaAnt {
			get;
			set;
		}

		public string texto;

		public EscenasForm (Escena escena)
		{
			this.escena = escena;
			this.texto = this.escena.Contenido;
			ConstruirGui ();
			this.Show ();
		}

		public EscenasForm ()
		{
			this.texto = "";
			this.escena = null;
			ConstruirGui ();
			this.Show ();
		}

		public void ConstruirGui ()
		{
			textBox = new TextBox ();
			if (this.escena == null) {
				textBox.Text = "Titulo";
			} else {
				textBox.Text = escena.Titulo;
			}
			textBox.Size = new Size (150, 30);

			comboBox = new ComboBox ();
			if (this.escena == null) {
				comboBox.Text = "Capitulo";
			} else {
				foreach (var i in Program.Book.Capitulos) {
					if (i.Escenas.Contains (this.escena)) {
						comboBox.Text = i.Titulo;
					}
				}
			}

			comboBox.Size = new Size (150, 30);
			foreach (var i in Program.Book.Capitulos) {
				comboBox.Items.Add (i);
			}
			richTextBox1 = new RichTextBox ();
			if (this.escena == null) {
				richTextBox1.Text = "Anotaciones";
			} else {
				richTextBox1.Text = escena.Anotacion;
			}
			richTextBox1.Size = new Size (150, 150);


			btnCancel = new Button ();
			btnCancel.Text = "Cancelar";
			btnCancel.Size = new Size (150, 30);
			btnCancel.Click += delegate(object sender, EventArgs e) {
				this.Close ();
			};


			btnSave = new Button ();
			btnSave.Text = "Guardar";
			btnSave.Size = new Size (150, 30);
			btnSave.Click += delegate(object sender, EventArgs e) {
				if (this.escena == null) {
					if (this.comboBox.SelectedItem == null) {
						MessageBox.Show ("Debes seleccionar un capitulo");
					}else{
						Capitulo cap1 = (Capitulo)comboBox.SelectedItem;
						cap1.CrearEscena (this.textBox.Text, this.richTextBox1.Text, this.texto, cap1.Id);
						TreeViewCapPer.Actualizar (Program.Book, Program.libA.treeView1);
						this.Close ();
					}
				} else {
					if(this.comboBox.SelectedItem == null)
						this.escena.ModificarEscena (this.textBox.Text, this.richTextBox1.Text, this.texto);
					else
					{
						Capitulo cap1 = (Capitulo)comboBox.SelectedItem;
						Program.Book.BuscarCapituloId(this.escena.IdCapitulo).Escenas.Remove(this.escena);
						cap1.CrearEscena(this.textBox.Text, this.richTextBox1.Text, this.texto, cap1.Id);
					}
					TreeViewCapPer.Actualizar (Program.Book, Program.libA.treeView1);
					this.Close ();
				}
			};

			btnEdit = new Button ();
			btnEdit.Text = "Editar escena";
			btnEdit.Size = new Size (150, 30);
			btnEdit.Click += delegate(object sender, EventArgs e) {
				Program.procesador = new ProcesadorTextos ();
				Program.procesador.setTexto(this.texto);
			};

			tableLayoutPanel = new TableLayoutPanel ();
			tableLayoutPanel.Dock = DockStyle.Fill;
			tableLayoutPanel.Padding = new Padding (50);
			tableLayoutPanel.Controls.Add (textBox);
			tableLayoutPanel.Controls.Add (comboBox);
			tableLayoutPanel.Controls.Add (richTextBox1);
			tableLayoutPanel.Controls.Add (btnCancel);
			tableLayoutPanel.Controls.Add (btnSave);
			tableLayoutPanel.Controls.Add (btnEdit);

			Controls.Add (tableLayoutPanel);
			this.Size = new Size (265, 420);
		}

		private TextBox textBox;
		private RichTextBox richTextBox1;
		private ComboBox comboBox;
		private Button btnCancel;
		private Button btnSave;
		private Button btnEdit;
		private TableLayoutPanel tableLayoutPanel;
	}
}

