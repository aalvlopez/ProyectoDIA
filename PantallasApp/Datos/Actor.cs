using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Representa un actor.
	/// </summary>
    public class Actor
    {

        

        /// <summary>
        /// devuelve o modidifica los capitulos 
        /// </summary>
        public string Cap
        {
            get;set;
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
		public string Descripcion { 
            get; set; 
        }

      
      

       
       
        
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
		public static Actor Crea(string name, string cap, string descripcion)
        {
			return new Actor(name, cap, descripcion);
        }

		private Actor(string name, string cap
		, string descripcion)
        {
            this.Nombre = name;
            this.Cap = cap;
			this.Descripcion = descripcion;
        }

        
    }
}
