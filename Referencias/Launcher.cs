using System;
using System.Windows.Forms;

namespace Referencias
{
	public class Launcher
	{
		[STAThread]
		public static void Main(){
		  Application.EnableVisualStyles();
		  Application.Run(new ReferencesMainPanel());
		}
	}
}

