using System;
using Net.Sgoliver.NRtfTree.Core;
using Net.Sgoliver.NRtfTree.Util;

namespace ProcesadorTextos
{
	/// <summary>
	/// Parser SAX para transformar un fichero rtf en html.
	/// </summary>
	public class HtmlParser : SarParser
	{

		public HtmlParser(string doc)
		{
			this.doc = doc;
		}

		/// <summary>
		/// Inserta la cabecera del documento html.
		/// </summary>
		public override void StartRtfDocument()
		{
			doc += "<!DOCTYPE html>\n<html>\n\t<head>\n\t\t<title>Documento</title>" +
				   "\n\t\t<meta charset=\"UTF-8\">\n\t</head>\n<body>\n\n\t";
		}

		/// <summary>
		/// Cierra el contenido del documento
		/// </summary>
		public override void EndRtfDocument()
		{
			doc += "\n</body>";
		}

		public override void StartRtfGroup()
		{
			;
		}

		/// <summary>
		/// Metodo que es llamado al final de un grupo rtf. Se encarga de 
		/// cerrar las etiquetas.
		/// </summary>
		public override void EndRtfGroup()
		{
			if (enTexto) {
				CloseTag ();

				negrita = false;
				cursiva = false;
				subrayado = false;
			}
		}

		/// <summary>
		/// Traduce caracteres acentuados y la letra 'ñ'.
		/// </summary>
		/// <param name="key">Caracter a traducir.</param>
		/// <param name="hasParam">Si es <c>true</c> es un parámetro.</param>
		/// <param name="param">Código del parámetro.</param>
		public override void RtfControl(string key, bool hasParam, int param)
		{
			//Caracter especial
			if (key == "'") { 
				string res = "";

				switch (param) {
					case 193:
					res = "Á";
					break;
					case 201:
					res = "É";
					break;
					case 205:
					res = "Í";
					break;
					case 211:
					res = "Ó";
					break;
					case 218:
					res = "Ú";
					break;
					case 225:
					res = "á";
					break;
					case 233:
					res = "é";
					break;
					case 237:
					res = "í";
					break;
					case 243:
					res = "ó";
					break;
					case 250:
					res = "ú";
					break;
					case 241:
					res = "ñ";
					break;
					case 209:
					res = "Ñ";
					break;
				}
				doc += res;
			}
		}

		/// <summary>
		/// Se encarga de procesar un caracter rtf.
		/// </summary>
		/// <param name="key">Caracter rtf.</param>
		/// <param name="hasParam">Si es <c>true</c> es un parámetro.</param>
		/// <param name="param">Código del parámetro.</param>
		public override void RtfKeyword(string key, bool hasParam, int param)
		{
			if (key.Equals ("pard")) {
				enTexto = true;
			}

			if (enTexto) {
				switch (key) {
				case "b":
					if (!hasParam || (hasParam && param == 1)) {
						doc += "<b>";
						negrita = true;
						order = order + "b";

					} else {
						CloseTag ();
					}
					break;

				case "i":
					if (!hasParam || (hasParam && param == 1)) {
						doc += "<i>";
						cursiva = true;
						order = order + "i";

					} else {
						CloseTag ();
					}
					break;

				case "ul":
					if (!hasParam || (hasParam && param == 1)) {
						doc += "<u>";
						subrayado = true;
						order = order + "u";


					} else {
						CloseTag ();
					}
					break;
						
				// case "ulnone":
				//     setOrder ();
				//	   break;

				case "par":
					if (negrita || cursiva || subrayado) {
						setReturn = true;

					} else {
						doc += "<br/>\n\t";
					}

					break;
				}
			}
		}

		/// <summary>
		/// Se encarga de procesar texto plano.
		/// </summary>
		/// <param name="text">Texto a procesar</param>
		public override void RtfText(string text) 
		{
			if (enTexto) {
				doc += text;
			}
		}

		/// <summary>
		/// Se encarga de cerrar las etiquetas de negrita, cursiva y subrayado.
		/// </summary>
		public void CloseTag() 
		{
			if (negrita && cursiva && subrayado) {

				switch (order) {
				case "biu":
					doc += "</u></i></b>";
					break;
				case "bui":
					doc += "</i></u></b>";
					break;
				case "ibu":
					doc += "</u></b></i>";
					break;
				case "iub":
					doc += "</b></u></i>";
					break;
				case "ubi":
					doc += "</i></b></u>";
					break;
				case "uib":
					doc += "</b></i></u>";
					break;
				}

			} else if (negrita && cursiva) {
				switch (order) {
				case "bi":
					doc += "</i></b>";
					break;
				case "ib":
					doc += "</b></i>";
					break;
				}

			} else if (cursiva && subrayado) {
				switch (order) {
				case "iu":
					doc += "</u></i>";
					break;
				case "ui":
					doc += "</i></u>";
					break;
				}

			} else if (negrita && subrayado) {
				switch (order) {
				case "bu":
					doc += "</u></b>";
					break;
				case "ub":
					doc += "</b></u>";
					break;
				}

			} else if (negrita) {
				doc += "</b>";

			} else if (cursiva) {
				doc += "</i>";
			
			} else if (subrayado) {
				doc += "</u>";
			}

			order = "";

			negrita = false;
			cursiva = false;
			subrayado = false;

			if (setReturn) {
				doc += "<br/>\n\t";
				setReturn = false;
			}
		}

		public string doc = "";

		private bool enTexto = false;
		private bool negrita = false;
		private bool cursiva = false;
		private bool subrayado = false;
		private bool setReturn = false;

		private string order = "";
	}
}


