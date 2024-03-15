using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using proyectoindicadoresWEB1.Models;
using proyectoIndicadoresWEB1.Controllers;

namespace proyectoindicadoresWEB1.Controllers
{
    public class ControlTipoActor
    {
        TipoActor objtipoActor;
        public ControlTipoActor(TipoActor tipoActor )
        {
            objtipoActor = tipoActor;

        }
         public ControlTipoActor()
        {
            objtipoActor = null;
        }

        public void guardar()
        {
            int id = objtipoActor.Id;
            string nombre  = objtipoActor.Nombre;
            string sql = "insert into tipoactor values('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();

        }
        public void modificar()
        {
            string sql = "UPDATE tipoactor SET nombre='" + objtipoActor.Nombre + "' WHERE id=" + objtipoActor.Id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objtipoActor.Id;
            string sql = "DELETE FROM tipoactor WHERE id='" + objtipoActor.Id + "'";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }
        public TipoActor[] listar()
        {
            int n = 0;
            int i = 0;
            TipoActor[] arregloTipoActor = null;
            string sql = "SELECT * FROM tipoactor";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloTipoActor = new TipoActor[n];
            while (i < n)
            {
                TipoActor objTipoActor = new TipoActor();
                objTipoActor.Id = (int)objDataset.Tables[0].Rows[i]["id"];
                objTipoActor.Nombre = objDataset.Tables[0].Rows[i]["nombre"].ToString();
                arregloTipoActor[i] = objTipoActor;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloTipoActor;
        }
        public TipoActor consultar()
        {
            int id = objtipoActor.Id;
            string sql = "SELECT * FROM tipoactor WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objtipoActor.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objtipoActor;
        }

    }
}