using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public class EscenasForm : Form
	{
		public EscenasForm ()
		{
			ConstruirGui ();
		}

		public Form PantallaAnt {
			get;
			set;
		}

		public void ConstruirGui() {
			textBox = new TextBox ();
			textBox.Text = "Titulo";
			textBox.Size = new Size (150,30);

			comboBox = new ComboBox ();
			comboBox.Text = "Capitulo";
			comboBox.Size = new Size (150,30);

			btnCancel = new Button ();
			btnCancel.Text = "Cancelar";
			btnCancel.Size = new Size (150,30);
			btnCancel.Click += delegate(object sender, EventArgs e) {
				this.Hide();
				this.PantallaAnt.Show();
			};


			btnSave = new Button ();
			btnSave.Text = "Guardar";
			btnSave.Size = new Size (150,30);
			btnSave.Click += delegate(object sender, EventArgs e) {
				this.Hide();
				this.PantallaAnt.Show();
			};

			btnEdit = new Button ();
			btnEdit.Text = "Editar escena";
			btnEdit.Size = new Size (150,30);
			btnEdit.Click += delegate(object sender, EventArgs e) {
				this.Hide ();
				Program.procesador.PantallaAnt = this;
				Program.procesador.Show ();
			};

			tableLayoutPanel = new TableLayoutPanel ();
			tableLayoutPanel.Dock = DockStyle.Fill;
			tableLayoutPanel.Padding = new Padding (50);
			tableLayoutPanel.Controls.Add (textBox);
			tableLayoutPanel.Controls.Add (comboBox);
			tableLayoutPanel.Controls.Add (btnCancel);
			tableLayoutPanel.Controls.Add (btnSave);
			tableLayoutPanel.Controls.Add (btnEdit);

			Controls.Add (tableLayoutPanel);
			this.Size = new Size (265,300);
		}

		private TextBox textBox;
		private ComboBox comboBox;
		private Button btnCancel;
		private Button btnSave;
		private Button btnEdit;
		private TableLayoutPanel tableLayoutPanel;
	}
}
