using System;
using System.Windows.Forms;

namespace Planificacion
{
	/// <summary>
	/// Clase principal con el método Main para ejecutar el programa.
	/// </summary>
	public class App
	{
		/// <summary>
		/// Este método se encarga de crear la instancia de la implementación que se desee utilizar de la 
		/// interface <see cref="Planificacion.IPersistence"/> , así como crear también <see cref="Planificacion.ListEvent"/>
		/// para pasarselo a la implementación de la interface <see cref="IUseerInterface"/>.
		/// La última tarea de la que se encarga es de hacer ejecutar el método Run de dicha aplicación.
		/// </summary>
		public static void Main ()
		{
			XmlPersistence xmlPersistence = new XmlPersistence("events.xml");
			ListEvent listEvents = new ListEvent(xmlPersistence);

			EventsWinForms GUI = new EventsWinForms(listEvents);

			Application.Run(GUI);
		}
	}
}

