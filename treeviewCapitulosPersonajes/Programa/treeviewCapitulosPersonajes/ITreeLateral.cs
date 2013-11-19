using System;
using System.Drawing;
using System.Windows.Forms;

namespace treeviewCapitulosPersonajes
{
	/// <summary>
	/// Interfaz que permite el uso de una interfaz grafica de forma transparente.
	/// </summary>
	interface ITreeLateral
	{
		/// <summary>
		/// Construye el winForm con el treeView para ser mostrado.
		/// </summary>
		void BuildGui();
		/// <summary>
		/// Actualiza el treeView.
		/// </summary>
		void Actualizar();
	}
}

