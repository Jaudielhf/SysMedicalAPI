using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SysMedicalAPI.Data;
using WebApiCost.ViewModels;

namespace SysMedicalAPI.Services
{
  public class DiagnosticoSrv
  {
    private readonly SaludEscolarContext _context;

    public DiagnosticoSrv(SaludEscolarContext context)
    {
      _context = context;
    }

    public async Task<ResponseVM> GetAllDiagnosticById()
    {
      var response = new ResponseVM();
      try
      {
        var diagnostics = await _context.Diagnosticos.ToListAsync();
        if (diagnostics == null || diagnostics.Count == 0)
        {
          response.Error("No existen datos");
        }
        else
        {
          response.Find(diagnostics?.Count > 0);
          response.Data = diagnostics;
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
