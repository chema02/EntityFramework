﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepApi1.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Equipolocal { get; set; }
        public string Equipovisitante { get; set; }
        public DateTime Fecha { get; }

        public Evento(int id, string equipolocal, string equipovisitante, DateTime fecha)
        {
            Id = id;
            Equipolocal = equipolocal;
            Equipovisitante = equipovisitante;
            Fecha = fecha;
        }
    }
}