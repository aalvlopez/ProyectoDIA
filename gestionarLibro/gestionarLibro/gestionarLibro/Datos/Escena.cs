using System;
using System.Collections.Generic;

namespace Scrivener
{
	public class Escena
	{
		public Escena (){
		}
		
		public Escena (String titulo, String anotacion, String contenido)
		{
			Titulo = titulo;
			Anotacion = anotacion;
			Contenido = contenido;
		}
		
		public String Titulo 
		{
			get;
			set;
		}
		
		public String Anotacion 
		{
			get;
			set;
		}
		
		public String Contenido 
		{
			get;
			set;
		}
	}
}


