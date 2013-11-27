using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;

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
            
			this.plantillas = Plantillas.Crea();
			this.actores = Actores.Crea();

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
           this.opPlantillaNueva.Click += (sender, e) => this.CreaPlantilla();

            this.mArchivo.MenuItems.Add(this.opSalir);
            this.mCrear.MenuItems.Add(this.opActor);
            this.mCrear.MenuItems.Add(this.opBorraActor);
            this.mPlantilla.MenuItems.Add(this.opPlantillaNueva);
            


            this.mPpal.MenuItems.Add(this.mArchivo);
            this.mPpal.MenuItems.Add(this.mCrear);
            this.mPpal.MenuItems.Add(this.mPlantilla);
            
            this.Menu = mPpal;
            
        }

        private void CreaPlantilla()
        {
            this.tbNombrePlantilla.Text = "";
            this.tbDatosPlantilla.Text = "Introduce datos personalizados";
            List<string> datos = new List<string>();
            var nombrePlantilla = "";
            



            string errorPlantilla = "Plantilla ya existe, continuar creando";
            string caption = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            

            while (this.dlgInsertaPlantilla.ShowDialog() != DialogResult.OK)
            {
                
                if (this.dlgInsertaPlantilla.ShowDialog() == DialogResult.Yes)
                {
                    
                    datos.Add(tbDatosPlantilla.Text);
                   
                    if (this.plantillas.GetListNombrePlantilla().Contains(tbNombrePlantilla.Text))
                    {
                        DialogResult result = MessageBox.Show(errorPlantilla, caption, buttons);
                        if (result == DialogResult.OK)
                        {

                            return;
                        }
                    }
                    
                }
                nombrePlantilla = tbNombrePlantilla.Text;
				this.ActualizaPlantillaAddTree(nombrePlantilla);

            }
            var data = Plantilla.crearDatos(datos);
            this.plantillas.Add(Plantilla.Recupera(nombrePlantilla,data));
            return;
           
        }

        /// <summary>
        /// Da de baja un actor
        /// </summary>
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
						this.ActualizaDelActorTree(p);
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
                
            

			if (this.dlgInsertaActor.ShowDialog () == DialogResult.OK) { 



				string p = cbPlantilla.SelectedItem.ToString ();

				if (!this.actores.GetNombreActor ().Contains (tbNombreActor.Text)) {
					this.actores.Add (
										Actor.Crea (p,
                                            this.tbNombreActor.Text,
                                            this.tbCapitulos.Text,
                                            this.plantillas.GetDatosPlantilla(p))
					);
                    this.ActualizaActorAddTree(this.tbNombreActor.Text);
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

        private void BuildGui()
        {
            this.SuspendLayout();

            this.pnlPpal = new Panel();
            this.pnlPpal.SuspendLayout();
            this.pnlPpal.Dock = DockStyle.Fill;
            this.Controls.Add(this.pnlPpal);

            
            this.BuildMenu();

           	this.BuildDialogCreaActor();
            this.BuildDialogBorraActor();
            this.BuildDialogCreaPlantilla();
			this.BuildTree();
            //this.BuildDialogBorraPlantilla();

            this.MinimumSize = new Size(320, 200);
            this.pnlPpal.ResumeLayout(false);
            this.ResumeLayout(true);
         
            this.Text = "Actores";
            this.InitializeComponent();
            
            this.Closed += (sender, e) => this.Salir();
        }

        private void BuildDialogCreaPlantilla()
        {
            this.dlgInsertaPlantilla = new Form();
            this.dlgInsertaPlantilla.SuspendLayout();

            var pnlInserta = new TableLayoutPanel();
            pnlInserta.Dock = DockStyle.Fill;
            pnlInserta.SuspendLayout();
            this.dlgInsertaPlantilla.Controls.Add(pnlInserta);

            var pnlNombrePlantilla = new Panel();
            this.tbNombrePlantilla = new TextBox();
            this.tbNombrePlantilla.Dock = DockStyle.Fill;
            var lbNombrePlantilla = new Label();
            lbNombrePlantilla.Text = "Nombre Plantilla:";
            lbNombrePlantilla.Dock = DockStyle.Left;
            pnlNombrePlantilla.Controls.Add(this.tbNombrePlantilla);
            pnlNombrePlantilla.Controls.Add(lbNombrePlantilla);
            pnlNombrePlantilla.Dock = DockStyle.Top;
            pnlNombrePlantilla.MaximumSize = new Size(int.MaxValue, tbNombrePlantilla.Height * 2);
            pnlInserta.Controls.Add(pnlNombrePlantilla);

            var pnlDatosPlantilla = new Panel();
            this.tbDatosPlantilla = new TextBox();
            this.tbDatosPlantilla.Dock = DockStyle.Fill;
            var lbDatosPlantilla = new Label();
            lbDatosPlantilla.Text = "Datos Plantilla:";
            lbDatosPlantilla.Dock = DockStyle.Left;
            pnlDatosPlantilla.Controls.Add(this.tbDatosPlantilla);
            pnlDatosPlantilla.Controls.Add(lbDatosPlantilla);
            pnlDatosPlantilla.Dock = DockStyle.Top;
            pnlDatosPlantilla.MaximumSize = new Size(int.MaxValue, tbDatosPlantilla.Height * 2);
            pnlInserta.Controls.Add(pnlDatosPlantilla);

            var pnlBotones = new TableLayoutPanel();
            pnlBotones.ColumnCount = 3;
            pnlBotones.RowCount = 1;
            var btGuarda = new Button();
            btGuarda.DialogResult = DialogResult.Yes;
            btGuarda.Text = "&Agregar otro dato";
            btGuarda.Width = btGuarda.Width * 2;
            var btAcepta = new Button();
            btAcepta.DialogResult = DialogResult.OK;
            btAcepta.Text = "&Terminar";
            pnlBotones.Controls.Add(btGuarda);
            pnlBotones.Controls.Add(btAcepta);
            pnlBotones.Dock = DockStyle.Top;
            pnlInserta.Controls.Add(pnlBotones);

            this.dlgInsertaPlantilla.AcceptButton = btGuarda;
            pnlInserta.ResumeLayout(true);
            this.dlgInsertaPlantilla.ResumeLayout(false);
            this.dlgInsertaPlantilla.Text = "Crea nueva Plantilla";
            this.dlgInsertaPlantilla.Size = new Size(400,
                            pnlNombrePlantilla.Height + pnlDatosPlantilla.Height
                            + pnlBotones.Height);
            this.dlgInsertaPlantilla.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.dlgInsertaPlantilla.MinimizeBox = false;
            this.dlgInsertaPlantilla.MaximizeBox = false;
            this.dlgInsertaPlantilla.StartPosition = FormStartPosition.CenterParent;
        }

        private void BuildDialogBorraPlantilla()
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Crea menu lateral ventana principal
		/// </summary>
		private void BuildTree ()
		{
			this.tvActor = new TreeView ();
			this.tvActor.BeginUpdate ();
			this.tvActor.Nodes.Add ("Actores");
			this.tvActor.Nodes.Add("Plantillas");
			int pos = 0;

			foreach (var r in this.actores) {
				this.tvActor.Nodes[0].Nodes.Add (r.Nombre,r.Nombre);
			}



			foreach (var s in this.plantillas) {
				this.tvActor.Nodes[1].Nodes.Add(s.NombrePlantilla,s.NombrePlantilla);
			}


			this.tvActor.Dock = DockStyle.Left;
			this.pnlPpal.Controls.Add(this.tvActor);
			this.tvActor.EndUpdate();


		}

        /// <summary>
        /// actualiza treeview actores
        /// </summary>
        /// <param name="n">
        /// Nombre del actor
        /// </param>
        private void ActualizaActorAddTree(string n)
        {
            this.tvActor.Nodes[0].Nodes.Add(n);
        }

        /// <summary>
        /// actualiza el treeview plantillas
        /// </summary>
        /// <param name="p">
        /// Nombre de la plantilla
        /// </param>
        private void ActualizaPlantillaAddTree(string p)
        {
            this.tvActor.Nodes[1].Nodes.Add(p);
        }

		private void ActualizaDelActorTree (string n)
		{
			this.tvActor.Nodes[0].Nodes.RemoveByKey(n);
		}


		/// <summary>
		/// Crea formulario alta actor.
		/// </summary>
        private void BuildDialogCreaActor()
		{
			this.dlgInsertaActor = new Form();
			this.dlgInsertaActor.SuspendLayout();

			var pnlInserta = new TableLayoutPanel();
			pnlInserta.Dock = DockStyle.Fill;
			pnlInserta.SuspendLayout();
			this.dlgInsertaActor.Controls.Add( pnlInserta );

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

			this.dlgInsertaActor.AcceptButton = btGuarda;
			this.dlgInsertaActor.CancelButton = btCierra;
			pnlInserta.ResumeLayout( true );
			this.dlgInsertaActor.ResumeLayout( false );
			this.dlgInsertaActor.Text = "Crea nuevo Actor";
			this.dlgInsertaActor.Size = new Size( 400, 
			                pnlNombreActor.Height + pnlCapitulos.Height
			                + pnlPlantilla.Height + pnlBotones.Height );
			this.dlgInsertaActor.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.dlgInsertaActor.MinimizeBox = false;
			this.dlgInsertaActor.MaximizeBox = false;
			this.dlgInsertaActor.StartPosition = FormStartPosition.CenterParent;
		}

        /// <summary>
        /// Crea formulario baja actor
        /// </summary>
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
        private Form dlgInsertaActor;
        private Form dlgInsertaPlantilla;
		private TreeView tvActor;
        private MenuItem opBorraActor;
        private Form dlgBorra;
        private ComboBox cbActor;
        private TextBox tbNombrePlantilla;
        private TextBox tbDatosPlantilla;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.ResumeLayout(false);

        }

    }
}
