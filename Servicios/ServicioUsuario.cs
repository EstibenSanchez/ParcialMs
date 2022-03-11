using Newtonsoft.Json;
using ParcialMs.Modelo;
using System;
using System.Collections.Generic;
using System.IO;

namespace ParcialMs.ServiciosUser
{
    public class ServicioUsuario
    {
        public Usuarios get(string correo)
        {
            var fileName = "Usuarios.json";
            var json = File.ReadAllText(fileName);
            var users = JsonConvert.DeserializeObject<List<Usuarios>>(json);
            var result = new Usuarios();
            foreach (var x in users)
            {
                if (x.correo == correo)
                {
                    result = x;
                    break;
                }
            }
            return result;
        }
        public string Postt(String correo, Usuarios usuario)
        {
            Usuarios existe = get(correo);
            if (existe.correo == null)
            {
                var fileName = "Usuarios.json";
                var json = System.IO.File.ReadAllText(fileName);
                var usuarios = JsonConvert.DeserializeObject<List<Usuarios>>(json);
                DateTime fecha = DateTime.Now;
                usuario.fecha = fecha;
                usuarios.Add(usuario);
                var users = JsonConvert.SerializeObject(usuarios);
                System.IO.File.WriteAllText(fileName, users);
                return usuario.correo;
            }
            {
                throw new Exception("El usuario ya existe en la BD.");
            }


        }
    }
}
