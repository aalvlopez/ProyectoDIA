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
		/// Gets y sets del identificador del personaje(Id).
		/// </summary>
		public String Id{
			get;
			set;
		}

		/// <summary>
		/// Gets y sets de la primera escena del personaje
		/// </summary>
		public String Esc{
			get;set;
		}

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

        public Actor (string name, string cap
		, string descripcion,string id,string esc)
		{
			this.Id = id;
			this.Nombre = name;
			this.Descripcion = descripcion;
			this.Cap = cap;
			this.Esc = esc;
		}
        /// <summary>
        /// Crea un nuevo actor
        /// </summary>
        /// <param name="name">
        /// El nombre del actor
        /// </param>
        /// <param name="cap">
        /// El primer capitulo en el que aparece
        /// </param>
        /// <param name="descripcion">
        /// descripcion del personaje
        /// </param>
        /// <returns>
        /// Un nuevo <seealso cref="scActores.Actor"/>
        /// </returns>
		public Actor (string name, string cap, string descripcion,string esc)
        {
		
			DateTime start = new DateTime(1995, 1, 1);
		    Random gen = new Random();
		    int range = (DateTime.Today - start).Days;       
			this.Id = start.AddDays(gen.Next(range)).ToString("yyyyMMddHHmmssffff");

            this.Nombre = name;
            this.Cap = cap;
			this.Descripcion = descripcion;
			this.Esc = esc;
        }


        
    }
}
