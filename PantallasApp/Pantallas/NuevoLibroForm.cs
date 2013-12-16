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
	/// Nuevo libro form.
	/// </summary>
    public partial class NuevoLibroForm : Form
    {
		/// <summary>
		/// Gets y sets the PantallaAnt.
		/// </summary>
		/// <value>
		/// La pantalla anterior.
		/// </value>
		public Form PantallaAnt {
			get;
			set;
		}

		/// <summary>
		/// Constructor de la clase <see cref="WindowsFormsApplication1.NuevoLibroForm"/>.
		/// </summary>
        public NuevoLibroForm()
        {
			this.PantallaAnt = null;
            InitializeComponent();
			this.Show();
		}
    }
}
