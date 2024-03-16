using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoindicadoresWEB1.Models
{
    public class Fuente
    {
        private int id;
        private string nombre;
         
        public int Id { get { return id; } set => id = value; }
        public string Nombre { get { return nombre; } set => nombre = value; }

        public Fuente(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public Fuente()
        {
            this.id = 0;
            this.nombre = "";
        }
    }
}