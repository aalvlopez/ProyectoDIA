using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Interface para la implementación de la Persistencia.
	/// Define dos funciones a implementar para cualquier tipo de <see cref="Planificacion.IPersistencia"/> que se desee tener en el sistema.
	/// </summary>
	public interface IPersistence
	{
		/// <summary>
		/// Este método guarda todos los <see cref="Event"/> que se le pasen como parámetro.
		/// </summary>
		/// <returns>
		/// En caso de que se guarden correctamente, se devuelve <c>TRUE</c>, en caso contrario <c>FALSE</c>.
		/// </returns>
		/// <param name='LEvents'>
		/// Este parámetro <see cref="List<Event>"/> contiene todos los <see cref="Event"/> que se desean almacenar.
		/// </param>
		Boolean SaveAll(List<Event> LEvents);

		/// <summary>
		/// Este método retorna todos los <see cref="Event"/> que se haya almacenado en la persistencia definida.
		/// </summary>
		/// <returns>
		/// Devuelve una <see cref="List<Event>"/> con todos los <see cref="Event"/> almacenados.
		/// </returns>
		List<Event> GetAllEvents();
	}
}

