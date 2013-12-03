using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace Scrivener
{
	class MainClass
	{
		public static void Main (string[] args)
		{		
			XMLPersistencia persistencia = new XMLPersistencia("plantilla.xml");
			
			Libro leido = persistencia.Leer();
			Console.WriteLine(leido.Capitulos.Count);
			foreach(var i in leido.Capitulos){
				Console.WriteLine(i.Titulo);
				Console.WriteLine("---Escenas---");
				foreach(var j in i.Escenas){
					Console.WriteLine(j.Contenido);
				}
			}
			
			Console.WriteLine("Guardando de nuevo el libro");
			persistencia.Guardar(leido);	

		}
	}
}
