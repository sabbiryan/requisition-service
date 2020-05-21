using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ReconciliationApp.EntityFrameworkCore;
using ReconciliationApp.Service.Mappers;

namespace ReconciliationApp.Service
{
    public abstract class LogicServiceBase
    {
        protected readonly IMapper Mapper;
        protected readonly ReconciliationDbContext Context;

        protected LogicServiceBase(ReconciliationDbContext context)
        {
            Mapper = MapperConfig.CreateMaps();
            Context = context;
        }
    }
}
