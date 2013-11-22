using System;
using System.Collections.Generic;
using System.Text;

namespace scActores
{
	/// <summary>
	/// Representa un actor.
	/// </summary>
    public class Actor
    {

        /// <summary>
        /// devuelve o modifica el nombre de la plantilla
        /// </summary>
        public string PlantillaName
        {
            get;set;

        }

        /// <summary>
        /// devuelve o modidifica los capitulos 
        /// </summary>
        public string Caps
        {
            get { return this.caps; }
            set {
                if (!this.caps.Contains(value) && this.caps!= null && this.caps.Length >0)
                {
                    this.caps += ",";
                    this.caps += value;
                }
                else if(this.caps.Length==0){
                        this.caps = value;
                    }
           }
        }

        /// <summary>
        /// devuelve o modifica el nombre 
        /// </summary>
        public string Nombre
        {
            get;set;

        }

        /// <summary>
        /// devuelve o modifica los datos de la plantilla
        /// </summary>
        public IDictionary<string, string> DatosPlantilla { 
            get; set; 
        }

      
      

       
        //p es nombre plantilla para el actor, viene vacia del getPlantilla
        //constructor para plantillas existentes
        
        
        /// <summary>
        /// Crea un nuevo actor
        /// </summary>
        /// <param name="p">
        /// El nombre de la plantilla asociada
        /// </param>
        /// <param name="name">
        /// El nombre del actor
        /// </param>
        /// <param name="caps">
        /// Los capitulos en los que aparece
        /// </param>
        /// <param name="datosPlantilla">
        /// Datos de la plantilla, campos vacíos
        /// </param>
        /// <returns>
        /// Un nuevo <seealso cref="scActores.Actor"/>
        /// </returns>
        public static Actor Crea(string p, string name, string caps, IDictionary<string, string> datosPlantilla)
        {
            return new Actor(p, name, caps, datosPlantilla);
        }

		  private Actor(string p, string name, string caps, IDictionary<string, string> datosPlantilla)
        {
            this.PlantillaName = p;
            this.Nombre = name;
            this.Caps = caps;
            this.DatosPlantilla = datosPlantilla;
        }

        private string caps = "";
        
    }
}
