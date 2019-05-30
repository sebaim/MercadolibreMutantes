using ExamenMercadolibreMutantes.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamenMercadolibreMutantes.Controllers
{
    [Route("/[action]")]
    [ApiController]
    public class MutantsController : ControllerBase
    {

        private MutantsIdentificationService mutantsIdentificationService;
        private IAnalysisLogService analysisLogService;
        public MutantsController(MutantsIdentificationService mutantsIdentificationService, IAnalysisLogService analysisLogService)
        {
            this.mutantsIdentificationService = mutantsIdentificationService;
            this.analysisLogService = analysisLogService;
        }

        // POST api/values
        [HttpPost]
        [Route("/mutants")]
        public ActionResult Mutants(string[] dna)
        {
            if (mutantsIdentificationService.IsMutant(dna, DateTime.Now))
                return new OkResult();
            else
                return new StatusCodeResult(403);
        }

        [HttpGet]
        [Route("/stats")]
        public ActionResult Stats()
        {

            return new JsonResult(analysisLogService.GetStatistics());
        }

    }
}