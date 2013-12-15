using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
		/// 
		public static AnadirModificarPersonajesForm anPers;
		public static EscenasForm esc;
		public static LibroAbiertoForm libA;
		public static ModificarCapituloForm modCap;
		public static NuevoCapituloForm nuevoCap;
		public static NuevoLibroForm nuevoLib;
		public static ReferencesForm references;
		public static ProcesadorTextos procesador;
		public static EventsWinForms eventosForm; 

		public static Libro Book;
		public static XMLPersistencia persistencia;
		public static ListEvent listEvents ;

        [STAThread]
		public static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			XmlPersistence xmlPersistence = new XmlPersistence("events.xml");
			Program.listEvents = new ListEvent(xmlPersistence);

			Program.libA = new LibroAbiertoForm();
			Program.libA.button1.Enabled=false;
			Program.libA.button2.Enabled=false;
			Program.libA.button3.Enabled=false;
			Program.libA.saveToolStripMenu.Enabled=false;
			Program.libA.saveAsToolStripMenu.Enabled=false;
			Program.libA.referenciasToolStripMenuItem.Enabled=false;
			Application.Run(Program.libA); // Libro sin Abrir
            
        }

        
    }
}
