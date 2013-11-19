using System;
using System.Drawing;
using System.Windows.Forms;

namespace treeviewCapitulosPersonajes{
	/// <summary>
	/// Esta es la clase encargada de dibujar el winForm con el treeview.
	/// </summary>
	public class Formulario : Form, ITreeLateral 
	{
		/// <summary>
		/// Gets y sets de la propiedad TreeView1.
		/// </summary>
		/// <value>
		/// Contien el objeto TreeView que estará presente en el WinForm
		/// </value>
	    private TreeView TreeView1 {
			get;
			set;
		}
		/// <summary>
		///Gets y sets de la propiedad Book.
		/// </summary>
		/// <value>
		/// Contine un objeto <see cref="treeviewCapitulosPersonajes.Libro"/> 
		/// que proporciona toda la informacion necesaria del libro
		/// </value>
		private Libro Book {
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad Ppanel.
		/// </summary>
		/// <value>
		/// Contiene un objeto Panel que estara presente en el winForm.
		/// </value>
		private Panel Ppanel {
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad ObjectPersistencia.
		/// </summary>
		/// <value>
		/// Objeto que proporciona los metodos para actualizar el treeView 
		/// nueva informacion guardad en disco.
		/// </value>
		public IPersistencia ObjectPersistencia{
			get;
			set;
		}
		/// <summary>
		/// Inicializa una instacia de la clase <see cref="treeviewCapitulosPersonajes.Formulario"/>.
		/// </summary>
		/// <param name='objectPersistencia'>
		/// Objeto que contiene los metodos para la lectura de los datos necesarios para la creacion del Treeview.
		/// </param>
		/// <param name='libro'>
		/// Objeto de tipo <see cref="treeviewCapitulosPersonajes.Libro"/> que contiene todos los datos del libro.
		/// </param>
		/// <param name='panel'>
		/// Panel al cual le agregaremos por la derecha el TreeView que se creara.
		/// </param>
		public Formulario (string nomFichero, Panel panel)
		{
			this.ObjectPersistencia = new XmlPersistencia(nomFichero);
			this.Ppanel = panel;
			this.Book = this.ObjectPersistencia.Lectura();
			this.BuildGui();
		}
		/// <summary>
		/// Este metodo se encarga de la construccion del winForm con el TreeView y el panel que se le ha pasado.
		/// </summary>
	    public void BuildGui()
	    {
	        this.TreeView1 = new TreeView();

	        this.SuspendLayout();
			this.Ppanel.SuspendLayout();
			this.Ppanel.Dock=DockStyle.Left;
			this.Ppanel.Location = new Point(0,25);

			
			var btActualizar = new Button ();
			btActualizar.Text = "&Actualizar";
			btActualizar.Location = new Point (15,0);
			btActualizar.Size = new Size(200, 20);
			btActualizar.Dock = DockStyle.Top;


	        // Initialize treeView1.
	        this.TreeView1.Location = new Point(15, 25);
	        this.TreeView1.Size = new Size(200, 350);
			this.TreeView1.Dock=DockStyle.Fill;
	        
			this.EscribirTree();

			
			var panelTree = new Panel();
			panelTree.SuspendLayout();
			panelTree.Size = new Size (this.TreeView1.Size.Width+30, this.TreeView1.Size.Height+btActualizar.Size.Height+30);
			panelTree.Location = new Point(this.Ppanel.Size.Width, 0);
			panelTree.Controls.Add(this.TreeView1);
			panelTree.Controls.Add (btActualizar);

			panelTree.Dock= DockStyle.Right;


			var pnlPal = new Panel();
			pnlPal.SuspendLayout();
			pnlPal.Controls.Add(this.Ppanel);
			pnlPal.Controls.Add(panelTree);
			pnlPal.Size = new Size(this.Ppanel.Size.Width+ panelTree.Size.Width , this.Ppanel.Size.Height+30);
			this.MinimumSize = new Size (pnlPal.Size.Width , pnlPal.Size.Height+30);
			this.Controls.AddRange(new Control[]{ pnlPal} );
			pnlPal.ResumeLayout(false);
			this.Ppanel.ResumeLayout (false);
	        this.ResumeLayout(false);
			this.TreeView1.NodeMouseDoubleClick+=delegate(object sender, TreeNodeMouseClickEventArgs e){
				this.PulsarNodo();
			};
			btActualizar.Click += delegate(object sender , EventArgs e){
				this.Actualizar();
			};
	    }
		/// <summary>
		/// Metodo utilizado para actualizar el contenido del TreeView.
		/// </summary>
		public void Actualizar(){
			this.Book=this.ObjectPersistencia.Lectura();
			TreeView1.BeginUpdate();
			this.TreeView1.Nodes.Clear(); 
			this.EscribirTree();
			this.TreeView1.EndUpdate();
			this.Controls.Clear();
			this.BuildGui();
		}
		/// <summary>
		/// Este metodo construye el treeView utilizando los datos del objeto libro.
		/// </summary>
		private void EscribirTree ()
		{
			TreeNode node;

			node = this.TreeView1.Nodes.Add (this.Book.Titulo);
			node = this.TreeView1.Nodes.Add ("Capitulos");
			TreeNode node2;
			foreach (Capitulo capitulo in this.Book.ListCapitulos) {
				node2 = node.Nodes.Add(capitulo.Id,capitulo.Titulo);
				foreach(Escena escena in capitulo.ListEscenas){
					node2.Nodes.Add(escena.Id ,escena.Titulo);
				}
			}
	        node = this.TreeView1.Nodes.Add ("Personajes");   
			foreach (Personaje personaje in this.Book.ListPersonajes) {
				node2 = node.Nodes.Add(personaje.Id, personaje.Nombre);
			}
		}
		private void PulsarNodo()
		{

		}

	}
}