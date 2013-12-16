using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace DIAScribe
{
	/// <summary>
	/// Esta clase representa una implementacion de la interfaz <see cref="Planificacion.IPersistence"/>.
	/// Con esta clase, los <see cref="Event"/> se guardarán un fichero XML.
	/// </summary>
	public class XMLEventos: IPersistence
	{
		/// <summary>
		/// <see cref="String"/> con el nombre del fichero en el que se guardarán los <see cref="Event"/>.
		/// </summary>
		private String FileName;

		/// <summary>
		/// Constructor de la clase <see cref="Planificacion.XmlPersistence"/>.
		/// </summary>
		/// <param name='filename'>
		/// <see cref="String"/> con el nombre del fichero en el que se quieren guardar los <see cref="Event"/>.
		/// </param>
		public XMLEventos (String filename)
		{
			this.FileName = filename;
		}

		/// <summary>
		/// Constructor en el que se asigna un nombre por defecto al fichero XML.
		/// </summary>
		public XMLEventos ()
		{
			this.FileName = "events.xml";
		}

		/// <summary>
		/// Este método guarda todos los <see cref="Event"/> que se le pasan como parámetro.
		/// </summary>
		/// <returns>
		/// Devuelve <c>TRUE</c> en caso de que todo se haya guardado correctamente y
		/// <c>FALSE</c> en caso contrario.
		/// </returns>
		/// <param name='LEvents'>
		/// <see cref="List<Event>"/> con todos los <see cref="Event"/> que se quieran guardar.
		/// </param>
		public Boolean SaveAll(List<Event> LEvents)
		{
			try{
				XmlTextWriter textWriter = new XmlTextWriter (this.FileName, Encoding.UTF8);
				textWriter.WriteStartDocument();
					textWriter.WriteStartElement ("Events");
						foreach (Event e in LEvents) 
						{
							// Creamos el nodo inicial con un ID

							textWriter.WriteStartElement ("Event");
								textWriter.WriteStartAttribute ("id");
									textWriter.WriteString ( e.Id );
								textWriter.WriteEndAttribute ();					
							textWriter.WriteElementString ("Title", e.Title);
							textWriter.WriteElementString ("DateStart", e.DateStart.ToString());
							textWriter.WriteElementString ("DateFinish", e.DateFinish.ToString());
							textWriter.WriteElementString ("Description", e.Description);
							textWriter.WriteEndElement ();
						}
					textWriter.WriteEndElement ();
				textWriter.WriteEndDocument ();

				textWriter.Close ();

				return true;
			}catch(Exception){ 
				return false;
			}
		}

		/// <summary>
		/// Método que recoge todos los <see cref="Event"/> guardados en el fichero XML.
		/// </summary>
		/// <returns>
		/// Devuelve una <see cref="List<Event>"/> con todos los <see cref="Event"/> que se han guardado en el fichero.
		/// </returns>
		public List<Event> GetAllEvents()
		{
			List<Event> LEvents = new List<Event>();
			XmlDocument document = new XmlDocument ();
			try {
				document.Load ( this.FileName );
				int index = 1;
				foreach (XmlNode nodo in document.DocumentElement.ChildNodes) 
				{
					String [] atributos = new string[5];
					foreach( XmlAttribute atr in nodo.Attributes)
						atributos[0] = atr.InnerText;

					foreach (XmlNode nodo2 in nodo.ChildNodes) {
						atributos [index] = nodo2.InnerText;
						index++;
					}
					index = 1;

//					if( Convert.ToDateTime(atributos[3]).CompareTo(DateTime.Now) >= 0 )
						LEvents.Add (new Event (atributos [0], atributos [1], atributos[4], Convert.ToDateTime(atributos [2]), Convert.ToDateTime(atributos[3]) ));
				}
				return LEvents;
			} catch (Exception) {
				return LEvents;
			}
		}
	}
}

