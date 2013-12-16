using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Un capitulo.
	/// </summary>
	public class Capitulo
	{
		/// <summary>
		/// Inicializa un <see cref="Scrivener.Capitulo"/> vacio.
		/// </summary>
		public Capitulo ()
		{
			DateTime start = new DateTime (1995, 1, 1);
			Random gen = new Random ();
			int range = (DateTime.Today - start).Days;       
			this.Id = start.AddDays (gen.Next (range)).ToString ("yyyyMMddHHmmssffff");
			
			this.Escenas = new LinkedList<Escena> ();
			this.Titulo = "";
			this.Anotacion = "";
		}
		
		/// <summary>
		/// Crea un nuevo <see cref="Scrivener.Capitulo"/>.
		/// </summary>
		/// <param name='titulo'>
		/// Titulo.
		/// </param>
		/// <param name='anotacion'>
		/// Anotacion.
		/// </param>
		public Capitulo (String titulo, String anotacion)
		{
			DateTime start = new DateTime (1995, 1, 1);
			Random gen = new Random ();
			int range = (DateTime.Today - start).Days;       
			this.Id = start.AddDays (gen.Next (range)).ToString ("yyyyMMddHHmmssffff");
			
			Titulo = titulo;
			Anotacion = anotacion;
			this.Escenas = new LinkedList<Escena> ();
		}
		
		/// <summary>
		/// Modificar el capitulo.
		/// </summary>
		/// <param name='titulo'>
		/// Titulo.
		/// </param>
		/// <param name='anotacion'>
		/// Anotacion.
		/// </param>
		public void ModificarCapitulo (String titulo, String anotacion)
		{		
			this.Titulo = titulo;
			this.Anotacion = anotacion;
		}
		
		/// <summary>
		/// Crear una escena nueva.
		/// </summary>
		/// <param name='tituloe'>
		/// Titulo.
		/// </param>
		/// <param name='anotacione'>
		/// Anotacion.
		/// </param>
		/// <param name='contenidoe'>
		/// Contenido.
		/// </param>
		public void CrearEscena (string tituloe, string anotacione, string contenidoe, string idCapitulo)
		{
			Escenas.AddLast (new Escena (tituloe, anotacione, contenidoe, idCapitulo));
		}

		/// <summary>
		/// Buscars una escena por su identificador.
		/// </summary>
		/// <returns>
		/// Devuelve la escena que coincida con el ID, o en caso de no encontrarla devuelve Null.
		/// </returns>
		/// <param name='id'>
		/// Identificador.
		/// </param>
		public Escena BuscarEscenaId (String id)
		{
			foreach (var i in this.Escenas) {
				if (id.Equals (i.Id))
					return i;
			}
			return null;
		}

		public override string ToString ()
		{
			return string.Format (this.Titulo);
		} 
		/// <summary>
		/// Gets y sets del identificador (ID).
		/// </summary>
		/// <value>
		/// El identificador.
		/// </value>
		public String Id {
			get;
			set;
		}
		
		/// <summary>
		/// Propiedad que define los Gets y Sets del titulo de <see cref="Scrivener.Capitulo"/>.
		/// </summary>
		/// <value>
		/// El titulo.
		/// </value>
		public String Titulo {
			get;
			set;
		}
		
		/// <summary>
		/// Propiedad que define los Gets y Sets de una anotacion de <see cref="Scrivener.Capitulo"/>.
		/// </summary>
		/// <value>
		/// Una anotacion.
		/// </value>
		public String Anotacion {
			get;
			set;
		}
		
		/// <summary>
		/// Gets y sets de escenas.
		/// </summary>
		/// <value>
		/// LinkedList que contiene las escenas.
		/// </value>
		public LinkedList<Escena> Escenas {
			get;
			set;
		}
	}
}


