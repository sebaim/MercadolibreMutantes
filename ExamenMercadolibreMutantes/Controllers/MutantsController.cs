using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenMercadolibreMutantes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenMercadolibreMutantes.Controllers
{
    [Route("/[action]")]
    [ApiController]
    public class MutantsController : ControllerBase
    {

        MutantsIdentificationService _mutantsIdentificationService;
        public MutantsController(MutantsIdentificationService mutantsIdentificationService)
        {
            _mutantsIdentificationService = mutantsIdentificationService;
        }

        // POST api/values
        [HttpPost]
        [Route("/mutants")]
        public ActionResult Mutants(string[] dna)
        {
            if (_mutantsIdentificationService.IsMutant(dna))
                return new OkResult();
            else
                return new StatusCodeResult(403);
        }

        [HttpGet]
        [Route("/stats")]
        public ActionResult Stats(string[] dna)
        {
            if (_mutantsIdentificationService.IsMutant(dna))
                return new OkResult();
            else
                return new ForbidResult();
        }

    }
}