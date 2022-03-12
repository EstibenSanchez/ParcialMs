using System;
using System.Text.Json;

namespace ParcialMs.Modelos
{
    public class Usuarios
    {
        public string correo { get; set; }
        public string password { get; set; }
        public DateTime fecha { get; set; }

        public string Json()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
