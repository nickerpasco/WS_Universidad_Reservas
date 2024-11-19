using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS_Universidad.Models;

namespace WS_Universidad.Controllers
{
    public class UsuariosController : ApiController
    {
        // Crear cuenta (Registro de usuarios)
        [HttpPost]
        [Route("api/Usuarios/login")]
        public dynamic LoginUsuario([FromBody] Usuarios dto)
        {
            // Validar que el DTO no sea nulo
            if (dto == null)
            {
                return new { success = false, message = "Datos de usuario inválidos." };
            }

            using (var context = new db_aaf83c_universidadtestEntities())
            {
                // Buscar usuario por nombre o correo electrónico
                var usuario = context.Usuarios.FirstOrDefault(u => u.Nombre == dto.Nombre || u.Email == dto.Email);

                // Validar que el usuario exista
                if (usuario == null)
                {
                    return new { success = false, message = "Usuario no encontrado." };
                }

                string decrypted = EncryptionHelper.DecryptString(usuario.Contraseña);


                // Validar la contraseña (esto asume que la contraseña está almacenada en texto plano, pero debe estar encriptada en un entorno de producción)
                if (decrypted != dto.Contraseña)
                {
                    return new { success = false, message = "Contraseña incorrecta." };
                }

                // Si el usuario y contraseña son correctos
                return new { success = true, message = "Inicio de sesión exitoso.", usuarioId = usuario.UsuarioID };
            }
        }


    }
}
