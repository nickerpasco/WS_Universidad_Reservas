using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS_Universidad.Models;

namespace WS_Universidad.Controllers
{
    public class PagoController : ApiController
    {
        // Seleccionar tipo de pago y confirmar
        [HttpPost]
        [Route("confirmarPago")]
        public dynamic confirmarPago([FromBody] Pagos dto)
        {
            Pagos pago = new Pagos();
            using (var context = new UNIVERSIDADEntities1())
            {
                pago.AlquilerID = dto.AlquilerID;
                pago.TipoPago = dto.TipoPago;
                pago.Estado = "Confirmado";
                pago.Monto = dto.Monto;
                context.Pagos.Add(pago);
                context.SaveChanges();
            }
            return pago;
        }

        // Imprimir boleta de venta
        [HttpGet]
        [Route("imprimirBoleta/{id}")]
        public dynamic imprimirBoleta(int id)
        {
            using (var context = new UNIVERSIDADEntities1())
            {
                var pago = context.Pagos.FirstOrDefault(p => p.PagoID == id);
                return pago != null ? $"Boleta generada para el pago ID: {pago.PagoID}" : "Pago no encontrado";
            }
        }
    }
}
