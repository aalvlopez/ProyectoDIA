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
    public partial class EscenasForm : Form
    {
		public Form PantallaAnt {
			get;
			set;
		}
        public EscenasForm()
        {
			this.PantallaAnt = null;
            InitializeComponent();
			this.Hide();
        }
    
	}
}
