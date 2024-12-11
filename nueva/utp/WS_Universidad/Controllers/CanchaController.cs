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



       
        [HttpGet]
        [Route("api/Canchas/EstadisticaDeporte")]
        public dynamic EstadisticaDeporte()
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                // Agrupa las canchas por el deporte y cuenta cuántas hay para cada uno
                var estadisticas = context.Canchas
                    .GroupBy(c => c.Deporte)
                    .Select(g => new
                    {
                        Deporte = g.Key, // Nombre del deporte
                        TotalCanchas = g.Count() // Número total de canchas para ese deporte
                    })
                    .OrderByDescending(g => g.TotalCanchas) // Ordenar de mayor a menor
                    .ToList();

                return estadisticas; // Devuelve el resultado como JSON
            }
        }

        [HttpGet]
        [Route("api/Canchas/IngresosPorDeporte")]
        public dynamic IngresosPorDeporte()
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var ingresos = context.Canchas
                    .Where(c => c.Deporte != null && c.PrecioPorHora != null) // Ignorar registros con valores nulos
                    .GroupBy(c => c.Deporte) // Agrupar por deporte
                    .Select(g => new
                    {
                        Deporte = g.Key, // Nombre del deporte
                        TotalIngresos = g.Sum(c => c.PrecioPorHora) // Suma de precios por deporte
                    })
                    .OrderByDescending(g => g.TotalIngresos) // Ordenar de mayor a menor ingreso
                    .ToList();

                return ingresos;
            }
        }

        [HttpGet]
        [Route("api/Canchas/ObtenerCanchaPorID/{id}")]
        public dynamic ObtenerCanchaPorID(int id)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var cancha = context.Canchas
                    .Where(c => c.CanchaID == id)
                    .Select(c => new
                    {
                        c.CanchaID,
                        c.Nombre,
                        c.Deporte,
                        c.PrecioPorHora,
                        c.Disponible
                    })
                    .FirstOrDefault();

                if (cancha == null)
                {
                    return new { success = false, message = "La cancha no existe." };
                }

                return cancha;
            }
        }

        [HttpPut]
        [Route("api/Canchas/EditarCancha/{id}")]
        public dynamic EditarCancha(int id, [FromBody] Canchas dto)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var cancha = context.Canchas.FirstOrDefault(c => c.CanchaID == id);

                if (cancha == null)
                {
                    return new { success = false, message = "La cancha no existe." };
                }

                cancha.Nombre = dto.Nombre;
                cancha.Deporte = dto.Deporte;
                cancha.PrecioPorHora = dto.PrecioPorHora;
                context.SaveChanges();

                return new { success = true, message = "Cancha actualizada exitosamente." };
            }
        }

        [HttpDelete]
        [Route("api/Canchas/EliminarCancha/{id}")]
        public dynamic EliminarCancha(int id)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var cancha = context.Canchas.FirstOrDefault(c => c.CanchaID == id);

                if (cancha == null)
                {
                    return new { success = false, message = "La cancha no existe." };
                }

                context.Canchas.Remove(cancha);
                context.SaveChanges();

                return new { success = true, message = "Cancha eliminada exitosamente." };
            }
        }

    }
}
