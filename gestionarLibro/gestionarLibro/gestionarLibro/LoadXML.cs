using System;
using System.Xml;
using System.Text;

namespace Scrivener
{
	/// <summary>
	/// Cargar archivo XML
	/// </summary>
	public class LoadXML:IPersistencia
	{
		public LoadXML (string documento)
		{
			this.Documento = documento;
		}
		
		/// <summary>
		/// Implementa el metodo principal de <see cref="Scrivener.LoadXML"/>
		/// con el que se carga en memoria un fichero "datos_scrivener.xml"
		/// que contiene los datos sobre los capitulos del libro.
		/// </summary>
		public Libro Leer ()
		{
			Libro libro = new Libro();
			
			XmlDocument docXml = new XmlDocument();
			docXml.Load (this.Documento);
			
			foreach(XmlNode nodo1 in docXml.DocumentElement.ChildNodes) {
				switch (nodo1.Name)
				{
				case "Titulo": 
					libro.Titulo = nodo1.InnerText;
					break;
				case "Anotacion": 
					libro.Anotacion = nodo1.InnerText;
					break;
				case "Capitulos": 
					Capitulo capitulo = new Capitulo();	
					foreach(XmlNode nodo2 in nodo1.ChildNodes) 
					{				
						switch (nodo2.Name)
						{
						case "Titulo":
							capitulo.Titulo = nodo2.InnerText;
							break;
						case "Anotacion": 
							capitulo.Anotacion = nodo1.InnerText;
							break;
						case "Escenas":
							Escena escena = new Escena();							
							foreach(XmlNode nodo3 in nodo2.ChildNodes)
							{
								switch (nodo3.Name)
								{
								case "Titulo":
									escena.Titulo = nodo3.InnerText;
									break;
								case "Anotacion": 
									escena.Anotacion = nodo3.InnerText;
									break;
								case "Escenas":
									escena.Contenido = nodo3.InnerText;
									break;
								}
							}						
							capitulo.escenas.AddLast(escena);	
							break;
						}
						
					}
					libro.capitulos.AddLast(capitulo);
					break;
				}
			}
			return libro;
		}
		
		private string Documento {
			get;
			set;
		}
	}
}
	

