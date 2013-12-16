using System;
using System.Collections.Generic;
using System.Collections;

namespace DIAScribe
{
	/// <summary>
	/// Esta clase almacena los <see cref="Event"/> que el usuario ya hubiera creado y crea en tiempo de ejecución
	/// para luego poder guardarlos mediante el mecanismo de <see cref="IPersistence"/> que se hubiera definido.
	/// </summary>
	public class ListEvent
	{
		/// <summary>
		/// Esta <see cref="List<Event>"/> guarda los <see cref="Event"/> que el usuario crea.
		/// </summary>
		private List<Event> LEvents;

		/// <summary>
		/// Este objeto <see cref="Planificacion.IPersistence"/> almacena una referencia a dicha clase, para acceder a los métodos de esta.
		/// </summary>
		private IPersistence IPersistenceImplementation;

		/// <summary>
		/// Constructor de <see cref="Planificacion.ListEvent"/>.
		/// Inicializa la lista de enventos y llama al metodo <see cref="IPersistence.GetAllEvents()"/>
		/// para cargar en la lista los eventos que estén ya guardados en el XML.
		/// </summary>
		/// <param name='xmlPers'>
		/// Parámetro del tipo <see cref="Planificacion.IPersistence"/>, donde se guardarán los <see cref="Event"/> del usuario.
		/// </param>
		public ListEvent (IPersistence xmlPers)
		{
			this.IPersistenceImplementation = xmlPers;
			this.LEvents = this.IPersistenceImplementation.GetAllEvents();
		}

		/// <summary>
		/// Método para añadir un <see cref="Event"/> que el usuario haya creado, tanto a la lista como a la persistencia.
		/// </summary>
		/// <returns>
		/// Devuelve <c>TRUE</c> en caso de que el objeto se añada correctamente en la <see cref="Planificacion.IPersistence"/>.
		/// En otro caso, devuelve <c>FALSE</c>.
		/// </returns>
		/// <param name='args'>
		/// Un <see cref="ArrayList"/> que contiene los diferentes parámetros del objeto <see cref="Event"/>.
		/// </param>
		public Boolean AddEvent(ArrayList args)
		{
			LEvents.Add(new Event(args[0].ToString(), args[1].ToString(), Convert.ToDateTime(args[2]), Convert.ToDateTime(args[3]) ) );
			return IPersistenceImplementation.SaveAll(LEvents);
		}

		/// <summary>
		/// Este método recibe un <see cref="String"/> con el ID del <see cref="Event"/> para obtener dicho objeto.
		/// </summary>
		/// <returns>
		/// Devuelve el objeto si existe, en caso contrario, devuelve <c>NULL</c>.
		/// </returns>
		/// <param name='id'>
		/// <see cref="String"/> con el ID del <see cref="Evento"/> que se quiere obtener.
		/// </param>
		public Event GetEvent (String id)
		{
			Event ev = null;

			foreach (Event e in LEvents)
			{
				if( e.Id.Equals(id) ){
					ev = e;
				}
			}

			if( ev != null )
				return ev;
			else
				return null;
		}


		/// <summary>
		/// Este método obtiene un <see cref="Event"/> a partir del <c>index</c> de la variable <c>LEvents</c>.
		/// </summary>
		/// <returns>
		/// Devuelve el <see cref="Event"/> en caso de que exista, en otro caso devuelve <c>NULL</c>.
		/// </returns>
		/// <param name='index'>
		/// <see cref="int"/> con la posición del evento en la lista.
		/// </param>
		public Event GetEventByIndex (int index)
		{
			Event toRet = null;

			int count = 0;
			foreach (Event e in this.LEvents) {
				if( count == index )
				{
					toRet = e;
					break;
				}

				count++;
			}

			return toRet;
		}

		/// <summary>
		/// Este método elimina un <see cref="Event"/> cuyo <c>ID</c> se le pasa como parámetro.
		/// </summary>
		/// <returns>
		/// Devuelve <c>TRUE</c> en caso de eliminarlo correctamente, <c>FALSE</c> en caso contrario.
		/// </returns>
		/// <param name='id'>
		/// <see cref="String"/> con el <c>ID</c> del <see cref="Event"/> que se quiere eliminar.
		/// </param>
		public Boolean RemoveEventByID (String id)
		{
			var element = this.GetEvent (id);

			if (element != null) {
				LEvents.Remove (element);
				return IPersistenceImplementation.SaveAll(LEvents);
			}
			return false;
		}

		/// <summary>
		/// Obtiene la cantidad de <see cref="Event"/> que hay guardados en la lista.
		/// </summary>
		/// <returns>
		/// Devuelve un <see cref="int"/> de dicha cantidad.
		/// </returns>
		public int GetLength ()
		{
			return this.LEvents.Count;
		}
	}
}

