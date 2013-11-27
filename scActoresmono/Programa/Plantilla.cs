using System;
using System.Collections.Generic;
using System.Text;

namespace scActores
{
    

	/// <summary>
	/// Representa una Plantilla.
	/// </summary>
    public class Plantilla
    {
		/// <summary>
		///Devuelve o modifica el nombre de una plantilla
		/// </summary>
        public string NombrePlantilla
        {
            get;
            set;
        }

		/// <summary>
		/// Devuelve o modifica la informacion asociada a una plantilla
		/// </summary>
        public IDictionary<string, string> DatosPlantilla
        {
            get;
            set;
        }
        

        

		/// <summary>
		/// Crea una nueva plantilla vacia
		/// </summary>
		/// <param name='name'>
		/// El nombre de la plantilla
		/// </param>
        public static Plantilla Crea(string name)
        {

            IDictionary<string, string> datosPlantilla = new Dictionary<string,string>();
            return new Plantilla(name, datosPlantilla);

        }

		/// <summary>
		/// Recupera una plantilla cubierta
		/// </summary>
		/// <param name='name'>
		/// Name.
		/// </param>
		/// <param name='datosPlantilla'>
		/// Datos plantilla.
		/// </param>
        public static Plantilla Recupera(string name, IDictionary<string, string> datosPlantilla)
        {
            return new Plantilla(name, datosPlantilla);
        }

		public static IDictionary<string,string> crearDatos (List<string> datos)
		{
			var toret = new Dictionary<string,string>();
			foreach (var r in datos) {
				toret.Add(r,null);
			}
			return toret;
		}

		private Plantilla(string name, IDictionary<string, string> n)
        {
            NombrePlantilla = name;
            DatosPlantilla = n;
        }

      


        
    }
}
