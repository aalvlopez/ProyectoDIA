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
		}

		public Capitulo (String titulo, String anotacion, LinkedList<Escena> escenas)
		{
			Titulo = titulo;
			Anotacion = anotacion;
			this.Escenas = escenas;
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

