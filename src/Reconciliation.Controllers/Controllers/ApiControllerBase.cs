using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReconciliationApp.Service.Mappers;

namespace ReconciliationApp.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMapper Mapper;

        protected ApiControllerBase()
        {
            Mapper = MapperConfig.CreateMaps();
        }
    }
}