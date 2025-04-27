using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient; // Ojo: agrega esto
using SysMedicalAPI.Data;
using SysMedicalAPI.ViewModels;

namespace SysMedicalAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsuarioController : Controller
  {
    private readonly SaludEscolarContext _context;
    public UsuarioController(SaludEscolarContext context)
    {
      _context = context;
    }

    [HttpGet]
    [Route("Lst")]
    public async Task<ResponseVM<List<Object>>> Lst()
    {
      var response = new ResponseVM<List<Object>>();
      try
      {
        var users = await _context.Usuarios.ToListAsync();
        if (users == null || users.Count == 0)
        {
          response.NotFind();
        }
        else
        {
          response.Data.AddRange(users);
          response.Find();
        }
      }
      catch (SqlException ex)
      {
        response.Error($"Error en la base de datos: {ex.Message}");
      }
      catch (DbUpdateException ex)
      {
        response.Error($"Error actualizando datos: {ex.Message}");
      }
      catch (Exception ex)
      {
        response.Error($"Error interno del servidor: {ex.Message}");
      }
      return response;
    }
  }
}
