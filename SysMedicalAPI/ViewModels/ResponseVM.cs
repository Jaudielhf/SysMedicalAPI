namespace SysMedicalAPI.ViewModels
{
  public class ResponseVM<T> where T : new()
  {
    public T Data { get; set; } = new T();
    public string Type { get; set; } = "error";
    public string Title { get; set; } = "Ocurrió un error interno";
    public bool Ok { get; set; } = false;
    public string Message { get; set; } = "Ocurrió un error interno por favor inténtalo más tarde.";
    public void SessionFinish()
    {
      this.Ok = false;
      this.Message = "A finalizado tu sesión, por favor da clic en 'Iniciar Sesión' para salir e ingresar nuevamente (CODSF1)";
      this.Type = "error";
      this.Title = "Ocurrió un error interno";
    }
    public void Error()
    {
      this.Ok = false;
      this.Message = "Ocurrió un error interno por favor inténtalo más tarde.";
      this.Type = "error";
      this.Title = "Ocurrió un error interno";
    }
    public void Error(string message)
    {
      this.Ok = false;
      this.Message = message;
      this.Type = "error";
      this.Title = "Ocurrió un error interno";
    }
    public void Warning(string message)
    {
      this.Ok = false;
      this.Message = message;
      this.Type = "warn";
      this.Title = "Advertencia interna";
    }
    public void Information(string message)
    {
      this.Ok = false;
      this.Message = message;
      this.Type = "info";
      this.Title = "Información";
    }
    public void Error(Exception ex)
    {
      this.Ok = false;
      this.Message = "Ocurrió un error interno, por favor contactar a sistemas. detalle: " + ex.Message;
      this.Type = "error";
      this.Title = "Ocurrió un error interno";
    }
    public void Success(string message)
    {
      this.Ok = true;
      this.Message = message;
      this.Type = "success";
      this.Title = "Proceso realizado correctamente";
    }
    public void Success()
    {
      this.Ok = true;
      this.Message = "Proceso realizado con éxito.";
      this.Type = "success";
      this.Title = "Proceso realizado correctamente";
    }
    public void Find()
    {
      this.Ok = true;
      this.Message = "Información encontrada";
      this.Type = "success";
      this.Title = "Proceso realizado correctamente";
    }
    public void NotFind()
    {
      this.Ok = false;
      this.Message = "Información no encontrada";
      this.Type = "info";
      this.Title = "Información";
    }
    public void Set(bool ok, string message)
    {
      if (ok)
      {
        message = message.Trim() == "" ? "Proceso realizado con éxito." : message;
        Success(message);
      }
      else
      {
        message = message.Trim() == "" ? "Ocurrió un error interno, por favor contactar a sistemas" : message;
        Error(message);
      }
    }
  }
}
