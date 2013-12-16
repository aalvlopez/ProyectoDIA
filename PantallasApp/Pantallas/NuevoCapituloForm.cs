using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Nuevo capitulo form.
	/// </summary>
    public partial class NuevoCapituloForm : Form
    {
		/// <summary>
		/// Gets y sets the PantallaAnt.
		/// </summary>
		/// <value>
		/// The pantalla ant.
		/// </value>
		public Form PantallaAnt {
			get;
			set;
		}

		/// <summary>
		/// Constructor por defecto de la clase  <see cref="WindowsFormsApplication1.NuevoCapituloForm"/> .
		/// </summary>
        public NuevoCapituloForm()
        {
			this.PantallaAnt = null;
            InitializeComponent();
			this.Show ();
        }
    }
}
