using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Caching;
using System.Web.Http;
using WS_Universidad.Models;

namespace WS_Universidad.Controllers
{
    public class ProveedorController : ApiController
    {
        // Ingresar a la plataforma web y crear cuenta default para proveedor
        [HttpPost]
        [Route("api/Proveedores/crearCuentaProveedor")]
        public dynamic crearCuentaProveedor([FromBody] Proveedores dto)
        {
            Proveedores proveedor = new Proveedores();
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                proveedor.Empresa = dto.Empresa;
                proveedor.Telefono = dto.Telefono;
                proveedor.Direccion = dto.Direccion;
                proveedor.UsuarioID = dto.UsuarioID;
                proveedor.FechaRegistro = DateTime.Now;
                context.Proveedores.Add(proveedor);
                context.SaveChanges();
            }
            return proveedor;
        }

        // Guardar proveedor y registrar canchas
        [HttpPost]
        [Route("api/Proveedores/registrarCanchaProveedor")]
        public dynamic registrarCanchaProveedor([FromBody] Canchas dto)
        {
            Canchas cancha = new Canchas();
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                cancha.ProveedorID = dto.ProveedorID;
                cancha.Nombre = dto.Nombre;
                cancha.Deporte = dto.Deporte;
                cancha.PrecioPorHora = dto.PrecioPorHora;
                cancha.Disponible = true;  // Inicialmente disponible
                context.Canchas.Add(cancha);
                context.SaveChanges();
            }
            return cancha;
        }


        [HttpGet]
        [Route("api/Proveedores/ObtenerProveedores")]
        public dynamic ObtenerProveedores()
        {
            
            using (var context = new db_aaf83c_universidadtestEntities())
            {


                //var data = context.Proveedores.Select(a => new
                //{
                    
                //    a.ProveedorID,
                //    a.UsuarioID,
                //    a.Empresa,
                //    a.Direccion,
                //    a.FechaRegistro,
                //    a.Telefono,

                //}).ToList();
                var data = (from proveedor in context.Proveedores
                            join usuario in context.Usuarios
                            on proveedor.UsuarioID equals usuario.UsuarioID
                            select new
                            {
                                proveedor.ProveedorID,
                                proveedor.UsuarioID,
                                proveedor.Empresa,
                                proveedor.Direccion,
                                proveedor.FechaRegistro,
                                proveedor.Telefono,
                                Nombre = usuario.Nombre  
                            }).ToList();


                string alumnosJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                var lstData = JsonConvert.DeserializeObject<List<Canchas>>(alumnosJson);
                return lstData;
            }

        }

    }
}
