using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace DIAScribe
{
	/// <summary>
	/// Referencia con datos sobre el libro como autoría, título, datos, edición o extensión.
	/// </summary>
	public class Referencia
	{
		public String Autoria{ get; set;}
		public String Titulo{ get; set;}
		public String Datos{ get; set;}
		public String Edicion{ get; set;}
		public String Extension{ get; set;}

		/// <summary>
		/// Constructor de <see cref="DIAScribe.Referencia"/> class.
		/// </summary>
		/// <param name='a'>
		/// Autoria.
		/// </param>
		/// <param name='t'>
		/// Titulo.
		/// </param>
		/// <param name='d'>
		/// Datos.
		/// </param>
		/// <param name='e'>
		/// Edicion.
		/// </param>
		/// <param name='ex'>
		/// Extension.
		/// </param>
		public Referencia(String a, String t, String d, String e, String ex){
			this.Autoria=a;
			this.Titulo=t;
			this.Datos=d;
			this.Edicion=e;
			this.Extension=ex;
		}	
	}
}

