using System;
using System.Xml;
using System.Text;
using System.IO;
using Net.Sgoliver.NRtfTree.Core;
using Net.Sgoliver.NRtfTree.Util;

namespace ProcesadorTextos
{
	/// <summary>
	/// Clase estática que permite exportar una cadena de texto en formato rft
	/// a xml y html.
	/// </summary>
	public static class Utilidades
	{
		/// <summary>
		/// Exporta una cadena de texto a xml.
		/// </summary>
		/// <param name="path">Ruta del fichero.</param>
		/// <param name="text">Cadena de texto en formato rtf.</param>
		public static void ExportarXml (String path, String text)
		{

			if (File.Exists (path)) {
				File.Delete (path);
			}

			String res = "";

			XmlParser parser = new XmlParser (res);
			RtfReader reader = new RtfReader (parser);
			reader.LoadRtfText (text);
			reader.Parse();

			using (StreamWriter sw = File.CreateText(path)) 
			{
				sw.Write (parser.doc);
			}	

		}

		/// <summary>
		/// Exporta una cadena de texto a html.
		/// </summary>
		/// <param name="path">Ruta del fichero.</param>
		/// <param name="text">Cadena de texto en formato rtf.</param>
		public static void ExportarHtml (String path, String text)
		{

			if (File.Exists (path)) {
				File.Delete (path);
			}

			String res = "";

			HtmlParser parser = new HtmlParser (res);
			RtfReader reader = new RtfReader (parser);
			reader.LoadRtfText (text);
			reader.Parse();

			using (StreamWriter sw = File.CreateText(path)) 
			{
				sw.Write (parser.doc);
			}	

		}
	}
}

