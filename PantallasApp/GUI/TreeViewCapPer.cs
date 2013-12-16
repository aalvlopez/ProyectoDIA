using System;
using System.Drawing;
using System.Windows.Forms;

namespace DIAScribe{
	/// <summary>
	/// Esta es la clase encargada de dibujar el winForm con el treeview.
	/// </summary>
	public class TreeViewCapPer : Form 
	{
		/// <summary>
		/// Este metodo se encarga de la construccion del winForm con el TreeView y el panel que se le ha pasado.
		/// </summary>
	    public static TreeView BuildTree(Libro book)
	    {
	        TreeView treeView1 = new TreeView();
			TreeViewCapPer.EscribirTree(book,treeView1);
			return treeView1;
		    }
		/// <summary>
		/// Metodo utilizado para actualizar el contenido del TreeView.
		/// </summary>
		public static TreeView Actualizar(Libro book, TreeView treeView1){
			treeView1.BeginUpdate();
			treeView1.Nodes.Clear(); 
			TreeViewCapPer.EscribirTree(book , treeView1);
			treeView1.EndUpdate();
			treeView1.Controls.Clear();
			return TreeViewCapPer.BuildTree(book);
		}
		/// <summary>
		/// Este metodo construye el treeView utilizando los datos del objeto libro.
		/// </summary>
		private static void EscribirTree (Libro book, TreeView treeView1)
		{
			TreeNode node;
			node = treeView1.Nodes.Add (book.Titulo);
			node = treeView1.Nodes.Add ("Capitulos");
			TreeNode node2;
			foreach (Capitulo capitulo in book.Capitulos) {
				node2 = node.Nodes.Add(capitulo.Id,capitulo.Titulo);
				foreach(Escena escena in capitulo.Escenas){
					node2.Nodes.Add(escena.Id ,escena.Titulo);
				}
			}
            node.ExpandAll();
            //prueba listado actores, borra o comenta si no te convence
            node = treeView1.Nodes.Add("Personajes");
            foreach (Actor actor in book.Actores)
            {
                node.Nodes.Add(actor.Id, actor.Nombre);
            }
            //fin prueba listado actores
            node.ExpandAll();
		}

	}
}