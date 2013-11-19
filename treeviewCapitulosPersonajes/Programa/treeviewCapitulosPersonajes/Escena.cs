using System;

namespace treeviewCapitulosPersonajes
{
	/// <summary>
	/// Clase que representa las escenas que componen los capitulos del libro.
	/// </summary>
	public class Escena
	{
		/// <summary>
		/// Gets y sets de la propiedad Id.
		/// </summary>
		/// <value>
		/// Contiene un identificador unico de la Escena.
		/// </value>
		public string Id {
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad titulo.
		/// </summary>
		/// <value>
		/// Contien el titulo asignado a la Escena.
		/// </value>
		public string Titulo{
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad contenido.
		/// </summary>
		/// <value>
		/// Contenido almacenado de la Escena.
		/// </value>
		public string Contenido {
			get;
			set;
		}
		/// <summary>
		/// Inicializa una instacia de la clase <see cref="treeviewCapitulosPersonajes.Escena"/>.
		/// </summary>
		public Escena ()
		{ 
			this.Titulo = "";
			this.Contenido = "";
		}
		/// <summary>
		/// Inicializa una instacia de la clase <see cref="treeviewCapitulosPersonajes.Escena"/>.
		/// </summary>
		/// <param name='titulo'>
		/// Titulo de la escena a crear.
		/// </param>
		/// <param name='contenido'>
		/// Contenido de la escena que se guardará.
		/// </param>
		/// <param name='id'>
		/// Identificador unico para la escena.
		/// </param>
		public Escena (string titulo , string contenido, string id)
		{
			this.Titulo=titulo;
			this.Contenido=contenido;
			this.Id = id;
		}

	}
}

