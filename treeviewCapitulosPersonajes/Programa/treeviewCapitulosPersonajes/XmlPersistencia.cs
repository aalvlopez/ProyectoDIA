using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Text;
using System.Collections.Generic;
namespace treeviewCapitulosPersonajes
{
	/// <summary>
	/// Implementacion de la interfaz <see cref="treeviewCapitulosPersonajes.IPersistencia"/>
	/// </summary>
	public  class XmlPersistencia:IPersistencia
	{
		/// <summary>
		/// Gets y sets de la propiedad Documento.
		/// </summary>
		/// <value>
		/// Contiene el nombre del documento xml que contiene la informacion a leer.
		/// </value>
		private string Documento {
			get;
			set;
		}
		/// <summary>
		/// Inicializa una instacia de la clase <see cref="treeviewCapitulosPersonajes.XmlPersistencia"/>.
		/// </summary>
		/// <param name='documento'>
		/// Nombre del documento que contiene la informacion.
		/// </param>
		public XmlPersistencia (string documento)
		{
			this.Documento = documento;
		}
		/// <summary>
		/// Este metodo lee los datos del fichero xml dado y devuelve un objeto 
		/// <see cref="treeviewCapitulosPersonajes.Libro"/> que contiene toda la informacion
		/// relativa al libro, los capitulos con sus escenas y los personajes.
		/// </summary>
		/// <returns>
		/// Devuelve un objeto <see cref="treeviewCapitulosPersonajes.Libro"/> con la informacion contenida en 
		/// el fichero xml leido.
		/// </returns>
		public  Libro Lectura ()
		{
			Libro libro = new Libro();
			try {
				XmlDocument document = new XmlDocument ();
				document.Load (this.Documento);
				foreach (XmlNode nodo in document.DocumentElement.ChildNodes) {
					switch (nodo.Name){
					case "titulo":
						libro.Titulo=nodo.InnerText;
							break;
					case "capitulos":
						foreach( XmlNode nodo2 in nodo.ChildNodes){
							Capitulo capitulo = new Capitulo ();
							XmlAttributeCollection atributes =  nodo2.Attributes;
							capitulo.Id=atributes.GetNamedItem("id").Value.ToString();
							foreach ( XmlNode nodo3 in nodo2.ChildNodes){
								switch( nodo3.Name){
								case "titulo":
									capitulo.Titulo = nodo3.InnerText;
									break;
								case "escenas":
									foreach( XmlNode nodo4 in nodo3.ChildNodes){
										Escena escena = new Escena();
										XmlAttributeCollection atributes2 =  nodo4.Attributes;
										escena.Id=atributes2.GetNamedItem("id").Value.ToString();
										foreach ( XmlNode nodo5 in nodo4.ChildNodes){
											switch( nodo5.Name){
											case "titulo":
												escena.Titulo = nodo5.InnerText;
												break;
											case "contenido":
												escena.Contenido = nodo5.InnerText;
												break;

											}
										}
										capitulo.ListEscenas.AddLast(escena);
									}
									break;
								}
							}
							libro.ListCapitulos.AddLast(capitulo);
						}
						break;
					case  "personajes":
						foreach( XmlNode nodo2 in nodo.ChildNodes){
							Personaje personaje = new Personaje ();
							XmlAttributeCollection atributes =  nodo2.Attributes;
							personaje.Id=atributes.GetNamedItem("id").Value.ToString();
							foreach(XmlNode nodo3 in nodo2.ChildNodes){
								switch( nodo3.Name){
								case "nombre":
									personaje.Nombre = nodo3.InnerText;
									break;
								case "descripcion":
									personaje.Descripcion = nodo3.InnerText;
									break;
								}
							}
							libro.ListPersonajes.AddLast(personaje);
						}
						break;
					}

				}
				return libro;

			} catch (Exception E) {
				Console.WriteLine(E.ToString());
				return null;
			}

		}
	}
}

