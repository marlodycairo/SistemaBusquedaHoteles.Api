﻿using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface ITarifasApplication
    {
        Task<IEnumerable<RatesModel>> GetTarifas();
        Task<RatesModel> GetTarifaById(int id);
    }
}
