using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WS_Universidad.Models;

namespace WS_Universidad.Controllers
{
    public class ClienteController : ApiController
    {
        // Crear cuenta (Registro de usuarios)
        [HttpPost]
        [Route("api/Clientes/crearCuenta")]
        public dynamic crearCuentaUsuarios([FromBody] Usuarios dto)
        {
            Usuarios cliente = new Usuarios();
            using (var context = new db_aaf83c_universidadtestEntities())
            {


                var usuario = context.Usuarios.Where(u => u.Email.ToUpper() == dto.Email.ToUpper()).ToList();

                // Validar que el usuario exista
                if (usuario.Count >= 1)
                {
                    return new { success = false, message = "El correo " + dto.Email + " ya existe en nuestra base de datos.." };
                }

                string encrypted = EncryptionHelper.EncryptString(dto.Contraseña);


                string decrypted = EncryptionHelper.EncryptString(encrypted);

                cliente.Nombre = dto.Nombre;
                cliente.Apellido = dto.Apellido;
                cliente.Email = dto.Email;
                cliente.Contraseña = encrypted;//GenerateKeyFromSeed(dto.Contraseña); ;
                cliente.Perfil = dto.Perfil;
                cliente.FechaRegistro = DateTime.Now;
                context.Usuarios.Add(cliente);
                context.SaveChanges();
            }
            return cliente;
        }

        [HttpGet]
        [Route("api/Clientes/ObtenerClientes")]
        public dynamic ObtenerClientes()
        {

            using (var context = new db_aaf83c_universidadtestEntities())
            {


                var data = context.Usuarios.Select(a => new
                {


                    a.UsuarioID,
                    a.Nombre,
                    a.Apellido,
                    a.FechaRegistro,
                    a.Email,
                    a.Perfil,

                }).ToList();


                string alumnosJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                var lstData = JsonConvert.DeserializeObject<List<Usuarios>>(alumnosJson);
                return lstData;
            }

        }

        [HttpGet]
        [Route("api/Clientes/ObtenerClientePorID/{id}")]
        public dynamic ObtenerClientePorID(int id)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var cliente = context.Usuarios
                    .Where(u => u.UsuarioID == id)
                    .Select(u => new
                    {
                        u.UsuarioID,
                        u.Nombre,
                        u.Apellido,
                        u.Email,
                        u.Perfil,
                        u.FechaRegistro
                    })
                    .FirstOrDefault();

                if (cliente == null)
                {
                    return new { success = false, message = "El cliente no existe." };
                }

                return cliente;
            }
        }




        // Seleccionar cancha disponible
        [HttpGet]
        [Route("api/Clientes/seleccionarCancha")]
        public dynamic seleccionarCanchaDisponible()
        {
            List<Canchas> canchasDisponibles = new List<Canchas>();
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                canchasDisponibles = context.Canchas.Where(c => c.Disponible == true).ToList();
            }
            return canchasDisponibles;
        }
        //editar cliente 

        [HttpPut]
        [Route("api/Clientes/EditarCliente/{id}")]
        public dynamic EditarCliente(int id, [FromBody] Usuarios dto)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var cliente = context.Usuarios.FirstOrDefault(u => u.UsuarioID == id);

                if (cliente == null)
                {
                    return new { success = false, message = "El usuario no existe." };
                }

                cliente.Nombre = dto.Nombre;
                cliente.Apellido = dto.Apellido;
                cliente.Email = dto.Email;

                context.SaveChanges();

                return new { success = true, message = "Usuario actualizado exitosamente." };
            }
        }
        //Eliminar cliente

        [HttpDelete]
        [Route("api/Clientes/EliminarCliente/{id}")]
        public dynamic EliminarCliente(int id)
        {
            using (var context = new db_aaf83c_universidadtestEntities())
            {
                var cliente = context.Usuarios.FirstOrDefault(u => u.UsuarioID == id);

                if (cliente == null)
                {
                    return new { success = false, message = "El usuario no existe." };
                }

                context.Usuarios.Remove(cliente);
                context.SaveChanges();

                return new { success = true, message = "Usuario eliminado exitosamente." };
            }
        }




    }
}
