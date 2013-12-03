//using System;
//using System.Xml;
//using System.Text;
//
//namespace Scrivener
//{
//	public class SaveXML
//	{
//		public SaveXML (string documento)
//		{
//			this.Documento = documento;
//		}
//		
//		public void Guardar (Libro libro)
//		{
//			XmlDocument docXml = new XmlDocument();
//			
//			XmlNode nodo = docXml.CreateNode( XmlNodeType.XmlDeclaration
//											, "xml", "");
// 			((XmlDeclaration)nodo).Encoding = "utf-8";
//			
//			docXml.AppendChild ( nodo );
//			
//			XmlNode nodol = docXml.CreateNode( XmlNodeType.Element, "libro", "");
//			nodol.InnerText = libro.Titulo;
//			docXml.AppendChild( nodol );
//		
//			XmlAttribute ltit = docXml.CreateAttribute( "titulo" );
//			ltit.InnerText = libro.Anotacion;
//			nodol.Attributes.Append( ltit );
//			
//			XmlAttribute lant = docXml.CreateAttribute( "anotacion" );
//			lant.InnerText = libro.Anotacion;
//			nodol.Attributes.Append( lant );
//			
//			XmlNode nodocs = docXml.CreateNode( XmlNodeType.Element, "capitulos", "");
//			docXml.AppendChild( nodocs );
//			
//			while (libro.Capitulos.First())
//			{
//				XmlNode nodoc = docXml.CreateNode( XmlNodeType.Element, "capitulo", "");
//				nodoc.InnerText = libro.Capitulos.First;
//				docXml.AppendChild( nodocs );
//				
//				XmlAttribute ctit = docXml.CreateAttribute( "titulo" );
//				ctit.InnerText = libro.Anotacion;
//				nodol.Attributes.Append( ctit );
//				
//				XmlAttribute cant = docXml.CreateAttribute( "anotacion" );
//				cant.InnerText = libro.Anotacion;
//				nodol.Attributes.Append( cant );
//				
//				XmlNode nodoes = docXml.CreateNode( XmlNodeType.Element, "escenas", "");
//				docXml.AppendChild( nodoes );
//				
//				while (libro.Capitulos.First.First)
//				{
//					XmlNode nodoe = docXml.CreateNode( XmlNodeType.Element, "escena", "");
//					//nodoe.InnerText = libro.Capitulos.First.;
//					docXml.AppendChild( nodoes );
//					
//					XmlAttribute etit = docXml.CreateAttribute( "titulo" );
//					etit.InnerText = libro.Anotacion;
//					nodol.Attributes.Append( etit );
//					
//					XmlAttribute eant = docXml.CreateAttribute( "anotacion" );
//					eant.InnerText = libro.Anotacion;
//					nodol.Attributes.Append( eant );
//					
//					XmlAttribute econt = docXml.CreateAttribute( "contenido" );
//					econt.InnerText = libro.Anotacion;
//					nodol.Attributes.Append( econt );		
//					
//					libro.Capitulos.RemoveFirst(); //Una vez guardado el primer nodo, se elimina.	
//					
//				}
//				nodocs.AppendChild( nodoes );
//				
//				libro.Capitulos.RemoveFirst(); //Una vez guardado el primer nodo, se elimina.
//				
//				
//			}
//			nodol.AppendChild( nodocs );
//			
//			
//			docXml.Save( "personas.dat" );
//		}
//		
//				private string Documento 
//		{
//			get;
//			set;
//		}
//	}
//}
//
///*
// * foreach(var i in list){
// * i es un objeto de la lista
// * foreach(var j in i.getEscenas())
// * j es una escena
// */