using System;
using System.Xml;
using System.Text;

namespace Scrivener
{
	/// <summary>
	/// Cargar archivo XML
	/// </summary>
	public class LoadXML
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
				case "titulo": 
					libro.Titulo = nodo1.InnerText;
					break;
				case "anotacion": 
					libro.Anotacion = nodo1.InnerText;
					break;
				case "capitulos": 
					
					foreach(XmlNode nodo4 in nodo1.ChildNodes) 
					{	
						Capitulo capitulo = new Capitulo();
						foreach(XmlNode nodo2 in nodo4.ChildNodes) 
						{
								
							switch (nodo2.Name)
							{
							case "titulo":
								capitulo.Titulo = nodo2.InnerText;
								break;
							case "anotacion": 
								capitulo.Anotacion = nodo2.InnerText;
								break;
							case "escenas":
															
								foreach(XmlNode nodo5 in nodo2.ChildNodes)
								{
									Escena escena = new Escena();
									foreach(XmlNode nodo3 in nodo5.ChildNodes)
									{
										switch (nodo3.Name)
										{
										case "titulo":
											escena.Titulo = nodo3.InnerText;
											break;
										case "anotacion": 
											escena.Anotacion = nodo3.InnerText;
											break;
										case "contenido":
											escena.Contenido = nodo3.InnerText;
											break;
										}
									}	
									capitulo.Escenas.AddLast(escena);
									
								}
								break;
							}
							
						}
						libro.Capitulos.AddLast(capitulo);
						
						
					}
					break;
				}
			}
			return libro;
		}
		
		private string Documento 
		{
			get;
			set;
		}
	}
}
	

