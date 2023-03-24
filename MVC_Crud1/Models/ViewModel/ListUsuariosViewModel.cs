using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Crud1.Models.ViewModel
{
    public class ListUsuariosViewModel
    {
        //Declaramos nombrte y tipo de los elementos de la BBDD y metodos de accesibilidad

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

    }
}