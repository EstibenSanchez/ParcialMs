using Newtonsoft.Json;
using ParcialMs.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ParcialMs.Servicios
{
    public class ServicioUsuario
    {
        private string key = "basdsadfasgdf.,lkf32sad";

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

            try {
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider md5;

                byte[] keyhash, buff, buff1;

                md5 = new MD5CryptoServiceProvider();
                keyhash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));

                md5 = null;
                des = new TripleDESCryptoServiceProvider();

                des.Key = keyhash;
                des.Mode = CipherMode.ECB;

                buff = ASCIIEncoding.ASCII.GetBytes(usuario.correo);
                buff1 = ASCIIEncoding.ASCII.GetBytes(usuario.password);

                usuario.correo = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff,0,buff.Length));
                usuario.password = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff1, 0, buff1.Length));

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
                    
                }


            }
            catch {
                throw new Exception("El usuario ya existe en la BD.");
            }
            return usuario.correo;


        }

        public List<Usuarios> GetUsers()
        {

            var fileName = "Usuarios.json";
            var json = System.IO.File.ReadAllText(fileName);
            var users = JsonConvert.DeserializeObject<List<Usuarios>>(json);
            return users;

        }
    }
}
