using System;

namespace treeviewCapitulosPersonajes
{
	/// <summary>
	/// Esta interfaz representa a la persistencia permitiendo su utilización
	/// sea cual sea su implementacion.
	/// </summary>
	public interface IPersistencia
	{
		/// <summary>
		/// Metodo que permite la lectura de disco
		/// </summary>
		/// <returns> Un objeto libro con la informacion leida</returns>
		Libro Lectura ();
	}
}

