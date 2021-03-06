using System;

namespace Scrivener
{
	/// <summary>
	/// Gestionar libro.
	/// </summary>
	public class GestionarLibro:IGestionarLibro
	{
		/// <summary>
		/// Crea un <see cref="Scrivener.Libro"/> nuevo
		/// </summary>
		/// <returns>
		/// El libro creado
		/// </returns>
		/// <param name='titulo'>
		/// Titulo del libro a crear.
		/// </param>
		public Libro CrearLibro (String titulo)
		{
			Libro libro = new Libro(titulo);
			return (libro);
		}
		
	}
}

