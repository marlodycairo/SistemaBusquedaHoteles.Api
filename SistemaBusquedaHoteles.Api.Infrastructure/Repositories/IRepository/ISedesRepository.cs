﻿using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository
{
    public interface ISedesRepository
    {
        Task<IEnumerable<Locations>> GetSedes();
        Task<Locations> GetSedeById(int id);
    }
}
