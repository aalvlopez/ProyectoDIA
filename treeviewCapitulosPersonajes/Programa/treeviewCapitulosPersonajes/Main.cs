using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Text;
using System.Collections.Generic;
namespace treeviewCapitulosPersonajes{
	public class Ppal 
	{
		/// <summary>
		/// Se crea un simple ejemplo para comprobar el buen funcionamiento y la creacion del 
		/// treeview resumen del libro que se esta escribiendo
		/// </summary>
    	public static void Main() 
    	{
			var btGuardar = new Button ();
			btGuardar.Text = "&Guardar"; 
			btGuardar.Dock = DockStyle.Top;
			btGuardar.Size= new Size(400 , 20);
			var btDescartar = new Button ();
			btDescartar.Text = "&Descartar";
			btDescartar.Dock = DockStyle.Top;
			btDescartar.Size= new Size(400 , 20);
			var pnlBotones = new Panel ();
			pnlBotones.SuspendLayout (); 
			pnlBotones.Dock = DockStyle.Right;

			pnlBotones.Controls.Add (btGuardar);
			pnlBotones.Controls.Add (btDescartar);
			pnlBotones.Size = new Size(btDescartar.Size.Width,350);
			pnlBotones.ResumeLayout (true);
			pnlBotones.ResumeLayout (false);
			IPersistencia objetoPersistencia = new XmlPersistencia("capitulos.xml");
			Application.Run(new Formulario(objetoPersistencia,pnlBotones));

         
    	}
	}
      
}
