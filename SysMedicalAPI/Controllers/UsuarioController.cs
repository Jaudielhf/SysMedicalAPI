using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient; // Ojo: agrega esto
using SysMedicalAPI.Data;
using SysMedicalAPI.Services;
using WebApiCost.ViewModels;

namespace SysMedicalAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsuarioController : Controller
  {
    private readonly SaludEscolarContext _context;
    private readonly AccountSrv _accSrv;
    public UsuarioController(SaludEscolarContext context )
    {
      _context = context;
      _accSrv = new AccountSrv(context);
    }

    [HttpGet]
    [Route("Lst")]
    public async Task<ActionResult<ResponseVM>> Lst() => await _accSrv.GetAllUsers();
  }
}
