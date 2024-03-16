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
    public partial class FrmFuente : System.Web.UI.Page
    {

        public Fuente[] arregloFuente = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlFuente objControlFuente = new ControlFuente();
            arregloFuente = objControlFuente.listar();
        }  

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            Fuente fuente = new Fuente(id, nombre);
            Fuente objFuente = fuente;
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.guardar();
            Response.Redirect("FrmFuente.aspx");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Fuente objFuente = new Fuente(id, "");
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            //txtContrasena.Text = objControlUsuario.consultar().Email;
            objFuente = objControlFuente.consultar();
            txtNombre.Text = objFuente.Nombre;

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            Fuente objFuente = new Fuente(id, nombre);
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.modificar();
            Response.Redirect("FrmFuente.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Fuente objFuente = new Fuente(id, "");
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.borrar();
            Response.Redirect("FrmFuente.aspx");
        }
    }  
}