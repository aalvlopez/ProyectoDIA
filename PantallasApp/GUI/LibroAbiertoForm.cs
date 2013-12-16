using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIAScribe
{
	/// <summary>
	/// Libro abierto form.
	/// </summary>
    public partial class LibroAbiertoForm : Form
    {
		/// <summary>
		/// Gets y sets de PantallaAnt
		/// </summary>
		/// <value>
		/// La pantalla anterior.
		/// </value>
		public Form PantallaAnt {
			get;
			set;
		}

		/// <summary>
		/// Constructor sin parámetros de la clase  <see cref="DIAScribe.LibroAbiertoForm"/>.
		/// </summary>
        public LibroAbiertoForm()
        {
			this.PantallaAnt = null;
            InitializeComponent();
		}
    }
}
