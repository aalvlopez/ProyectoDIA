using System;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Esta clase representa los <see cref="Planificacion.Event"/> que el usuario crea. 
	/// </summary>
	public class Event
	{
		/// <summary>
		/// Esta propiedad <see cref="String"/> guardará el identificador de cada uno de los <see cref="Planificacion.Event"/>.
		/// </summary>
		public String Id{
			get; private set;
		}

		/// <summary>
		/// La propiedad <see cref="String"/> Title almacenará el título de cada uno de los <see cref="Planificacion.Event"/>.
		/// </summary>
		public String Title{
			get; private set;
		}

		/// <summary>
		/// La propiedad <see cref="String"/> Description almacenará la descripción del <see cref="Planificacion.Event"/>.
		/// </summary>
		public String Description{
			get; private set;
		}

		/// <summary>
		/// Esta propiedad <see cref="DateTime"/> almacenará la fecha de inicio del <see cref="Planificacion.Event"/>.
		/// </summary>
		public DateTime DateStart{
			get; private set;
		}

		/// <summary>
		/// La propiedad <see cref="DateTime"/> DateFinish almacenará la fecha de finalización del <see cref="Planificacion.Event"/>.
		/// </summary>
		public DateTime DateFinish{
			get; private set;
		}

		/// <summary>
		/// Constructor de la clase <see cref="Planificacion.Event"/>. Inicializa una nueva instancia, creando un ID random para el nuevo objeto.
		/// </summary>
		/// <param name='title'>
		/// <see cref="String"/> con el título del evento.
		/// </param>
		/// <param name='description'>
		/// <see cref="String"/> con la descripción del evento.
		/// </param>
		/// <param name='dateStart'>
		/// <see cref="DateTime"/> con la fecha de inicio del evento.
		/// </param>
		/// <param name='dateFinish'>
		/// <see cref="DateTime"/> con la fecha de finalización del evento
		/// </param>
		public Event (String title, String description, DateTime dateStart, DateTime dateFinish)
		{
			DateTime start = new DateTime(1995, 1, 1);
		    Random gen = new Random();
		    int range = (DateTime.Today - start).Days;       

			this.Id = start.AddDays(gen.Next(range)).ToString("yyyyMMddHHmmssffff");
			this.Title = title;
			this.Description = description;
			this.DateStart = dateStart;
			this.DateFinish = dateFinish;
		}

		/// <summary>
		/// Crea un nuevo objeto de la clase <see cref="Planificacion.Event"/> con los parametros que se le pasen.
		/// En este constructor, el ID se le pasa directamente para asignarselo al objeto.
		/// </summary>
		/// <param name='id'>
		/// <see cref="String"/> con el ID del objeto que se va a crear.
		/// </param>
		/// <param name='title'>
		/// <see cref="String"/> con el título del evento.
		/// </param>
		/// <param name='description'>
		/// <see cref="String"/> con la descripción del evento.
		/// </param>
		/// <param name='dateStart'>
		/// <see cref="DateTime"/> con la fecha de inicio del evento.
		/// </param>
		/// <param name='dateFinish'>
		/// <see cref="DateTime"/> con la fecha de finalización del evento
		/// </param>
		public Event (String id, String title, String description, DateTime dateStart, DateTime dateFinish )
		{
			this.Id = id;
			this.Title = title;
			this.Description = description;
			this.DateStart = dateStart;
			this.DateFinish = dateFinish;
		}
	}
}

