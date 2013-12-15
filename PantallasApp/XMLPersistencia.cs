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
                        string idPersonaje = "";
                        string escPersonaje = "";
                        XmlDocument docXml = new XmlDocument();
                         docXml.Load (this.Documento);
                        //carga contenido personajes libro
                        XmlNodeList personajes = docXml.GetElementsByTagName("personaje");
                        foreach (XmlNode personaje in personajes) {
                                idPersonaje = personaje.Attributes["id"].Value;
                                nombrePersonaje  = personaje.ChildNodes[0].InnerText.Trim();
                                capPersonaje  = personaje.ChildNodes[1].InnerText.Trim();
                                escPersonaje = personaje.ChildNodes[2].InnerText.Trim();
                                descPersonaje  = personaje.ChildNodes[3].InnerText.Trim();
                                libro.Actores.Add(new Actor(nombrePersonaje, 
                                                                                capPersonaje,
                                                                                descPersonaje,idPersonaje,escPersonaje)
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
                                                                        XmlAttributeCollection eid = nodo5.Attributes;
                                                                        escena.Id = eid.GetNamedItem("id").Value;
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
                        XmlTextWriter textWriter = new XmlTextWriter(this.Documento, Encoding.UTF8); 
                        
                        textWriter.WriteStartDocument();
                        textWriter.WriteStartElement("tns:libro");                        
                        textWriter.WriteAttributeString("xmlns:tns", "http://www.esei.uvigo.es/libro");
                        textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.esei.uvigo.es/libro libro.xsd");                        
                        
                        textWriter.WriteElementString("titulo",libro.Titulo);
                        textWriter.WriteElementString("anotacion",libro.Anotacion);
                        
                        //bof personajes
                        textWriter.WriteStartElement("personajes");
                        foreach (var actor in libro.Actores) {
                                textWriter.WriteStartElement("personaje");
                                textWriter.WriteAttributeString("id",actor.Id);
                                textWriter.WriteElementString("nombrePersonaje",actor.Nombre);
                                textWriter.WriteElementString("cap",actor.Cap);
                                textWriter.WriteElementString("escena",actor.Esc);                                
                                textWriter.WriteStartElement("descripcion");
                                textWriter.WriteCData(actor.Descripcion);
                                textWriter.WriteEndElement();                                
                                textWriter.WriteEndElement();
                        }                        
                        textWriter.WriteEndElement();
                        //eof personajes
                        
                        //bof capitulos
                        textWriter.WriteStartElement("capitulos");
                        foreach(var i in libro.Capitulos)
                        {
                                textWriter.WriteStartElement("capitulo");
                                textWriter.WriteAttributeString("id",i.Id);
                                textWriter.WriteElementString("titulo",i.Titulo);
                                textWriter.WriteElementString("anotacion",i.Anotacion);
                                
                                //escenas
                                textWriter.WriteStartElement("escenas");
                                foreach(var j in i.Escenas)
                                {
                                        textWriter.WriteStartElement("escena");
                                        textWriter.WriteAttributeString("id",j.Id);
                                        textWriter.WriteElementString("titulo",j.Titulo);
                                        textWriter.WriteElementString("anotacion",j.Anotacion);
                                        
                                        textWriter.WriteStartElement("contenido");
                                        textWriter.WriteCData(j.Contenido);
                                        textWriter.WriteEndElement();                        
                                        
                                        textWriter.WriteEndElement();
                                }
                                textWriter.WriteEndElement();
                                
                                textWriter.WriteEndElement();
                        }
                        textWriter.WriteEndElement();
                        //eof capitulos                
                        
                        //bof - Sección Referencias
                        textWriter.WriteStartElement("referencias");                        
                        foreach(Referencia r in libro.Referencias){
                                textWriter.WriteStartElement("referencia");
                                textWriter.WriteElementString("autor",r.Autoria);
                                textWriter.WriteElementString("titulo", r.Titulo);
                                textWriter.WriteElementString("datos",r.Datos);
                                textWriter.WriteElementString("edicion",r.Edicion);
                                textWriter.WriteElementString("extension",r.Extension);
                                textWriter.WriteEndElement();
                        }                        
                        textWriter.WriteEndElement();
                        //eof - Sección Referencias
                        
                        textWriter.WriteEndElement();
                        textWriter.WriteEndDocument();
                        textWriter.Flush();
                        textWriter.Close();
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
        