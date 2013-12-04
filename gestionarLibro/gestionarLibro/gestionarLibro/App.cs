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
		/// <summary>
		/// Programa main de ejemplo, donde se pueden probar las funcionalidades
		/// </summary>
		/// <param name='args'>
		/// Argumentos de linea de comando.
		/// </param>
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
			
			persistencia.documento("plantilla_nueva.xml");			
			Console.WriteLine("Guardando de nuevo el libro");
			persistencia.Guardar(leido);	
			
			/// Creamos un libro vacio llamado "Nuevo libro"
			var x = new GestionarLibro();
			Console.WriteLine("Nombre del libro a crear:");
			string r = Console.ReadLine();
			Libro nuevoLibro = x.CrearLibro(r);
			persistencia.documento(nuevoLibro.Titulo + ".xml");
			
			/// Introducimos en ese libro un capitulo y dos escenas
			Console.WriteLine("Introduciendo un capitulo y dos escenas");
			nuevoLibro.CrearCapitulo("titulo","anotacion generica");
			nuevoLibro.Capitulos.First.Value.CrearEscena("titulo escena 1","","contenido generico");
			nuevoLibro.Capitulos.First.Value.CrearEscena("titulo escena 2","","contenido generico");
			nuevoLibro.CrearCapitulo("titulo capitulo 2","anotacion generica");
		
			//Buscamos y editamos un capitulo en concreto			
			Console.WriteLine("Nombre del capitulo a editar:");
			r = Console.ReadLine();
			//Llamamos a la funcion de busqueda
			var cap = nuevoLibro.BuscarCapitulo(r);
			Console.WriteLine("Nuevo titulo:");
			string t = Console.ReadLine();
			Console.WriteLine("Nueva anotacion:");
			string a = Console.ReadLine();
			//A partir del capitulo concreto editamos los atributos que nos interesan
			cap.ModificarCapitulo(t,a);
			
			//Lo mismo para escenas, con la funcion BuscarEscena de la clase Capitulo y EditarEscena de la clase Escena
			
			///Guardamos todo
			persistencia.Guardar(nuevoLibro);	
			Console.WriteLine("Se ha guardado '" + nuevoLibro.Titulo + "'");
			
			
		}
	}
}
