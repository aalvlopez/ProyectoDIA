using System;
using System.Collections.Generic;
namespace treeviewCapitulosPersonajes
{
	/// <summary>
	/// Clase que almacena la informacion relativa a un capitulo del libro.
	/// </summary>
	public class Capitulo
	{
		/// <summary>
		/// Gets y sets de la propiedad Id.
		/// </summary>
		/// <value>
		/// Contiene un identificador unico del capitulo.
		/// </value>
		public string Id {
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad Titulo.
		/// </summary>
		/// <value>
		/// Contiene el titulo que se ha asignado al capitulo.
		/// </value>
		public string Titulo {
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad listEscenas.
		/// </summary>
		/// <value>
		/// Se trata de una lista de escenas que forman el capitulo.
		/// </value>
		public LinkedList<Escena> ListEscenas {
			get;
			set;
		}
		/// <summary>
		/// Inicializa una instacia de la clase <see cref="treeviewCapitulosPersonajes.Capitulo"/>.
		/// </summary>
		public Capitulo ()
		{
			this.Titulo = "";
			this.ListEscenas = new LinkedList<Escena>();
		}
		/// <summary>
		/// Inicializa una instacia de la clase <see cref="treeviewCapitulosPersonajes.Capitulo"/>.
		/// </summary>
		/// <param name='listEscenas'>
		/// Se trata una lista de objetos <see cref = "treeviewCapitulosPersonajes.Escena"/> que hemos obtenido de la 
		/// lectura del Xml.
		/// </param>
		/// <param name='titulo'>
		/// Titulo correspondiente al capitulo.
		/// </param>
		/// <param name='id'>
		/// Contiene el identificador unico para el capitulo
		/// </param>
		public Capitulo (LinkedList<Escena> listEscenas, string titulo, string id)
		{
			this.ListEscenas=listEscenas;
			this.Titulo=titulo;
			this.Id=id;
		}

	}
}

