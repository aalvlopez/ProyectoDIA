using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Un libro.
	/// </summary>
	public class Libro
	{
		/// <summary>
		/// Propiedad que define los Gets y Sets del titulo de <see cref="Scrivener.Libro">.
		/// </summary>
		/// <value>
		/// El titulo.
		/// </value>
		public String Titulo {
			get;
			set;
		}
		
		/// <summary>
		/// Propiedad que define los Gets y Sets de una anotacion de <see cref="Scrivener.Libro">.
		/// </summary>
		/// <value>
		/// Una anotacion.
		/// </value>
		public String Anotacion {
			get;
			set;
		}
		
		/// <summary>
		/// Gets or sets de capitulos.
		/// </summary>
		/// <value>
		/// LinkedList de Capitulos.
		/// </value>
		public LinkedList<Capitulo> Capitulos {
			get;
			set;
		}

		/// <summary>
		/// Propiedad que define los Gets y Sets de los actores de <see cref="Scrivener.Libro">.
		/// </summary>
		/// <value>
		/// Los actores
		/// </value>
		public Actores Actores {
			get;
			set;
		}
		
		public List<Referencia> Referencias {
			get;
			set;
		}	
		
		/// <summary>
		/// Crea un nuevo <see cref="Scrivener.Libro"/> vacio.
		/// </summary>
		public Libro ()
		{
			this.Capitulos = new LinkedList<Capitulo> ();
			this.Referencias = new List<Referencia> ();
			this.Anotacion = "";
			this.Titulo = "";
			this.Actores = new Actores ();
		}
		
		/// <summary>
		/// Crea un nuevo <see cref="Scrivener.Libro"/>.
		/// </summary>
		/// <param name='titulo'>
		/// Titulo.
		/// </param>
		public Libro (String titulo)
		{
			this.Capitulos = new LinkedList<Capitulo> ();
			this.Anotacion = "";
			this.Titulo = titulo;
			this.Referencias = new List<Referencia> (); 
			this.Actores = new Actores ();
		}
		
		/// <summary>
		/// Crea un nuevo <see cref="Scrivener.Libro"/>.
		/// </summary>
		/// <param name='titulo'>
		/// Titulo.
		/// </param>
		/// <param name='anotacion'>
		/// Anotacion.
		/// </param>
		/// <param name='capitulos'>
		/// Capitulos.
		/// </param>
		/// <param name='actores'>
		/// Actores.
		/// </param>
		public Libro (String titulo, String anotacion, LinkedList<Capitulo> capitulos, Actores actores, List<Referencia> referencias)
		{
			Titulo = titulo;
			Anotacion = anotacion;			
			this.Capitulos = capitulos;
			this.Actores = actores;
			this.Referencias = referencias;
		}
		
		/// <summary>
		/// Crear un nuevo capitulo.
		/// </summary>
		/// <param name='titulo'>
		/// Titulo.
		/// </param>
		/// <param name='anotacion'>
		/// Anotacion.
		/// </param>
		public void CrearCapitulo (String titulo, String anotacion)
		{
			this.Capitulos.AddLast (new Capitulo (titulo, anotacion));
		}

		/// <summary>
		/// Buscas el capítulo que coincida con el identificador.
		/// </summary>
		/// <returns>
		/// Devuelve el capítulo que coincida con el ID, o en caso de no encontrarlo devuelve Null
		/// </returns>
		/// <param name='id'>
		/// Identificador.
		/// </param>
		public Capitulo BuscarCapituloId (String id)
		{
			foreach (var i in this.Capitulos) {
				if (id.Equals (i.Id))
					return i;
			}
			return null;
		}

		/// <summary>
		/// Buscas la escena dentro de todos los capítulos contenidos en el libro que coincida con el identificador.
		/// </summary>
		/// <returns>
		/// Devuelve la escena que coincida con el ID, o en caso de no encontrarlo devuelve Null
		/// </returns>
		/// <param name='id'>
		/// Identificador.
		/// </param>
		public Escena BuscarEscenaId (String id)
		{
			foreach (var i in this.Capitulos) {
				Escena aux = i.BuscarEscenaId (id);
				if (aux != null) {
					return aux;
				}
						
			}
			return null;
		}
        
		/// <summary>
		/// Buscas el personaje que coincida con el identificador.
		/// </summary>
		/// <returns>
		/// evuelve el personaje que coincida con el ID, o en caso de no encontrarlo devuelve Null
		/// </returns>
		/// <param name='id'>
		/// Identificador.
		/// </param>
		public Actor BuscarPersonajeId (String id)
		{
			foreach (var i in this.Actores) {
				if (id.Equals (i.Id))
					return i;
			}
			return null;
		}
	}
}

