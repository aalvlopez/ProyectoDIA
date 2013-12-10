using System;
using System.Collections.Generic;

namespace Referencias
{
	public class Libro
	{
		private static List<Referencia> listadoReferencias = new List<Referencia>();

		public Libro()
		{

		}

		public static List<Referencia> ListReferencias(){
			return listadoReferencias;
		}
	}
}

