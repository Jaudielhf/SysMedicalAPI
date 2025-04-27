namespace SysMedicalAPI.DesicionTree
{
  public class NodeDesicion
  {
    public string PreguntaOSintoma { get; set; }
    public bool isDiagnostic { get; set; }
    public NodeDesicion NodeYes { get; set; }
    public NodeDesicion NodeNo { get; set; }

    public NodeDesicion(string preguntaOSintoma, bool esDiagnostico = false, NodeDesicion nodeYes = null, NodeDesicion nodeNo = null)
    {
      PreguntaOSintoma = preguntaOSintoma;
      isDiagnostic = esDiagnostico;
      NodeYes = nodeYes;
      NodeNo = nodeNo;
    }
  }
}
