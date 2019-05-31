using ExamenMercadolibreMutantes.Dto;
using ExamenMercadolibreMutantes.Services;
using ExamenMercadolibreMutantes.Utils;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamenMercadolibreMutantes.Controllers
{
    [Route("/[action]")]
    [ApiController]
    public class MutantsController : ControllerBase
    {
        private char[] validCharacters = new char[] { 'A', 'T', 'C', 'G' };
        private MutantsIdentificationService mutantsIdentificationService;
        private IAnalysisLogService analysisLogService;
        public MutantsController(MutantsIdentificationService mutantsIdentificationService, IAnalysisLogService analysisLogService)
        {
            this.mutantsIdentificationService = mutantsIdentificationService;
            this.analysisLogService = analysisLogService;
        }

        // POST api/values
        [HttpPost]
        [Route("/mutant")]
        public ActionResult Mutant(RequestDto request)
        {
            var dna = request.dna;

            if (!MatrixUtils.IsSquareMatrix(dna) || MatrixUtils.ContainsInvalidCharacters (dna, validCharacters)) return BadRequest();

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