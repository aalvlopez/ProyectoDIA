using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Representa los actores 
	/// </summary>
    public class Actores : ICollection<Actor>
    {
              /// <summary>
       /// Añade un actor
       /// </summary>
       /// <param name='a'>
       /// Un <see cref="scActores.Actor"/>
       /// </param>
        public void Add(Actor a)
        {
            this.actores.Add(a);
        }


		/// <summary>
		/// Borra un actor
		/// </summary>
        /// <param name='a'>
        /// Un <see cref="scActores.Actor"/>
        /// </param>
		///  
		/// 
        public bool Remove(Actor a)
        {
            return this.actores.Remove(a);
        }

		/// <summary>
		/// Borra el actor en la posicion indicada por el indice i
		/// </summary>
		/// <param name='i'>
		/// El indice
		/// </param>
        public void RemoveAt(int i)
        {
            this.actores.RemoveAt(i);
        }

		/// <summary>
		/// Añade unac coleccion de actores
		/// </summary>
        public void AddRange(ICollection<Actor> r)
        {
            this.actores.AddRange(r);
        }

		/// <summary>
		/// Devuelve el numero de actores
		/// </summary>
        public int Count
        {
            get { return this.actores.Count; }
        }

		/// <summary>
		/// Devuelve que no es de solo lectura
		/// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

		/// <summary>
		/// Borra todos los actores
		/// </summary>
        public void Clear()
        {
            this.actores.Clear();
        }


		/// <summary>
		/// Devuelve si existe el actor buscado
		/// </summary>
		/// <param name='r'>
		/// El <see cref="scActores.Actor"/> a buscar
		/// </param>
        public bool Contains(Actor r)
        {
            return this.actores.Contains(r);
        }

		/// <summary>
		/// Copia los actores a un array
		/// </summary>
		/// <param name='v'>
		/// Los actores
		/// </param>
		/// <param name='i'>
		/// La posicion desde la que se empieza a copiar
		/// </param>
        public void CopyTo(Actor[] v, int i)
        {
            this.actores.CopyTo(v, i);
        }

        // Enumerador genérico
        IEnumerator<Actor> IEnumerable<Actor>.GetEnumerator()
        {
            foreach (var r in this.actores)
            {
                yield return r;
            }
        }

        // Enumerador básico
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var r in this.actores)
            {
                yield return r;
            }
        }

        // Indizador
        public Actor this[int i]
        {
            get { return this.actores[i]; }
            set { this.actores[i] = value; }
        }

		/// <summary>
		/// Devuelve una cadena que representa los actores.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> que representa los <see cref="scActores.Actores"/>.
		/// </returns>
        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (var r in this.actores)
            {
                toret.AppendLine(r.ToString());
            }

            return toret.ToString();
        }


        

		

		/// <summary>
		/// Devuelve los nombres de los actores
		/// </summary>
		/// <returns>
		/// Una <see cref="System.Collections.Generic.List"> con los nombres de los actores
		/// </returns>
		public List<string> GetNombreActor()
        {
            var toret = new List<string>();

            foreach (var r in actores)
            {
                toret.Add(r.Nombre);
            }

            return toret;

            
        }

        public Actores()
        {
            actores = new List<Actor>();
        }

        private List<Actor> GetActores()
        {
            return this.actores;
        }
      

        private List<Actor> actores;
        

    }
}
