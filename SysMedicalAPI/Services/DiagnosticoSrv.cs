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

    public async Task<ResponseVM> GetAllDiagnostic()
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


    public async Task<ResponseVM> GetDiagnostic(long id = -1)
    {
      ResponseVM res = new ResponseVM();
      try
      {
        if (id == -1)
        {
          var lst = await _context.Diagnosticos.ToListAsync();
          res.Find(lst?.Count > 0);
          res.Data = lst;
        } else
        {
          var lst = await _context.Diagnosticos.Where(x => x.Id == id).ToListAsync();
          res.Find(lst?.Count > 0);
          res.Data = lst;
        }
      } catch (Exception)
      {
        res.Error("Erro al obtener los datos");
      }
      return res;
    }
  }
}
