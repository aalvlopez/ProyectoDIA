using System;
using System.Xml;
using System.Text;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Carga y guarda los archivos XML
	/// </summary>
	public class XMLPersistencia
	{
		/// <summary>
		/// Crea una nueva instancia de la clase <see cref="Scrivener.XMLPersistencia"/>.
		/// </summary>
		/// <param name='documento'>
		/// Nombre del documento por defecto que se va a cargar/guardar.
		/// </param>
		public XMLPersistencia (string documento)
		{
			this.Documento = documento;
		}
		
		/// <summary>
		/// Modifica el nombre del documento
		/// </summary>
		/// <param name='documento'>
		/// Nombre del documento por defecto que se va a cargar/guardar.
		/// </param>
		public void documento (string documento)
		{
			this.Documento = documento;
		}
		
		/// <summary>
		/// Implementa el metodo cargar de <see cref="Scrivener.XMLPersistencia"/>
		/// con el que se carga en memoria un fichero .xml que coincida con
		/// el nombre del atributo documento. Este libro contiene todos
		/// los datos de <see cref="Scrivener.Libro"/>
		/// </summary>
		public Libro Leer ()
		{
			Libro libro = new Libro();
			string nombrePersonaje = "";
			string capPersonaje = "";
			string descPersonaje = "";
			XmlDocument docXml = new XmlDocument();
 			docXml.Load (this.Documento);
			//carga contenido personajes libro
			XmlNodeList personajes = docXml.GetElementsByTagName("personaje");
			foreach (XmlNode personaje in personajes) {
				XmlNode nombre = personaje.ChildNodes["nombrePersonaje"];
				XmlNode cap = personaje.ChildNodes ["cap"];
				XmlNode desc = personaje.ChildNodes["descripcion"];
				nombrePersonaje = nombre.InnerText.Trim();
				capPersonaje = cap.InnerText.Trim();
				descPersonaje = desc.InnerText.Trim();
				libro.Actores.Add(Actor.Crea(nombrePersonaje, 
										capPersonaje,
										descPersonaje)
								);
			}
			//fin carga personajes libro
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
						XmlAttributeCollection id = nodo4.Attributes;
						capitulo.Id = id.GetNamedItem("id").Value;
						
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
					
				case "referencias":
					foreach(XmlNode singleRef in nodo1.ChildNodes){
						Referencia r = new Referencia(singleRef.SelectSingleNode("autor").InnerText,
					                              singleRef.SelectSingleNode("titulo").InnerText,
					                              singleRef.SelectSingleNode("datos").InnerText,
					                              singleRef.SelectSingleNode("edicion").InnerText,
					                              singleRef.SelectSingleNode("extension").InnerText
					                              );
						libro.Referencias.Add(r);				
					}
				break;
					
				}
			}
			return libro;
		}
		
		/// <summary>
		/// Guarda el libro pasado por parametro.
		/// </summary>
		/// <param name='libro'>
		/// Un <see cref="Scrivener.Libro"/>
		/// </param>
		public void Guardar (Libro libro)
		{
			XmlDocument docXml = new XmlDocument();
			
			XmlNode nodo = docXml.CreateNode( XmlNodeType.XmlDeclaration
											, "xml", "");
 			((XmlDeclaration)nodo).Encoding = "utf-8";
			
			docXml.AppendChild ( nodo );
			
			XmlNode nodol = docXml.CreateNode( XmlNodeType.Element, "libro", "tns");
			
			XmlAttribute xmln = docXml.CreateAttribute( "xmlns:tns" );
			xmln.InnerText = "http://www.esei.uvigo.es/libro" ;
			nodol.Attributes.Append( xmln );
			
			 xmln = docXml.CreateAttribute( "xmlns:xsi" );
			xmln.InnerText = "http://www.w3.org/2001/XMLSchema-instance" ;
			nodol.Attributes.Append( xmln );
			
			 xmln = docXml.CreateAttribute( "xsi:schemaLocation" );
			xmln.InnerText = "http://www.esei.uvigo.es/libro libro.xsd" ;
			nodol.Attributes.Append( xmln );
			//codigo insertado para procesar guardado de personajes
			XmlNode personajes = docXml.CreateNode (XmlNodeType.Element, "personajes", "");
			XmlNode personaje;
			XmlNode nombre;
			XmlNode cap;
			XmlNode descripcion;
			foreach (var actor in libro.Actores) {
				personaje = docXml.CreateNode (XmlNodeType.Element, "personaje", "");
				nombre = docXml.CreateNode (XmlNodeType.Element, "nombrePersonaje", "");
				cap = docXml.CreateNode (XmlNodeType.Element, "cap", "");
				descripcion = docXml.CreateNode (XmlNodeType.Element, "descripcion", "");
				nombre.InnerText = actor.Nombre;
				cap.InnerText = actor.Caps;
				descripcion.InnerText = actor.Descripcion;
				personaje.AppendChild(nombre);
				personaje.AppendChild(cap);
				personaje.AppendChild(descripcion);
				personajes.AppendChild(personaje);
			}
			nodol.AppendChild(personajes);
			//fin insertado personajes




			XmlNode ltit = docXml.CreateNode( XmlNodeType.Element, "titulo", "");
			ltit.InnerText = libro.Titulo;
			nodol.AppendChild( ltit );
			
			XmlNode lant = docXml.CreateNode( XmlNodeType.Element, "anotacion", "" );
			lant.InnerText = libro.Anotacion;
			nodol.AppendChild( lant );
			
			XmlNode nodocs = docXml.CreateNode( XmlNodeType.Element, "capitulos", "");
			
			foreach(var i in libro.Capitulos)
			{
				XmlNode nodoc = docXml.CreateNode( XmlNodeType.Element, "capitulo", "");
				docXml.AppendChild( nodocs );
				
				XmlAttribute id = docXml.CreateAttribute( "id" );
				id.InnerText = i.Id;
				nodoc.Attributes.Append( id );
				
				XmlNode ctit = docXml.CreateNode( XmlNodeType.Element, "titulo", "" );
				ctit.InnerText = i.Titulo;
				nodoc.AppendChild( ctit );
				
				XmlNode cant = docXml.CreateNode( XmlNodeType.Element, "anotacion", "" );
				cant.InnerText = i.Anotacion;
				nodoc.AppendChild( cant );
				
				XmlNode nodoes = docXml.CreateNode( XmlNodeType.Element, "escenas", "");
				
				foreach(var j in i.Escenas)
				{
					XmlNode nodoe = docXml.CreateNode( XmlNodeType.Element, "escena", "");
					nodoes.AppendChild( nodoe );
					
					XmlNode etit = docXml.CreateNode( XmlNodeType.Element, "titulo", "" );
					etit.InnerText = j.Titulo;
					nodoe.AppendChild( etit );
					
					XmlNode eant = docXml.CreateNode( XmlNodeType.Element, "anotacion", "" );
					eant.InnerText = j.Anotacion;
					nodoe.AppendChild( eant );
					
					XmlNode econt = docXml.CreateNode( XmlNodeType.Element, "contenido", "" );

					XmlCDataSection CData;
   					CData = docXml.CreateCDataSection(j.Contenido);
					
					econt.AppendChild( CData );			
					nodoe.AppendChild( econt );
					
					nodoc.AppendChild( nodoes );
				}
				nodocs.AppendChild( nodoc );
				
				
				
				
				
				
				
			}
			nodol.AppendChild( nodocs );
			docXml.AppendChild( nodol );
			
			//bof - Sección Referencias
			XmlNode nodoRefs = docXml.CreateNode( XmlNodeType.Element, "referencias", "");
			foreach(Referencia r in libro.Referencias){
					XmlNode singleRef = docXml.CreateNode( XmlNodeType.Element, "referencia", "");
					
					XmlNode nodeAutor = docXml.CreateNode( XmlNodeType.Element, "autor", "");
					XmlNode nodeTitulo = docXml.CreateNode( XmlNodeType.Element, "titulo", "");
					XmlNode nodeDatos = docXml.CreateNode( XmlNodeType.Element, "datos", "");
					XmlNode nodeEdicion = docXml.CreateNode( XmlNodeType.Element, "edicion", "");
					XmlNode nodeExtension = docXml.CreateNode( XmlNodeType.Element, "extension", "");
					
					nodeAutor.InnerText = r.Autoria;
					nodeTitulo.InnerText = r.Titulo;
					nodeDatos.InnerText = r.Datos;
					nodeEdicion.InnerText = r.Edicion;
					nodeExtension.InnerText = r.Extension;
					
					singleRef.AppendChild(nodeAutor);
					singleRef.AppendChild(nodeTitulo);
					singleRef.AppendChild(nodeDatos);
					singleRef.AppendChild(nodeEdicion);
					singleRef.AppendChild(nodeExtension);
					
					nodoRefs.AppendChild(singleRef);
			}
			nodol.AppendChild(nodoRefs);
			//eof - Sección Referencias
			
			docXml.Save(this.Documento);			
		}
		
		/// <summary>
		/// Gets y sets del atributo documento.
		/// </summary>
		/// <value>
		/// El documento (nombre del .xml donde se guarda/crea).
		/// </value>
		private string Documento 
		{
			get;
			set;
		}
	}
}
	

