using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string ConfirmarContraseña { get; set; }
        public string TipoUsuario { get; set; }
        public decimal TotalVendido { get; set; }
        public DateTime Fecha { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Contraseña = string.Empty;
            ConfirmarContraseña = string.Empty;
            TipoUsuario = string.Empty;
            TotalVendido = 0;
            Fecha = DateTime.Now;
        }

        public Usuarios(string nombreUsuario, string contraseña)
        {
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
        }
    }
}