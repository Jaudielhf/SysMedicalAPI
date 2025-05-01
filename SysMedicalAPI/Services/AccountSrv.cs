using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SysMedicalAPI.Data;
using WebApiCost.ViewModels;

namespace SysMedicalAPI.Services
{
  public class AccountSrv
  {
    private readonly SaludEscolarContext _context;
    public AccountSrv(SaludEscolarContext context)
    {
      _context = context;
    }

    public async Task<ResponseVM> GetAllUsers()
    {
      var response = new ResponseVM();
      try
      {
        var users = await _context.Usuarios.ToListAsync();
        if (users == null || users.Count == 0)
        {
          response.Error("No existen datos");
        }
        else
        {
          response.Find(users?.Count > 0);
          response.Data = users;
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

      return response; // Ensure a value is returned in all code paths  
    }
  }
}
