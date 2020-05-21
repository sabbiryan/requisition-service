using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReconciliationApp.Service.Reconciliations;
using ReconciliationApp.Service.Reconciliations.Dtos;

namespace ReconciliationApp.Controllers.Controllers
{
    public class ReconciliationController : ApiControllerBase
    {

        private readonly ILogger<ReconciliationController> _logger;
        private readonly IReconciliationLogicService _reconciliationLogicService;


        public ReconciliationController(ILogger<ReconciliationController> logger,
            IReconciliationLogicService reconciliationLogicService)
        {
            _logger = logger;
            _reconciliationLogicService = reconciliationLogicService;
        }

        [HttpGet]
        public async Task<List<ReconciliationListDto>> Get()
        {
            var reconciliations = await _reconciliationLogicService.GetReconciliationsAsync();
            return reconciliations;
        }

        [HttpGet, Route("yearly-table")]
        public async Task<YearlyReconciliationGridDto> GetYearlyTable()
        {
            var reconciliations = await _reconciliationLogicService.GetReconciliationsAsync(2019);
            return reconciliations;
        }

        [HttpGet, Route("{id}")]
        public async Task<ReconciliationDto> Get(string id)
        {
            var reconciliation = await _reconciliationLogicService.GetAsync(id);
            return reconciliation;
        }

        [HttpPost]
        public async Task Post([FromBody] ReconciliationFormDto form)
        {
            await _reconciliationLogicService.CreateAsync(form);
        }


        [HttpPut]
        public async Task Put([FromBody] ReconciliationFormDto form)
        {
            if (!string.IsNullOrWhiteSpace(form.Id))
            {
                await _reconciliationLogicService.EditAsync(form);
            }
            else
            {
                await Post(form);
            }
        }
    }
}