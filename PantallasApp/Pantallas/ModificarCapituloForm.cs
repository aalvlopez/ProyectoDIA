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
	/// Modificar capitulo form.
	/// </summary>
    public partial class ModificarCapituloForm : Form
    {
		public Capitulo cap;

		/// <summary>
		/// Constructor de la clase <see cref="WindowsFormsApplication1.ModificarCapituloForm"/> .
		/// </summary>
		/// <param name='cap'>
		/// Capitulo.
		/// </param>
        public ModificarCapituloForm(Capitulo cap)
		{
			this.cap = cap;
            InitializeComponent();
			this.Show ();
        }
    }
}
