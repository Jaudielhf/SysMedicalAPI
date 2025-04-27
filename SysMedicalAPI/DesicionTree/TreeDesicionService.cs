namespace SysMedicalAPI.DesicionTree
{
  public class TreeDesicionService
  {
    public NodeDesicion Root { get; private set; }

    public TreeDesicionService()
    {
      ConstruirArbol();
    }

    private void ConstruirArbol()
    {
      var diagnosticoGripe = new NodeDesicion("Posible gripe", true);
      var diagnosticoInfeccion = new NodeDesicion("Posible infección", true);
      var diagnosticoGastritis = new NodeDesicion("Posible gastritis", true);
      var diagnosticoApendicitis = new NodeDesicion("Posible apendicitis", true);
      var estadoSaludable = new NodeDesicion("Estado Saludable", true);

      var dolorCabeza = new NodeDesicion("¿Tienes dolor de cabeza?", false, diagnosticoGripe, diagnosticoInfeccion);
      var nauseas = new NodeDesicion("¿Tienes náuseas?", false, diagnosticoGastritis, diagnosticoApendicitis);
      var dolorEstomago = new NodeDesicion("¿Tienes dolor de estómago?", false, nauseas, estadoSaludable);
      Root = new NodeDesicion("¿Tienes fiebre?", false, dolorCabeza, dolorEstomago);
    }

    public string Diagnosticar(List<bool> respuestas)
    {
      if (respuestas == null || respuestas.Count == 0)
        return "No se recibieron respuestas.";

      var nodoActual = Root;
      int idx = 0;

      while (nodoActual != null && !nodoActual.isDiagnostic && idx < respuestas.Count)
      {
        nodoActual = respuestas[idx++] ? nodoActual.NodeYes : nodoActual.NodeNo;
      }

      if (nodoActual == null)
        return "Diagnóstico incompleto.";

      return nodoActual.PreguntaOSintoma;
    }
  }
}
