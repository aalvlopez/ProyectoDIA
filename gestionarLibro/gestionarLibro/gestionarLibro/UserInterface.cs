using System;
using System.Drawing;
using System.Windows.Forms;

using Scrivener;

namespace Scrivener {
	public class UserInterface: Form {

		public UserInterface (IPersistencia objectPersistencia, Panel panel)
		{
			this.ObjectPersistencia = objectPersistencia;
			this.Ppanel = panel;
			this.Book = objectPersistencia.Leer();
			this.BuildGui();
		}

	    public void BuildGui()
	    {
	        this.TreeView1 = new TreeView();

	        this.SuspendLayout();
			this.Ppanel.SuspendLayout();
			this.Ppanel.Dock=DockStyle.Left;
			this.Ppanel.Location = new Point(0,25);
			
	        this.TreeView1.Location = new Point(15, 25);
	        this.TreeView1.Size = new Size(200, 350);
			this.TreeView1.Dock=DockStyle.Fill;
	        
			this.EscribirTree();

			
			var panelTree = new Panel();
			panelTree.SuspendLayout();
			panelTree.Size = new Size (this.TreeView1.Size.Width+30);
			panelTree.Location = new Point(this.Ppanel.Size.Width, 0);
			panelTree.Controls.Add(this.TreeView1);

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
	    }

		private void EscribirTree ()
		{
			TreeNode node;

			node = this.TreeView1.Nodes.Add (this.Book.Titulo);
			node = this.TreeView1.Nodes.Add ("Capitulos");
			TreeNode node2;
			foreach (Capitulo capitulo in this.Book.Capitulos) {
				node2 = node.Nodes.Add(capitulo.Anotacion,capitulo.Titulo);
				foreach(Escena escena in capitulo.Escenas){
					node2.Nodes.Add(escena.Anotacion ,escena.Titulo, escena.Contenido);
				}
			}

		}
		private void PulsarNodo()
		{
		}
		
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
		/// Objeto que contiene toda la informacion de <see cref="Libro"/>
		/// </value>
		private Libro Book {
			get;
			set;
		}
		
		/// <summary>
		/// Gets y sets de la propiedad Ppanel.
		/// </summary>
		/// <value>
		/// Objeto Panel contenido en el winForm
		/// </value>
		private Panel Ppanel {
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad ObjectPersistencia.
		/// </summary>
		/// <value>
		/// Objeto que proporciona los metodos para actualizar treeView nuevos datos.
		/// </value>
		public IPersistencia ObjectPersistencia{
			get;
			set;
		}
	}
}

