using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;  
using System.Web;
using proyectoindicadoresWEB1.Models;
using proyectoIndicadoresWEB1.Controllers;

namespace proyectoindicadoresWEB1.Controllers
{      
    public class ControlFuente
    {
        Fuente objfuente;
        public ControlFuente(Fuente fuente)  
        {
            objfuente = fuente;

        }
        public ControlFuente()
        {
            objfuente = null;
        }

        public void guardar()
        {
            int id = objfuente.Id;
            string nombre = objfuente.Nombre;
            string sql = "insert into fuente values('" + nombre + "')";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();

        }
        public void modificar()
        {
            string sql = "UPDATE fuente SET nombre='" + objfuente.Nombre + "' WHERE id=" + objfuente.Id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objfuente.Id;
            string sql = "DELETE FROM fuente WHERE id=" + objfuente.Id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(sql);
            objControlConexion.cerrarBD();
        }
        public Fuente[] listar()
        {
            int n = 0;
            int i = 0;
            Fuente[] arregloFuente = null;
            string sql = "SELECT * FROM fuente";
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            n = objDataset.Tables[0].Rows.Count;
            arregloFuente = new Fuente[n];
            while (i < n)
            {
                Fuente fuente = new Fuente();
                fuente.Id = (int)objDataset.Tables[0].Rows[i]["id"];
                fuente.Nombre = objDataset.Tables[0].Rows[i]["nombre"].ToString();
                arregloFuente[i] = fuente;
                i++;
            }
            objControlConexion.cerrarBD();
            return arregloFuente;
        }
        public Fuente consultar()
        {
            int id = objfuente.Id;
            string sql = "SELECT * FROM fuente WHERE id=" + id;
            ControlConexion objControlConexion = new ControlConexion("BDINDICADORES1.mdf");
            objControlConexion.abrirBD();
            DataSet objDataset = objControlConexion.ejecutarConsultaSql(sql);
            objfuente.Nombre = objDataset.Tables[0].Rows[0]["nombre"].ToString();
            objControlConexion.cerrarBD();
            return objfuente;
        }

    }
}