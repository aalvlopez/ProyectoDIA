using System;

namespace Scrivener
{
	public interface IGestionarLibro
	{
		/// <summary>
		/// Crears the libro.
		/// </summary>
		/// <returns>
		/// The libro.
		/// </returns>
		/// <param name='titulo'>
		/// Titulo.
		/// </param>
		Libro CrearLibro(String titulo);
		
	}
}

