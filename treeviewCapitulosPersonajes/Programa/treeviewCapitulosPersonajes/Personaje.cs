using System;

namespace treeviewCapitulosPersonajes
{
	/// <summary>
	/// Contiene la informacion relativa a un personaje.
	/// </summary>
	public class Personaje
	{
		/// <summary>
		/// Gets y sets de la propiedad Id.
		/// </summary>
		/// <value>
		/// Contiene el identificador unico del personaje.
		/// </value>
		public string Id {
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad Nombre.
		/// </summary>
		/// <value>
		/// Contiene el nombre propio del personaje.
		/// </value>
		public string Nombre {
			get;
			set;
		}
		/// <summary>
		/// Gets y sets de la propiedad Descripcion.
		/// </summary>
		/// <value>
		/// Contien la descripcion del personaje.
		/// </value>
		public string Descripcion {
			get;
			set;
		}
		/// <summary>
		/// Inicializa una instacia de la clase <see cref="treeviewCapitulosPersonajes.Personaje"/>.
		/// </summary>
		public Personaje ()
		{
			this.Nombre = "";
			this.Descripcion = "";
		}
		/// <summary>
		/// Inicializa una instacia de la clase  <see cref="treeviewCapitulosPersonajes.Personaje"/>.
		/// </summary>
		/// <param name='nombre'>
		/// Nombre propio del personaje.
		/// </param>
		/// <param name='descripcion'>
		/// Descripcion dada del personaje.
		/// </param>
		/// <param name='id'>
		/// Identificador unico para el personaje.
		/// </param>
		public Personaje (string nombre , string descripcion, string id)
		{
			this.Nombre= nombre;
			this.Descripcion= descripcion;
			this.Id = id;
		}
	}
}

