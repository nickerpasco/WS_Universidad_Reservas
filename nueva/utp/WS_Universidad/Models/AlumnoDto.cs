using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Universidad.Models
{
    public class AlumnoDto
    {
     
        public int AlumnoID { get; set; }
        public string CodigoAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
    }
}