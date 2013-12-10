using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;

namespace Referencias
{	
	/// <summary>
	/// Panel de control para la gestión de referencias.
	/// </summary>
	public class ReferencesMainPanel : Form			
	{
		private List<Referencia> listado;
		
		private Panel mainPanel;
		private Form insertForm;

		private TextBox txtAutoria;
		private TextBox txtTitulo;
		private TextBox txtDatos;
		private TextBox txtEdicion;
		private TextBox txtExtension;		

		private DataGridView gridView;
		
		private StatusBar sbStatus;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Referencias.ReferencesMainPanel"/> class.
		/// </summary>
		public ReferencesMainPanel(){
			//listado = Referencia.LoadXml();

			listado = Libro.ListReferencias();

			this.SuspendLayout();
			this.MinimumSize = new Size(640, 430);
			this.mainPanel = new Panel();
			this.mainPanel.MinimumSize = new Size(640, 360);
			
			this.Controls.Add( mainPanel );		
			
			this.BuildMenu();
			this.CreateGridView();
			this.BuildInsertUpdateDialog();
			this.BuildStatus();
			this.UpdateGridData();
			this.Resize += (obj, e) => this.ResizeWindow();				
			
			this.ResizeWindow();

			mainPanel.ResumeLayout( false );
			this.ResumeLayout( true );
			this.Closed += (sender, e) => this.Salir();
			
			this.Text = "Gestor de Referencias";
			
			
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
			opSalir.Click += (sender, e) => this.Salir();
			
			MenuItem opSave = new MenuItem( "&Salvar" );
			opSave.Shortcut = Shortcut.CtrlS;
			opSave.Click += (sender, e) => this.Save();

			MenuItem opInsertar = new MenuItem( "&Insertar" );
			opInsertar.Shortcut = Shortcut.CtrlI;
			opInsertar.Click += (sender, e) => this.InsertReferencia();
			
			MenuItem opEliminar = new MenuItem("&Eliminar");
			opEliminar.Shortcut = Shortcut.CtrlR;
			opEliminar.Click += (sender, e) => this.DeleteReferencia();
			
			MenuItem opEditar = new MenuItem("&Editar");
			opEditar.Shortcut = Shortcut.CtrlE;
			opEditar.Click += (sender, e) => this.UpdateReferencia();
			
			mArchivo.MenuItems.Add( opSave );
			mArchivo.MenuItems.Add( opSalir );			
			
			mEditar.MenuItems.Add( opInsertar );
			mEditar.MenuItems.Add( opEliminar );
			mEditar.MenuItems.Add( opEditar );
			 
			Actions.MenuItems.Add( mArchivo );
			Actions.MenuItems.Add( mEditar );
			this.Menu = Actions;			
		}
		/// <summary>
		/// Crea un objeto DataGridView para la muestra y gestión de los datos almacenados
		/// </summary>
		private void CreateGridView(){			
			
			mainPanel.SuspendLayout();						
			
			this.gridView = new DataGridView();
			this.gridView.Anchor = AnchorStyles.Top;
			this.gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.gridView.Dock = DockStyle.Fill;
			
			this.gridView.AllowUserToResizeRows = false;
			this.gridView.AllowUserToResizeColumns = true;
			this.gridView.RowHeadersVisible = false;
			this.gridView.AutoGenerateColumns = false;
			this.gridView.MultiSelect = false;			
			this.gridView.AllowUserToAddRows = false;
			this.gridView.ReadOnly = true;
			this.gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;			
			this.gridView.ScrollBars = ScrollBars.Vertical;
			this.gridView.MinimumSize = new Size(960, 360);				
			
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
			this.insertForm = new Form();
			this.insertForm.SuspendLayout();

			var pnlInserta = new TableLayoutPanel();
			pnlInserta.Dock = DockStyle.Fill;
			pnlInserta.SuspendLayout();
			this.insertForm.Controls.Add( pnlInserta );

			//Autoria
			var pnlAutoria = new Panel();
			this.txtAutoria = new TextBox();
			this.txtAutoria.Dock = DockStyle.Fill;
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
			this.txtTitulo = new TextBox();
			this.txtTitulo.Dock = DockStyle.Fill;
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
			this.txtDatos = new TextBox();
			this.txtDatos.Dock = DockStyle.Fill;
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
			this.txtEdicion = new TextBox();
			this.txtEdicion.Dock = DockStyle.Fill;
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
			this.txtExtension = new TextBox();
			this.txtExtension.Dock = DockStyle.Fill;
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

			this.insertForm.AcceptButton = btGuarda;
			this.insertForm.CancelButton = btCierra;
			pnlInserta.ResumeLayout( true );
			this.insertForm.ResumeLayout( false );			
			this.insertForm.Size = new Size( 400, 
			                pnlAutoria.Height + pnlTitulo.Height
			                + pnlDatos.Height + pnlEdicion.Height
			                + pnlExtension.Height + pnlBotones.Height );
			this.insertForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.insertForm.MinimizeBox = false;
			this.insertForm.MaximizeBox = false;
			this.insertForm.StartPosition = FormStartPosition.CenterParent;
		}
		
