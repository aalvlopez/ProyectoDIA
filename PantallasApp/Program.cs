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
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
//            Application.Run(new Form1()); // Libro Abierto
//            Application.Run(new Form2()); // Libro sin Abrir
            Application.Run(new Form3()); // Nuevo Libro
//            Application.Run(new Form4()); // Nuevo Capitulo
//            Application.Run(new Form5()); // Escenas
//            Application.Run(new Form6()); // Modificar Capitulo
//            Application.Run(new Form7()); // Añadir/Modificar Personajes
        }
    }
}
