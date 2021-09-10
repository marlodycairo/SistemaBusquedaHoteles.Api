﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class GenericPagination<T> where T : class
    {
        public int PaginaActual { get; set; }
        public int RegistroPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public string BusquedaActual { get; set; }
        public string OrdenActual { get; set; }
        public string TipoOrdenActual { get; set; }
        public IEnumerable<T> Resultado { get; set; }
    }
}
