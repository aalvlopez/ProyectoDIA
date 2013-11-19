using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProcesadorTextos
{
	/// <summary>
	/// Se encarga de crear la interfaz gráfica de la aplicación.
	/// </summary>
	public class MainWindow : Form
	{

		public MainWindow()
		{
			ConstruirGui ();
		}

		/// <summary>
		/// Crea un menú en la parte superior.
		/// </summary>
		public void ConstruirMenu()
		{
			mainMenu = new MainMenu ();

			menuArchivo = new MenuItem ("&Archivo");
			menuEditar = new MenuItem ("&Editar");

			operacionAbrir = new MenuItem ("&Abrir");
			operacionAbrir.Shortcut = Shortcut.CtrlO;
			operacionAbrir.Click += (sender, e) => Abrir();

			operacionGuardar = new MenuItem ("&Guardar");
			operacionGuardar.Shortcut = Shortcut.CtrlS;
			operacionGuardar.Click += (sender, e) => Guardar();

			operacionExportarXml = new MenuItem ("&Exportar a XML");
			operacionExportarXml.Click += (sender, e) => ExportarXml();

			operacionExportarHtml = new MenuItem ("&Exportar a HTML");
			operacionExportarHtml.Click += (sender, e) => ExportarHtml();

			operacionSalir = new MenuItem ("&Salir");
			operacionSalir.Shortcut = Shortcut.CtrlQ;
			operacionSalir.Click += (sender, e) => Salir ();

			operacionCortar = new MenuItem ("&Cortar");
			operacionCortar.Shortcut = Shortcut.CtrlX;
			operacionCortar.Click += (sender, e) => Cortar ();

			operacionCopiar = new MenuItem ("&Copiar");
			operacionCopiar.Shortcut = Shortcut.CtrlC;
			operacionCopiar.Click += (sender, e) => Copiar ();

			operacionPegar = new MenuItem ("&Pegar");
			operacionPegar.Shortcut = Shortcut.CtrlV;
			operacionPegar.Click += (sender, e) => Pegar ();

			operacionDeshacer = new MenuItem ("&Deshacer");
			operacionDeshacer.Shortcut = Shortcut.CtrlZ;
			operacionDeshacer.Click += (sender, e) => Deshacer ();

			menuArchivo.MenuItems.Add (operacionAbrir);
			menuArchivo.MenuItems.Add (operacionGuardar);
			menuArchivo.MenuItems.Add (operacionExportarXml);
			menuArchivo.MenuItems.Add (operacionExportarHtml);
			menuArchivo.MenuItems.Add (operacionSalir);

			menuEditar.MenuItems.Add (operacionCortar);
			menuEditar.MenuItems.Add (operacionCopiar);
			menuEditar.MenuItems.Add (operacionPegar);
			menuEditar.MenuItems.Add (operacionDeshacer);

			mainMenu.MenuItems.Add (menuArchivo);
			mainMenu.MenuItems.Add (menuEditar);

			Menu = mainMenu;
		}

		/// <summary>
		/// Crea un panel con 3 botones y otro con un TextBox.
		/// </summary>
		public void ConstruirPanel() 
		{
			btnLoad = new Button ();
			btnSave = new Button ();
			btnSave.Margin = new Padding (
				btnLoad.Margin.Left,
				btnLoad.Margin.Top,
				15,
				btnLoad.Margin.Bottom);

			btnNegrita = new CheckBox ();
			btnCursiva = new CheckBox ();
			btnSubrayado = new CheckBox ();
			btnSave.BackgroundImage = Image.FromFile ("../../Img/doc_export_icon.png");
			btnLoad.BackgroundImage = Image.FromFile ("../../Img/doc_import_icon.png");
			btnNegrita.BackgroundImage = Image.FromFile ("../../Img/font_bold_icon.png");
			btnCursiva.BackgroundImage = Image.FromFile ("../../Img/font_italic_icon.png");
			btnSubrayado.BackgroundImage = Image.FromFile ("../../Img/font_underline_icon.png");
			btnSave.BackgroundImageLayout = ImageLayout.Center;
			btnLoad.BackgroundImageLayout = ImageLayout.Center;
			btnNegrita.BackgroundImageLayout = ImageLayout.Center;
			btnCursiva.BackgroundImageLayout = ImageLayout.Center;
			btnSubrayado.BackgroundImageLayout = ImageLayout.Center;
			btnSave.Size = new Size (32, 32);
			btnLoad.Size = new Size (32, 32);
			btnNegrita.Size = new Size (32, 32);
			btnCursiva.Size = new Size (32, 32);
			btnSubrayado.Size = new Size (32, 32);
			btnNegrita.Appearance = Appearance.Button;
			btnCursiva.Appearance = Appearance.Button;
			btnSubrayado.Appearance = Appearance.Button;
			btnNegrita.TextAlign = ContentAlignment.MiddleRight;
			btnCursiva.TextAlign = ContentAlignment.MiddleRight;
			btnSubrayado.TextAlign = ContentAlignment.MiddleRight;
			btnNegrita.Font = new Font ("Arial", 12, FontStyle.Bold);
			btnCursiva.Font = new Font ("Arial", 12, FontStyle.Italic);
			btnSubrayado.Font = new Font ("Arial", 12, FontStyle.Underline);

			btnLoad.Click += delegate (object sender, EventArgs e) {
				Abrir ();
			};

			btnSave.Click += delegate (object sender, EventArgs e) {
				Guardar ();
			};

			btnNegrita.Click += delegate (object sender, EventArgs e) {
				AplicarEstilo();
				richTextBox.Focus ();
			};

			btnCursiva.Click += delegate (object sender, EventArgs e) {
				AplicarEstilo();
				richTextBox.Focus ();
			};

			btnSubrayado.Click += delegate (object sender, EventArgs e) {
				AplicarEstilo();
				richTextBox.Focus ();
			};

			flowLayoutPanel = new FlowLayoutPanel ();
			flowLayoutPanel.Controls.Add (btnLoad);
			flowLayoutPanel.Controls.Add (btnSave);
			flowLayoutPanel.Controls.Add (btnNegrita);
			flowLayoutPanel.Controls.Add (btnCursiva);
			flowLayoutPanel.Controls.Add (btnSubrayado);
			flowLayoutPanel.AutoSize = true;

			richTextBox = new RichTextBox ();
			richTextBox.Multiline = true;
			richTextBox.Dock = DockStyle.Fill;
			richTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
			richTextBox.Font = new Font ("Arial", 12, FontStyle.Regular);

			tableLayoutPanel = new TableLayoutPanel ();
			tableLayoutPanel.Padding = new Padding (5);

			// Suspende temporalmente la lógica de diseño del control
			tableLayoutPanel.SuspendLayout(); 
			tableLayoutPanel.Dock = DockStyle.Fill;
			tableLayoutPanel.Controls.Add (flowLayoutPanel);
			tableLayoutPanel.Controls.Add (richTextBox);

			// Reanuda la lógica de diseño habitual
			tableLayoutPanel.ResumeLayout(false);
			Controls.Add(tableLayoutPanel);

			// Establece el foco inicial en el TextBox
			tableLayoutPanel.Paint += delegate {
				richTextBox.Focus ();
			};

			MinimumSize = new Size (800, 600);
		}

		/// <summary>
		/// Sale de la aplicación liberando los recursos.
		/// </summary>
		public void Salir()
		{
			Dispose (true);
		}

		/// <summary>
		/// Corta el texto seleccionado al portapapeles.
		/// </summary>
		public void Cortar() 
		{
			if (richTextBox.SelectionLength > 0) {
				richTextBox.Cut ();
			}
		}

		/// <summary>
		/// Copia el texto seleccionado al portapapeles.
		/// </summary>
		public void Copiar() 
		{
			if (richTextBox.SelectionLength > 0) {
				richTextBox.Copy ();
			}
		}

		/// <summary>
		/// Pega el texto seleccionado al portapapeles.
		/// </summary>
		public void Pegar() 
		{
			// Determina si hay algún texto en el portapapeles para pegar en el cuadro de texto.
			if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text)) {

				if (richTextBox.SelectionLength > 0) {
					richTextBox.SelectionStart = 
						richTextBox.SelectionStart + richTextBox.SelectionLength;
				}

				richTextBox.Paste();
			}
		}

		/// <summary>
		/// Deshace una acción almacenada en el búffer.
		/// </summary>
		public void Deshacer() 
		{
			// determinar si la última operación se puede deshacer
			if (richTextBox.CanUndo == true) {
				richTextBox.Undo();

				// Borra del búfer la última acción
				richTextBox.ClearUndo();
			}
		}

		/// <summary>
		/// Guarda el contenido del TextBox en un fichero rtf.
		/// </summary>
		public void Guardar()
		{
			saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "RTF Files (*.rtf)|*.rtf";
			saveFileDialog.FilterIndex = 0 ;
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.CreatePrompt = true;
			saveFileDialog.FileName = null;
			saveFileDialog.Title = "Guardar documento";

			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				richTextBox.SaveFile (saveFileDialog.FileName);
			}

		}

		/// <summary>
		///  Carga un fichero rtf en el TextBox.
		/// </summary>
		public void Abrir() 
		{
			openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "RTF Files (*.rtf)|*.rtf";
			openFileDialog.FilterIndex = 0 ;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.FileName = null;
			openFileDialog.Title = "Abrir documento";

			if (openFileDialog.ShowDialog () == DialogResult.OK) {
				richTextBox.LoadFile (openFileDialog.FileName);
			}
		}

		/// <summary>
		/// Exporta el contenido del TextBox (formato rtf) a xml.
		/// </summary>
		public void ExportarXml() {
			saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "XML files (*.xml)|*.xml";
			saveFileDialog.FilterIndex = 0 ;
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.CreatePrompt = true;
			saveFileDialog.FileName = null;
			saveFileDialog.Title = "Exportar en formato XML";

			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				Utilidades.ExportarXml (saveFileDialog.FileName, richTextBox.Rtf);
			}
		}

		/// <summary>
		/// Exporta el contenido del TextBox (formato rtf) a html.
		/// </summary>
		public void ExportarHtml() {
			saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "HTML files (*.html)|*.html";
			saveFileDialog.FilterIndex = 0 ;
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.CreatePrompt = true;
			saveFileDialog.FileName = null;
			saveFileDialog.Title = "Exportar en formato HTML";

			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				Utilidades.ExportarHtml (saveFileDialog.FileName, richTextBox.Rtf);
			}
		}

		/// <summary>
		/// Establece el tipo de fuente en el TextBox
		/// </summary>
		public void AplicarEstilo() 
		{
			if ((btnNegrita.CheckState == CheckState.Checked) &&
			    (btnCursiva.CheckState == CheckState.Checked) && 
			    (btnSubrayado.CheckState == CheckState.Checked)) {

				richTextBox.SelectionFont = new Font (
					richTextBox.Font, 
					FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

			} else if ((btnNegrita.CheckState == CheckState.Checked) && 
			           (btnCursiva.CheckState == CheckState.Checked)) {

				richTextBox.SelectionFont = new Font (
					richTextBox.Font, 
					FontStyle.Bold | FontStyle.Italic);

			} else if ((btnNegrita.CheckState == CheckState.Checked) && 
			           (btnSubrayado.CheckState == CheckState.Checked)) {

				richTextBox.SelectionFont = new Font (
					richTextBox.Font, 
					FontStyle.Bold | FontStyle.Underline);

			} else if ((btnCursiva.CheckState == CheckState.Checked) && 
			           (btnSubrayado.CheckState == CheckState.Checked)) {

				richTextBox.SelectionFont = new Font (
					richTextBox.Font, 
					FontStyle.Italic | FontStyle.Underline);

			} else {

				if (btnNegrita.CheckState == CheckState.Checked) {
					richTextBox.SelectionFont = new Font (
						richTextBox.Font, 
						FontStyle.Bold);

				} else if (btnCursiva.CheckState == CheckState.Checked) {
					richTextBox.SelectionFont = new Font (
						richTextBox.Font, 
						FontStyle.Italic);

				} else if (btnSubrayado.CheckState == CheckState.Checked) {
					richTextBox.SelectionFont = new Font (
						richTextBox.Font, 
						FontStyle.Underline);

				} else {
					richTextBox.SelectionFont = new Font (
						richTextBox.Font, 
						FontStyle.Regular);
				}
			}
		}

		private void ConstruirGui()
		{
			this.Text = "Procesador de textos";

			ConstruirMenu ();
			ConstruirPanel ();
		}

		private TableLayoutPanel tableLayoutPanel;
		private FlowLayoutPanel flowLayoutPanel;
		private Button btnSave;
		private Button btnLoad;
		private CheckBox btnNegrita;
		private CheckBox btnCursiva;
		private CheckBox btnSubrayado;
		private RichTextBox richTextBox;
		private MainMenu mainMenu;
		private MenuItem menuArchivo;
		private MenuItem menuEditar;
		private MenuItem operacionGuardar;
		private MenuItem operacionAbrir;
		private MenuItem operacionExportarXml;
		private MenuItem operacionExportarHtml;
		private MenuItem operacionSalir;
		private MenuItem operacionCortar;
		private MenuItem operacionCopiar;
		private MenuItem operacionPegar;
		private MenuItem operacionDeshacer;
		private SaveFileDialog saveFileDialog;
		private OpenFileDialog openFileDialog;

	}
}
