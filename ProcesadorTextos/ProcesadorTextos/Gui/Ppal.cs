using System;
using System.Windows.Forms;

namespace ProcesadorTextos
{
	/// <summary>
	/// Clase encargada de crear una instancia de la interfaz gráfica.
	/// </summary>
	public class Ppal
	{

		static void Main()
		{
			var f = new MainWindow ();

			Application.Run (f);
		}

	}
}

