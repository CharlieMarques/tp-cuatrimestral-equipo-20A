﻿using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string direccion { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}