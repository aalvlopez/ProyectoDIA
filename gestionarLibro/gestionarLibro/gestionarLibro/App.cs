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
			LoadXML load = new LoadXML("plantilla.xml");
			
			Libro leido = load.Leer();
			Console.WriteLine(leido.Capitulos.Count);
			foreach(var i in leido.Capitulos){
				Console.WriteLine(i.Titulo);
				Console.WriteLine("---Escenas---");
				foreach(var j in i.Escenas){
					Console.WriteLine(j.Titulo);
				}
			}
			
			Console.WriteLine("Guardando de nuevo el libro");
			SaveXML save = new SaveXML("plantilla_nueva.xml");
			save.Guardar(leido);	

		}
	}
}
