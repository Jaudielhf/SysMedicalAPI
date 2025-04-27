using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysMedicalAPI.Models;

public partial class Receta
{
    [Key]
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int DiagnosticoId { get; set; }

    public int MedicamentoId { get; set; }

    [StringLength(255)]
    public string? Indicaciones { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaReceta { get; set; }

    [ForeignKey("DiagnosticoId")]
    [InverseProperty("Receta")]
    public virtual Diagnostico Diagnostico { get; set; } = null!;

    [ForeignKey("MedicamentoId")]
    [InverseProperty("Receta")]
    public virtual Medicamento Medicamento { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Receta")]
    public virtual Usuario Usuario { get; set; } = null!;
}
