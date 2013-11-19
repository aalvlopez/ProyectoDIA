using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace scActores
{
	/// <summary>
	/// Toda la logica de intefaz de usuario
	/// </summary>
    public class MainWindow : Form
    {
        /// <summary>
        /// Crea todas las interfaces 
        /// </summary>
        public MainWindow()
        {
            this.actores = Actores.Crea();
			this.plantillas = Plantillas.Crea();
			this.BuildGui();
           
           
        }

		/// <summary>
		/// Crea la barra de menu
		/// </summary>
        private void BuildMenu()
        {
            this.mPpal = new MainMenu();

            this.mArchivo = new MenuItem("&Archivo");
            this.mCrear = new MenuItem("&Editar");
            this.mPlantilla = new MenuItem("&Plantilla");

            this.opSalir = new MenuItem("&Salir");
            this.opSalir.Shortcut = Shortcut.CtrlQ;
            this.opSalir.Click += (sender, e) => this.Salir();

            this.opActor = new MenuItem("&Nuevo Actor");
            this.opActor.Shortcut = Shortcut.CtrlN;
            this.opActor.Click += (sender, e) => this.CreaActor();

            this.opBorraActor = new MenuItem("&Borra Actor");
            this.opBorraActor.Shortcut = Shortcut.CtrlB;
            this.opBorraActor.Click += (sender, e) => this.BorraActor();

            this.opPlantillaNueva = new MenuItem("&Nueva Plantilla");
            this.opPlantillaNueva.Shortcut = Shortcut.CtrlP;
            this.opPlantillaNueva.Click += (sender, e) => this.NuevaPlantilla();

            this.mArchivo.MenuItems.Add(this.opSalir);
            this.mCrear.MenuItems.Add(this.opActor);
            this.mCrear.MenuItems.Add(this.opBorraActor);
            this.mPlantilla.MenuItems.Add(this.opPlantillaNueva);
            


            this.mPpal.MenuItems.Add(this.mArchivo);
            this.mPpal.MenuItems.Add(this.mCrear);
            this.mPpal.MenuItems.Add(this.mPlantilla);
            
            this.Menu = mPpal;
            
        }

        private void BorraActor()
        {
            Actores toret = Actores.Crea();
            toret.Clear();
            
           
            string Aviso = "Estas seguro";
            string caption = "Alert";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            
            this.cbActor.Items.AddRange(this.actores.GetNombreActor().ToArray());

            if (this.dlgBorra.ShowDialog() == DialogResult.OK)
            {



                string p = cbActor.SelectedItem.ToString();

               
                    foreach (var r in this.actores)
                    {
                        if (!r.Nombre.Equals(p)){
                            toret.Add(r);
                        }
                    }
                    DialogResult result = MessageBox.Show(Aviso, caption, buttons);
                    if (result == DialogResult.OK)
                    {
                        this.cbActor.Items.Clear();
                        this.actores = toret;
                        this.actores.GuardaXml();
                        return;
                    }
                    else
                    {
                        this.cbPlantilla.Items.Clear();
                    }

            } 

            return;
        }
                   
                
  

		/// <summary>
		/// Da de alta un nuevo actor
		/// </summary>
        private void CreaActor ()
		{
			this.tbNombreActor.Text = "";
			this.tbCapitulos.Text = "1,2";
			this.cbPlantilla.Text = "Escoge Plantilla";



			string errorActor = "Actor ya existe, continuar creando";
			string caption = "Error";
			MessageBoxButtons buttons = MessageBoxButtons.OK;
           
            
		
			this.cbPlantilla.Items.AddRange (this.plantillas.GetNombrePlantilla ());
                
            

			if (this.dlgInserta.ShowDialog () == DialogResult.OK) { 



				string p = cbPlantilla.SelectedItem.ToString ();

				if (!this.actores.GetNombreActor ().Contains (tbNombreActor.Text)) {
					this.actores.Add (
										Actor.Crea (p,
                                            this.tbNombreActor.Text,
                                            this.tbCapitulos.Text,
                                            this.plantillas.GetDatosPlantilla(p))
					);
					this.cbPlantilla.Items.Clear ();
				} else { 

					DialogResult result = MessageBox.Show (errorActor, caption, buttons);
					if (result == DialogResult.OK) {
						this.cbPlantilla.Items.Clear();
						return;
					}
				}
			} else {
				this.cbPlantilla.Items.Clear ();
			}

			return;
		}
        
		/// <summary>
		/// guarda y cierra programa
		/// </summary>
        private void Salir()
        {
            this.actores.GuardaXml();
            this.plantillas.GuardaXml();
            this.Dispose(true);
        }

		private void NuevaPlantilla ()
		{

		}



        private void BuildGui()
        {
            this.SuspendLayout();

            this.pnlPpal = new Panel();
            this.pnlPpal.SuspendLayout();
            this.pnlPpal.Dock = DockStyle.Fill;
            this.Controls.Add(this.pnlPpal);

            
            this.BuildMenu();
			this.BuildTree();
           	this.BuildDialogCreaActor();
            this.BuildDialogBorraActor();

            this.MinimumSize = new Size(320, 200);
            this.pnlPpal.ResumeLayout(false);
            this.ResumeLayout(true);
         
            this.Text = "Actores";
            this.InitializeComponent();
            
            this.Closed += (sender, e) => this.Salir();
        }

		/// <summary>
		/// Crea menu lateral ventana principal
		/// </summary>
		private void BuildTree ()
		{
			this.tvActor = new TreeView ();
			this.tvActor.BeginUpdate ();
			this.tvActor.Nodes.Add ("Actores");

			foreach (var r in this.actores) {
				this.tvActor.Nodes[0].Nodes.Add(r.Nombre);
			}

			this.tvActor.Nodes.Add("Plantillas");

			foreach (var r in this.plantillas) {
				this.tvActor.Nodes[1].Nodes.Add(r.NombrePlantilla);
			}

			this.tvActor.EndUpdate();
			this.tvActor.Dock = DockStyle.Left;
			this.pnlPpal.Controls.Add(this.tvActor);


		}


		/// <summary>
		/// Crea formulario alta actor.
		/// </summary>
        private void BuildDialogCreaActor()
		{
			this.dlgInserta = new Form();
			this.dlgInserta.SuspendLayout();

			var pnlInserta = new TableLayoutPanel();
			pnlInserta.Dock = DockStyle.Fill;
			pnlInserta.SuspendLayout();
			this.dlgInserta.Controls.Add( pnlInserta );

			var pnlNombreActor = new Panel();
			this.tbNombreActor = new TextBox();
			this.tbNombreActor.Dock = DockStyle.Fill;
			var lbNombreActor = new Label();
			lbNombreActor.Text = "Nombre Actor:";
			lbNombreActor.Dock = DockStyle.Left;
			pnlNombreActor.Controls.Add( this.tbNombreActor );
			pnlNombreActor.Controls.Add( lbNombreActor );
			pnlNombreActor.Dock = DockStyle.Top;
			pnlNombreActor.MaximumSize = new Size( int.MaxValue, tbNombreActor.Height * 2 );
			pnlInserta.Controls.Add( pnlNombreActor );

			var pnlCapitulos = new Panel();
			this.tbCapitulos = new TextBox();
			this.tbCapitulos.Dock = DockStyle.Fill;
			var lbCapitulos = new Label();
			lbCapitulos.Text = "Capitulos:";
			lbCapitulos.Dock = DockStyle.Left;
			pnlCapitulos.Controls.Add( this.tbCapitulos );
			pnlCapitulos.Controls.Add( lbCapitulos );
			pnlCapitulos.Dock = DockStyle.Top;
			pnlCapitulos.MaximumSize = new Size( int.MaxValue, tbCapitulos.Height * 2 );
			pnlInserta.Controls.Add( pnlCapitulos );

			var pnlPlantilla = new Panel();
			this.cbPlantilla = new ComboBox();
			this.cbPlantilla.Text = "Escoge Plantilla";
            
			this.cbPlantilla.Dock = DockStyle.Fill;

			var lbPlantilla = new Label();
			lbPlantilla.Text = "Plantilla:";
			lbPlantilla.Dock = DockStyle.Left;
			pnlPlantilla.Controls.Add( this.cbPlantilla );
			pnlPlantilla.Controls.Add( lbPlantilla );
			pnlPlantilla.Dock = DockStyle.Top;
			pnlPlantilla.MaximumSize = new Size( int.MaxValue, cbPlantilla.Height * 2 );
			pnlInserta.Controls.Add( pnlPlantilla );

			var pnlBotones = new TableLayoutPanel();
			pnlBotones.ColumnCount = 2;
			pnlBotones.RowCount = 1;
			var btCierra = new Button();
			btCierra.DialogResult = DialogResult.Cancel;
			btCierra.Text = "&Cancelar";
			var btGuarda = new Button();
			btGuarda.DialogResult = DialogResult.OK;
			btGuarda.Text = "&Guardar";
			pnlBotones.Controls.Add( btGuarda );
			pnlBotones.Controls.Add( btCierra );
			pnlBotones.Dock = DockStyle.Top;
			pnlInserta.Controls.Add( pnlBotones );

			this.dlgInserta.AcceptButton = btGuarda;
			this.dlgInserta.CancelButton = btCierra;
			pnlInserta.ResumeLayout( true );
			this.dlgInserta.ResumeLayout( false );
			this.dlgInserta.Text = "Crea nuevo Actor";
			this.dlgInserta.Size = new Size( 400, 
			                pnlNombreActor.Height + pnlCapitulos.Height
			                + pnlPlantilla.Height + pnlBotones.Height );
			this.dlgInserta.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.dlgInserta.MinimizeBox = false;
			this.dlgInserta.MaximizeBox = false;
			this.dlgInserta.StartPosition = FormStartPosition.CenterParent;
		}

        private void BuildDialogBorraActor()
        {
            this.dlgBorra = new Form();
            this.dlgBorra.SuspendLayout();

            var pnlBorra = new TableLayoutPanel();
            pnlBorra.Dock = DockStyle.Fill;
            pnlBorra.SuspendLayout();
            this.dlgBorra.Controls.Add(pnlBorra);

            var pnlActor= new Panel();
            this.cbActor = new ComboBox();
            this.cbActor.Text = "Escoge Actor";

            this.cbActor.Dock = DockStyle.Fill;

            var lbActor = new Label();
            lbActor.Text = "Actor:";
            lbActor.Dock = DockStyle.Left;
            pnlActor.Controls.Add(this.cbActor);
            pnlActor.Controls.Add(lbActor);
            pnlActor.Dock = DockStyle.Top;
            pnlActor.MaximumSize = new Size(int.MaxValue, cbPlantilla.Height * 2);
            pnlBorra.Controls.Add(pnlActor);

            var pnlBotones = new TableLayoutPanel();
            pnlBotones.ColumnCount = 2;
            pnlBotones.RowCount = 1;
            var btCierra = new Button();
            btCierra.DialogResult = DialogResult.Cancel;
            btCierra.Text = "&Cancelar";
            var btGuarda = new Button();
            btGuarda.DialogResult = DialogResult.OK;
            btGuarda.Text = "&Guardar";
            pnlBotones.Controls.Add(btGuarda);
            pnlBotones.Controls.Add(btCierra);
            pnlBotones.Dock = DockStyle.Top;
            pnlBorra.Controls.Add(pnlBotones);

            this.dlgBorra.AcceptButton = btGuarda;
            this.dlgBorra.CancelButton = btCierra;
            pnlBorra.ResumeLayout(true);
            this.dlgBorra.ResumeLayout(false);
            this.dlgBorra.Text = "Crea nuevo Actor";
            this.dlgBorra.Size = new Size(400,
                            cbActor.Height +
                            pnlBotones.Height);
            this.dlgBorra.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.dlgBorra.MinimizeBox = false;
            this.dlgBorra.MaximizeBox = false;
            this.dlgBorra.StartPosition = FormStartPosition.CenterParent;
        }



        private Actores actores;
        private Plantillas plantillas;

        private MainMenu mPpal;

        private MenuItem mArchivo;
        private MenuItem mCrear;
        private MenuItem mPlantilla;
        private MenuItem opSalir;
        private MenuItem opActor;
        private MenuItem opPlantillaNueva;
        private Panel pnlPpal;
        
        
        private TextBox tbNombreActor;
        private TextBox tbCapitulos;
        private ComboBox cbPlantilla;
        private Form dlgInserta;
		private TreeView tvActor;
        private MenuItem opBorraActor;
        private Form dlgBorra;
        private ComboBox cbActor;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(443, 266);
            this.Name = "MainWindow";
            this.ResumeLayout(false);

        }

    }
}
