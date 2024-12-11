using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WS_Universidad.Models;

namespace WS_Universidad.Controllers
{
    public class AlumnoController : ApiController
    {

        [HttpPost]
        [Route("api/Alumnos/create")]
        public dynamic crearAlumno([FromBody] AlumnoDto dto)
        {

            Alumno bean = new Alumno();
            using (var context = new db_aaf83c_universidadtestEntities())
            {

                bean.Apellido = dto.Apellido;
                bean.Nombre = dto.Nombre;
                bean.Email = dto.Email; 
                bean.CodigoAlumno = dto.CodigoAlumno; 

                context.Alumno.Add(bean);
                context.SaveChanges();
            }

            return bean;
        }

        [HttpGet]
        [Route("api/Alumnos/read")]
        public dynamic readAlumno()
        {

            List<Alumno> lstAlumnos = new List<Alumno>();
            using (var context = new db_aaf83c_universidadtestEntities())
            {

                var alumnos = context.Alumno.Select(a => new
                {
                    a.AlumnoID,
                    a.Nombre,
                    a.Apellido,
                    a.Email,
                  
                }).ToList();

                 
                string alumnosJson = JsonConvert.SerializeObject(alumnos, Formatting.Indented);
                 lstAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(alumnosJson);

            }
             

            return lstAlumnos;
        }

        [HttpPut]
        [Route("api/Alumnos/update")]
        public dynamic modificarAlumno([FromBody] AlumnoDto dto)
        {

            Alumno bean = new Alumno();
            using (var context = new db_aaf83c_universidadtestEntities())
            {

               

                bean = context.Alumno.Where(a => a.AlumnoID == dto.AlumnoID).FirstOrDefault();

                bean.Apellido = dto.Apellido;
                bean.Nombre = dto.Nombre;
                bean.Email = dto.Email;
                bean.CodigoAlumno = dto.CodigoAlumno;

                context.Entry(bean).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

            return bean;
        }

        [HttpDelete]
        [Route("api/Alumnos/delete")]
        public dynamic deleteAlumno([FromBody] AlumnoDto dto)
        {
            Alumno bean = new Alumno();

            using (var context = new db_aaf83c_universidadtestEntities())
            { 

                bean = context.Alumno.Where(a => a.AlumnoID == dto.AlumnoID).FirstOrDefault();


                context.Entry(bean).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

            return bean;
        }
    }
}
