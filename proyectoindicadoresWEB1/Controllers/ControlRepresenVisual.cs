using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using proyectoindicadoresWEB1.Models;
using proyectoIndicadoresWEB1.Controllers;

namespace proyectoindicadoresWEB1.Controllers
{
    public class ControlRepresenvisual
    {
       RepresenVisual objrepresenVisual;
        public ControlRepresenvisual(RepresenVisual represenVisual)
        {
            objrepresenVisual = represenVisual;

        }  
        public ControlRepresenvisual()
        {
            objrepresenVisual = null;
        }

        public void guardar()
        {
            int id = objrepresenVisual.Id;
            string nombre = objrepresenVisual.Nombre;
            string sql = "insert into represenvisual values('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();

        }
        public void modificar()
        {
            string sql = "UPDATE represenvisual SET nombre='" + objrepresenVisual.Nombre + "' WHERE id=" + objrepresenVisual.Id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objrepresenVisual.Id;
            string sql = "DELETE FROM represenvisual WHERE id=" + objrepresenVisual.Id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }
        public RepresenVisual[] listar()
        {
            int n = 0;
            int i = 0;
            RepresenVisual[] arregloRepresenVisual = null;
            string sql = "SELECT * FROM represenvisual";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloRepresenVisual = new RepresenVisual[n];
            while (i < n)
            {
                RepresenVisual objRepresenVisual = new RepresenVisual();
                objRepresenVisual.Id = (int)objDataset.Tables[0].Rows[i]["id"];
                objRepresenVisual.Nombre = objDataset.Tables[0].Rows[i]["nombre"].ToString();
                arregloRepresenVisual[i] = objRepresenVisual;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloRepresenVisual;
        }
        public RepresenVisual consultar()
        {
            int id = objrepresenVisual.Id;
            string sql = "SELECT * FROM represenvisual WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objrepresenVisual.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objrepresenVisual;
        }

    }
}