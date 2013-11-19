using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace scActores
{
	/// <summary>
	/// Plantillas para ayudar a crear actores
	/// </summary>
    class Plantillas : ICollection<Plantilla>
    {
        public const string ArchivoXml = "plantillas.xml";
        public const string NombrePlantilla = "nombrePlantilla";
        public const string PlantillasActores = "plantillas";
        public const string PlantillaActor = "plantilla";
        public const string DatosPlantilla = "datosPlantilla";
        
		/// <summary>
		/// Devuelve o modifica las plantillas
		/// </summary>
        public List<Plantilla> PlantillasActor
        {
            get;set;

        }

      
		/// <summary>
		/// Guarda the xml de las plantillas.
		/// </summary>
        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }

        
		/// <summary>
		/// Añade una plantilla
		/// </summary>
		/// <param name='a'>
		/// La <see cref="scActores.Plantilla"/> a insertar
		/// </param>
        public void Add(Plantilla a)
        {
            this.plantillasActor.Add(a);
        }

	
		/// <summary>
		/// Borra una plantilla
		/// </summary>
		/// <param name='a'>
		/// La <see cref="scActores.Plantilla"/> a borrar
		/// </param>
        public bool Remove(Plantilla a)
        {
            return this.plantillasActor.Remove(a);
        }

		/// <summary>
		/// Borra una plantilla en el indice i
		/// </summary>
		/// <param name='i'>
		/// El indice
		/// </param>
        public void RemoveAt(int i)
        {
            this.plantillasActor.RemoveAt(i);
        }

		/// <summary>
		/// Añade actores
		/// </summary>
		/// <param name='r'>
		/// Una coleccion de plantillas
		/// </param>
        public void AddRange(ICollection<Plantilla> r)
        {
            this.plantillasActor.AddRange(r);
        }

		/// <summary>
		/// Devuelve el numero de plantillas
		/// </summary>
        public int Count
        {
            get { return this.plantillasActor.Count; }
        }

		/// <summary>
		/// Devuelve si es de solo lectura
		/// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

		/// <summary>
		/// borra las plantillas
		/// </summary>
        public void Clear()
        {
            this.plantillasActor.Clear();
        }


		/// <summary>
		/// Devuelve si existe la plantilla buscada
		/// </summary>
		/// <param name='r'>
		/// La <see cref="scActores.Plantilla"/> a buscar
		/// </param>
        public bool Contains(Plantilla r)
        {
            return this.plantillasActor.Contains(r);
        }

	
		/// <summary>
		/// Copia las plantillas a un array
		/// </summary>
		/// <param name='v'>
		/// Las plantillas
		/// </param>
		/// <param name='i'>
		/// La posicion desde la que se empieza a copiar
		/// </param>
        public void CopyTo(Plantilla[] v, int i)
        {
            this.plantillasActor.CopyTo(v, i);
        }

        // Enumerador genérico
        IEnumerator<Plantilla> IEnumerable<Plantilla>.GetEnumerator()
        {
            foreach (var r in this.plantillasActor)
            {
                yield return r;
            }
        }

        // Enumerador básico
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var r in this.plantillasActor)
            {
                yield return r;
            }
        }

        // Indizador
        public Plantilla this[int i]
        {
            get { return this.plantillasActor[i]; }
            set { this.plantillasActor[i] = value; }
        }

		/// <summary>
		/// Devueleve una cadena que representa las <see cref="scActores.Plantillas"/>.
		/// </summary>
		/// <returns>
		/// Una <see cref="System.String"/> que representa las <see cref="scActores.Plantillas"/>.
		/// </returns>
        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (var r in this.plantillasActor)
            {
                toret.AppendLine(r.ToString());
            }

            return toret.ToString();
        }

		/// <summary>
		/// Recuperas las plantillas del xml.
		/// </summary>
		/// <returns>
		/// Las plantillas
		/// </returns>
		/// <param name='f'>
		/// El nombre del archivo xml que contiene las plantillas
		/// </param>
       
        public static Plantilla[] RecuperaXml(string f)
        {
            var toret = new List<Plantilla>();
            var datos = new Dictionary<string, string>();
            var docXml = new XmlDocument();
            var atra = "";
           

            try
            {
                docXml.Load(ArchivoXml);
          




                if (docXml.DocumentElement.Name == PlantillasActores)
                {
                    string nombrePlantilla = "";
                    string nombreNodo = "";
                    string data = "";
                    
              

                    foreach (XmlNode nodo in docXml.DocumentElement.ChildNodes)
                    {
                        if (nodo.Name == PlantillaActor)
                        {
                            XmlAttribute atr = nodo.Attributes[NombrePlantilla];


                            nombrePlantilla = atr.InnerText.Trim();


                            // Recorrer los nodos interiores: plantilla, caps
                            foreach (XmlNode subNodo in nodo.ChildNodes)
                            {
                                if (subNodo.Name.Equals(DatosPlantilla))
                                {
                                    foreach (XmlNode node in subNodo.ChildNodes)
                                    {
                                        nombreNodo = node.Name.Trim();
                                        data = node.InnerText.Trim();
                                        if((nombreNodo.Length > 0 ) && (data.Length > 0)){
                                            datos.Add(nombreNodo, data);
                                        }
                                    }
                                }
                                
                            }

                            
                            if (nombrePlantilla.Length > 0)
                            {

                                toret.Add(Plantilla.Recupera(nombrePlantilla, datos));
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

		/// <summary>
		/// recuepera las plantillas
		/// </summary>
        public static Plantillas Crea()
        {
            var toret = new Plantillas();
            Plantilla[] plantillas= RecuperaXml(ArchivoXml);
           

            toret.AddRange(plantillas);

            return toret;
        }

      	/// <summary>
      	/// Devuelve los nombres de las plantillas
      	/// </summary>
      	/// <returns>
      	/// Un array con los nombres de las <see cref="scActores.Plantillas"/>
      	/// </returns>
        public string[] GetNombrePlantilla()
        {
            var toret = new List<string>();

            foreach (var r in plantillasActor)
            {
                toret.Add(r.NombrePlantilla);
            }

            return toret.ToArray();

            
        }

		/// <summary>
		/// Devuelve los datos de la plantilla
		/// </summary>
		/// <returns>
		/// Un <see cref="System.Collections.Generic.IDictionary"/> con los datos de la plantilla
		/// </returns>
		/// <param name='p'>
		/// El nombre de la plantilla
		/// </param>
        public IDictionary<string,string> GetDatosPlantilla(string p)
        {
            IDictionary<string, string> toret = new Dictionary<string, string>();

            foreach (var r in plantillasActor)
            {
                if (r.NombrePlantilla.Equals(p))
                {
                    toret = r.DatosPlantilla;
                }
                    
            }

            return toret;


        }

		 private Plantillas()
        {
            plantillasActor = new List<Plantilla>();
        }

      

        private void GuardaXml(string f)
        {
            var writer = new XmlTextWriter(f, Encoding.UTF8);
            writer.WriteStartDocument();

            writer.WriteStartElement(PlantillasActores);

            foreach (var r in this.plantillasActor)
            {
                writer.WriteStartElement(PlantillaActor);
                writer.WriteStartAttribute(NombrePlantilla);
                writer.WriteString(r.NombrePlantilla);
                writer.WriteEndAttribute();

                writer.WriteStartElement(DatosPlantilla);//abre datosPlantilla

               	writer.WriteStartAttribute(NombrePlantilla);
                writer.WriteString(r.NombrePlantilla);
                writer.WriteEndAttribute();

                writer.WriteEndElement();//cierra datosPlantilla
                writer.WriteEndElement();//cierra plantilla
            }

            writer.WriteEndElement();//cierra plantillas

            writer.WriteEndDocument();
            writer.Close();
        }


        private List<Plantilla> plantillasActor;
        


        
    }

    
}
