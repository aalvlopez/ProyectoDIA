using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIAScribe
{
    static class Core
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
		public static XMLGeneral persistencia;
		public static ListEvent listEvents ;

		/// <summary>
		/// Método de inicialización y punto de entrada del programa, donde empieza y acaba el control del mismo.
		/// </summary>
        [STAThread]
		public static void Init()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			XMLEventos xmlPersistence = new XMLEventos("events.xml");
			Core.listEvents = new ListEvent(xmlPersistence);

			Core.libA = new LibroAbiertoForm();
			Core.libA.button1.Enabled=false;
			Core.libA.button2.Enabled=false;
			Core.libA.button3.Enabled=false;
			Core.libA.saveToolStripMenu.Enabled=false;
			Core.libA.saveAsToolStripMenu.Enabled=false;
			Core.libA.referenciasToolStripMenuItem.Enabled=false;
			Application.Run(Core.libA); // Libro sin Abrir
            
        }
    }
}
