//using EfCoreDbFirstTutorial.Data;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace EfCoreDbFirstTutorial.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BancoCentralController : ControllerBase
//    {
//    }
//}


using EfCoreDbFirstTutorial.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EfCoreDbFirstTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoCentralController : ControllerBase
    {
        private readonly BancoCentralContext _context;

        public BancoCentralController(BancoCentralContext context)
        {
            _context = context;
        }


        [HttpGet("Reversadas")]
        public IActionResult GetOperacionesPosicions(DateTime? date)
        {
            var query = _context.OperacionesPosicions.AsQueryable();

            if (date.HasValue)
            {
                query = query.Where(op => op.FechaReporte.Date == date.Value.Date && op.FechaRegistro < op.FechaReporte);
            }

            var results = query.ToList();

            return Ok(results);
        }

        [HttpGet("Anuladas")]
        public IActionResult GetAnuladas(DateTime? date)
        {
            var query = _context.OperacionesPosicions.AsQueryable();

            if (date.HasValue)
            {
                query = query.Where(op => op.FechaReporte.Date == date.Value.Date && (op.Estado == "Anulado" || op.Estado == "Anulada"));
            }

            var results = query.ToList();

            return Ok(results);
        }


        [HttpGet("CierresRepetidosMismoDia")]
        public IActionResult GetCierresRepetidosMismoDia()
        {
            var cierreIds = _context.OperacionesInformadas
                .Where(oi => oi.FechaReporte.Date == oi.FechaRegistro.Date
                    && (oi.Estado == "Anulado" || oi.Estado == "Anulada"))
                .GroupBy(oi => oi.CierreId)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key).ToList();

            var operacionesInformadas = _context.OperacionesInformadas
                .Where(oi => cierreIds.Contains(oi.CierreId))
                .ToList();

            return Ok(operacionesInformadas);
        }



    }
}