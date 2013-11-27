using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace scActores
{
	/// <summary>
	/// Representa los actores 
	/// </summary>
    public class Actores : ICollection<Actor>
    {
        private const string ArchivoXml = "actores.xml";
        private const string NombreActor = "nombreActor";
        private const string NombrePlantilla = "nombrePlantilla";
        private const string Plantilla = "plantilla";
        private const string DatosPlantilla = "datosPlantilla";
        private const string ActoresNodo = "actores";
        private const string ActorNodo = "actor";
        private const string Capitulos = "capitulos";
      

     
		/// <summary>
		/// Guarda el archivo ArchivoXml
		/// </summary>
        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }

       
       /// <summary>
       /// Añade un actor
       /// </summary>
       /// <param name='a'>
       /// Un <see cref="scActores.Actor"/>
       /// </param>
        public void Add(Actor a)
        {
            this.actores.Add(a);
        }


		/// <summary>
		/// Borra un actor
		/// </summary>
        /// <param name='a'>
        /// Un <see cref="scActores.Actor"/>
        /// </param>
		///  
		/// 
        public bool Remove(Actor a)
        {
            return this.actores.Remove(a);
        }

		/// <summary>
		/// Borra el actor en la posicion indicada por el indice i
		/// </summary>
		/// <param name='i'>
		/// El indice
		/// </param>
        public void RemoveAt(int i)
        {
            this.actores.RemoveAt(i);
        }

		/// <summary>
		/// Añade unac coleccion de actores
		/// </summary>
        public void AddRange(ICollection<Actor> r)
        {
            this.actores.AddRange(r);
        }

		/// <summary>
		/// Devuelve el numero de actores
		/// </summary>
        public int Count
        {
            get { return this.actores.Count; }
        }

		/// <summary>
		/// Devuelve que no es de solo lectura
		/// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

		/// <summary>
		/// Borra todos los actores
		/// </summary>
        public void Clear()
        {
            this.actores.Clear();
        }


		/// <summary>
		/// Devuelve si existe el actor buscado
		/// </summary>
		/// <param name='r'>
		/// El <see cref="scActores.Actor"/> a buscar
		/// </param>
        public bool Contains(Actor r)
        {
            return this.actores.Contains(r);
        }

		/// <summary>
		/// Copia los actores a un array
		/// </summary>
		/// <param name='v'>
		/// Los actores
		/// </param>
		/// <param name='i'>
		/// La posicion desde la que se empieza a copiar
		/// </param>
        public void CopyTo(Actor[] v, int i)
        {
            this.actores.CopyTo(v, i);
        }

        // Enumerador genérico
        IEnumerator<Actor> IEnumerable<Actor>.GetEnumerator()
        {
            foreach (var r in this.actores)
            {
                yield return r;
            }
        }

        // Enumerador básico
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var r in this.actores)
            {
                yield return r;
            }
        }

        // Indizador
        public Actor this[int i]
        {
            get { return this.actores[i]; }
            set { this.actores[i] = value; }
        }

		/// <summary>
		/// Devuelve una cadena que representa los actores.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> que representa los <see cref="scActores.Actores"/>.
		/// </returns>
        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (var r in this.actores)
            {
                toret.AppendLine(r.ToString());
            }

            return toret.ToString();
        }


        

		/// <summary>
		/// Devuelve los actores
		/// </summary>
        public static Actores Crea()
        {
            var toret = new Actores();
            Actor[] actoresLocal = RecuperaXml(ArchivoXml);

            toret.AddRange(actoresLocal);
            return toret;
        }

		/// <summary>
		/// Devuelve los nombres de los actores
		/// </summary>
		/// <returns>
		/// Una <see cref="System.Collections.Generic.List"> con los nombres de los actores
		/// </returns>
		public List<string> GetNombreActor()
        {
            var toret = new List<string>();

            foreach (var r in actores)
            {
                toret.Add(r.Nombre);
            }

            return toret;

            
        }

        private Actores()
        {
            actores = new List<Actor>();
        }

        private List<Actor> GetActores()
        {
            return this.actores;
        }
        private void GuardaXml(string f)
        {
            var writer = new XmlTextWriter(f, Encoding.UTF8);
            writer.WriteStartDocument();

            writer.WriteStartElement(ActoresNodo);

            foreach (var r in this.actores)
            {
                writer.WriteStartElement(ActorNodo);//abre actor

                writer.WriteStartAttribute(NombreActor);
                writer.WriteString(r.Nombre);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute(Capitulos);
                writer.WriteString(r.Caps);
                writer.WriteEndAttribute();


                writer.WriteStartElement(Plantilla);//abre plantilla

                writer.WriteStartElement(NombrePlantilla);
                writer.WriteString(r.PlantillaName);
                writer.WriteEndElement();//cierre nombre plantilla


                writer.WriteStartElement(DatosPlantilla);//abre datosPlantilla

                foreach (var a in r.DatosPlantilla)
                {
                    writer.WriteStartElement(a.Key);
                    writer.WriteString(a.Value);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();//cierra datosPlantilla

                writer.WriteEndElement();//cierra plantilla

                writer.WriteEndElement();//cierra actor

            }

            writer.WriteEndElement();//cierra actores

            writer.WriteEndDocument();
            writer.Close();
        }

		private static Actor[] RecuperaXml(string f)
        {
            var toret = new List<Actor>();
            var docXml = new XmlDocument();
            IDictionary<string, string> datos = new Dictionary<string, string>();

            try
            {
                docXml.Load(ArchivoXml);
                if (docXml.DocumentElement.Name.Equals(ActoresNodo))
                {
                    string nombre = "";
                    string plantilla = "";
                    string caps = "";
                    
                    foreach (XmlNode nodo in docXml.DocumentElement.ChildNodes)
                    {

                        if(nodo.Name.Equals(ActorNodo)){

                            XmlAttribute atr = nodo.Attributes[NombreActor];
                            nombre = atr.InnerText.Trim();

                            XmlAttribute atr2 = nodo.Attributes[Capitulos];
                            caps = atr2.InnerText.Trim();
                            

                            // Recorrer los nodos interiores: plantilla, datosPlantilla
                            foreach (XmlNode subNodo in nodo.ChildNodes)
                            {
                                
                                  if(subNodo.Name.Equals(Plantilla))
									{
										plantilla = subNodo.InnerText.Trim();
									}
                                
                                    else if (subNodo.Name.Equals(DatosPlantilla) && subNodo.HasChildNodes)
                                    {
                                        foreach (XmlNode node in subNodo.ChildNodes)
                                        {
                                            //elem representa una caracteristica de la plantilla
                                            //node.InnerText aqui es lo guardado para esa caracteristica
											
                                            string elem = node.Name;
                                            datos.Add(elem,node.InnerText.Trim());
                                        }
                                    }
                            }

                            if (nombre.Length > 0
                              && plantilla.Length > 0
                              && caps.Length > 0)
                            {
								toret.Add(Actor.Crea(plantilla, nombre, caps,datos));
                            }
                        }
                    }
				}
			}
            catch (XmlException)
            {
                toret.Clear();
            }
            catch (IOException)
            {
                toret.Clear();
            }

            return toret.ToArray();
        }

        private List<Actor> actores;
        

    }
}
