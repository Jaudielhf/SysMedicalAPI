using Microsoft.AspNetCore.Mvc;
using SysMedicalAPI.DesicionTree;

namespace SysMedicalAPI.Controllers
{
  [ApiController]
  [Route("tree/[controller]")]
  public class DesicionTreeController : Controller
  {
    private readonly TreeDesicionService _treeDesicionService;
    public DesicionTreeController(TreeDesicionService treeDesicionService)
    {
      _treeDesicionService = treeDesicionService;
    }
    [HttpGet("diagnosticar")]
    public IActionResult Diagnosticar([FromQuery] List<bool> respuestas)
    {
      if (respuestas == null || respuestas.Count == 0)
      {
        return BadRequest("No se recibieron respuestas.");
      }
      var resultado = _treeDesicionService.Diagnosticar(respuestas);
      return Ok(new { Diagnostico = resultado });
    }
  }
}