		/// <summary>
		/// Crea la barra de estado informando del total de referencias
		/// </summary>
		private void BuildStatus()
		{
			this.sbStatus = new StatusBar();
			this.sbStatus.Dock = DockStyle.Bottom;
			this.Controls.Add( this.sbStatus );
		}

		/// <summary>
		/// Inserts the referencia.
		/// </summary>
		private void InsertReferencia(){
			this.insertForm.Text = "Crear Nueva Referencia";
			
			this.txtAutoria.Text = "";
			this.txtEdicion.Text = "";
			this.txtDatos.Text = "";
			this.txtExtension.Text = "";
			this.txtTitulo.Text = "";
			
			if ( this.insertForm.ShowDialog() == DialogResult.OK ) {
				Referencia r = new Referencia(txtAutoria.Text,txtTitulo.Text,txtDatos.Text,txtEdicion.Text,txtExtension.Text)	;
				listado.Add(r);
			}
			UpdateGridData();
		}
		
		/// <summary>
		/// Elimina la referencia actualmente seleccionada en el GridView
		/// </summary>
		private void DeleteReferencia(){
			if (this.gridView.Rows.Count > 0){				
				int n = this.gridView.CurrentCell.RowIndex;												
				
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
			if (this.gridView.Rows.Count > 0){
				this.insertForm.Text = "Editar Referencia";
				
				int n = this.gridView.CurrentCell.RowIndex;				
								
				Referencia r = listado[n];
				
				this.txtAutoria.Text = r.Autoria;
				this.txtEdicion.Text = r.Edicion;
				this.txtDatos.Text = r.Datos;
				this.txtExtension.Text = r.Extension;
				this.txtTitulo.Text = r.Titulo;
				
				if ( this.insertForm.ShowDialog() == DialogResult.OK ) {
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
			int width = this.ClientRectangle.Width;			
			
			// Redimensionar la tabla
			this.gridView.Width = width;
			this.mainPanel.Width = width;
			this.gridView.Columns[ 0 ].Width = 	(int) Math.Floor( width *.05 );	
			this.gridView.Columns[ 1 ].Width =	(int) Math.Floor( width *.20 );	
			this.gridView.Columns[ 2 ].Width =	(int) Math.Floor( width *.35 );	
			this.gridView.Columns[ 3 ].Width =	(int) Math.Floor( width *.20 ); 
			this.gridView.Columns[ 4 ].Width =	(int) Math.Floor( width *.10 ); 
			this.gridView.Columns[ 5 ].Width =	(int) Math.Floor( width *.10 ); 
		}
		
		
		/// <summary>
		/// Actualiza los datos del GridView en uso
		/// </summary>
		private void UpdateGridData(){
			int n=0;	
			foreach (Referencia r in this.listado) {
				if( n >= this.gridView.Rows.Count )
					this.gridView.Rows.Add();
				
				DataGridViewRow row = this.gridView.Rows[ n++ ];	
				row.Cells[0].Value = n;								
				row.Cells[1].Value = r.Autoria;
				row.Cells[2].Value = r.Titulo;
				row.Cells[3].Value = r.Datos;
				row.Cells[4].Value = r.Edicion;
				row.Cells[5].Value = r.Extension;					
			}
			//Limpieza de filas sobrantes
			while( n < this.gridView.Rows.Count)
				this.gridView.Rows.RemoveAt(this.gridView.Rows.Count - 1);
			
			this.sbStatus.Text= "Total de Referencias = " + n;
		}	

		/// <summary>
		/// Save this instance.
		/// </summary>
		private void Save(){
			Referencia.SaveToXml(listado);	
		}
		
		
		/// <summary>
		/// Cierre de App
		/// </summary>
		private void Salir(){
			this.Save();
			this.Dispose( true );
		}						
	}
}

