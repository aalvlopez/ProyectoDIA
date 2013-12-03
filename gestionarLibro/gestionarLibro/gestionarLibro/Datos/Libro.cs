using System;
using System.Collections.Generic;

namespace Scrivener
{
	/// <summary>
	/// Un libro.
	/// </summary>
	public class Libro: 
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
			this.Capitulos = new LinkedList<Capitulo>();
			this.Anotacion = "";
			this.Titulo="";
		}
		
		public Libro (String titulo, String anotacion, LinkedList<Capitulo> capitulos)
		{
			Titulo = titulo;
			Anotacion = anotacion;
			this.Capitulos = capitulos;
		}
		
		public Capitulo CrearCapitulo(String titulo, String anotacion)
		{
			Capitulo capitulo = new Capitulo();
			//capitulo.setTitulo( titulo );
			///capitulo.setAnotacion ( anotacion );
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

