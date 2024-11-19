using Newtonsoft.Json;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS_Universidad.Models;

namespace WS_Universidad.Controllers
{
    public class AlquilerController : ApiController
    {
        // Validar perfil de usuario
        [HttpPost] 
        [Route("api/Alquileres/ObtenerAlquiler")]
        public dynamic validarUsuario([FromBody] Usuarios dto)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var usuario = context.Usuarios.FirstOrDefault(u => u.Email == dto.Email && u.Contraseña == dto.Contraseña);
                return usuario;
            }
        }


        // Registrar alquiler de cancha
        [HttpPost]
        [Route("api/Alquileres/canchasalquiladasMes")]
        public dynamic canchasalquiladasMes([FromBody] Alquileres dto)
        {
            Alquileres alquiler = new Alquileres();

            String correo = null;
            using (var context = new db_aaf83c_universidadtestEntities())
            {

                var data = context.Alquileres.ToList();


                 

            }

            /// creando codigoooooo
            

            return true;
        }


        // Registrar alquiler de cancha
        [HttpPost]
        [Route("api/Alquileres/registrarAlquiler")] 
        public dynamic registrarAlquiler([FromBody] Alquileres dto)
        {
            Alquileres alquiler = new Alquileres();

            String correo = null;
            using (var context = new db_aaf83c_universidadtestEntities())
            { 

                alquiler.UsuarioID = dto.UsuarioID;
                alquiler.CanchaID = dto.CanchaID;
                alquiler.FechaAlquiler = dto.FechaAlquiler;
                alquiler.DuracionHoras = dto.DuracionHoras;
                alquiler.MontoTotal = dto.MontoTotal;
                alquiler.Estado ="A";
                alquiler.CodigoAlquiler = Guid.NewGuid().ToString();
                context.Alquileres.Add(alquiler);
                context.SaveChanges();


                Usuarios data = context.Usuarios.Where(x=> x.UsuarioID == dto.UsuarioID).FirstOrDefault();

                if(data != null)
                {
                    correo = data.Email;
                }
               
            }


            /// enviar correo 
            /// 
            if (correo != null)
            {
                EnviarCorreoUsuario(correo);
            }
            

            return true;
        }

        private void EnviarCorreoUsuario(string correoDestino)
        {
           


            ////////
            ///


        }

        // ObtenerAlquiler alquiler de cancha
        [HttpGet]
        [Route("api/Alquileres/ObtenerAlquiler")]
        public dynamic ObtenerAlquiler(int IdAlquiler)
        {
            Alquileres alquiler = new Alquileres();
            using (var context = new db_aaf83c_universidadtestEntities())
            {

                

                var data = context.Alquileres.Select(a => new
                {
                    a.AlquilerID,
                    a.UsuarioID,
                    a.CanchaID,
                    a.FechaAlquiler,
                    a.DuracionHoras,
                    a.MontoTotal,
                    a.Estado,
                    a.CodigoAlquiler,

                }).ToList();


                string alumnosJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                var lstData = JsonConvert.DeserializeObject<List<Alquileres>>(alumnosJson);
                return lstData;

            }
             
           
        }


        // Atualizar alquiler de cancha
        [HttpPut]
        [Route("api/Alquileres/ActualizarAlquiler")]
        public dynamic ActualizarAlquiler([FromBody] Alquileres dto)
        {
            Alquileres alquiler = new Alquileres();
            using (var context = new db_aaf83c_universidadtestEntities())
            {

                alquiler = context.Alquileres.Where(x => x.AlquilerID == dto.AlquilerID).FirstOrDefault();

                alquiler.UsuarioID = dto.UsuarioID;
                alquiler.CanchaID = dto.CanchaID;
                alquiler.FechaAlquiler = dto.FechaAlquiler;
                alquiler.DuracionHoras = dto.DuracionHoras;
                alquiler.MontoTotal = dto.MontoTotal;
                alquiler.CodigoAlquiler = Guid.NewGuid().ToString();

                context.Entry(alquiler).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
 
            }
            return alquiler;
        }



        // Eliminar alquiler de cancha
        [HttpDelete] 
        [Route("api/Alquileres/EliminarAlquiler")]
        public dynamic EliminarAlquiler([FromBody] Alquileres dto)
        {
            Alquileres alquiler = new Alquileres();
            using (var context = new db_aaf83c_universidadtestEntities())
            {

                alquiler = context.Alquileres.Where(x => x.AlquilerID == dto.AlquilerID).FirstOrDefault();

            
                context.Entry(alquiler).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

            }
            return alquiler;
        }


        // Verificar pago de alquiler
        [HttpPost] 
        [Route("api/Alquileres/verificarPago")]
        public dynamic verificarPago([FromBody] Pagos dto)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var pago = context.Pagos.FirstOrDefault(p => p.AlquilerID == dto.AlquilerID && p.Estado == "Confirmado");
                return pago;
            }
        }
    }
}
