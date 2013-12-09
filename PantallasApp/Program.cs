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
		public static LibroSinAbrirForm libS;
		public static ModificarCapituloForm modCap;
		public static NuevoCapituloForm nuevoCap;
		public static NuevoLibroForm nuevoLib;
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			Program.anPers = new AnadirModificarPersonajesForm();
			Program.esc = new EscenasForm();
			Program.libA = new LibroAbiertoForm();
			Program.libS = new LibroSinAbrirForm();
			Program.modCap = new ModificarCapituloForm();
			Program.nuevoCap = new NuevoCapituloForm();
			Program.nuevoLib = new NuevoLibroForm();

//            Application.Run(Program.libA); // Libro Abierto
//            Application.Run(Program.nuevoLib); // Nuevo Libro
//            Application.Run(Program.nuevoCap); // Nuevo Capitulo
//            Application.Run(Program.esc); // Escenas
//            Application.Run(Program.modCap); // Modificar Capitulo
//            Application.Run(Program.anPers); // Añadir/Modificar Personajes
//
//
			Application.Run(Program.libS); // Libro sin Abrir
            
        }
    }
}
