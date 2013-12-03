using System;
using System.Collections.Generic;

namespace Scrivener
{
	/// <summary>
	/// Un capitulo.
	/// </summary>
	public class Capitulo
	{
		/// <summary>
		/// Lista de escenas de las que se compone.
		/// </summary>
		public LinkedList<Escena> escenas;
		
		/// <summary>
		/// Inicializa un <see cref="Scrivener.Capitulo"/> vacio.
		/// </summary>
		public Capitulo ()
		{
			this.Escenas=new LinkedList<Escena>();
			this.Titulo="";
			this.Anotacion="";
			this.Id="";
		}

		public Capitulo (String id, String titulo, String anotacion, LinkedList<Escena> escenas)
		{
			this.Id = Id;
			Titulo = titulo;
			Anotacion = anotacion;
			this.Escenas = escenas;
		}
		
		public String Id
		{
			get;
			set;
		}
		
		/// <summary>
		/// Propiedad que define los Gets y Sets del titulo de <see cref="Scrivener.Capitulo"/>.
		/// </summary>
		/// <value>
		/// El titulo.
		/// </value>
		public String Titulo 
		{
			get;
			set;
		}
		
		/// <summary>
		/// Propiedad que define los Gets y Sets de una anotacion de <see cref="Scrivener.Capitulo"/>.
		/// </summary>
		/// <value>
		/// Una anotacion.
		/// </value>
		public String Anotacion 
		{
			get;
			set;
		}
		
		public LinkedList<Escena> Escenas
		{
			get;
			set;
		}
	}
}

