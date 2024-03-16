using proyectoIndicadoresWEB1.Controllers;
using proyectoindicadoresWEB1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyectoindicadoresWEB1.Controllers;
using System.Xml.Linq;

namespace proyectoindicadoresWEB1
{
    public partial class FrmRepresenVisual : System.Web.UI.Page
    {

        public RepresenVisual[] arregloRepresenVisual = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlRepresenvisual objControlRepresenVisual = new ControlRepresenvisual();
            arregloRepresenVisual = objControlRepresenVisual.listar();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            RepresenVisual objTipoActor = new RepresenVisual(id, nombre);
            ControlRepresenvisual objControlRepresenVisual = new ControlRepresenvisual(objTipoActor);
            objControlRepresenVisual.guardar();
            Response.Redirect("FrmRepresenVisual.aspx");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            RepresenVisual objTipoActor = new RepresenVisual(id, "");
            ControlRepresenvisual objControlRepresenVisual = new ControlRepresenvisual(objTipoActor);
            //txtContrasena.Text = objControlUsuario.consultar().Email;
            objTipoActor = objControlRepresenVisual.consultar();
            txtNombre.Text = objTipoActor.Nombre;

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            RepresenVisual objTipoActor = new RepresenVisual(id, nombre);
            ControlRepresenvisual objControlRepresenVisual = new ControlRepresenvisual(objTipoActor);
            objControlRepresenVisual.modificar();
            Response.Redirect("FrmRepresenVisual.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            RepresenVisual objTipoActor = new RepresenVisual(id, "");
            ControlRepresenvisual objControlRepresenVisual = new ControlRepresenvisual(objTipoActor);
            objControlRepresenVisual.borrar();
            Response.Redirect("FrmRepresenVisual.aspx");
        }
    }
}