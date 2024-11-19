using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS_Universidad.Models;

namespace WS_Universidad.Controllers
{
    public class CanchaController : ApiController
    {
        // Ingresar a la web y validar cuenta del proveedor
        [HttpPost] 
        [Route("api/Canchas/validarCuentaProveedor")]
        public dynamic validarCuentaProveedor([FromBody] Proveedores dto)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var proveedor = context.Proveedores.FirstOrDefault(p => p.UsuarioID == dto.UsuarioID);
                return proveedor != null ? "Cuenta validada" : "Credenciales incorrectas";
            }
        }

        // Registrar cancha
        [HttpPost]
        [Route("api/Canchas/registrarCancha")] 
        public dynamic registrarCancha([FromBody] Canchas dto)
        {
            Canchas cancha = new Canchas();
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                cancha.ProveedorID = dto.ProveedorID;
                cancha.Nombre = dto.Nombre;
                cancha.Deporte = dto.Deporte;
                //cancha.FechaRegistro = dto.FechaRegistro;
                //cancha.TiempoDisponible = dto.TiempoDisponible;
                cancha.PrecioPorHora = dto.PrecioPorHora;
                cancha.Disponible = true;
                context.Canchas.Add(cancha);
                context.SaveChanges();
            }
            return cancha;
        }


        [HttpPut]
        [Route("api/Canchas/ActualizarCancha")]
        public dynamic ActualizarCancha([FromBody] Canchas dto)
        {
            Canchas cancha = new Canchas();
            using (var context = new db_aaf83c_universidadtestEntities())
            {

                cancha = context.Canchas.FirstOrDefault(c => c.CanchaID == dto.CanchaID);

                cancha.ProveedorID = dto.ProveedorID;
                cancha.Nombre = dto.Nombre;
                cancha.Deporte = dto.Deporte;
                //cancha.FechaRegistro = dto.FechaRegistro;
                //cancha.TiempoDisponible = dto.TiempoDisponible;
                cancha.PrecioPorHora = dto.PrecioPorHora;
                cancha.Disponible = true;

                context.Entry(cancha).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges(); 
            }


         
            return dto;
             
        }


        [HttpGet]
        [Route("api/Canchas/ObtenerCancha")]
        public dynamic ObtenerCancha(int IdCancha)
        {
            Canchas cancha = new Canchas();
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                 

                var data = context.Canchas.Select(a => new
                {
                    a.CanchaID,
                    a.ProveedorID,
                    a.Nombre,
                    a.Deporte,
                    a.Direccion,
                    a.PrecioPorHora,
                    a.Disponible, 

                }).Where(x=> x.CanchaID== IdCancha).ToList();


                string alumnosJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                var lstData = JsonConvert.DeserializeObject<List<Canchas>>(alumnosJson);
                return lstData;
            }
          
        }

        [HttpGet]
        [Route("api/Canchas/ObtenerCanchaTodo")]
        public dynamic ObtenerCanchaTodo()
        {
            Canchas cancha = new Canchas();
            using (var context = new db_aaf83c_universidadtestEntities())
            {


                var data = context.Canchas.Select(a => new
                {
                    a.CanchaID,
                    a.ProveedorID,
                    a.Nombre,
                    a.Deporte,
                    a.Direccion,
                    a.PrecioPorHora,
                    a.Disponible,

                }).ToList();


                string alumnosJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                var lstData = JsonConvert.DeserializeObject<List<Canchas>>(alumnosJson);
                return lstData;
            }

        }


        [HttpDelete]
        [Route("api/Canchas/Eliminarcancha")]
        public dynamic Eliminarcancha([FromBody] Canchas dto)
        {
            Canchas cancha = new Canchas();
            using (var context = new db_aaf83c_universidadtestEntities())
            {

                cancha = context.Canchas.FirstOrDefault(c => c.CanchaID == dto.CanchaID);

                context.Entry(cancha).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return cancha;
        }


        // Verificar registro en el sistema de canchas
        [HttpGet] 
        [Route("api/Canchas/verificarRegistroCancha/{id}")]
        public dynamic verificarRegistroCancha(int id)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var cancha = context.Canchas.FirstOrDefault(c => c.CanchaID == id);
                return cancha;
            }
        }
    }
}
