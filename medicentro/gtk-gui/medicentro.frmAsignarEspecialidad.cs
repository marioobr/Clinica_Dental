
// This file has been generated by the GUI designer. Do not modify.
namespace medicentro
{
	public partial class frmAsignarEspecialidad
	{
		private global::Gtk.Fixed fixedAsignarEsp;

		private global::Gtk.Label lblAsignarEsp;

		private global::Gtk.Label lblInformacionDoc;

		private global::Gtk.Label lblNombreDoc;

		private global::Gtk.Label lblEspecialidad;

		private global::Gtk.Label lblEspecialidadInfo;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView tvwDoctorEsp;

		private global::Gtk.ComboBox cbxDoctor;

		private global::Gtk.ComboBox cbxEspecialidad;

		private global::Gtk.Button btnAsignarEsp;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget medicentro.frmAsignarEspecialidad
			this.Name = "medicentro.frmAsignarEspecialidad";
			this.Title = global::Mono.Unix.Catalog.GetString("frmAsignarEspecialidad");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child medicentro.frmAsignarEspecialidad.Gtk.Container+ContainerChild
			this.fixedAsignarEsp = new global::Gtk.Fixed();
			this.fixedAsignarEsp.Name = "fixedAsignarEsp";
			this.fixedAsignarEsp.HasWindow = false;
			// Container child fixedAsignarEsp.Gtk.Fixed+FixedChild
			this.lblAsignarEsp = new global::Gtk.Label();
			this.lblAsignarEsp.Name = "lblAsignarEsp";
			this.lblAsignarEsp.LabelProp = global::Mono.Unix.Catalog.GetString("Asignar Especialidad");
			this.fixedAsignarEsp.Add(this.lblAsignarEsp);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixedAsignarEsp[this.lblAsignarEsp]));
			w1.X = 245;
			w1.Y = 12;
			// Container child fixedAsignarEsp.Gtk.Fixed+FixedChild
			this.lblInformacionDoc = new global::Gtk.Label();
			this.lblInformacionDoc.Name = "lblInformacionDoc";
			this.lblInformacionDoc.LabelProp = global::Mono.Unix.Catalog.GetString("Informacion del Doctor");
			this.fixedAsignarEsp.Add(this.lblInformacionDoc);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixedAsignarEsp[this.lblInformacionDoc]));
			w2.X = 41;
			w2.Y = 62;
			// Container child fixedAsignarEsp.Gtk.Fixed+FixedChild
			this.lblNombreDoc = new global::Gtk.Label();
			this.lblNombreDoc.Name = "lblNombreDoc";
			this.lblNombreDoc.LabelProp = global::Mono.Unix.Catalog.GetString("Doctor: ");
			this.fixedAsignarEsp.Add(this.lblNombreDoc);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixedAsignarEsp[this.lblNombreDoc]));
			w3.X = 15;
			w3.Y = 121;
			// Container child fixedAsignarEsp.Gtk.Fixed+FixedChild
			this.lblEspecialidad = new global::Gtk.Label();
			this.lblEspecialidad.Name = "lblEspecialidad";
			this.lblEspecialidad.LabelProp = global::Mono.Unix.Catalog.GetString("Especialidad: ");
			this.fixedAsignarEsp.Add(this.lblEspecialidad);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixedAsignarEsp[this.lblEspecialidad]));
			w4.X = 307;
			w4.Y = 120;
			// Container child fixedAsignarEsp.Gtk.Fixed+FixedChild
			this.lblEspecialidadInfo = new global::Gtk.Label();
			this.lblEspecialidadInfo.Name = "lblEspecialidadInfo";
			this.lblEspecialidadInfo.LabelProp = global::Mono.Unix.Catalog.GetString("Informacion de Especialidad");
			this.fixedAsignarEsp.Add(this.lblEspecialidadInfo);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixedAsignarEsp[this.lblEspecialidadInfo]));
			w5.X = 392;
			w5.Y = 63;
			// Container child fixedAsignarEsp.Gtk.Fixed+FixedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.WidthRequest = 616;
			this.GtkScrolledWindow.HeightRequest = 146;
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvwDoctorEsp = new global::Gtk.TreeView();
			this.tvwDoctorEsp.CanFocus = true;
			this.tvwDoctorEsp.Name = "tvwDoctorEsp";
			this.GtkScrolledWindow.Add(this.tvwDoctorEsp);
			this.fixedAsignarEsp.Add(this.GtkScrolledWindow);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixedAsignarEsp[this.GtkScrolledWindow]));
			w7.X = 10;
			w7.Y = 208;
			// Container child fixedAsignarEsp.Gtk.Fixed+FixedChild
			this.cbxDoctor = global::Gtk.ComboBox.NewText();
			this.cbxDoctor.WidthRequest = 205;
			this.cbxDoctor.Name = "cbxDoctor";
			this.fixedAsignarEsp.Add(this.cbxDoctor);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixedAsignarEsp[this.cbxDoctor]));
			w8.X = 73;
			w8.Y = 112;
			// Container child fixedAsignarEsp.Gtk.Fixed+FixedChild
			this.cbxEspecialidad = global::Gtk.ComboBox.NewText();
			this.cbxEspecialidad.WidthRequest = 211;
			this.cbxEspecialidad.Name = "cbxEspecialidad";
			this.fixedAsignarEsp.Add(this.cbxEspecialidad);
			global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixedAsignarEsp[this.cbxEspecialidad]));
			w9.X = 402;
			w9.Y = 113;
			// Container child fixedAsignarEsp.Gtk.Fixed+FixedChild
			this.btnAsignarEsp = new global::Gtk.Button();
			this.btnAsignarEsp.CanFocus = true;
			this.btnAsignarEsp.Name = "btnAsignarEsp";
			this.btnAsignarEsp.UseUnderline = true;
			this.btnAsignarEsp.Label = global::Mono.Unix.Catalog.GetString("Asignar Especialidad");
			this.fixedAsignarEsp.Add(this.btnAsignarEsp);
			global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixedAsignarEsp[this.btnAsignarEsp]));
			w10.X = 462;
			w10.Y = 166;
			this.Add(this.fixedAsignarEsp);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 626;
			this.DefaultHeight = 354;
			this.Show();
			this.btnAsignarEsp.Clicked += new global::System.EventHandler(this.OnBtnAsignarEspClicked);
		}
	}
}
