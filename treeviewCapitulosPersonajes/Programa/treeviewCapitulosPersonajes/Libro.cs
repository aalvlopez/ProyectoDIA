using System;
using System.Collections.Generic;

namespace treeviewCapitulosPersonajes
{
	/// <summary>
	/// Esta clase contiene toda la informacion necesaria para la creacion de TreeView
	/// relativa al libro.
	/// </summary>
	public class Libro
	{
		/// <summary>
		/// GGets y sets de la propiedad ListCapitulos.
		/// </summary>
		/// <value>
		/// Lista que contiene los <see cref="treeviewCapitulosPersonajes.Capitulo"/>
		/// que componen el libro.
		/// </value>
		public LinkedList<Capitulo> ListCapitulos {
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad ListPersonajes.
		/// </summary>
		/// <value>
		/// Lista que contiene los <see cref="treeviewCapitulosPersonajes.Personaje"/>
		/// que se encuentran en el libro.
		/// </value>
		public LinkedList<Personaje> ListPersonajes {
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad Titulo.
		/// </summary>
		/// <value>
		/// Titulo asignado al libro.
		/// </value>
		public string Titulo {
			get;
			set;
		}
		/// <summary>
		/// Inicializa una instacia de la clase <see cref="treeviewCapitulosPersonajes.Libro"/>.
		/// </summary>
		public Libro ()
		{
			this.Titulo = "";
			this.ListCapitulos = new LinkedList<Capitulo> ();
			this.ListPersonajes = new LinkedList<Personaje> ();
		}
		/// <summary>
		/// Inicializa una instacia de la clase <see cref="treeviewCapitulosPersonajes.Libro"/>.
		/// </summary>
		/// <param name='listCapitulos'>
		/// Lista que contiene los <see cref="treeviewCapitulosPersonajes.Capitulo"/> del libro
		/// </param>
		/// <param name='listpersonajes'>
		/// Lista que contiene los <see cref="treeviewCapitulosPersonajes.Personaje"/> del libro
		/// </param>
		/// <param name='titulo'>
		/// Titulo asignado al libro.
		/// </param>
		public Libro (LinkedList<Capitulo> listCapitulos , LinkedList<Personaje> listpersonajes ,string titulo)
		{
			this.ListPersonajes = listpersonajes;
			this.ListCapitulos=listCapitulos;
			this.Titulo = titulo;
		}
	}
}

