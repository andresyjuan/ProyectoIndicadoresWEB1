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
    public partial class FrmTipoActor : System.Web.UI.Page
    {

        public TipoActor[] arregloTipoActor = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlTipoActor objControlTipoActor = new ControlTipoActor();
            arregloTipoActor = objControlTipoActor.listar();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            TipoActor objTipoActor = new TipoActor(id, nombre);
            ControlTipoActor objControlTipoActor = new ControlTipoActor(objTipoActor);
            objControlTipoActor.guardar();
            Response.Redirect("FrmTipoActor.aspx");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            TipoActor objTipoActor = new TipoActor(id, "");
            ControlTipoActor objControlTipoActor = new ControlTipoActor(objTipoActor);
            //txtContrasena.Text = objControlUsuario.consultar().Email;
            objTipoActor = objControlTipoActor.consultar();
            txtNombre.Text = objTipoActor.Nombre;

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            TipoActor objTipoActor = new TipoActor(id, nombre);
            ControlTipoActor objControlTipoActor = new ControlTipoActor(objTipoActor);
            objControlTipoActor.modificar();
            Response.Redirect("FrmTipoActor.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            TipoActor objTipoActor = new TipoActor(id, "");
            ControlTipoActor objControlTipoActor = new ControlTipoActor(objTipoActor);
            objControlTipoActor.borrar();
            Response.Redirect("FrmTipoActor.aspx");
        }
    }
}