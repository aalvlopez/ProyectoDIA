using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Referencia con datos sobre el libro como autoría, título, datos, edición o extensión.
	/// </summary>
	public class Referencia
	{
		public String Autoria{ get; set;}
		public String Titulo{ get; set;}
		public String Datos{ get; set;}
		public String Edicion{ get; set;}
		public String Extension{ get; set;}

		/// <summary>
		/// Constructor de <see cref="WindowsFormsApplication1.Referencia"/> class.
		/// </summary>
		/// <param name='a'>
		/// Autoria.
		/// </param>
		/// <param name='t'>
		/// Titulo.
		/// </param>
		/// <param name='d'>
		/// Datos.
		/// </param>
		/// <param name='e'>
		/// Edicion.
		/// </param>
		/// <param name='ex'>
		/// Extension.
		/// </param>
		public Referencia(String a, String t, String d, String e, String ex){
			this.Autoria=a;
			this.Titulo=t;
			this.Datos=d;
			this.Edicion=e;
			this.Extension=ex;
		}	

		/// <summary>
		/// Verifica la correcta creación del archivo XML
		/// </summary>
		/*public static void InitializeXml(){
			if(!File.Exists(ArchivoXml)){
				XmlTextWriter textWritter = new XmlTextWriter(ArchivoXml, Encoding.UTF8); 
				textWritter.WriteStartDocument();
				textWritter.WriteStartElement("ListadoReferencias");
				textWritter.WriteEndElement();
				textWritter.WriteEndDocument();
				textWritter.Flush(); 
				textWritter.Close();
			}

		}*/
		/// <summary>
		/// Vuelca contenido de la lista en el archivo XML.
		/// </summary>
		/// <param name='list'>
		/// Lista de las referencias.
		/// </param>
		/*public static void SaveToXml(List<Referencia> list){			
			
				XmlTextWriter textWritter = new XmlTextWriter(ArchivoXml, Encoding.UTF8); 
				textWritter.WriteStartDocument();
				textWritter.WriteStartElement("ListadoReferencias");
				
				foreach(Referencia r in list){
					textWritter.WriteStartElement("Referencia");
					textWritter.WriteElementString("Autoria",r.Autoria);
					textWritter.WriteElementString("Titulo", r.Titulo);
					textWritter.WriteElementString("Edicion",r.Edicion);
					textWritter.WriteElementString("Extension",r.Edicion);
					textWritter.WriteElementString("Datos",r.Datos);
					textWritter.WriteEndElement();
				}
				
				textWritter.WriteEndElement();
				textWritter.WriteEndDocument();
				textWritter.Flush(); 
				textWritter.Close();
					
		}*/

		/// <summary>
		/// Carga el contenido del XML en una lista.
		/// </summary>
		/// <returns>
		/// La lista de referencias.
		/// </returns>
		/*public static List<Referencia> LoadXml(){
			InitializeXml();
			List<Referencia> list = new List<Referencia>();
			
				XmlDocument docXml=new XmlDocument(); 
				docXml.Load(ArchivoXml);
			
				foreach (XmlNode nodo in docXml.DocumentElement.ChildNodes) {
				
					Referencia r = new Referencia(nodo.SelectSingleNode("Autoria").InnerText,
				                              nodo.SelectSingleNode("Titulo").InnerText,
				                              nodo.SelectSingleNode("Datos").InnerText,
				                              nodo.SelectSingleNode("Edicion").InnerText,
				                              nodo.SelectSingleNode("Extension").InnerText
				                              );
					list.Add(r);
				}			
			return list;
		}*/
	}
}

