using System;

namespace DIAScribe
{
	/// <summary>
	/// Interface para la implementación de una GUI.
	/// Define 3 métodos que se deberán implementar para cualquier tipo de <see cref="Planificacion.IUserInterface"/>.
	/// </summary>
	public interface IUserInterface
	{
		/// <summary>
		/// Este método le mostrará al usuario el <see cref="Event"/> que se pasa por parámetro.
		/// </summary>
		/// <param name='e'>
		/// <see cref="Event"/> que se quiere mostrar al usuario.
		/// </param>
		void DisplayEvent(Event e);

		/// <summary>
		/// Formulario que se le muestra al usuario para rellenar y poder crear
		/// un nuevo <see cref="Event"/>.
		/// </summary>
		void AddEvents();

		/// <summary>
		/// Método para mostrarle al usuario un formulario con los datos del <see cref="Event"/> que se quiere modificar
		/// y ofrecerle la posibilidad de modificarlo y guardarlo.
		/// </summary>
		/// <param name='e'>
		/// <see cref="Event"/> que el usuario quiere modificar.
		/// </param>
		void ModifyEvent(Event e);

		/// <summary>
		/// Método en el que se le mostrará al usuario todos los <see cref="Event"/> que tiene creados.
		/// </summary>
		void ListEvents ();
	}
}

