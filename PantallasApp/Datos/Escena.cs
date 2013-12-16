using System;
using System.Collections.Generic;

namespace DIAScribe
{
	/// <summary>
	/// Escena.
	/// </summary>
	public class Escena
	{
		/// <summary>
        /// Crea una nueva <see cref="DIAScribe.Escena"/> vacia.
		/// </summary>
		public Escena (){
			DateTime start = new DateTime(1995, 1, 1);
		    Random gen = new Random();
		    int range = (DateTime.Today - start).Days;       
			this.Id = start.AddDays(gen.Next(range)).ToString("yyyyMMddHHmmssffff");
			
			this.Anotacion="";
			this.Contenido="";
			this.Titulo="";
		}
		
		/// <summary>
        /// Crea una nueva <see cref="DIAScribe.Escena"/> .
		/// </summary>
		/// <param name='titulo'>
		/// Titulo.
		/// </param>
		/// <param name='anotacion'>
		/// Anotacion.
		/// </param>
		/// <param name='contenido'>
		/// Contenido.
		/// </param>
		public Escena (String titulo, String anotacion, String contenido, String idCapitulo)
		{
			DateTime start = new DateTime(1995, 1, 1);
		    Random gen = new Random();
		    int range = (DateTime.Today - start).Days;       
			this.Id = start.AddDays(gen.Next(range)).ToString("yyyyMMddHHmmssffff");
			
			Titulo = titulo;
			Anotacion = anotacion;
			Contenido = contenido;
			IdCapitulo = idCapitulo;
		}
		
		/// <summary>
		/// Modifica la escena
		/// </summary>
		/// <param name='titulo'>
		/// Titulo.
		/// </param>
		/// <param name='anotacion'>
		/// Anotacion.
		/// </param>
		/// <param name='contenido'>
		/// Contenido.
		/// </param>
		public void ModificarEscena (String titulo, String anotacion, String contenido)
		{
			this.Titulo = titulo;
			this.Anotacion = anotacion;
			this.Contenido = contenido;
		}
		public override string ToString ()
		{
			return string.Format (this.Titulo);
		}
		/// <summary>
		/// Gets y sets del identificador(ID).
		/// </summary>
		/// <value>
		/// El identificador(ID).
		/// </value>
		public String Id{
			get;
			set;
		}
		
		/// <summary>
		/// Gets y sets de titulo.
		/// </summary>
		/// <value>
		/// El titulo.
		/// </value>
		public String Titulo 
		{
			get;
			set;
		}
		
		/// <summary>
		/// Gets y sets de anotacion.
		/// </summary>
		/// <value>
		/// La anotacion.
		/// </value>
		public String Anotacion 
		{
			get;
			set;
		}
		
		/// <summary>
		/// Gets y sets de contenido.
		/// </summary>
		/// <value>
		/// El contenido
		/// </value>
		public String Contenido 
		{
			get;
			set;
		}

		public String IdCapitulo
		{
			get;
			set;
		}
	}
}