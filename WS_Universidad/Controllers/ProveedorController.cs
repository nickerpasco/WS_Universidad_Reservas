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
        // Ingresar a la plataforma web y crear cuenta predeterminada para proveedor
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

        [HttpGet]
        [Route("api/Proveedores/ObtenerProveedores")]
        public dynamic ObtenerProveedores()
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
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

        // Obtener un proveedor por ID
        [HttpGet]
        [Route("api/Proveedores/ObtenerProveedorPorID/{id}")]
        public dynamic ObtenerProveedorPorID(int id)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var proveedor = context.Proveedores
                    .Where(p => p.ProveedorID == id)
                    .Select(p => new
                    {
                        p.ProveedorID,
                        p.Empresa,
                        p.Telefono,
                        p.Direccion,
                        p.UsuarioID,
                        p.FechaRegistro
                    })
                    .FirstOrDefault();

                if (proveedor == null)
                {
                    return new { success = false, message = "El proveedor no existe." };
                }

                return proveedor;
            }
        }

        // Editar un proveedor existente
        [HttpPut]
        [Route("api/Proveedores/EditarProveedor/{id}")]
        public dynamic EditarProveedor(int id, [FromBody] Proveedores dto)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var proveedor = context.Proveedores.FirstOrDefault(p => p.ProveedorID == id);

                if (proveedor == null)
                {
                    return new { success = false, message = "El proveedor no existe." };
                }

                proveedor.Empresa = dto.Empresa;
                proveedor.Telefono = dto.Telefono;
                proveedor.Direccion = dto.Direccion;

                context.SaveChanges();

                return new { Success = true, message = "Proveedor actualizado exitosamente." };
            }
        }

        // Eliminar un proveedor por ID
        [HttpDelete]
        [Route("api/Proveedores/EliminarProveedor/{id}")]
        public dynamic EliminarProveedor(int id)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var proveedor = context.Proveedores.FirstOrDefault(p => p.ProveedorID == id);

                if (proveedor == null)
                {
                    return new { success = false, message = "El proveedor no existe." };
                }

                context.Proveedores.Remove(proveedor);
                context.SaveChanges();

                return new { Success = true, message = "Proveedor eliminado exitosamente." };
            }
        }
    }
}
