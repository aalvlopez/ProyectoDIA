using System;
using System.Collections.Generic;

namespace Scrivener
{
	/// <summary>
	/// Un libro.
	/// </summary>
	public class Libro
	{
		/// <summary>
		/// Lista de capitulos de los que se compone.
		/// </summary>
		public LinkedList<Capitulo> capitulos;
		
		/// <summary>
		/// Inicializa un <see cref="Scrivener.Libro"/> vacio.
		/// </summary>
		public Libro ()
		{
		}
		
		public Libro (String titulo, String anotacion, LinkedList<Capitulo> capitulos)
		{
			Titulo = titulo;
			Anotacion = anotacion;
			this.Capitulos = capitulos;
		}
		
		/// <summary>
		/// Propiedad que define los Gets y Sets del titulo de <see cref="Scrivener.Libro">.
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
		/// Propiedad que define los Gets y Sets de una anotacion de <see cref="Scrivener.Libro">.
		/// </summary>
		/// <value>
		/// Una anotacion.
		/// </value>
		public String Anotacion 
		{
			get;
			set;
		}
		
		public LinkedList<Capitulo> Capitulos
		{
			get;
			set;
		}
	}
}
