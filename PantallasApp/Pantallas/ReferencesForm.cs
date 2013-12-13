using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{	
	/// <summary>
	/// Panel de control para la gestión de referencias.
	/// </summary>
	public class ReferencesForm : Form			
	{
		private static List<Referencia> listado;

		private static Panel mainPanel;
		private static Form insertForm;

		private static TextBox txtAutoria;
		private static TextBox txtTitulo;
		private static TextBox txtDatos;
		private static TextBox txtEdicion;
		private static TextBox txtExtension;		

		private static DataGridView gridView;
		
		private static StatusBar sbStatus;

		/// <summary>
		/// Initializes a new instance of the <see cref="Referencias.ReferencesForm"/> class.
		/// </summary>
		public ReferencesForm(){
			listado = Program.Book.Referencias;

			SuspendLayout();
			MinimumSize = new Size(640, 430);
			mainPanel = new Panel();
			mainPanel.MinimumSize = new Size(640, 360);
			
			Controls.Add( mainPanel );		
			
			BuildMenu();
			CreateGridView();
			BuildInsertUpdateDialog();
			BuildStatus();
			UpdateGridData();
			Resize += (obj, e) => ResizeWindow();				
			
			ResizeWindow();

			mainPanel.ResumeLayout( false );
			ResumeLayout( true );
			Closed += (sender, e) => Salir();
			
			Text = "Gestor de Referencias";	
			this.Show();
		}

		/// <summary>
		/// Construye el menu		
		/// </summary>
		private void BuildMenu(){
			MainMenu Actions = new MainMenu();			
			
			MenuItem mArchivo = new MenuItem( "&Archivo" );
			MenuItem mEditar = new MenuItem( "&Editar");			
			
			MenuItem opSalir = new MenuItem( "&Salir" );
			opSalir.Shortcut = Shortcut.CtrlQ;
			opSalir.Click += (sender, e) => Salir();
			
			MenuItem opSave = new MenuItem( "&Salvar" );
			opSave.Shortcut = Shortcut.CtrlS;

			MenuItem opInsertar = new MenuItem( "&Insertar" );
			opInsertar.Shortcut = Shortcut.CtrlI;
			opInsertar.Click += (sender, e) => InsertReferencia();
			
			MenuItem opEliminar = new MenuItem("&Eliminar");
			opEliminar.Shortcut = Shortcut.CtrlR;
			opEliminar.Click += (sender, e) => DeleteReferencia();
			
			MenuItem opEditar = new MenuItem("&Editar");
			opEditar.Shortcut = Shortcut.CtrlE;
			opEditar.Click += (sender, e) => UpdateReferencia();
			
			mArchivo.MenuItems.Add( opSave );
			mArchivo.MenuItems.Add( opSalir );			
			
			mEditar.MenuItems.Add( opInsertar );
			mEditar.MenuItems.Add( opEliminar );
			mEditar.MenuItems.Add( opEditar );
			 
			Actions.MenuItems.Add( mArchivo );
			Actions.MenuItems.Add( mEditar );
			Menu = Actions;			
		}
		/// <summary>
		/// Crea un objeto DataGridView para la muestra y gestión de los datos almacenados
		/// </summary>
		private void CreateGridView(){			
			
			mainPanel.SuspendLayout();						
			
			gridView = new DataGridView();
			gridView.Anchor = AnchorStyles.Top;
			gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			gridView.Dock = DockStyle.Fill;
			
			gridView.AllowUserToResizeRows = false;
			gridView.AllowUserToResizeColumns = true;
			gridView.RowHeadersVisible = false;
			gridView.AutoGenerateColumns = false;
			gridView.MultiSelect = false;			
			gridView.AllowUserToAddRows = false;
			gridView.ReadOnly = true;
			gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;			
			gridView.ScrollBars = ScrollBars.Vertical;
			gridView.MinimumSize = new Size(960, 360);				
			
			var column0 = new DataGridViewTextBoxColumn();
			var column1 = new DataGridViewTextBoxColumn();
			var column2 = new DataGridViewTextBoxColumn();
			var column3 = new DataGridViewTextBoxColumn();
			var column4 = new DataGridViewTextBoxColumn();
			var column5 = new DataGridViewTextBoxColumn();
			
			column0.SortMode = DataGridViewColumnSortMode.NotSortable;
			column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			column2.SortMode = DataGridViewColumnSortMode.NotSortable;
			column3.SortMode = DataGridViewColumnSortMode.NotSortable;
			column4.SortMode = DataGridViewColumnSortMode.NotSortable;
			column5.SortMode = DataGridViewColumnSortMode.NotSortable;
			
			column0.HeaderText = "-";
			column1.HeaderText = "Autoria";	
			column2.HeaderText = "Titulo";
			column3.HeaderText = "Datos";
			column4.HeaderText = "Edicion";		
			column5.HeaderText = "Extension";

			gridView.Columns.AddRange( new DataGridViewColumn[] {
				column0, column1, column2, column3, column4, column5
			} );			
			
			mainPanel.Controls.Add( gridView );
			mainPanel.ResumeLayout( true );
		}
		
		/// <summary>
		/// Construye el panel de diálogo empleado en la inserción y el borrado
		/// </summary>
		private void BuildInsertUpdateDialog(){
			insertForm = new Form();
			insertForm.SuspendLayout();

			var pnlInserta = new TableLayoutPanel();
			pnlInserta.Dock = DockStyle.Fill;
			pnlInserta.SuspendLayout();
			insertForm.Controls.Add( pnlInserta );

			//Autoria
			var pnlAutoria = new Panel();
			txtAutoria = new TextBox();
			txtAutoria.Dock = DockStyle.Fill;
			var labelAutoria = new Label();
			labelAutoria.Text = "Autoria:";
			labelAutoria.Dock = DockStyle.Left;
			pnlAutoria.Controls.Add( txtAutoria );
			pnlAutoria.Controls.Add( labelAutoria );
			pnlAutoria.Dock = DockStyle.Top;
			pnlAutoria.MaximumSize = new Size( int.MaxValue, txtAutoria.Height * 2 );
			pnlInserta.Controls.Add( pnlAutoria );

			//Titulo
			var pnlTitulo = new Panel();
			txtTitulo = new TextBox();
			txtTitulo.Dock = DockStyle.Fill;
			var labelTitulo = new Label();
			labelTitulo.Text = "Titulo:";
			labelTitulo.Dock = DockStyle.Left;
			pnlTitulo.Controls.Add( txtTitulo );
			pnlTitulo.Controls.Add( labelTitulo );
			pnlTitulo.Dock = DockStyle.Top;
			pnlTitulo.MaximumSize = new Size( int.MaxValue, txtTitulo.Height * 2 );
			pnlInserta.Controls.Add( pnlTitulo );

			//Datos
			var pnlDatos = new Panel();
			txtDatos = new TextBox();
			txtDatos.Dock = DockStyle.Fill;
			var labelDatos = new Label();
			labelDatos.Text = "Datos:";
			labelDatos.Dock = DockStyle.Left;
			pnlDatos.Controls.Add( txtDatos );
			pnlDatos.Controls.Add( labelDatos );
			pnlDatos.Dock = DockStyle.Top;
			pnlDatos.MaximumSize = new Size( int.MaxValue, txtDatos.Height * 2 );
			pnlInserta.Controls.Add( pnlDatos );

			//Edicion
			var pnlEdicion = new Panel();
			txtEdicion = new TextBox();
			txtEdicion.Dock = DockStyle.Fill;
			var labelEdicion = new Label();
			labelEdicion.Text = "Edición:";
			labelEdicion.Dock = DockStyle.Left;
			pnlEdicion.Controls.Add( txtEdicion );
			pnlEdicion.Controls.Add( labelEdicion );
			pnlEdicion.Dock = DockStyle.Top;
			pnlEdicion.MaximumSize = new Size( int.MaxValue, txtEdicion.Height * 2 );
			pnlInserta.Controls.Add( pnlEdicion );

			//Extension
			var pnlExtension = new Panel();
			txtExtension = new TextBox();
			txtExtension.Dock = DockStyle.Fill;
			var labelExtension = new Label();
			labelExtension.Text = "Extensión:";
			labelExtension.Dock = DockStyle.Left;
			pnlExtension.Controls.Add( txtExtension );
			pnlExtension.Controls.Add( labelExtension );
			pnlExtension.Dock = DockStyle.Top;
			pnlExtension.MaximumSize = new Size( int.MaxValue, txtEdicion.Height * 2 );
			pnlInserta.Controls.Add( pnlExtension );
			
			//Panel Botones			
			var pnlBotones = new TableLayoutPanel();
			pnlBotones.ColumnCount = 2;
			pnlBotones.RowCount = 1;
			var btCierra = new Button();
			btCierra.DialogResult = DialogResult.Cancel;
			btCierra.Text = "&Cancelar";
			var btGuarda = new Button();
			btGuarda.DialogResult = DialogResult.OK;
			btGuarda.Text = "&Guardar";
			pnlBotones.Controls.Add( btGuarda );
			pnlBotones.Controls.Add( btCierra );
			pnlBotones.Dock = DockStyle.Top;
			pnlInserta.Controls.Add( pnlBotones );

			insertForm.AcceptButton = btGuarda;
			insertForm.CancelButton = btCierra;
			pnlInserta.ResumeLayout( true );
			insertForm.ResumeLayout( false );			
			insertForm.Size = new Size( 400, 
			                pnlAutoria.Height + pnlTitulo.Height
			                + pnlDatos.Height + pnlEdicion.Height
			                + pnlExtension.Height + pnlBotones.Height );
			insertForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			insertForm.MinimizeBox = false;
			insertForm.MaximizeBox = false;
			insertForm.StartPosition = FormStartPosition.CenterParent;
		}		
		/// <summary>
		/// Crea la barra de estado informando del total de referencias
		/// </summary>
		private void BuildStatus()
		{
			sbStatus = new StatusBar();
			sbStatus.Dock = DockStyle.Bottom;
			Controls.Add( sbStatus );
		}

		/// <summary>
		/// Inserts the referencia.
		/// </summary>
		public static void InsertReferencia(){
			insertForm.Text = "Crear Nueva Referencia";
			
			txtAutoria.Text = "";
			txtEdicion.Text = "";
			txtDatos.Text = "";
			txtExtension.Text = "";
			txtTitulo.Text = "";
			
			if ( insertForm.ShowDialog() == DialogResult.OK ) {
				Referencia r = new Referencia(txtAutoria.Text,txtTitulo.Text,txtDatos.Text,txtEdicion.Text,txtExtension.Text)	;
				listado.Add(r);
			}
			UpdateGridData();
		}
		
		/// <summary>
		/// Elimina la referencia actualmente seleccionada en el GridView
		/// </summary>
		private void DeleteReferencia(){
			if (gridView.Rows.Count > 0){				
				int n = gridView.CurrentCell.RowIndex;												
				
				//Confirmación de borrado
				if (MessageBox.Show("Realmente quiere borrar esta entrada?","Confirmar Borrado", MessageBoxButtons.YesNo) == DialogResult.Yes)
			   {
					listado.RemoveAt(n);
					UpdateGridData();	
			   }
			}else MessageBox.Show("Ninguna fila seleccionada","Error");
		}
		
		/// <summary>
		/// Actualiza la referencia actualmente seleccionada en el GridView
		/// </summary>
		private void UpdateReferencia(){
			if (gridView.Rows.Count > 0){
				insertForm.Text = "Editar Referencia";
				
				int n = gridView.CurrentCell.RowIndex;				
								
				Referencia r = listado[n];
				
				txtAutoria.Text = r.Autoria;
				txtEdicion.Text = r.Edicion;
				txtDatos.Text = r.Datos;
				txtExtension.Text = r.Extension;
				txtTitulo.Text = r.Titulo;
				
				if ( insertForm.ShowDialog() == DialogResult.OK ) {
					r.Autoria = txtAutoria.Text;
					r.Titulo = txtTitulo.Text;
					r.Datos = txtDatos.Text;
					r.Edicion = txtEdicion.Text;
					r.Extension = txtExtension.Text;
				}
				UpdateGridData();
			}else MessageBox.Show("Ninguna fila seleccionada","Error");
		}
		
		/// <summary>
		/// Reajusta la GridView
		/// </summary>
		private void ResizeWindow(){
			// Tomar las nuevas medidas
			int width = ClientRectangle.Width;			
			
			// Redimensionar la tabla
			gridView.Width = width;
			mainPanel.Width = width;
			gridView.Columns[ 0 ].Width = 	(int) Math.Floor( width *.05 );	
			gridView.Columns[ 1 ].Width =	(int) Math.Floor( width *.20 );	
			gridView.Columns[ 2 ].Width =	(int) Math.Floor( width *.35 );	
			gridView.Columns[ 3 ].Width =	(int) Math.Floor( width *.20 ); 
			gridView.Columns[ 4 ].Width =	(int) Math.Floor( width *.10 ); 
			gridView.Columns[ 5 ].Width =	(int) Math.Floor( width *.10 ); 
		}
		
		/// <summary>
		/// Actualiza los datos del GridView en uso
		/// </summary>
		private static void UpdateGridData(){
			int n=0;	
			foreach (Referencia r in listado) {
				if( n >= gridView.Rows.Count )
					gridView.Rows.Add();
				
				DataGridViewRow row = gridView.Rows[ n++ ];	
				row.Cells[0].Value = n;								
				row.Cells[1].Value = r.Autoria;
				row.Cells[2].Value = r.Titulo;
				row.Cells[3].Value = r.Datos;
				row.Cells[4].Value = r.Edicion;
				row.Cells[5].Value = r.Extension;					
			}
			//Limpieza de filas sobrantes
			while( n < gridView.Rows.Count)
				gridView.Rows.RemoveAt(gridView.Rows.Count - 1);
			
			sbStatus.Text= "Total de Referencias = " + n;
		}	

		/// <summary>
		/// Cierre de App
		/// </summary>
		private void Salir(){
		}						
	}
}

