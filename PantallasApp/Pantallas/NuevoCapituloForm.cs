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
    public partial class NuevoCapituloForm : Form
    {
		public Form PantallaAnt {
			get;
			set;
		}

		public string id;

        public NuevoCapituloForm()
        {
			this.PantallaAnt = null;
			this.id="";
            InitializeComponent();
			this.Hide();
        }
    }
}
