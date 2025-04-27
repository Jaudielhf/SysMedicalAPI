using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysMedicalAPI.Models;

public partial class Diagnostico
{
    [Key]
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int SintomaId { get; set; }

    [StringLength(255)]
    public string? DiagnosticoTexto { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaDiagnostico { get; set; }

    [InverseProperty("Diagnostico")]
    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();

    [ForeignKey("SintomaId")]
    [InverseProperty("Diagnosticos")]
    public virtual Sintoma Sintoma { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Diagnosticos")]
    public virtual Usuario Usuario { get; set; } = null!;
}
