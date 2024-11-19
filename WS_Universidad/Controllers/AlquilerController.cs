using Newtonsoft.Json;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Caching;
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
            String mensajeCorreo = null;


        

            using (var context = new db_aaf83c_universidadtestEntities())
            {


                // Validar Cancha
                var cancha = context.Canchas.FirstOrDefault(c => c.CanchaID == dto.CanchaID);
                if (cancha == null)
                {
                    return new { success = false, message = "La cancha no está disponible." };
                }




                alquiler.UsuarioID = dto.UsuarioID;
                alquiler.CanchaID = dto.CanchaID;
                alquiler.FechaAlquiler = dto.FechaAlquiler;
                alquiler.DuracionHoras = dto.DuracionHoras;
                alquiler.MontoTotal = dto.MontoTotal;
                alquiler.Estado ="A";
                alquiler.CodigoAlquiler = Guid.NewGuid().ToString();
                context.Alquileres.Add(alquiler);
                context.SaveChanges();


                // Enviar correo
                mensajeCorreo = $"Reserva confirmada:\nCancha: {cancha.Nombre}\nFecha: {alquiler.FechaAlquiler.ToShortDateString()}";


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
                EnviarCorreoUsuario(correo, mensajeCorreo);
            }


            return new { success = true, message = "Reserva registrada exitosamente." };

        }

        private void EnviarCorreoUsuario(string correoCliente, string detallesReserva)
        {
           
            const string subject = "Confirmación de Reserva de Cancha";
            string body = $"Estimado cliente,\n\n{detallesReserva}\n\nGracias por reservar con nosotros.";

            const string UserName = "appluisintinerante@gmail.com";
            const string fromPassword = "qyyowoybmldfvptt";

            CorreoMailArchivo(correoCliente, correoCliente,
                                                   correoCliente, "CONFIRMACIÓN DE RESERVA", "<table align='center' border='0' cellpadding='0' cellspacing='0'  </table>", UserName, fromPassword);

        }



        public static void CorreoMailArchivo( string str_pTo, string str_pCC, string str_pBCC, string asunto, string mensaje, string UserName, string Password)
        {
       

            try
            {
                MailMessage obj_Mail = new MailMessage();
                obj_Mail.From = new MailAddress(UserName, "Administrador");

                if (str_pTo != null)
                {
                    if (str_pTo.Length > 0)
                    {
                        obj_Mail.To.Add(new MailAddress(str_pTo));
                    }
                }
                if (str_pCC != null)
                {
                    if (str_pCC.Length > 0)
                    {
                        obj_Mail.To.Add(new MailAddress(str_pCC));
                    }
                }
                if (str_pBCC != null)
                {
                    if (str_pBCC.Length > 0)
                    {
                        string[] Contenido = str_pBCC.Split('|');
                        for (int i = 0; i < Contenido.Length; i++)
                        {
                            if (Contenido[i].Length > 0)
                            {
                                obj_Mail.To.Add(new MailAddress(Contenido[i].Trim()));
                            }
                        }
                    }
                }




                const string subject = "Confirmación de Reserva de Cancha";
                string detallesReserva = "Su reserva ha sido confirmada para el 25 de noviembre de 2024 a las 10:00 AM.";
                string body = $"Estimado cliente,<br><br>{detallesReserva}<br><br>Gracias por reservar con nosotros.";

                // Crear el contenido HTML con estilo atractivo
                string htmlBody = $@"
        <!DOCTYPE html>
        <html lang='es'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>{subject}</title>
            <style>
                body {{
                    font-family: 'Arial', sans-serif;
                    background-color: #f7f7f7;
                    margin: 0;
                    padding: 0;
                }}
                .email-container {{
                    background-color: #ffffff;
                    padding: 30px;
                    margin: 30px auto;
                    max-width: 600px;
                    border-radius: 10px;
                    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
                }}
                .header {{
                    font-size: 26px;
                    color: #4CAF50;
                    text-align: center;
                    margin-bottom: 20px;
                }}
                .body {{
                    font-size: 16px;
                    color: #333333;
                    line-height: 1.6;
                }}
                .body p {{
                    margin: 10px 0;
                }}
                .button {{
                    display: inline-block;
                    background-color: #4CAF50;
                    color: #ffffff;
                    padding: 10px 20px;
                    text-decoration: none;
                    font-weight: bold;
                    border-radius: 5px;
                    margin-top: 20px;
                }}
                .footer {{
                    text-align: center;
                    margin-top: 30px;
                    font-size: 14px;
                    color: #777777;
                }}
                .footer a {{
                    color: #4CAF50;
                    text-decoration: none;
                }}
            </style>
        </head>
        <body>
            <div class='email-container'>
                <div class='header'>{subject}</div>
                <div class='body'>
                    <p>{body}</p>
                    <p><strong>Fecha y hora de la reserva:</strong> 25 de noviembre de 2024, 10:00 AM</p>
                    <p>Para más detalles o para realizar cambios en su reserva, por favor haga clic en el siguiente botón:</p>
                    <a href='https://www.tusitio.com/reservas' class='button'>Ver mi reserva</a>
                </div>
                <div class='footer'>
                    <p>Este es un correo automático, por favor no responda.</p>
                    <p>Si tiene alguna pregunta, puede <a href='mailto:contacto@tusitio.com'>contactarnos</a>.</p>
                </div>
            </div>
        </body>
        </html>";


                string text = string.Empty;

              



                obj_Mail.BodyEncoding = System.Text.Encoding.UTF8;
                obj_Mail.Subject = asunto;
                obj_Mail.IsBodyHtml = true;
                obj_Mail.Body = htmlBody;




                SmtpClient obj_Smtp = new SmtpClient();
                obj_Smtp.Host = "smtp.gmail.com";
                obj_Smtp.Port = 587;
                obj_Smtp.EnableSsl = true;
                obj_Smtp.UseDefaultCredentials = true;
                obj_Smtp.Credentials = new System.Net.NetworkCredential(UserName, Password);




                obj_Smtp.Send(obj_Mail);


            }
            catch (Exception e)
            {
                e.Message.ToString();

            }
         
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
