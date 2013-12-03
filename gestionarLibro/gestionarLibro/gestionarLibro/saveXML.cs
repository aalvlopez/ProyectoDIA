using System;
using System.Xml;
using System.Text;

namespace Scrivener
{
	public class SaveXML
	{
		public SaveXML (string documento)
		{
			this.Documento = documento;
		}
		
		public void Guardar (Libro libro)
		{
			XmlDocument docXml = new XmlDocument();
			
			XmlNode nodo = docXml.CreateNode( XmlNodeType.XmlDeclaration
											, "xml", "");
 			((XmlDeclaration)nodo).Encoding = "utf-8";
			
			docXml.AppendChild ( nodo );
			
			XmlNode nodol = docXml.CreateNode( XmlNodeType.Element, "libro", "");
			
			
			
			XmlNode ltit = docXml.CreateNode( XmlNodeType.Element, "titulo", "");
			ltit.InnerText = libro.Titulo;
			nodol.AppendChild( ltit );
			
			XmlNode lant = docXml.CreateNode( XmlNodeType.Element, "anotacion", "" );
			lant.InnerText = libro.Anotacion;
			nodol.AppendChild( lant );
			
			XmlNode nodocs = docXml.CreateNode( XmlNodeType.Element, "capitulos", "");
			
			Console.WriteLine("epilepsia");
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
					econt.InnerText = j.Contenido;
					nodoe.AppendChild( econt );			
					
					nodoc.AppendChild( nodoes );
				}
				nodocs.AppendChild( nodoc );				
				
			}
			nodol.AppendChild( nodocs );
			
			docXml.AppendChild( nodol );
			
			docXml.Save(this.Documento);
			
		}
		
		private string Documento 
		{
			get;
			set;
		}
	}
}

/*
 * foreach(var i in list){
 * i es un objeto de la lista
 * foreach(var j in i.getEscenas())
 * j es una escena
 */