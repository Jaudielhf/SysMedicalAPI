using Microsoft.AspNetCore.Mvc;
using SysMedicalAPI.Data;
using SysMedicalAPI.Services;
using WebApiCost.ViewModels;

namespace SysMedicalAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DiagnosticoController : Controller
  {
    private readonly SaludEscolarContext _context;
    private readonly DiagnosticoSrv diagnosticoSrv;

    public DiagnosticoController(SaludEscolarContext context)
    {
      _context = context;
      diagnosticoSrv = new DiagnosticoSrv(context);
    }

    [HttpGet]
    [Route("Lst")]
    public async Task<ActionResult<ResponseVM>> Lst() => await diagnosticoSrv.GetAllDiagnostic();

    [HttpGet]
    [Route("Get")]
    public async Task<ActionResult<ResponseVM>> GetDiagnostic() => await diagnosticoSrv.GetDiagnostic();

    [HttpGet]
    [Route("Get/{Id}")]
    public async Task<ActionResult<ResponseVM>> GetDiagnostic(long Id) => await diagnosticoSrv.GetDiagnostic(Id);

  }
}
