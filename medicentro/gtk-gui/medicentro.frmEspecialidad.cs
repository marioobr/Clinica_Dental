
// This file has been generated by the GUI designer. Do not modify.
namespace medicentro
{
	public partial class frmEspecialidad
	{
		private global::Gtk.Fixed fixedEspecialidad;

		private global::Gtk.Label lblNombreEsp;

		private global::Gtk.Label lblDescESp;

		private global::Gtk.Entry txtNombreEsp;

		private global::Gtk.ScrolledWindow tvwEspecialidad;

		private global::Gtk.TreeView tvwEspecialidades;

		private global::Gtk.Entry txtBuscarEsp;

		private global::Gtk.Button btnBuscarEsp;

		private global::Gtk.Button btnGuardarEsp;

		private global::Gtk.Button btnActualizarEsp;

		private global::Gtk.Button btnCancelar;

		private global::Gtk.Button btnEliminarEsp;

		private global::Gtk.Label lblEspecialidad;

		private global::Gtk.Entry txtDesEsp;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget medicentro.frmEspecialidad
			this.WidthRequest = 800;
			this.HeightRequest = 430;
			this.Name = "medicentro.frmEspecialidad";
			this.Title = global::Mono.Unix.Catalog.GetString("Especialidad");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child medicentro.frmEspecialidad.Gtk.Container+ContainerChild
			this.fixedEspecialidad = new global::Gtk.Fixed();
			this.fixedEspecialidad.Name = "fixedEspecialidad";
			this.fixedEspecialidad.HasWindow = false;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.lblNombreEsp = new global::Gtk.Label();
			this.lblNombreEsp.Name = "lblNombreEsp";
			this.lblNombreEsp.LabelProp = global::Mono.Unix.Catalog.GetString("Nombre: ");
			this.fixedEspecialidad.Add(this.lblNombreEsp);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.lblNombreEsp]));
			w1.X = 41;
			w1.Y = 54;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.lblDescESp = new global::Gtk.Label();
			this.lblDescESp.Name = "lblDescESp";
			this.lblDescESp.LabelProp = global::Mono.Unix.Catalog.GetString("Descripcion: ");
			this.fixedEspecialidad.Add(this.lblDescESp);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.lblDescESp]));
			w2.X = 20;
			w2.Y = 95;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.txtNombreEsp = new global::Gtk.Entry();
			this.txtNombreEsp.WidthRequest = 271;
			this.txtNombreEsp.CanFocus = true;
			this.txtNombreEsp.Name = "txtNombreEsp";
			this.txtNombreEsp.IsEditable = true;
			this.txtNombreEsp.InvisibleChar = '•';
			this.fixedEspecialidad.Add(this.txtNombreEsp);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.txtNombreEsp]));
			w3.X = 118;
			w3.Y = 51;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.tvwEspecialidad = new global::Gtk.ScrolledWindow();
			this.tvwEspecialidad.WidthRequest = 770;
			this.tvwEspecialidad.HeightRequest = 145;
			this.tvwEspecialidad.Name = "tvwEspecialidad";
			this.tvwEspecialidad.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child tvwEspecialidad.Gtk.Container+ContainerChild
			this.tvwEspecialidades = new global::Gtk.TreeView();
			this.tvwEspecialidades.CanFocus = true;
			this.tvwEspecialidades.Name = "tvwEspecialidades";
			this.tvwEspecialidad.Add(this.tvwEspecialidades);
			this.fixedEspecialidad.Add(this.tvwEspecialidad);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.tvwEspecialidad]));
			w5.X = 17;
			w5.Y = 272;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.txtBuscarEsp = new global::Gtk.Entry();
			this.txtBuscarEsp.WidthRequest = 252;
			this.txtBuscarEsp.CanFocus = true;
			this.txtBuscarEsp.Name = "txtBuscarEsp";
			this.txtBuscarEsp.IsEditable = true;
			this.txtBuscarEsp.InvisibleChar = '•';
			this.fixedEspecialidad.Add(this.txtBuscarEsp);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.txtBuscarEsp]));
			w6.X = 15;
			w6.Y = 232;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.btnBuscarEsp = new global::Gtk.Button();
			this.btnBuscarEsp.WidthRequest = 82;
			this.btnBuscarEsp.CanFocus = true;
			this.btnBuscarEsp.Name = "btnBuscarEsp";
			this.btnBuscarEsp.UseUnderline = true;
			this.btnBuscarEsp.Label = global::Mono.Unix.Catalog.GetString("Buscar");
			this.fixedEspecialidad.Add(this.btnBuscarEsp);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.btnBuscarEsp]));
			w7.X = 282;
			w7.Y = 230;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.btnGuardarEsp = new global::Gtk.Button();
			this.btnGuardarEsp.WidthRequest = 82;
			this.btnGuardarEsp.CanFocus = true;
			this.btnGuardarEsp.Name = "btnGuardarEsp";
			this.btnGuardarEsp.UseUnderline = true;
			this.btnGuardarEsp.Label = global::Mono.Unix.Catalog.GetString("Guardar");
			this.fixedEspecialidad.Add(this.btnGuardarEsp);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.btnGuardarEsp]));
			w8.X = 415;
			w8.Y = 230;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.btnActualizarEsp = new global::Gtk.Button();
			this.btnActualizarEsp.CanFocus = true;
			this.btnActualizarEsp.Name = "btnActualizarEsp";
			this.btnActualizarEsp.UseUnderline = true;
			this.btnActualizarEsp.Label = global::Mono.Unix.Catalog.GetString("Actualizar");
			this.fixedEspecialidad.Add(this.btnActualizarEsp);
			global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.btnActualizarEsp]));
			w9.X = 508;
			w9.Y = 230;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.btnCancelar = new global::Gtk.Button();
			this.btnCancelar.WidthRequest = 82;
			this.btnCancelar.CanFocus = true;
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.UseUnderline = true;
			this.btnCancelar.Label = global::Mono.Unix.Catalog.GetString("Cancelar");
			this.fixedEspecialidad.Add(this.btnCancelar);
			global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.btnCancelar]));
			w10.X = 693;
			w10.Y = 229;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.btnEliminarEsp = new global::Gtk.Button();
			this.btnEliminarEsp.WidthRequest = 82;
			this.btnEliminarEsp.CanFocus = true;
			this.btnEliminarEsp.Name = "btnEliminarEsp";
			this.btnEliminarEsp.UseUnderline = true;
			this.btnEliminarEsp.Label = global::Mono.Unix.Catalog.GetString("Eliminar");
			this.fixedEspecialidad.Add(this.btnEliminarEsp);
			global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.btnEliminarEsp]));
			w11.X = 601;
			w11.Y = 230;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.lblEspecialidad = new global::Gtk.Label();
			this.lblEspecialidad.Name = "lblEspecialidad";
			this.lblEspecialidad.LabelProp = global::Mono.Unix.Catalog.GetString("Especialidades");
			this.fixedEspecialidad.Add(this.lblEspecialidad);
			global::Gtk.Fixed.FixedChild w12 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.lblEspecialidad]));
			w12.X = 333;
			w12.Y = 11;
			// Container child fixedEspecialidad.Gtk.Fixed+FixedChild
			this.txtDesEsp = new global::Gtk.Entry();
			this.txtDesEsp.WidthRequest = 270;
			this.txtDesEsp.CanFocus = true;
			this.txtDesEsp.Name = "txtDesEsp";
			this.txtDesEsp.IsEditable = true;
			this.txtDesEsp.InvisibleChar = '•';
			this.fixedEspecialidad.Add(this.txtDesEsp);
			global::Gtk.Fixed.FixedChild w13 = ((global::Gtk.Fixed.FixedChild)(this.fixedEspecialidad[this.txtDesEsp]));
			w13.X = 120;
			w13.Y = 92;
			this.Add(this.fixedEspecialidad);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 800;
			this.DefaultHeight = 430;
			this.Show();
			this.tvwEspecialidades.CursorChanged += new global::System.EventHandler(this.OnTvwEspecialidadesCursorChanged);
			this.btnBuscarEsp.Clicked += new global::System.EventHandler(this.OnBtnBuscarEspClicked);
			this.btnGuardarEsp.Clicked += new global::System.EventHandler(this.OnBtnGuardarEspClicked);
			this.btnActualizarEsp.Clicked += new global::System.EventHandler(this.OnBtnActualizarEspClicked);
			this.btnCancelar.Clicked += new global::System.EventHandler(this.OnBtnCancelarClicked);
			this.btnEliminarEsp.Clicked += new global::System.EventHandler(this.OnBtnEliminarEspClicked);
		}
	}
}
