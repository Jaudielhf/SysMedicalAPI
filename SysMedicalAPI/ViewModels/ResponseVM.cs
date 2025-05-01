namespace WebApiCost.ViewModels
{
  public class BaseVM<T> where T : new()
  {
    public bool Ok { get; set; } = false;
    public string Title { get; set; } = "Ups!!!";
    public string Message { get; set; } = "Ocurrió un error de nuestro lado, estamos trabajado para solucionalo.";
    public string Type { get; set; } = "Error";
    public T? Data { get; set; } = new T();
    public void SetStatus(bool ok, string title, string type, string message)
    {
      Ok = ok;
      Title = title;
      Type = type;
      Message = message;
    }

    public void Error(string message) => SetStatus(false, "Error", "error", message);
    public void Error(Exception ex) => SetStatus(false, "Error", "error", ex.Message);

    public void Success(string message = "Proceso realizado correctamente") => SetStatus(true, "Exitoso", "success", message);

    public void Info(string message) => SetStatus(false, "Información", "info", message);

    public void Find(bool found) => SetStatus(found, "Información", "info", found ? "Información encontrada." : "Información no encontrada.");
  }
  public class ResponseVM : BaseVM<object> { }
  public class ResponseVM<T> : BaseVM<T> where T : new() { }
}