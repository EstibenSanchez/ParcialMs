﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcialMs.Modelo;
using ParcialMs.ServiciosUser;

namespace ParcialMs.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ServicioUsuario servicio = new ServicioUsuario();
     


        [HttpPost]
        [Route("api/Usuario")]

        public string Post(Usuarios usuarios)
        {
            return servicio.Postt(usuarios.correo, usuarios);

        }


       /* [HttpPost]
        [Route("insertuser")]

        public string Pos(Modelos2 usuarios)
        {
            return servicio2.Post2(usuarios.correo, usuarios);

        }*/
    }
}